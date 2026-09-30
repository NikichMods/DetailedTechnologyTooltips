// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace DetailedTechnologyTooltips
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "nikich.gyk.detailedtechnologytooltips";
        public const string PluginName = "Detailed Technology Tooltips";
        public const string PluginVersion = "1.0.2";

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

                try
                {
                    TechnologyTextWrapRepair.Install(_harmony, Log);
                }
                catch (Exception ex)
                {
                    Log.LogWarning(
                        "DTT_WRAP_REPAIR_FALLBACK action=native-wrap reason="
                        + ex.GetType().Name + ": " + ex.Message);
                }

                try
                {
                    TechnologyTooltipViewportClamp.Install(_harmony, Log);
                }
                catch (Exception ex)
                {
                    Log.LogWarning(
                        "DTT_VIEWPORT_FALLBACK action=native-placement reason="
                        + ex.GetType().Name + ": " + ex.Message);
                }

                Log.LogInfo(
                    "DTT_READY version=" + PluginVersion
                    + " contract=technology-tooltip"
                    + " host_mvid=" + GameApi.HostModuleVersionId + ".");
            }
            catch (Exception ex)
            {
                RuntimeDisabled = true;
                Log.LogError(
                    "DTT_INIT_FAILED fallback=vanilla reason="
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
                "DTT_RUNTIME_DISABLED stage=" + stage
                + " fallback=vanilla reason="
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
            object tooltip,
            out TechTooltipPatchState __state)
        {
            __state = new TechTooltipPatchState
            {
                Previous = _currentContext,
                Current = null
            };

            if (Plugin.RuntimeDisabled || __instance == null)
                return;

            TechnologyTooltipViewportClamp.MarkTechnologyTooltip(tooltip);

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

    internal static class TechnologyTooltipViewportClamp
    {
        private const float SafeMarginPixels = 24f;
        private const string GamepadTooltipPositionFixHarmonyId =
            "nikich.gyk.movegamepadtooltips";

        private sealed class Marker
        {
            internal static readonly Marker Instance = new Marker();
        }

        private sealed class BubbleState
        {
            internal readonly Component Root;

            internal BubbleState(Component root)
            {
                Root = root;
            }
        }

        private static readonly ConditionalWeakTable<object, Marker> OwnedTooltips =
            new ConditionalWeakTable<object, Marker>();
        private static readonly ConditionalWeakTable<object, BubbleState> OwnedBubbles =
            new ConditionalWeakTable<object, BubbleState>();

        private static ManualLogSource _log;
        private static bool _installed;
        private static bool _runtimeFailed;
        private static Type _uiRootType;
        private static MemberInfo _linkedTooltip;
        private static MemberInfo _widget;
        private static MemberInfo _widgetWidth;
        private static MemberInfo _widgetHeight;
        private static MemberInfo _manualHeight;

        internal static void Install(Harmony harmony, ManualLogSource log)
        {
            _log = log;

            var tooltipType = AccessTools.TypeByName("Tooltip");
            var bubbleType = AccessTools.TypeByName("WidgetsBubbleGUI");
            _uiRootType = AccessTools.TypeByName("UIRoot");
            if (tooltipType == null || bubbleType == null || _uiRootType == null)
                throw new MissingMemberException("Tooltip / WidgetsBubbleGUI / UIRoot type unavailable.");

            _linkedTooltip = RequireMember(tooltipType, "linked_tooltip");
            _widget = RequireMember(bubbleType, "widget");
            var widgetType = MemberType(_widget);
            _widgetWidth = RequireMember(widgetType, "width");
            _widgetHeight = RequireMember(widgetType, "height");
            _manualHeight = RequireMember(_uiRootType, "manualHeight");

            var show = RequireInstanceMethod(tooltipType, "Show", new[] { typeof(bool) });
            var clear = RequireInstanceMethod(tooltipType, "ClearData", Type.EmptyTypes);
            var update = RequireInstanceMethod(bubbleType, "Update", Type.EmptyTypes);

            harmony.Patch(
                show,
                postfix: new HarmonyMethod(
                    AccessTools.Method(typeof(TechnologyTooltipViewportClamp), nameof(TooltipShowPostfix))));
            harmony.Patch(
                clear,
                postfix: new HarmonyMethod(
                    AccessTools.Method(typeof(TechnologyTooltipViewportClamp), nameof(TooltipClearPostfix))));

            var updatePatch = new HarmonyMethod(
                AccessTools.Method(typeof(TechnologyTooltipViewportClamp), nameof(BubbleUpdatePostfix)));
            updatePatch.after = new[] { GamepadTooltipPositionFixHarmonyId };
            harmony.Patch(update, postfix: updatePatch);

            _installed = true;
        }

        internal static void MarkTechnologyTooltip(object tooltip)
        {
            if (!_installed || _runtimeFailed || tooltip == null)
                return;

            OwnedTooltips.Remove(tooltip);
            OwnedTooltips.Add(tooltip, Marker.Instance);
        }

        public static void TooltipClearPostfix(object __instance)
        {
            if (__instance != null)
                OwnedTooltips.Remove(__instance);
        }

        public static void TooltipShowPostfix(object __instance)
        {
            if (_runtimeFailed || __instance == null)
                return;

            Marker marker;
            if (!OwnedTooltips.TryGetValue(__instance, out marker))
                return;

            try
            {
                var bubbleObject = ReadMember(__instance, _linkedTooltip);
                var bubble = bubbleObject as Component;
                if (bubble == null)
                    return;

                var rootTransform = bubble.transform.root;
                var root = rootTransform == null
                    ? null
                    : rootTransform.GetComponent(_uiRootType);
                if (root == null)
                    return;

                OwnedBubbles.Remove(bubbleObject);
                OwnedBubbles.Add(bubbleObject, new BubbleState(root));
            }
            catch (Exception ex)
            {
                Disable("linking Technology tooltip bubble", ex);
            }
        }

        public static void BubbleUpdatePostfix(object __instance)
        {
            if (_runtimeFailed || __instance == null)
                return;

            BubbleState state;
            if (!OwnedBubbles.TryGetValue(__instance, out state))
                return;

            try
            {
                var bubble = __instance as Component;
                var widget = ReadMember(__instance, _widget);
                if (bubble == null || widget == null || state.Root == null)
                    return;

                var width = Convert.ToInt32(ReadMember(widget, _widgetWidth));
                var height = Convert.ToInt32(ReadMember(widget, _widgetHeight));
                var manualHeight = Convert.ToInt32(ReadMember(state.Root, _manualHeight));
                var screenWidth = Screen.width;
                var screenHeight = Screen.height;

                if (width <= 0 || height <= 0 || manualHeight <= 0
                    || screenWidth <= 0 || screenHeight <= 0)
                    return;

                var scale = manualHeight / (float)screenHeight;
                var safe = Screen.safeArea;
                var halfWidth = screenWidth * 0.5f;
                var halfHeight = screenHeight * 0.5f;
                var left = (safe.xMin - halfWidth) * scale;
                var right = (safe.xMax - halfWidth) * scale;
                var bottom = (safe.yMin - halfHeight) * scale;
                var top = (safe.yMax - halfHeight) * scale;
                var margin = SafeMarginPixels * scale;

                var pos = bubble.transform.localPosition;
                var x = ClampAxis(pos.x, left, right, width, margin);
                var y = ClampAxis(pos.y, bottom, top, height, margin);

                if (Math.Abs(x - pos.x) > 0.01f || Math.Abs(y - pos.y) > 0.01f)
                    bubble.transform.localPosition = new Vector3(x, y, pos.z);
            }
            catch (Exception ex)
            {
                Disable("clamping Technology tooltip bubble", ex);
            }
        }

        private static float ClampAxis(
            float value,
            float low,
            float high,
            float size,
            float margin)
        {
            var min = low + margin + size * 0.5f;
            var max = high - margin - size * 0.5f;
            if (min > max) return value;
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static void Disable(string stage, Exception ex)
        {
            if (_runtimeFailed)
                return;

            _runtimeFailed = true;
            _log?.LogError(
                "DTT_VIEWPORT_DISABLED stage=" + stage
                + " fallback=native-placement reason="
                + ex.GetType().Name + ": " + ex.Message);
        }

        private static MethodInfo RequireInstanceMethod(
            Type type,
            string name,
            Type[] args)
        {
            var method = type.GetMethod(
                name,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                args,
                null);
            if (method == null)
                throw new MissingMethodException(type.FullName, name);
            return method;
        }

        private static MemberInfo RequireMember(Type type, string name)
        {
            for (var current = type; current != null; current = current.BaseType)
            {
                var field = current.GetField(
                    name,
                    BindingFlags.Instance | BindingFlags.Public
                    | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                if (field != null)
                    return field;

                var property = current.GetProperty(
                    name,
                    BindingFlags.Instance | BindingFlags.Public
                    | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                if (property != null && property.CanRead)
                    return property;
            }

            throw new MissingMemberException(type.FullName, name);
        }

        private static Type MemberType(MemberInfo member)
        {
            var field = member as FieldInfo;
            if (field != null) return field.FieldType;

            var property = member as PropertyInfo;
            if (property != null) return property.PropertyType;

            throw new NotSupportedException("Unsupported member type.");
        }

        private static object ReadMember(object instance, MemberInfo member)
        {
            var field = member as FieldInfo;
            if (field != null) return field.GetValue(instance);

            var property = member as PropertyInfo;
            if (property != null) return property.GetValue(instance, null);

            throw new NotSupportedException("Unsupported member type.");
        }
    }

}
