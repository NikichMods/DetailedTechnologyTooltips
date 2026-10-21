// SPDX-License-Identifier: MPL-2.0
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;

namespace DetailedTechnologyTooltips
{
    internal enum PilotRole { Title, Purpose, Material, Location, TitleGap, PurposeGap, MaterialGap, EntryGap }

    internal static class PilotLayout
    {
        private sealed class Tag { internal PilotRole Role; internal float Natural; }
        private sealed class State
        {
            internal bool Dirty = true;
            internal readonly Dictionary<Component, float> Shifts = new Dictionary<Component, float>();
            internal readonly List<Component> Materials = new List<Component>();
            internal int Width, MaterialWidth;
        }
        private static readonly ConditionalWeakTable<object, Tag> Tags = new ConditionalWeakTable<object, Tag>();
        private static readonly ConditionalWeakTable<object, State> States = new ConditionalWeakTable<object, State>();
        private static Type bubbleType, widgetType, labelType, textWidgetType, blankType, rootType;
        private static FieldInfo tooltipData, dataList, widgets, widgetData;
        private static PropertyInfo width, height, overflow, overflowWidth, printed, alignment, pivot;
        private static object resizeFreely, resizeHeight, left, center, leftPivot;
        private static bool installed, failed;
        internal static bool Available { get { return installed && !failed; } }
        private static ConstructorInfo blankCtor;

        internal static void Install(Harmony harmony)
        {
            bubbleType = AccessTools.TypeByName("WidgetsBubbleGUI");
            widgetType = AccessTools.TypeByName("UIWidget");
            labelType = AccessTools.TypeByName("UILabel");
            rootType = AccessTools.TypeByName("UIRoot");
            textWidgetType = AccessTools.TypeByName("BubbleWidgetText");
            blankType = AccessTools.TypeByName("BubbleWidgetBlankSeparatorData");
            tooltipData = AccessTools.Field(AccessTools.TypeByName("Tooltip"), "data");
            dataList = AccessTools.Field(tooltipData.FieldType, "data_list");
            widgets = AccessTools.Field(bubbleType, "bubble_widgets");
            widgetData = AccessTools.Field(textWidgetType, "data");
            width = AccessTools.Property(widgetType, "width"); height = AccessTools.Property(widgetType, "height");
            overflow = AccessTools.Property(labelType, "overflowMethod");
            overflowWidth = AccessTools.Property(labelType, "overflowWidth");
            printed = AccessTools.Property(labelType, "printedSize");
            alignment = AccessTools.Property(labelType, "alignment"); pivot = AccessTools.Property(widgetType, "pivot");
            resizeFreely = Enum.Parse(overflow.PropertyType, "ResizeFreely");
            resizeHeight = Enum.Parse(overflow.PropertyType, "ResizeHeight");
            left = Enum.Parse(alignment.PropertyType, "Left"); center = Enum.Parse(alignment.PropertyType, "Center");
            leftPivot = Enum.Parse(pivot.PropertyType, "Left");
            blankCtor = blankType.GetConstructor(Type.EmptyTypes);
            if (widgets == null || widgetData == null || printed == null || blankCtor == null)
                throw new MissingMemberException("Pilot layout native contract");
            harmony.Patch(AccessTools.DeclaredMethod(bubbleType, "UpdateSize", Type.EmptyTypes),
                prefix: new HarmonyMethod(typeof(PilotLayout), nameof(Prepare)));
            foreach (string name in new[] { "SimpleUITable", "UITable" })
                harmony.Patch(AccessTools.DeclaredMethod(AccessTools.TypeByName(name), "Reposition", Type.EmptyTypes),
                    new HarmonyMethod(typeof(PilotLayout), nameof(TableBefore)),
                    new HarmonyMethod(typeof(PilotLayout), nameof(TableAfter)), null, null, null);
            installed = true;
        }
        internal static int Count(object tooltip)
        {
            if (!installed || tooltip == null) return 0;
            var data = tooltipData.GetValue(tooltip);
            return data == null ? 0 : ((IList)dataList.GetValue(data)).Count;
        }
        internal static void Mark(object data, PilotRole role)
        {
            if (!installed || failed) return;
            Tags.Add(data, new Tag { Role = role });
        }
        internal static object Gap(PilotRole role)
        {
            var data = blankCtor.Invoke(null); Mark(data, role); return data;
        }
        internal static void Header(object tooltip, int start)
        {
            if (!installed || failed) return;
            var list = (IList)dataList.GetValue(tooltipData.GetValue(tooltip));
            if (start + 1 >= list.Count) return;
            Mark(list[start], PilotRole.Title); PilotCalibration.Mark(list[start], false);
            if (blankType.IsInstanceOfType(list[start + 1])) Mark(list[start + 1], PilotRole.TitleGap);
            if (start > 0) list.Insert(start, Gap(PilotRole.EntryGap));
        }
        internal static void Drawn(object widget, object data)
        {
            if (!installed || failed || widget == null || data == null) return;
            try { DrawnCore(widget, data); }
            catch (Exception ex) { Disable(ex); }
        }
        private static void DrawnCore(object widget, object data)
        {
            Tag tag;
            if (!Tags.TryGetValue(data, out tag)) return;
            var component = widget as Component;
            if (component == null) return;
            var bubble = component.GetComponentInParent(bubbleType);
            if (bubble == null) return;
            State state = States.GetValue(bubble, _ => new State());
            state.Dirty = true;
            if (tag.Role != PilotRole.Material) return;
            var label = component.GetComponent(labelType);
            // Measure with the actual locale font. No synthetic font or character estimates.
            var oldMode = overflow.GetValue(label, null);
            var oldLimit = overflowWidth.GetValue(label, null);
            var oldWidth = width.GetValue(label, null);
            try
            {
                overflow.SetValue(label, resizeFreely, null);
                overflowWidth.SetValue(label, 16384, null); width.SetValue(label, 16384, null);
                tag.Natural = ((Vector2)printed.GetValue(label, null)).x;
            }
            finally
            {
                overflowWidth.SetValue(label, oldLimit, null); width.SetValue(label, oldWidth, null);
                overflow.SetValue(label, oldMode, null); printed.GetValue(label, null);
            }
        }
        internal static void Invalidate(object bubble)
        {
            State state;
            if (bubble != null && States.TryGetValue(bubble, out state)) state.Dirty = true;
        }
        public static void Prepare(object __instance)
        {
            if (!installed || failed) return;
            try
            {
                State state;
                if (!States.TryGetValue(__instance, out state) || !state.Dirty) return;
                var list = (IList)widgets.GetValue(__instance);
                float longest = 0;
                foreach (var item in list)
                {
                    if (!textWidgetType.IsInstanceOfType(item)) continue;
                    Tag tag; var data = widgetData.GetValue(item);
                    if (data != null && Tags.TryGetValue(data, out tag) && tag.Role == PilotRole.Material)
                        longest = Math.Max(longest, tag.Natural);
                }
                int max = Screen.width - 48;
                var root = ((Component)__instance).GetComponentInParent(rootType);
                if (root != null && Screen.height > 0)
                {
                    var field = AccessTools.Field(rootType, "manualHeight");
                    object value = field != null ? field.GetValue(root) : AccessTools.Property(rootType, "manualHeight").GetValue(root, null);
                    max = (int)(Screen.width * Convert.ToSingle(value) / Screen.height) - 48;
                }
                state.Width = LayoutPolicy.Width(longest, Math.Max(100, max));
                state.MaterialWidth = Math.Min(state.Width, (int)Math.Ceiling(longest) + 4);
                state.Materials.Clear();
                foreach (var item in list)
                {
                    var component = item as Component;
                    if (component == null) continue;
                    var dataField = AccessTools.Field(item.GetType(), "data");
                    var data = dataField == null ? null : dataField.GetValue(item);
                    Tag tag;
                    if (data == null || !Tags.TryGetValue(data, out tag)) continue;
                    var ui = component.GetComponent(widgetType);
                    if (tag.Role >= PilotRole.TitleGap)
                    {
                        int gap = PilotCalibration.Gap(tag.Role);
                        component.gameObject.SetActive(gap > 0);
                        width.SetValue(ui, state.Width, null);
                        if (gap > 0) height.SetValue(ui, gap, null);
                        continue;
                    }
                    var label = component.GetComponent(labelType);
                    overflow.SetValue(label, resizeHeight, null);
                    overflowWidth.SetValue(label, state.Width, null);
                    width.SetValue(label, state.Width, null);
                    pivot.SetValue(label, leftPivot, null);
                    alignment.SetValue(label, tag.Role == PilotRole.Material ? left : PilotCalibration.Center(tag.Role) ? center : left, null);
                    printed.GetValue(label, null); // Commit wrapped height before native measurement.
                    if (tag.Role == PilotRole.Material) state.Materials.Add(component);
                }
                state.Dirty = false;
            }
            catch (Exception ex) { Disable(ex); }
        }
        public static void TableBefore(object __instance)
        {
            if (!installed || failed) return;
            try
            {
                var bubble = ((Component)__instance).GetComponentInParent(bubbleType);
                State state;
                if (bubble == null || !States.TryGetValue(bubble, out state)) return;
                foreach (var shift in state.Shifts)
                    if (shift.Key != null)
                    {
                        var p = shift.Key.transform.localPosition; p.x -= shift.Value; shift.Key.transform.localPosition = p;
                    }
                state.Shifts.Clear();
            }
            catch (Exception ex) { Disable(ex); }
        }
        public static void TableAfter(object __instance)
        {
            if (!installed || failed || !PilotCalibration.MaterialCenter) return;
            try
            {
                var bubble = ((Component)__instance).GetComponentInParent(bubbleType);
                State state;
                if (bubble == null || !States.TryGetValue(bubble, out state)) return;
                float shift = (state.Width - state.MaterialWidth) * 0.5f;
                foreach (var material in state.Materials)
                    if (material != null && material.gameObject.activeInHierarchy)
                    {
                        var p = material.transform.localPosition; p.x += shift; material.transform.localPosition = p;
                        state.Shifts[material] = shift;
                    }
            }
            catch (Exception ex) { Disable(ex); }
        }
        private static void Disable(Exception ex)
        {
            if (failed) return;
            failed = true;
            Plugin.Log.LogError("DTT_LAYOUT_DISABLED fallback=native-layout reason=" + ex.GetType().Name + ": " + ex.Message);
        }
    }

}
