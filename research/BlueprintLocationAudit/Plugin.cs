// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DTTBlueprintLocationAudit
{
    [BepInPlugin(
        "nikich.gyk.dtt.blueprintlocationaudit",
        "DTT Blueprint Location Audit",
        "0.1.0")]
    public sealed class Plugin : BaseUnityPlugin
    {
        private const BindingFlags AllStatic =
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        private static ManualLogSource _log;
        private static bool _dumped;
        private Harmony _harmony;

        private void Awake()
        {
            _log = Logger;

            try
            {
                var mainGameType = AccessTools.TypeByName("MainGame");
                var target = AccessTools.Method(
                    mainGameType,
                    "OnGameStartedPlaying",
                    Type.EmptyTypes);

                if (target == null)
                    throw new MissingMethodException(
                        "MainGame.OnGameStartedPlaying was not found.");

                _harmony = new Harmony(
                    "nikich.gyk.dtt.blueprintlocationaudit");
                _harmony.Patch(
                    target,
                    postfix: new HarmonyMethod(
                        typeof(Plugin),
                        nameof(OnGameStartedPlayingPostfix)));

                _log.LogInfo(
                    "DTT_LOCATION_AUDIT_ARMED version=0.1.0 "
                    + "scope=technology-blueprint-builders");
            }
            catch (Exception ex)
            {
                _log.LogError(
                    "DTT_LOCATION_AUDIT_INIT_FAILED reason="
                    + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void OnDestroy()
        {
            if (_harmony != null)
                _harmony.UnpatchSelf();
        }

        public static void OnGameStartedPlayingPostfix()
        {
            if (_dumped)
                return;

            _dumped = true;

            try
            {
                Dump();
            }
            catch (Exception ex)
            {
                _log.LogError(
                    "DTT_LOCATION_AUDIT_FAILED reason="
                    + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void Dump()
        {
            var gameBalanceType = RequireType("GameBalance");
            var balance =
                RequireProperty(gameBalanceType, "me", AllStatic)
                    .GetValue(null, null);

            if (balance == null)
                throw new InvalidOperationException(
                    "GameBalance.me returned null.");

            var techs = RequireList(
                RequireField(gameBalanceType, "techs_data")
                    .GetValue(balance),
                "GameBalance.techs_data");
            var objectCrafts = RequireList(
                RequireField(gameBalanceType, "craft_obj_data")
                    .GetValue(balance),
                "GameBalance.craft_obj_data");

            var byId = new Dictionary<string, object>(
                StringComparer.Ordinal);
            foreach (var craft in objectCrafts)
            {
                var id = GetStringField(craft, "id");
                if (!string.IsNullOrEmpty(id))
                    byId[id] = craft;
            }

            var ownerTechs =
                new Dictionary<string, List<string>>(
                    StringComparer.Ordinal);

            foreach (var tech in techs)
            {
                var techId = GetStringField(tech, "id");
                var rawCrafts = GetStringListField(tech, "crafts");

                foreach (var raw in rawCrafts)
                {
                    var id = StripHiddenPrefix(raw);
                    List<string> owners;
                    if (!ownerTechs.TryGetValue(id, out owners))
                    {
                        owners = new List<string>();
                        ownerTechs.Add(id, owners);
                    }

                    if (!owners.Contains(techId))
                        owners.Add(techId);
                }
            }

            var visibleBlueprints = 0;
            var sameTechMultiBuilder = 0;
            var globalExtraGroups = 0;
            var unresolvedVisibleBlueprints = 0;

            _log.LogInfo(
                "DTT_LOCATION_AUDIT_BEGIN techs=" + techs.Count
                + " object_crafts=" + objectCrafts.Count);

            foreach (var tech in techs)
            {
                var techId = GetStringField(tech, "id");
                var rawCrafts = GetStringListField(tech, "crafts");

                var refs = new List<CraftRef>();
                foreach (var raw in rawCrafts)
                {
                    var hidden = !string.IsNullOrEmpty(raw)
                        && raw[0] == '@';
                    var id = StripHiddenPrefix(raw);
                    object craft;
                    if (!byId.TryGetValue(id, out craft))
                        continue;

                    refs.Add(new CraftRef(
                        raw,
                        id,
                        hidden,
                        craft,
                        GetStringField(craft, "out_obj"),
                        GetFieldValue(craft, "build_type")));
                }

                foreach (var visible in refs.Where(x => !x.Hidden))
                {
                    visibleBlueprints++;

                    if (string.IsNullOrEmpty(visible.OutObj))
                    {
                        unresolvedVisibleBlueprints++;
                        continue;
                    }

                    var sameTech = refs
                        .Where(x =>
                            string.Equals(
                                x.OutObj,
                                visible.OutObj,
                                StringComparison.Ordinal)
                            && Equals(
                                x.BuildType,
                                visible.BuildType))
                        .ToList();

                    var visibleBuilders =
                        GetBuilders(visible.Craft);
                    var sameTechBuilders =
                        DistinctOrdered(
                            sameTech.SelectMany(
                                x => GetBuilders(x.Craft)));

                    var hiddenSiblings = sameTech
                        .Where(x => x.Hidden)
                        .Select(x => x.Id)
                        .ToList();

                    if (sameTechBuilders.Count > 1)
                    {
                        sameTechMultiBuilder++;
                        _log.LogInfo(
                            "DTT_LOCATION_AUDIT_SAME_TECH"
                            + " tech=" + Escape(techId)
                            + " visible=" + Escape(visible.Id)
                            + " out_obj=" + Escape(visible.OutObj)
                            + " visible_builders="
                            + Join(visibleBuilders)
                            + " all_builders="
                            + Join(sameTechBuilders)
                            + " sibling_ids="
                            + Join(sameTech.Select(x => x.Id))
                            + " hidden_sibling_ids="
                            + Join(hiddenSiblings));
                    }

                    var globalMatches = new List<object>();
                    foreach (var candidate in objectCrafts)
                    {
                        if (!string.Equals(
                                GetStringField(candidate, "out_obj"),
                                visible.OutObj,
                                StringComparison.Ordinal))
                        {
                            continue;
                        }

                        if (!Equals(
                                GetFieldValue(candidate, "build_type"),
                                visible.BuildType))
                        {
                            continue;
                        }

                        globalMatches.Add(candidate);
                    }

                    var globalBuilders =
                        DistinctOrdered(
                            globalMatches.SelectMany(GetBuilders));

                    var extraBuilders = globalBuilders
                        .Where(x => !sameTechBuilders.Contains(x))
                        .ToList();

                    if (extraBuilders.Count > 0)
                    {
                        globalExtraGroups++;

                        var extraDefs = globalMatches
                            .Where(x =>
                                GetBuilders(x).Any(
                                    b => extraBuilders.Contains(b)))
                            .Select(x =>
                                DescribeDefinition(
                                    x,
                                    ownerTechs))
                            .ToList();

                        _log.LogInfo(
                            "DTT_LOCATION_AUDIT_GLOBAL_EXTRA"
                            + " tech=" + Escape(techId)
                            + " visible=" + Escape(visible.Id)
                            + " out_obj=" + Escape(visible.OutObj)
                            + " same_tech_builders="
                            + Join(sameTechBuilders)
                            + " extra_builders="
                            + Join(extraBuilders)
                            + " extra_defs="
                            + string.Join(";", extraDefs.ToArray()));
                    }
                }
            }

            _log.LogInfo(
                "DTT_LOCATION_AUDIT_DONE"
                + " visible_blueprints=" + visibleBlueprints
                + " same_tech_multi_builder="
                + sameTechMultiBuilder
                + " global_extra_groups="
                + globalExtraGroups
                + " unresolved_visible_blueprints="
                + unresolvedVisibleBlueprints);
        }

        private static string DescribeDefinition(
            object craft,
            Dictionary<string, List<string>> ownerTechs)
        {
            var id = GetStringField(craft, "id");
            List<string> owners;
            if (!ownerTechs.TryGetValue(id, out owners))
                owners = new List<string>();

            return "{id=" + Escape(id)
                + ",builders=" + Join(GetBuilders(craft))
                + ",owners=" + Join(owners)
                + ",hidden=" + GetBoolField(craft, "hidden")
                + ",needs_unlock="
                + GetBoolField(craft, "needs_unlock")
                + ",enabled="
                + GetBoolField(craft, "enabled")
                + "}";
        }

        private static IList RequireList(
            object value,
            string name)
        {
            var list = value as IList;
            if (list == null)
                throw new InvalidOperationException(
                    name + " is not an IList.");
            return list;
        }

        private static List<string> GetStringListField(
            object obj,
            string name)
        {
            var value = GetFieldValue(obj, name) as IList;
            var result = new List<string>();

            if (value == null)
                return result;

            foreach (var item in value)
            {
                var valueText = item as string;
                if (!string.IsNullOrEmpty(valueText))
                    result.Add(valueText);
            }

            return result;
        }

        private static List<string> GetBuilders(object craft)
        {
            return GetStringListField(craft, "builder_ids");
        }

        private static List<string> DistinctOrdered(
            IEnumerable<string> values)
        {
            var result = new List<string>();
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value)
                    && !result.Contains(value))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        private static string StripHiddenPrefix(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            return value[0] == '@'
                ? value.Substring(1)
                : value;
        }

        private static string GetStringField(
            object obj,
            string name)
        {
            return GetFieldValue(obj, name) as string;
        }

        private static bool GetBoolField(
            object obj,
            string name)
        {
            var value = GetFieldValue(obj, name);
            return value is bool && (bool)value;
        }

        private static object GetFieldValue(
            object obj,
            string name)
        {
            if (obj == null)
                return null;

            var field = AccessTools.Field(
                obj.GetType(),
                name);
            if (field == null)
                return null;

            return field.GetValue(obj);
        }

        private static FieldInfo RequireField(
            Type type,
            string name)
        {
            var field = AccessTools.Field(type, name);
            if (field == null)
                throw new MissingFieldException(
                    type.FullName,
                    name);
            return field;
        }

        private static PropertyInfo RequireProperty(
            Type type,
            string name,
            BindingFlags flags)
        {
            var property = type.GetProperty(
                name,
                flags);
            if (property == null)
                throw new MissingMemberException(
                    type.FullName,
                    name);
            return property;
        }

        private static Type RequireType(string name)
        {
            var type = AccessTools.TypeByName(name);
            if (type == null)
                throw new TypeLoadException(
                    name + " was not found.");
            return type;
        }

        private static string Join(
            IEnumerable<string> values)
        {
            var array = values
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(Escape)
                .ToArray();

            return array.Length == 0
                ? "-"
                : string.Join(",", array);
        }

        private static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "-";

            return value
                .Replace("|", "/")
                .Replace(";", ",")
                .Replace("\r", " ")
                .Replace("\n", " ");
        }

        private sealed class CraftRef
        {
            internal CraftRef(
                string raw,
                string id,
                bool hidden,
                object craft,
                string outObj,
                object buildType)
            {
                Raw = raw;
                Id = id;
                Hidden = hidden;
                Craft = craft;
                OutObj = outObj;
                BuildType = buildType;
            }

            internal string Raw { get; private set; }
            internal string Id { get; private set; }
            internal bool Hidden { get; private set; }
            internal object Craft { get; private set; }
            internal string OutObj { get; private set; }
            internal object BuildType { get; private set; }
        }
    }
}
