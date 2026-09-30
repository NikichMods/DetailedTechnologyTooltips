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
        public string IngredientsRow;
        public string LocationRow;
        public string SparseDescriptionRow;
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
        private static object _workUnlockEnumValue;
        private static object _perkUnlockEnumValue;

        private static PropertyInfo _gameBalanceMeProperty;
        private static MethodInfo _getCraftById;
        private static MethodInfo _getObjectCraftById;
        private static MethodInfo _getItemDefinitionById;
        private static MethodInfo _getItemsOfBaseName;

        private static FieldInfo _needsField;
        private static FieldInfo _craftInField;
        private static FieldInfo _builderIdsField;

        private static FieldInfo _itemIdField;
        private static FieldInfo _itemValueField;
        private static MethodInfo _itemGetItemName;
        private static MethodInfo _itemDefinitionGetItemName;
        private static MethodInfo _itemDefinitionGetItemDetails;
        private static FieldInfo _itemDetailsCraftsInField;

        private static MethodInfo _gjlLString;
        private static MethodInfo _getCurrentLanguage;
        private static MethodInfo _tooltipAddData;
        private static ConstructorInfo _textDataCtor;
        private static object _tinyDescriptionStyle;
        private static object _leftAlignment;
        private static object _centerAlignment;

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
            var gameSettingsType = RequireType("GameSettings");
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
            _workUnlockEnumValue = Enum.Parse(
                _techUnlockTypeField.FieldType,
                "Work",
                false);
            _perkUnlockEnumValue = Enum.Parse(
                _techUnlockTypeField.FieldType,
                "Perk",
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
            _getItemDefinitionById =
                genericGetData.MakeGenericMethod(itemDefinitionType);
            _getItemsOfBaseName = RequireMethod(
                gameBalanceType,
                "GetItemsOfBaseName",
                AllInstance,
                new[] { typeof(string) });

            _needsField = RequireField(craftDefinitionType, "needs");
            _craftInField = RequireField(craftDefinitionType, "craft_in");
            _builderIdsField =
                RequireField(objectCraftDefinitionType, "builder_ids");

            _itemIdField = RequireField(_itemType, "id");
            _itemValueField = RequireField(_itemType, "value");

            _itemGetItemName = RequireMethod(
                _itemType,
                "GetItemName",
                AllInstance,
                Type.EmptyTypes);

            _itemDefinitionGetItemName = RequireMethod(
                itemDefinitionType,
                "GetItemName",
                AllInstance,
                new[] { typeof(bool) });

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

            _getCurrentLanguage = RequireMethod(
                gameSettingsType,
                "GetCurrentLanguage",
                AllStatic,
                Type.EmptyTypes);

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
            _centerAlignment =
                Enum.Parse(alignmentType, "Center", false);
        }

        internal static TechTooltipContext TryCreateContext(object techUnlock)
        {
            if (techUnlock == null)
                return null;

            var unlockType = _techUnlockTypeField.GetValue(techUnlock);
            var id = _techUnlockIdField.GetValue(techUnlock) as string;
            if (string.IsNullOrEmpty(id))
                return null;

            if (Equals(unlockType, _craftUnlockEnumValue))
                return TryCreateCraftContext(id);

            if (Equals(unlockType, _workUnlockEnumValue)
                || Equals(unlockType, _perkUnlockEnumValue))
            {
                var sparseDescription = BuildSparseUnlockDescription(
                    id,
                    Equals(unlockType, _workUnlockEnumValue));

                if (string.IsNullOrEmpty(sparseDescription))
                    return null;

                return new TechTooltipContext
                {
                    SparseDescriptionRow = sparseDescription
                };
            }

            return null;
        }

        private static TechTooltipContext TryCreateCraftContext(string id)
        {
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
                IsBlueprint = isBlueprint,
                IngredientsRow = BuildIngredientsRow(craft),
                LocationRow = BuildLocationRow(craft, isBlueprint)
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
            if (tooltip == null || context == null)
                return;

            if (!string.IsNullOrEmpty(context.SparseDescriptionRow))
                AddTinyLeftText(tooltip, context.SparseDescriptionRow);

            if (context.Craft == null)
                return;

            if (!string.IsNullOrEmpty(context.IngredientsRow))
                AddTinyCenteredText(tooltip, context.IngredientsRow);

            if (!string.IsNullOrEmpty(context.LocationRow))
                AddTinyCenteredText(tooltip, context.LocationRow);
        }

        private static string BuildIngredientsRow(object craft)
        {
            var ingredients = FormatNeeds(
                _needsField.GetValue(craft) as IList);

            if (string.IsNullOrEmpty(ingredients))
                return null;

            return GetRequirementsPrefix() + ingredients;
        }

        private static string BuildLocationRow(
            object craft,
            bool isBlueprint)
        {
            var locationIds = isBlueprint
                ? _builderIdsField.GetValue(craft) as IList
                : _craftInField.GetValue(craft) as IList;

            var locations = FormatLocalizedIds(locationIds);
            if (string.IsNullOrEmpty(locations))
                return null;

            return (isBlueprint ? GetBuildMenuPrefix() : GetCraftedAtPrefix())
                + locations;
        }

        private static string BuildSparseUnlockDescription(
            string id,
            bool isWork)
        {
            var language = GetCurrentLanguage();
            var russian = IsLanguage(language, "ru");
            var english = IsLanguage(language, "en");

            if (!russian && !english)
                return null;

            if (isWork)
            {
                switch (id)
                {
                    case "t_diamond":
                        return russian
                            ? "Теперь можно добывать алмазы."
                            : "Diamonds can now be mined.";
                    case "t_marble":
                        return russian
                            ? "Теперь можно добывать мрамор."
                            : "Marble can now be quarried.";
                    default:
                        return null;
                }
            }

            switch (id)
            {
                case "p_t_gold_ore":
                case "p_t_silver_ore":
                    return russian
                        ? "Теперь может попадаться при добыче и переработке железной руды."
                        : "Can now appear while mining or processing iron ore.";

                case "p_t_lifestone":
                case "p_t_sulfur":
                    return russian
                        ? "Теперь может попадаться при добыче угля."
                        : "Can now appear while mining coal.";

                case "p_t_beeswax":
                case "p_t_bee":
                    return russian
                        ? "Теперь может попадаться при сборе мёда."
                        : "Can now appear while collecting honey.";

                case "p_t_butterfly":
                    return russian
                        ? "Теперь может попадаться при сборе цветов днём."
                        : "Can now appear while gathering flowers during the day.";

                case "p_t_moth":
                    return russian
                        ? "Теперь может попадаться при сборе цветов ночью."
                        : "Can now appear while gathering flowers at night.";

                case "p_t_maggot":
                    return russian
                        ? "Теперь может получаться при переработке отходов в торф."
                        : "Can now be produced when processing waste into peat.";

                case "p_t_pyrite":
                    return russian
                        ? "Примечание: не реализовано в текущей версии игры."
                        : "Note: not implemented in the current game version.";

                // Intentionally excluded:
                // p_t_old_books — no proved consumer in the accepted audit.
                default:
                    return null;
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

                var name = ResolveNeedDisplayName(item);
                if (string.IsNullOrEmpty(name))
                    return null;

                names[i] = name;
            }

            return string.Join(GetListSeparator(), names);
        }

        private static string ResolveNeedDisplayName(object item)
        {
            try
            {
                var direct = _itemGetItemName.Invoke(item, null) as string;
                if (!string.IsNullOrEmpty(direct))
                    return direct;
            }
            catch
            {
                // Vanilla Craft UI has a base-name fallback for group /
                // multi-quality ingredients whose base ID has no ItemDefinition.
            }

            var id = _itemIdField.GetValue(item) as string;
            if (string.IsNullOrEmpty(id))
                return null;

            var balance = _gameBalanceMeProperty.GetValue(null, null);
            if (balance == null)
                return null;

            var variants =
                _getItemsOfBaseName.Invoke(balance, new object[] { id }) as IList;
            if (variants == null || variants.Count == 0)
                return null;

            object definition = null;
            for (var i = 0; i < variants.Count; i++)
            {
                var variantId = variants[i] as string;
                if (string.IsNullOrEmpty(variantId))
                    continue;

                definition =
                    _getItemDefinitionById.Invoke(
                        balance,
                        new object[] { variantId });

                if (definition != null)
                    break;
            }

            if (definition == null)
                return null;

            var name =
                _itemDefinitionGetItemName.Invoke(
                    definition,
                    new object[] { true }) as string;
            if (string.IsNullOrEmpty(name))
                return null;

            var value = Convert.ToInt32(_itemValueField.GetValue(item));
            if (value > 1)
                name += string.Format(" (x{0:0})", value);

            return name;
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

            return string.Join(GetListSeparator(), names);
        }

        private static string GetRequirementsPrefix()
        {
            var language = GetCurrentLanguage();
            if (IsLanguage(language, "ru"))
                return "Нужно: ";
            if (IsLanguage(language, "en"))
                return "Requires: ";

            return LocalizeRequired("ingredients")
                + LocalizeRequired(":")
                + " ";
        }

        private static string GetCraftedAtPrefix()
        {
            var language = GetCurrentLanguage();
            if (IsLanguage(language, "ru"))
                return "Изготовление: ";
            if (IsLanguage(language, "en"))
                return "Crafted at: ";

            return LocalizeRequired("crafted_at") + " ";
        }

        private static string GetBuildMenuPrefix()
        {
            var language = GetCurrentLanguage();
            if (IsLanguage(language, "ru"))
                return "Строительство: ";
            if (IsLanguage(language, "en"))
                return "Build menu: ";

            return LocalizeRequired("crafted_at") + " ";
        }

        private static string GetListSeparator()
        {
            var language = GetCurrentLanguage();
            if (IsLanguage(language, "ru") || IsLanguage(language, "en"))
                return ", ";

            var localized = Localize(",");
            return string.IsNullOrEmpty(localized) ? ", " : localized;
        }

        private static string GetCurrentLanguage()
        {
            try
            {
                var language = _getCurrentLanguage.Invoke(null, null) as string;
                return string.IsNullOrEmpty(language)
                    ? string.Empty
                    : language.Trim().ToLowerInvariant();
            }
            catch
            {
                return string.Empty;
            }
        }

        private static bool IsLanguage(string current, string expected)
        {
            if (string.IsNullOrEmpty(current))
                return false;

            return string.Equals(current, expected, StringComparison.Ordinal)
                || current.StartsWith(expected + "_", StringComparison.Ordinal)
                || current.StartsWith(expected + "-", StringComparison.Ordinal);
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
            AddTinyText(tooltip, text, _leftAlignment);
        }

        private static void AddTinyCenteredText(object tooltip, string text)
        {
            AddTinyText(tooltip, text, _centerAlignment);
        }

        private static void AddTinyText(
            object tooltip,
            string text,
            object alignment)
        {
            if (string.IsNullOrEmpty(text))
                return;

            var data = _textDataCtor.Invoke(
                new[] { (object)text, _tinyDescriptionStyle, alignment, -1 });

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
