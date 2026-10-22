// SPDX-License-Identifier: MPL-2.0
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace DetailedTechnologyTooltips
{
    // Fixed appearance accepted in 1.2.10. No input, settings window or save data.
    internal static class TooltipAppearance
    {
        internal const int IconSize = 20, IconY = 0, TextSpaces = 5, Opacity = 100;
        internal const bool TitleCenter = true, PurposeCenter = true, MaterialCenter = false, LocationCenter = true;
        internal const int TitleGap = 2, PurposeGap = 6, MaterialGap = 6, EntryGap = 10;
        private sealed class Row { internal string Raw; internal bool Material; }
        private static readonly ConditionalWeakTable<object, Row> Rows = new ConditionalWeakTable<object, Row>();
        private static FieldInfo text;
        private static bool ready;

        internal static void Install(Harmony harmony)
        {
            var dataType = AccessTools.TypeByName("BubbleWidgetTextData");
            var widgetType = AccessTools.TypeByName("BubbleWidgetText");
            text = AccessTools.Field(dataType, "text");
            var draw = AccessTools.DeclaredMethod(widgetType, "Draw", new[] { dataType });
            if (text == null || draw == null)
                throw new MissingMemberException("Tooltip appearance draw contract");
            harmony.Patch(draw, new HarmonyMethod(typeof(TooltipAppearance), nameof(BeforeDraw)),
                new HarmonyMethod(typeof(TooltipAppearance), nameof(AfterDraw)), null, null, null);
            ready = true;
        }
        internal static void Mark(object data, bool material)
        {
            if (!ready) return;
            Rows.Add(data, new Row { Raw = (string)text.GetValue(data), Material = material });
        }
        internal static void MarkNativeBody(object data)
        {
            if (!ready) return;
            Rows.Add(data, new Row { Raw = "[AA]" + (string)text.GetValue(data) + "[FF]" });
        }
        public static void BeforeDraw(object __0)
        {
            try
            {
                Row row;
                if (__0 == null || !Rows.TryGetValue(__0, out row)) return;
                string raw = row.Material ? LayoutPolicy.BindQuantity(row.Raw.Replace("[AA]      ", "[AA]" + new string(' ', TextSpaces))) : row.Raw;
                string alpha = "[" + ((int)Math.Round(Opacity * 255 / 100.0)).ToString("X2") + "]";
                text.SetValue(__0, raw.Replace("[AA]", alpha));
            }
            catch (Exception e) { Fail(e); }
        }
        public static void AfterDraw(object __instance, object __0)
        {
            PilotLayout.Drawn(__instance, __0);
        }
        private static void Fail(Exception e)
        {
            if (!ready) return;
            ready = false;
            var cause = e.GetBaseException();
            Plugin.Log.LogError("DTT_APPEARANCE_DISABLED reason=" + cause.GetType().Name + ": " + cause.Message);
        }
        internal static bool Center(PilotRole role)
        {
            return role == PilotRole.Title ? TitleCenter : role == PilotRole.Purpose ? PurposeCenter : LocationCenter;
        }
        internal static int Gap(PilotRole role)
        {
            return role == PilotRole.TitleGap ? TitleGap : role == PilotRole.PurposeGap ? PurposeGap : role == PilotRole.MaterialGap ? MaterialGap : EntryGap;
        }
    }
}
