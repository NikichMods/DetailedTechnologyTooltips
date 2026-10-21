// SPDX-License-Identifier: MPL-2.0
using System;
using System.Collections.Generic;
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
        internal static int TitleGap = 4, PurposeGap = 8, MaterialGap = 8, EntryGap = 0;
        private sealed class Row { internal string Raw; internal bool Material; }
        private sealed class Live { internal WeakReference Widget, Data; }
        private sealed class CameraState { internal Behaviour Camera; internal bool Enabled; }
        private static readonly ConditionalWeakTable<object, Row> Rows = new ConditionalWeakTable<object, Row>();
        private static readonly ConditionalWeakTable<object, Row> Tooltips = new ConditionalWeakTable<object, Row>();
        private static readonly List<Live> LiveRows = new List<Live>();
        private static readonly List<CameraState> Cameras = new List<CameraState>();
        private static FieldInfo text;
        private static MethodInfo draw, resize;
        private static Type bubbleType, cameraType;
        private static object lastTooltip;
        private static bool ready, open;
        private static Rect window = new Rect(650, 45, 460, 640);
        private static Vector2 scroll;

        internal static void Install(Harmony harmony)
        {
            var dataType = AccessTools.TypeByName("BubbleWidgetTextData");
            var widgetType = AccessTools.TypeByName("BubbleWidgetText");
            text = AccessTools.Field(dataType, "text");
            draw = AccessTools.DeclaredMethod(widgetType, "Draw", new[] { dataType });
            bubbleType = AccessTools.TypeByName("WidgetsBubbleGUI");
            resize = AccessTools.Method(bubbleType, "UpdateSizeAndWidgetsPositions", Type.EmptyTypes);
            if (text == null || draw == null || resize == null) throw new MissingMemberException("Calibration draw contract");
            harmony.Patch(draw, new HarmonyMethod(typeof(PilotCalibration), nameof(BeforeDraw)),
                new HarmonyMethod(typeof(PilotCalibration), nameof(AfterDraw)), null, null, null);
#if DTT_CALIBRATION
            cameraType = AccessTools.TypeByName("UICamera");
            var tooltipType = AccessTools.TypeByName("Tooltip");
            harmony.Patch(AccessTools.DeclaredMethod(tooltipType, "Show", new[] { typeof(bool) }),
                postfix: new HarmonyMethod(typeof(PilotCalibration), nameof(Shown)));
            harmony.Patch(AccessTools.DeclaredMethod(tooltipType, "Hide", Type.EmptyTypes),
                prefix: new HarmonyMethod(typeof(PilotCalibration), nameof(Hide)));
            var lazy = AccessTools.TypeByName("LazyInput");
            foreach (var method in lazy.GetMethods(BindingFlags.Public | BindingFlags.Static))
                if (method.ReturnType == typeof(bool) && (method.Name == "GetKey" || method.Name == "GetKeyDown"
                    || method.Name == "AnyClick" || method.Name == "AnyKeyDown"))
                    harmony.Patch(method, prefix: new HarmonyMethod(typeof(PilotCalibration), nameof(KeyGuard)));
#endif
            ready = true;
        }
        internal static void Mark(object data, bool material)
        {
            if (!ready) return;
            Rows.Add(data, new Row { Raw = (string)text.GetValue(data), Material = material });
        }
        internal static void RememberTooltip(object tooltip)
        {
            if (!ready) return;
            Tooltips.Remove(tooltip); Tooltips.Add(tooltip, new Row());
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
            Row row;
            if (__0 == null || !Rows.TryGetValue(__0, out row)) return;
            foreach (var live in LiveRows) if (ReferenceEquals(live.Widget.Target, __instance))
                { live.Data = new WeakReference(__0); return; }
            if (LiveRows.Count >= 256) LiveRows.RemoveAt(0);
            LiveRows.Add(new Live { Widget = new WeakReference(__instance), Data = new WeakReference(__0) });
        }
        public static void Shown(object __instance)
        {
            Row marker;
            if (Tooltips.TryGetValue(__instance, out marker)) lastTooltip = __instance;
        }
        public static bool Hide(object __instance) { return !open || !ReferenceEquals(lastTooltip, __instance); }
        public static bool KeyGuard(ref bool __result) { if (!open) return true; __result = false; return false; }
        private static void Refresh()
        {
            var bubbles = new HashSet<Component>();
            foreach (var live in LiveRows.ToArray())
            {
                var widget = live.Widget.Target as Component;
                var data = live.Data.Target;
                if (widget == null || data == null || !widget.gameObject.activeInHierarchy) continue;
                draw.Invoke(widget, new[] { data });
                var bubble = widget.GetComponentInParent(bubbleType);
                if (bubble != null) bubbles.Add(bubble);
            }
            foreach (var bubble in bubbles) { PilotLayout.Invalidate(bubble); resize.Invoke(bubble, null); }
        }
        private static void Fail(Exception e)
        {
            if (!ready) return;
            ready = false; Close();
            Plugin.Log.LogError("DTT_CALIBRATION_DISABLED reason=" + e.GetType().Name + ": " + e.Message);
        }
        internal static void Update()
        {
#if DTT_CALIBRATION
            if (!ready || !Input.GetKeyDown(KeyCode.F2)) return;
            if (open) { Close(); return; }
            try
            {
                open = true;
                foreach (var obj in UnityEngine.Object.FindObjectsOfType(cameraType))
                {
                    var camera = obj as Behaviour;
                    if (camera == null) continue;
                    Cameras.Add(new CameraState { Camera = camera, Enabled = camera.enabled });
                    camera.enabled = false;
                }
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
            GUILayout.Label("Перед F2 наведите мышь на нужный чертёж.\nОкно можно перетащить за заголовок.");
            GUI.changed = false;
            IconSize = Slider("Размер иконок (UI)", IconSize, 10, 32);
            IconY = Slider("Сдвиг иконок вверх (+) / вниз (−)", IconY, -16, 16);
            TextSpaces = Slider("Отступ текста (пробелы)", TextSpaces, 0, 16);
            Opacity = Slider("Насыщенность текста, %", Opacity, 20, 100);
            GUILayout.Label("По центру (выключено — слева):");
            TitleCenter = GUILayout.Toggle(TitleCenter, "Заголовок");
            PurposeCenter = GUILayout.Toggle(PurposeCenter, "Описание назначения");
            MaterialCenter = GUILayout.Toggle(MaterialCenter, "Блок материалов целиком");
            LocationCenter = GUILayout.Toggle(LocationCenter, "Место строительства");
            TitleGap = Slider("Заголовок → описание (UI)", TitleGap, 0, 24);
            PurposeGap = Slider("Описание → материалы (UI)", PurposeGap, 0, 24);
            MaterialGap = Slider("Материалы → место строительства (UI)", MaterialGap, 0, 24);
            EntryGap = Slider("Дополнительно между открытиями (UI)", EntryGap, 0, 24);
            if (GUILayout.Button("Сбросить к выбранному образцу"))
            {
                IconSize = 20; IconY = 0; TextSpaces = 5; Opacity = 100;
                TitleCenter = PurposeCenter = LocationCenter = true; MaterialCenter = false;
                TitleGap = 4; PurposeGap = MaterialGap = 8; EntryGap = 0; GUI.changed = true;
            }
            if (GUI.changed) try { Refresh(); } catch (Exception e) { Fail(e); }
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
            foreach (var state in Cameras) if (state.Camera != null) state.Camera.enabled = state.Enabled;
            Cameras.Clear();
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
