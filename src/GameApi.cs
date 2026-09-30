// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace DetailedTechnologyTooltips
{
    internal sealed class TechTooltipContext
    {
        public object Craft;
        public bool IsBlueprint;
    }

    internal static class GameApi
    {
        private const BindingFlags AllInstance =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private const BindingFlags AllStatic =
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        internal static MethodInfo TechUnlockGetTooltip;
        internal static MethodInfo ItemDefinitionGetTooltipData;
        internal static MethodInfo ItemDefinitionGetTooltipDataCraftAt;
        internal static Guid HostModuleVersionId;

        private static Type _itemType;

        private static FieldInfo _techUnlockTypeField;
        private static FieldInfo _techUnlockIdField;
        private static object _craftUnlockEnumValue;

        private static PropertyInfo _gameBalanceMeProperty;
        private static MethodInfo _getCraftById;
        private static MethodInfo _getObjectCraftById;

        private static FieldInfo _needsField;
        private static FieldInfo _craftInField;
        private static FieldInfo _builderIdsField;

        private static MethodInfo _itemGetItemName;
        private static MethodInfo _itemDefinitionGetItemDetails;
        private static FieldInfo _itemDetailsCraftsInField;

        private static MethodInfo _gjlLString;
        private static MethodInfo _tooltipAddData;
        private static ConstructorInfo _textDataCtor;
        private static object _tinyDescriptionStyle;
        private static object _leftAlignment;

        internal static void Bind()
        {
            var techUnlockType = RequireType("TechUnlock");
            var tooltipType = RequireType("Tooltip");
            var itemDefinitionType = RequireType("ItemDefinition");
            _itemType = RequireType("Item");
            var craftDefinitionType = RequireType("CraftDefinition");
            var objectCraftDefinitionType = RequireType("ObjectCraftDefinition");
            var gameBalanceType = RequireType("GameBalance");
            var gameBalanceBaseType = RequireType("GameBalanceBase");
            var bubbleWidgetDataType = RequireType("BubbleWidgetData");
            var bubbleWidgetTextDataType = RequireType("BubbleWidgetTextData");
            var textStyleType = RequireType("UITextStyles+TextStyle");
            var alignmentType = RequireType("NGUIText+Alignment");
            var gjlType = RequireType("GJL");

            HostModuleVersionId = techUnlockType.Module.ModuleVersionId;

            TechUnlockGetTooltip = RequireMethod(
                techUnlockType,
                "GetTooltip",
                AllInstance,
                new[] { tooltipType });

            ItemDefinitionGetTooltipData = RequireMethod(
                itemDefinitionType,
                "GetTooltipData",
                AllInstance,
                new[] { _itemType, typeof(bool) });

            ItemDefinitionGetTooltipDataCraftAt = RequireMethod(
                itemDefinitionType,
                "GetTooltipDataCraftAt",
                AllInstance,
                new[] { _itemType });

            _techUnlockTypeField = RequireField(techUnlockType, "type");
            _techUnlockIdField = RequireField(techUnlockType, "id");
            _craftUnlockEnumValue = Enum.Parse(
                _techUnlockTypeField.FieldType,
                "Craft",
                false);

            _gameBalanceMeProperty = gameBalanceType.GetProperty("me", AllStatic);
            if (_gameBalanceMeProperty == null)
                throw new MissingMemberException(gameBalanceType.FullName, "me");

            var genericGetData = gameBalanceBaseType
                .GetMethods(AllInstance)
                .SingleOrDefault(m =>
                    m.Name == "GetDataOrNull"
                    && m.IsGenericMethodDefinition
                    && m.GetGenericArguments().Length == 1
                    && m.GetParameters().Length == 1
                    && m.GetParameters()[0].ParameterType == typeof(string));

            if (genericGetData == null)
                throw new MissingMethodException(
                    gameBalanceBaseType.FullName,
                    "GetDataOrNull<T>(string)");

            _getCraftById = genericGetData.MakeGenericMethod(craftDefinitionType);
            _getObjectCraftById =
                genericGetData.MakeGenericMethod(objectCraftDefinitionType);

            _needsField = RequireField(craftDefinitionType, "needs");
            _craftInField = RequireField(craftDefinitionType, "craft_in");
            _builderIdsField =
                RequireField(objectCraftDefinitionType, "builder_ids");

            _itemGetItemName = RequireMethod(
                _itemType,
                "GetItemName",
                AllInstance,
                Type.EmptyTypes);

            _itemDefinitionGetItemDetails = RequireMethod(
                itemDefinitionType,
                "GetItemDetails",
                AllInstance,
                Type.EmptyTypes);

            var itemDetailsType =
                itemDefinitionType.GetNestedType(
                    "ItemDetails",
                    BindingFlags.Public | BindingFlags.NonPublic);

            if (itemDetailsType == null)
                throw new TypeLoadException("ItemDefinition.ItemDetails was not found.");

            _itemDetailsCraftsInField =
                RequireField(itemDetailsType, "crafts_in");

            _gjlLString = RequireMethod(
                gjlType,
                "L",
                AllStatic,
                new[] { typeof(string) });

            _tooltipAddData = RequireMethod(
                tooltipType,
                "AddData",
                AllInstance,
                new[] { bubbleWidgetDataType });

            _textDataCtor = bubbleWidgetTextDataType.GetConstructor(
                AllInstance,
                null,
                new[]
                {
                    typeof(string),
                    textStyleType,
                    alignmentType,
                    typeof(int)
                },
                null);

            if (_textDataCtor == null)
                throw new MissingMethodException(
                    bubbleWidgetTextDataType.FullName,
                    ".ctor(string, UITextStyles.TextStyle, NGUIText.Alignment, int)");

            _tinyDescriptionStyle =
                Enum.Parse(textStyleType, "TinyDescription", false);
            _leftAlignment =
                Enum.Parse(alignmentType, "Left", false);
        }

        internal static TechTooltipContext TryCreateContext(object techUnlock)
        {
            if (techUnlock == null)
                return null;

            var unlockType = _techUnlockTypeField.GetValue(techUnlock);
            if (!Equals(unlockType, _craftUnlockEnumValue))
                return null;

            var id = _techUnlockIdField.GetValue(techUnlock) as string;
            if (string.IsNullOrEmpty(id))
                return null;

            var balance = _gameBalanceMeProperty.GetValue(null, null);
            if (balance == null)
                return null;

            var craft = _getCraftById.Invoke(balance, new object[] { id });
            var isBlueprint = false;

            if (craft == null && id.IndexOf(':') >= 0)
            {
                craft = _getObjectCraftById.Invoke(balance, new object[] { id });
                isBlueprint = craft != null;
            }

            if (craft == null)
                return null;

            return new TechTooltipContext
            {
                Craft = craft,
                IsBlueprint = isBlueprint
            };
        }

        internal static bool HasAggregateCraftLocation(object itemDefinition)
        {
            var details =
                _itemDefinitionGetItemDetails.Invoke(itemDefinition, null);

            if (details == null)
                return false;

            var craftsIn =
                _itemDetailsCraftsInField.GetValue(details) as IList;

            return craftsIn != null && craftsIn.Count > 0;
        }

        internal static void AppendDetails(
            object tooltip,
            TechTooltipContext context)
        {
            if (tooltip == null || context == null || context.Craft == null)
                return;

            var ingredients = FormatNeeds(
                _needsField.GetValue(context.Craft) as IList);

            if (!string.IsNullOrEmpty(ingredients))
            {
                var ingredientsLabel = LocalizeRequired("ingredients");
                var colon = LocalizeRequired(":");

                AddTinyLeftText(
                    tooltip,
                    ingredientsLabel + colon + " " + ingredients);
            }

            var locationIds = context.IsBlueprint
                ? _builderIdsField.GetValue(context.Craft) as IList
                : _craftInField.GetValue(context.Craft) as IList;

            var locations = FormatLocalizedIds(locationIds);
            if (!string.IsNullOrEmpty(locations))
            {
                AddTinyLeftText(
                    tooltip,
                    LocalizeRequired("crafted_at") + " " + locations);
            }
        }

        private static string FormatNeeds(IList items)
        {
            if (items == null || items.Count == 0)
                return null;

            var names = new string[items.Count];

            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item == null || !_itemType.IsInstanceOfType(item))
                    return null;

                string name;
                try
                {
                    name = _itemGetItemName.Invoke(item, null) as string;
                }
                catch
                {
                    return null;
                }

                if (string.IsNullOrEmpty(name))
                    return null;

                names[i] = name;
            }

            return string.Join(GetCommaSeparator(), names);
        }

        private static string FormatLocalizedIds(IList ids)
        {
            if (ids == null || ids.Count == 0)
                return null;

            var names = new string[ids.Count];

            for (var i = 0; i < ids.Count; i++)
            {
                var id = ids[i] as string;
                if (string.IsNullOrEmpty(id))
                    return null;

                var localized = LocalizeRequired(id);
                if (string.Equals(localized, id, StringComparison.Ordinal))
                    return null;

                names[i] = localized;
            }

            return string.Join(GetCommaSeparator(), names);
        }

        private static string GetCommaSeparator()
        {
            var localized = Localize(",");
            return string.IsNullOrEmpty(localized) ? ", " : localized;
        }

        private static string LocalizeRequired(string key)
        {
            var value = Localize(key);
            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException(
                    "Localization returned an empty value for key '" + key + "'.");

            return value;
        }

        private static string Localize(string key)
        {
            return _gjlLString.Invoke(null, new object[] { key }) as string;
        }

        private static void AddTinyLeftText(object tooltip, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            var data = _textDataCtor.Invoke(
                new[] { (object)text, _tinyDescriptionStyle, _leftAlignment, -1 });

            _tooltipAddData.Invoke(tooltip, new[] { data });
        }

        private static Type RequireType(string name)
        {
            var type = AccessTools.TypeByName(name);
            if (type == null)
                throw new TypeLoadException(name + " was not found.");

            return type;
        }

        private static FieldInfo RequireField(Type type, string name)
        {
            var field = type.GetField(name, AllInstance);
            if (field == null)
                throw new MissingFieldException(type.FullName, name);

            return field;
        }

        private static MethodInfo RequireMethod(
            Type type,
            string name,
            BindingFlags flags,
            Type[] parameters)
        {
            var method = type.GetMethod(
                name,
                flags,
                null,
                parameters,
                null);

            if (method == null)
            {
                throw new MissingMethodException(
                    type.FullName,
                    name + "("
                    + string.Join(
                        ", ",
                        parameters.Select(p => p == null ? "<null>" : p.Name))
                    + ")");
            }

            return method;
        }
    }
}
