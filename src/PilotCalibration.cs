// SPDX-License-Identifier: MPL-2.0
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;

namespace DetailedTechnologyTooltips
{
    // Candidate-only live calibration. No settings enter a game save.
    internal static class PilotCalibration
    {
        internal static int IconSize = 20, IconY = 0, TextSpaces = 5, Opacity = 100;
        internal static bool TitleCenter = true, PurposeCenter = true, MaterialCenter = false, LocationCenter = true;
        private const int DefaultTitleGap = 2, DefaultBodyGap = 6, DefaultEntryGap = 10;
        internal static int TitleGap = DefaultTitleGap, PurposeGap = DefaultBodyGap,
            MaterialGap = DefaultBodyGap, EntryGap = DefaultEntryGap;
        private sealed class Row { internal string Raw; internal bool Material; }
        private static readonly ConditionalWeakTable<object, Row> Rows = new ConditionalWeakTable<object, Row>();
        private static FieldInfo text;
        private static bool ready, open;
        private static Rect window = new Rect(650, 45, 460, 640);
        private static Vector2 scroll;

        internal static void Install(Harmony harmony)
        {
            var dataType = AccessTools.TypeByName("BubbleWidgetTextData");
            var widgetType = AccessTools.TypeByName("BubbleWidgetText");
            text = AccessTools.Field(dataType, "text");
            var draw = AccessTools.DeclaredMethod(widgetType, "Draw", new[] { dataType });
            if (text == null || draw == null)
                throw new MissingMemberException("Calibration draw contract");
            harmony.Patch(draw, new HarmonyMethod(typeof(PilotCalibration), nameof(BeforeDraw)),
                new HarmonyMethod(typeof(PilotCalibration), nameof(AfterDraw)), null, null, null);
            ready = true;
        }
        internal static void Mark(object data, bool material)
        {
            if (!ready) return;
            Rows.Add(data, new Row { Raw = (string)text.GetValue(data), Material = material });
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
            ready = false; Close();
            var cause = e.GetBaseException();
            Plugin.Log.LogError("DTT_CALIBRATION_DISABLED reason=" + cause.GetType().Name + ": " + cause.Message);
        }
        internal static void Update()
        {
#if DTT_CALIBRATION
            if (!ready || !Input.GetKeyDown(KeyCode.F2)) return;
            if (open) { Close(); return; }
            try
            {
                open = true;
                window.x = Math.Max(0, Math.Min(window.x, Screen.width - window.width));
                window.y = Math.Max(0, Math.Min(window.y, Screen.height - window.height));
            }
            catch (Exception e) { Fail(e); }
#endif
        }
        internal static void Draw()
        {
#if DTT_CALIBRATION
            if (open) window = GUI.Window(284021, window, Contents, "DTT — настройка подсказок (F2)");
#endif
        }
        private static void Contents(int id)
        {
            scroll = GUILayout.BeginScrollView(scroll);
            GUILayout.Label("Меняйте настройки и снова наводите на чертёж.\nF2 не удерживает подсказку и не блокирует игру.\nОкно можно перетащить за заголовок.");
            IconSize = Slider("Размер иконок (ед. интерфейса)", IconSize, 10, 32);
            IconY = Slider("Сдвиг иконок вверх (+) / вниз (−)", IconY, -16, 16);
            TextSpaces = Slider("Отступ текста (пробелы)", TextSpaces, 0, 16);
            Opacity = Slider("Насыщенность текста, %", Opacity, 20, 100);
            GUILayout.Label("По центру (выключено — слева):");
            TitleCenter = GUILayout.Toggle(TitleCenter, "Заголовок");
            PurposeCenter = GUILayout.Toggle(PurposeCenter, "Описание назначения");
            MaterialCenter = GUILayout.Toggle(MaterialCenter, "Блок материалов целиком");
            LocationCenter = GUILayout.Toggle(LocationCenter, "Место строительства");
            GUILayout.Label("Промежутки (ед. интерфейса, не пиксели экрана):");
            TitleGap = Slider("Заголовок → описание", TitleGap, 0, 24);
            PurposeGap = Slider("Описание → материалы", PurposeGap, 0, 24);
            MaterialGap = Slider("Материалы → место строительства", MaterialGap, 0, 24);
            EntryGap = Slider("Дополнительно между открытиями", EntryGap, 0, 24);
            GUILayout.Label("Последний ползунок — для нескольких открытий\nв общей подсказке геймпада.");
            if (GUILayout.Button("Сбросить к выбранному образцу"))
            {
                IconSize = 20; IconY = 0; TextSpaces = 5; Opacity = 100;
                TitleCenter = PurposeCenter = LocationCenter = true; MaterialCenter = false;
                TitleGap = DefaultTitleGap; PurposeGap = MaterialGap = DefaultBodyGap; EntryGap = DefaultEntryGap;
            }
            if (GUILayout.Button("Записать значения и закрыть")) Close();
            GUILayout.Label("100% — полный цвет. Настройки действуют до выхода из игры.");
            GUILayout.EndScrollView();
            GUI.DragWindow(new Rect(0, 0, 460, 23));
        }
        private static int Slider(string label, int value, int min, int max)
        {
            GUILayout.Label(label + ": " + value);
            return (int)Math.Round(GUILayout.HorizontalSlider(value, min, max));
        }
        internal static void Close()
        {
            if (open) Plugin.Log.LogInfo("DTT_CALIBRATION icon_size=" + IconSize + " icon_y=" + IconY + " text_spaces=" + TextSpaces + " opacity=" + Opacity
                + " title_center=" + TitleCenter + " purpose_center=" + PurposeCenter + " material_center=" + MaterialCenter + " location_center=" + LocationCenter
                + " title_gap=" + TitleGap + " purpose_gap=" + PurposeGap + " material_gap=" + MaterialGap + " entry_gap=" + EntryGap);
            open = false;
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
