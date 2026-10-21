// SPDX-License-Identifier: MPL-2.0
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;

namespace DetailedTechnologyTooltips
{
    internal static class PilotMaterialIcons
    {
        private const string ChildName = "DTT-material-icon";
        private sealed class Icon { internal string Name; }
        private static readonly ConditionalWeakTable<object, Icon> Rows = new ConditionalWeakTable<object, Icon>();
        private static bool installed, failed;
        internal static bool Available { get { return installed && !failed; } }
        private static Type spriteType;
        private static FieldInfo labelField;
        private static MethodInfo getSprite;
        private static PropertyInfo sprite2D, depth, width, height;
        private static FieldInfo[] anchors;
        private static FieldInfo anchorTarget, anchorRelative, anchorAbsolute;
        private static Component nativeIcon;
        private static Color nativeColor;

        internal static void Install(Harmony harmony)
        {
            var widget = AccessTools.TypeByName("BubbleWidgetText");
            var data = AccessTools.TypeByName("BubbleWidgetTextData");
            spriteType = AccessTools.TypeByName("UI2DSprite");
            var collection = AccessTools.TypeByName("EasySpritesCollection");
            var rect = AccessTools.TypeByName("UIRect");
            if (widget == null || data == null || spriteType == null || collection == null || rect == null)
                throw new TypeLoadException("Pilot icon native types unavailable");
            labelField = AccessTools.Field(widget, "_label");
            getSprite = AccessTools.Method(collection, "GetSprite", new[] { typeof(string), typeof(bool), typeof(string) });
            sprite2D = AccessTools.Property(spriteType, "sprite2D");
            depth = AccessTools.Property(spriteType, "depth");
            width = AccessTools.Property(spriteType, "width");
            height = AccessTools.Property(spriteType, "height");
            anchors = new[] { AccessTools.Field(rect, "leftAnchor"), AccessTools.Field(rect, "rightAnchor"),
                AccessTools.Field(rect, "bottomAnchor"), AccessTools.Field(rect, "topAnchor") };
            if (labelField == null || getSprite == null || sprite2D == null || depth == null || width == null || height == null)
                throw new MissingMemberException("Pilot icon drawing contract");
            foreach (var anchor in anchors) if (anchor == null) throw new MissingFieldException("UIRect anchors");
            var anchorType = anchors[0].FieldType;
            anchorTarget = AccessTools.Field(anchorType, "target");
            anchorRelative = AccessTools.Field(anchorType, "relative");
            anchorAbsolute = AccessTools.Field(anchorType, "absolute");
            if (anchorTarget == null || anchorRelative == null || anchorAbsolute == null)
                throw new MissingFieldException("UIRect.AnchorPoint contract");
            var draw = AccessTools.DeclaredMethod(widget, "Draw", new[] { data });
            if (draw == null) throw new MissingMethodException("BubbleWidgetText.Draw");
            harmony.Patch(draw, postfix: new HarmonyMethod(typeof(PilotMaterialIcons), nameof(DrawPostfix)));
            installed = true;
        }

        internal static void Mark(object row, string icon)
        {
            if (!Available) return;
            Rows.Add(row, new Icon { Name = icon });
        }

        public static void DrawPostfix(object __instance, object __0)
        {
            if (!installed || __instance == null || __0 == null) return;
            try
            {
                var label = labelField.GetValue(__instance) as Component;
                if (label == null) return;
                var existing = label.transform.Find(ChildName);
                Icon icon;
                if (!Available || !Rows.TryGetValue(__0, out icon))
                {
                    if (existing != null) existing.gameObject.SetActive(false);
                    return;
                }
                // Same native sprite lookup used by BaseItemCellGUI.DrawIcon.
                var sprite = getSprite.Invoke(null, new object[] { icon.Name, false, "" }) as Sprite;
                if (sprite == null) throw new InvalidOperationException("Missing native sprite " + icon.Name);
                Component image;
                if (existing == null)
                {
                    EnsureNativeRenderer();
                    image = UnityEngine.Object.Instantiate(nativeIcon, label.transform, false);
                    image.name = ChildName;
                    image.gameObject.layer = label.gameObject.layer;
                }
                else image = existing.GetComponent(spriteType);
                sprite2D.SetValue(image, sprite, null);
                AccessTools.Property(spriteType, "color").SetValue(image, nativeColor, null);
                depth.SetValue(image, Convert.ToInt32(depth.GetValue(label, null)) + 1, null);
                width.SetValue(image, PilotCalibration.IconSize, null);
                height.SetValue(image, PilotCalibration.IconSize, null);
                // Fixed 14x14 icon inside reserved indent, native anchors follow wrap/position changes.
                for (int i = 0; i < anchors.Length; i++)
                {
                    var point = anchors[i].GetValue(image);
                    anchorTarget.SetValue(point, label.transform);
                    anchorRelative.SetValue(point, i < 2 ? 0f : 1f);
                    anchorAbsolute.SetValue(point, i == 1 ? PilotCalibration.IconSize :
                        i == 2 ? PilotCalibration.IconY - PilotCalibration.IconSize : i == 3 ? PilotCalibration.IconY : 0);
                }
                image.gameObject.SetActive(true);
            }
            catch (Exception ex)
            {
                if (failed) return;
                failed = true;
                Plugin.Log.LogError("DTT_PILOT_ICONS_DISABLED fallback=material-names reason=" + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void EnsureNativeRenderer()
        {
            if (nativeIcon != null) return;
            var guiType = AccessTools.TypeByName("GUIElements");
            var gui = AccessTools.Property(guiType, "me").GetValue(null, null);
            var craft = AccessTools.Field(guiType, "craft").GetValue(gui);
            var prefab = AccessTools.Field(craft.GetType(), "craft_item_prefab").GetValue(craft);
            var itemGui = AccessTools.Field(prefab.GetType(), "item_gui").GetValue(prefab);
            var cell = AccessTools.Field(itemGui.GetType(), "x1").GetValue(itemGui);
            nativeIcon = (Component)AccessTools.Field(cell.GetType(), "icon").GetValue(cell);
            var colors = AccessTools.Field(itemGui.GetType(), "colors").GetValue(itemGui);
            nativeColor = (Color)AccessTools.Field(colors.GetType(), "normal").GetValue(colors);
            if (nativeIcon == null) throw new MissingMemberException("Native item renderer unavailable");
        }
    }
}
