// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using BepInEx.Logging;
using HarmonyLib;

namespace DetailedTechnologyTooltips
{
    internal static class TechnologyTextWrapRepair
    {
        private const BindingFlags AllInstance =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private sealed class Marker
        {
            internal static readonly Marker Instance = new Marker();
        }

        private static readonly ConditionalWeakTable<object, Marker> OwnedRows =
            new ConditionalWeakTable<object, Marker>();

        private static ManualLogSource _log;
        private static bool _installed;
        private static bool _runtimeFailed;
        private static FieldInfo _labelField;
        private static PropertyInfo _labelTextProperty;
        private static PropertyInfo _processedTextProperty;

        internal static void Install(Harmony harmony, ManualLogSource log)
        {
            if (harmony == null)
                throw new ArgumentNullException(nameof(harmony));

            _log = log;

            var bubbleType = AccessTools.TypeByName("BubbleWidgetText");
            var dataType = AccessTools.TypeByName("BubbleWidgetTextData");
            if (bubbleType == null || dataType == null)
            {
                throw new TypeLoadException(
                    "BubbleWidgetText / BubbleWidgetTextData was not found.");
            }

            var draw = bubbleType.GetMethod(
                "Draw",
                AllInstance,
                null,
                new[] { dataType },
                null);
            if (draw == null)
                throw new MissingMethodException(
                    bubbleType.FullName,
                    "Draw(BubbleWidgetTextData)");

            _labelField = bubbleType.GetField("_label", AllInstance);
            if (_labelField == null)
                throw new MissingFieldException(bubbleType.FullName, "_label");

            var labelType = _labelField.FieldType;
            _labelTextProperty = labelType.GetProperty("text", AllInstance);
            _processedTextProperty =
                labelType.GetProperty("processedText", AllInstance);

            if (_labelTextProperty == null || !_labelTextProperty.CanRead
                || !_labelTextProperty.CanWrite)
            {
                throw new MissingMemberException(
                    labelType.FullName,
                    "text");
            }

            if (_processedTextProperty == null
                || !_processedTextProperty.CanRead)
            {
                throw new MissingMemberException(
                    labelType.FullName,
                    "processedText");
            }

            harmony.Patch(
                draw,
                postfix: new HarmonyMethod(
                    AccessTools.Method(
                        typeof(TechnologyTextWrapRepair),
                        nameof(BubbleWidgetTextDrawPostfix))));

            _installed = true;
        }

        internal static void Mark(object data)
        {
            if (!_installed || _runtimeFailed || data == null)
                return;

            OwnedRows.Remove(data);
            OwnedRows.Add(data, Marker.Instance);
        }

        public static void BubbleWidgetTextDrawPostfix(
            object __instance,
            object __0)
        {
            if (!_installed
                || _runtimeFailed
                || __instance == null
                || __0 == null)
            {
                return;
            }

            Marker marker;
            if (!OwnedRows.TryGetValue(__0, out marker))
                return;

            try
            {
                var label = _labelField.GetValue(__instance);
                if (label == null)
                    return;

                var raw = _labelTextProperty.GetValue(label, null) as string;
                var processed =
                    _processedTextProperty.GetValue(label, null) as string;

                var repaired =
                    TextFormatting.RepairBrokenQuantityTokens(
                        raw,
                        processed);

                if (string.Equals(raw, repaired, StringComparison.Ordinal))
                    return;

                _labelTextProperty.SetValue(label, repaired, null);

                // Force NGUI to commit processedText again after the explicit,
                // semantics-safe break was moved before the quantity token.
                _processedTextProperty.GetValue(label, null);
            }
            catch (Exception ex)
            {
                Disable("repairing DTT quantity wrapping", ex);
            }
        }

        private static void Disable(string stage, Exception ex)
        {
            if (_runtimeFailed)
                return;

            _runtimeFailed = true;
            _log?.LogError(
                "DTT_WRAP_REPAIR_DISABLED stage=" + stage
                + " fallback=native-wrap reason="
                + ex.GetType().Name + ": " + ex.Message);
        }
    }
}
