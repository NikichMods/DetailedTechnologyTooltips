// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DetailedTechnologyTooltips
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "nikich.gyk.detailedtechnologytooltips";
        public const string PluginName = "Detailed Technology Tooltips";
        public const string PluginVersion = "0.1.0";

        internal static ManualLogSource Log;
        internal static bool RuntimeDisabled;

        private Harmony _harmony;
        private static bool _runtimeFailureLogged;

        private void Awake()
        {
            Log = Logger;

            try
            {
                GameApi.Bind();

                _harmony = new Harmony(PluginGuid);
                Patch(
                    GameApi.TechUnlockGetTooltip,
                    nameof(RuntimePatches.TechUnlockPrefix),
                    nameof(RuntimePatches.TechUnlockPostfix),
                    nameof(RuntimePatches.TechUnlockFinalizer));
                Patch(
                    GameApi.ItemDefinitionGetTooltipData,
                    null,
                    nameof(RuntimePatches.ItemTooltipDataPostfix),
                    null);
                Patch(
                    GameApi.ItemDefinitionGetTooltipDataCraftAt,
                    null,
                    nameof(RuntimePatches.ItemTooltipCraftAtPostfix),
                    null);

                Log.LogInfo(
                    PluginName + " " + PluginVersion
                    + " loaded; Technology tooltip contract bound; "
                    + "Assembly-CSharp MVID="
                    + GameApi.HostModuleVersionId + ".");
            }
            catch (Exception ex)
            {
                RuntimeDisabled = true;
                Log.LogError(
                    PluginName + " failed to initialize; vanilla behavior preserved: "
                    + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnDestroy()
        {
            try
            {
                if (_harmony != null)
                    _harmony.UnpatchSelf();
            }
            catch
            {
            }
        }

        private void Patch(
            MethodInfo target,
            string prefixName,
            string postfixName,
            string finalizerName)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            HarmonyMethod prefix = null;
            HarmonyMethod postfix = null;
            HarmonyMethod finalizer = null;

            if (!string.IsNullOrEmpty(prefixName))
                prefix = new HarmonyMethod(GetPatchMethod(prefixName));
            if (!string.IsNullOrEmpty(postfixName))
                postfix = new HarmonyMethod(GetPatchMethod(postfixName));
            if (!string.IsNullOrEmpty(finalizerName))
                finalizer = new HarmonyMethod(GetPatchMethod(finalizerName));

            _harmony.Patch(target, prefix, postfix, null, finalizer, null);
        }

        private static MethodInfo GetPatchMethod(string name)
        {
            var method = typeof(RuntimePatches).GetMethod(
                name,
                BindingFlags.Static | BindingFlags.Public);

            if (method == null)
                throw new MissingMethodException(typeof(RuntimePatches).FullName, name);

            return method;
        }

        internal static void DisableAfterRuntimeFailure(string stage, Exception ex)
        {
            RuntimeDisabled = true;

            if (_runtimeFailureLogged)
                return;

            _runtimeFailureLogged = true;
            Log.LogError(
                PluginName + " disabled tooltip enrichment after "
                + stage + " failure; subsequent tooltips stay vanilla: "
                + ex.GetType().Name + ": " + ex.Message);
        }
    }

    internal sealed class TechTooltipPatchState
    {
        public TechTooltipContext Previous;
        public TechTooltipContext Current;
    }

    internal static class RuntimePatches
    {
        [ThreadStatic]
        private static TechTooltipContext _currentContext;

        public static void TechUnlockPrefix(
            object __instance,
            out TechTooltipPatchState __state)
        {
            __state = new TechTooltipPatchState
            {
                Previous = _currentContext,
                Current = null
            };

            if (Plugin.RuntimeDisabled || __instance == null)
                return;

            try
            {
                __state.Current = GameApi.TryCreateContext(__instance);
                _currentContext = __state.Current;
            }
            catch (Exception ex)
            {
                Plugin.DisableAfterRuntimeFailure("Technology context", ex);
                _currentContext = null;
            }
        }

        public static void TechUnlockPostfix(
            object tooltip,
            TechTooltipPatchState __state)
        {
            if (Plugin.RuntimeDisabled
                || tooltip == null
                || __state == null
                || __state.Current == null)
            {
                return;
            }

            try
            {
                GameApi.AppendDetails(tooltip, __state.Current);
            }
            catch (Exception ex)
            {
                Plugin.DisableAfterRuntimeFailure("tooltip composition", ex);
            }
        }

        public static Exception TechUnlockFinalizer(
            Exception __exception,
            TechTooltipPatchState __state)
        {
            _currentContext = __state == null ? null : __state.Previous;
            return __exception;
        }

        public static void ItemTooltipDataPostfix(
            object __instance,
            bool full_detail,
            IList __result)
        {
            if (Plugin.RuntimeDisabled
                || _currentContext == null
                || string.IsNullOrEmpty(_currentContext.LocationRow)
                || full_detail
                || __instance == null
                || __result == null)
            {
                return;
            }

            try
            {
                if (GameApi.HasAggregateCraftLocation(__instance)
                    && __result.Count > 0)
                {
                    // In GK 1.407 ItemDefinition.GetTooltipData appends the
                    // aggregate crafting-location row last. Remove that single
                    // row only when an exact Technology-owned replacement has
                    // already been composed successfully.
                    __result.RemoveAt(__result.Count - 1);
                }
            }
            catch (Exception ex)
            {
                Plugin.DisableAfterRuntimeFailure("aggregate-location suppression", ex);
            }
        }

        public static void ItemTooltipCraftAtPostfix(IList __result)
        {
            if (Plugin.RuntimeDisabled
                || _currentContext == null
                || string.IsNullOrEmpty(_currentContext.LocationRow)
                || __result == null)
            {
                return;
            }

            try
            {
                // The special sermon branch calls this helper directly.
                // Clear it only when an exact Technology-owned replacement is
                // ready; otherwise the vanilla aggregate row remains intact.
                __result.Clear();
            }
            catch (Exception ex)
            {
                Plugin.DisableAfterRuntimeFailure("sermon-location suppression", ex);
            }
        }
    }
}
