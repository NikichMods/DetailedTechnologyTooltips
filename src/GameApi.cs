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
        public string CraftDescriptionRow;
        public string SparseDescriptionRow;
        public string[] ExtraCraftRows;
        public string OverrideName;
        public bool CorrectBigGuyStats;
        public bool SeparateDescriptionRow;
    }

    internal sealed class TechTooltipPresentationOverride
    {
        public object Data;
        public string OriginalName;
        public string OriginalDescription;
        public bool NameChanged;
        public bool DescriptionChanged;
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
        private static MethodInfo _techUnlockGetData;
        private static FieldInfo _techUnlockDataNameField;
        private static FieldInfo _techUnlockDataDescriptionField;
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
        private static FieldInfo _outObjField;
        private static FieldInfo _buildTypeField;
        private static FieldInfo _techsDataField;
        private static FieldInfo _objectCraftDataField;
        private static FieldInfo _techCraftsField;
        private static FieldInfo _mainGameMeField;
        private static FieldInfo _mainGameSaveField;
        private static MethodInfo _isCraftVisible;

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
            var techDefinitionType = RequireType("TechDefinition");
            var gameBalanceType = RequireType("GameBalance");
            var gameBalanceBaseType = RequireType("GameBalanceBase");
            var mainGameType = RequireType("MainGame");
            var gameSaveType = RequireType("GameSave");
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
            _techUnlockGetData = RequireMethod(
                techUnlockType,
                "GetData",
                AllInstance,
                Type.EmptyTypes);

            var techUnlockDataType = techUnlockType.GetNestedType(
                "TechUnlockData",
                BindingFlags.Public | BindingFlags.NonPublic);
            if (techUnlockDataType == null)
                throw new TypeLoadException("TechUnlock.TechUnlockData was not found.");

            _techUnlockDataNameField = RequireField(techUnlockDataType, "name");
            _techUnlockDataDescriptionField =
                RequireField(techUnlockDataType, "description");

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
            _outObjField =
                RequireField(objectCraftDefinitionType, "out_obj");
            _buildTypeField =
                RequireField(objectCraftDefinitionType, "build_type");
            _techsDataField =
                RequireField(gameBalanceType, "techs_data");
            _objectCraftDataField =
                RequireField(gameBalanceType, "craft_obj_data");
            _techCraftsField =
                RequireField(techDefinitionType, "crafts");
            _mainGameMeField =
                RequireField(mainGameType, "me");
            _mainGameSaveField =
                RequireField(mainGameType, "save");
            _isCraftVisible = RequireMethod(
                gameSaveType,
                "IsCraftVisible",
                AllInstance,
                new[] { craftDefinitionType });

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
                var isWork = Equals(unlockType, _workUnlockEnumValue);
                var description = BuildUnlockDescription(id, isWork);
                var correctBigGuy =
                    !isWork
                    && string.Equals(id, "p_big_guy", StringComparison.Ordinal);

                if (string.IsNullOrEmpty(description) && !correctBigGuy)
                    return null;

                return new TechTooltipContext
                {
                    SparseDescriptionRow = description,
                    CorrectBigGuyStats = correctBigGuy,
                    SeparateDescriptionRow =
                        ShouldSeparateUnlockDescription(id, isWork)
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

            var growthContext = BuildGrowthCraftContext(id, craft);
            if (growthContext != null)
                return growthContext;

            return new TechTooltipContext
            {
                Craft = craft,
                IsBlueprint = isBlueprint,
                IngredientsRow = BuildIngredientsRow(craft),
                LocationRow = BuildLocationRow(
                    balance,
                    craft,
                    isBlueprint,
                    id),
                CraftDescriptionRow = BuildCraftDescription(id)
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
            {
                var description = context.SeparateDescriptionRow
                    ? "\n" + context.SparseDescriptionRow
                    : context.SparseDescriptionRow;
                AddTinyLeftText(tooltip, description);
            }

            if (context.Craft == null)
                return;

            if (!string.IsNullOrEmpty(context.CraftDescriptionRow))
                AddTinyCenteredText(tooltip, context.CraftDescriptionRow, false);

            if (!string.IsNullOrEmpty(context.IngredientsRow))
                AddTinyCenteredText(tooltip, context.IngredientsRow, true);

            if (!string.IsNullOrEmpty(context.LocationRow))
                AddTinyCenteredText(tooltip, context.LocationRow, false);

            if (context.ExtraCraftRows != null)
            {
                foreach (var row in context.ExtraCraftRows)
                {
                    if (!string.IsNullOrEmpty(row))
                        AddTinyCenteredText(tooltip, row, false);
                }
            }
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
            object balance,
            object craft,
            bool isBlueprint,
            string craftId)
        {
            var locationIds = isBlueprint
                ? BuildBlueprintLocationIds(
                    balance,
                    craft,
                    craftId)
                : _craftInField.GetValue(craft) as IList;

            var locations = FormatLocalizedIds(
                locationIds,
                isBlueprint);
            if (string.IsNullOrEmpty(locations))
                return null;

            var prefix =
                isBlueprint ? GetBuildMenuPrefix() : GetCraftedAtPrefix();
            if (string.IsNullOrEmpty(prefix))
                return null;

            return prefix + locations;
        }

        // The Technology owns hidden sibling blueprints that purchase together;
        // separately gated aliases are included only after vanilla exposes them.
        private static IList BuildBlueprintLocationIds(
            object balance,
            object visibleCraft,
            string visibleCraftId)
        {
            var result = new System.Collections.Generic.List<string>();
            AppendBuilderIds(result, visibleCraft);

            if (balance == null
                || visibleCraft == null
                || string.IsNullOrEmpty(visibleCraftId))
            {
                return result;
            }

            var outObj = _outObjField.GetValue(visibleCraft) as string;
            var buildType = _buildTypeField.GetValue(visibleCraft);
            if (string.IsNullOrEmpty(outObj) || buildType == null)
                return result;

            var techs = _techsDataField.GetValue(balance) as IList;
            if (techs != null)
            {
                foreach (var tech in techs)
                {
                    var authoredCrafts =
                        _techCraftsField.GetValue(tech) as IList;
                    if (!ContainsAuthoredCraft(
                            authoredCrafts,
                            visibleCraftId))
                    {
                        continue;
                    }

                    foreach (var authored in authoredCrafts)
                    {
                        var siblingId = StripHiddenUnlockPrefix(
                            authored as string);
                        if (string.IsNullOrEmpty(siblingId))
                            continue;

                        var sibling = _getObjectCraftById.Invoke(
                            balance,
                            new object[] { siblingId });

                        if (IsSameBlueprintVariant(
                                visibleCraft,
                                sibling,
                                outObj,
                                buildType))
                        {
                            AppendBuilderIds(result, sibling);
                        }
                    }
                }
            }

            var objectCrafts =
                _objectCraftDataField.GetValue(balance) as IList;
            if (objectCrafts != null)
            {
                foreach (var candidate in objectCrafts)
                {
                    if (!IsSameBlueprintVariant(
                            visibleCraft,
                            candidate,
                            outObj,
                            buildType))
                    {
                        continue;
                    }

                    if (IsCraftVisibleNow(candidate))
                        AppendBuilderIds(result, candidate);
                }
            }

            return result;
        }

        private static bool ContainsAuthoredCraft(
            IList authoredCrafts,
            string craftId)
        {
            if (authoredCrafts == null
                || string.IsNullOrEmpty(craftId))
            {
                return false;
            }

            foreach (var authored in authoredCrafts)
            {
                if (string.Equals(
                        StripHiddenUnlockPrefix(authored as string),
                        craftId,
                        StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSameBlueprintVariant(
            object visibleCraft,
            object candidate,
            string outObj,
            object buildType)
        {
            if (candidate == null)
                return false;

            if (ReferenceEquals(visibleCraft, candidate))
                return true;

            return string.Equals(
                    _outObjField.GetValue(candidate) as string,
                    outObj,
                    StringComparison.Ordinal)
                && Equals(
                    _buildTypeField.GetValue(candidate),
                    buildType);
        }

        private static void AppendBuilderIds(
            System.Collections.Generic.List<string> result,
            object craft)
        {
            if (result == null || craft == null)
                return;

            var builders =
                _builderIdsField.GetValue(craft) as IList;
            if (builders == null)
                return;

            foreach (var value in builders)
            {
                var id = value as string;
                if (!string.IsNullOrEmpty(id)
                    && !result.Contains(id))
                {
                    result.Add(id);
                }
            }
        }

        private static string StripHiddenUnlockPrefix(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return id[0] == '@'
                ? id.Substring(1)
                : id;
        }

        private static bool IsCraftVisibleNow(object craft)
        {
            try
            {
                var mainGame = _mainGameMeField.GetValue(null);
                if (mainGame == null)
                    return false;

                var save = _mainGameSaveField.GetValue(mainGame);
                if (save == null)
                    return false;

                var result = _isCraftVisible.Invoke(
                    save,
                    new[] { craft });

                return result is bool && (bool)result;
            }
            catch
            {
                return false;
            }
        }

        private static string BuildCraftDescription(string id)
        {
            var language = GetCurrentLanguage();
            string key = null;

            switch (id)
            {
                case "fake_global_craft":
                    key = Localization.RemoteControl;
                    break;
                case "peat_from_waste":
                    key = Localization.PeatEffect;
                    break;
                case "sack_clock_silver":
                    key = Localization.BoostFertilizerI;
                    break;
                case "sack_clock_gold":
                    key = Localization.BoostFertilizerII;
                    break;
                case "sack_star_silver":
                    key = Localization.QualityFertilizerI;
                    break;
                case "sack_star_gold":
                    key = Localization.QualityFertilizerII;
                    break;
            }

            return string.IsNullOrEmpty(key)
                ? null
                : Localization.Get(key, language);
        }

        private static string BuildUnlockDescription(
            string id,
            bool isWork)
        {
            var language = GetCurrentLanguage();
            string key = null;

            if (isWork)
            {
                switch (id)
                {
                    case "t_diamond":
                        key = Localization.Diamonds;
                        break;
                    case "t_marble":
                        key = Localization.Marble;
                        break;
                    case "t_mushroom2":
                        key = Localization.SuperMushroom;
                        break;
                }
            }
            else
            {
                switch (id)
                {
                    case "p_t_gold_ore":
                    case "p_t_silver_ore":
                        key = Localization.IronOreBonus;
                        break;

                    case "p_t_lifestone":
                    case "p_t_sulfur":
                        key = Localization.CoalBonus;
                        break;

                    case "p_t_beeswax":
                    case "p_t_bee":
                        key = Localization.HoneyBonus;
                        break;

                    case "p_t_butterfly":
                        key = Localization.Butterfly;
                        break;

                    case "p_t_moth":
                        key = Localization.Moth;
                        break;

                    case "p_t_maggot":
                        key = Localization.Maggot;
                        break;

                    case "p_t_pyrite":
                        return BuildPyriteDescription(id, language);

                    case "p_jevelery":
                        key = Localization.Jeweler;
                        break;
                    case "p_wine_master":
                        key = Localization.WineMaster;
                        break;
                    case "p_writer":
                        key = Localization.Writer;
                        break;
                    case "p_good_writer":
                        key = Localization.Playwright;
                        break;
                    case "p_industriousness":
                        key = Localization.Industriousness;
                        break;
                    case "p_engineer":
                        key = Localization.Engineer;
                        break;
                    case "p_sword_master":
                        key = Localization.SwordMaster;
                        break;
                    case "p_persistence":
                        key = Localization.Persistence;
                        break;
                    case "p_butcher":
                        key = Localization.Butcher;
                        break;
                    case "p_blacksmith":
                        key = Localization.Blacksmith;
                        break;
                    case "p_doctor":
                        return BuildDoctorDescription(language);

                    // Intentionally excluded:
                    // p_t_old_books — no proved consumer in the accepted audit.
                }
            }

            return string.IsNullOrEmpty(key)
                ? null
                : Localization.Get(key, language);
        }

        private static string BuildPyriteDescription(
            string id,
            string language)
        {
            var nativeName = Localize(id);
            if (string.IsNullOrEmpty(nativeName)
                || string.Equals(nativeName, id, StringComparison.Ordinal))
            {
                return null;
            }

            return Localization.Format(
                Localization.PyriteNote,
                language,
                nativeName);
        }

        private static bool ShouldSeparateUnlockDescription(
            string id,
            bool isWork)
        {
            if (isWork)
            {
                return string.Equals(
                    id,
                    "t_mushroom2",
                    StringComparison.Ordinal);
            }

            switch (id)
            {
                case "p_jevelery":
                case "p_wine_master":
                case "p_writer":
                case "p_good_writer":
                case "p_industriousness":
                case "p_engineer":
                case "p_sword_master":
                case "p_persistence":
                case "p_butcher":
                case "p_doctor":
                case "p_blacksmith":
                    return true;
                default:
                    return false;
            }
        }

        private static string BuildDoctorDescription(string language)
        {
            var table1 = LocalizeWithFallback(
                "mf_preparation_1",
                Localization.PreparationPlace);
            var table2 = LocalizeWithFallback(
                "mf_preparation_2",
                Localization.PreparationPlaceII);

            if (string.IsNullOrEmpty(table1) || string.IsNullOrEmpty(table2))
                return null;

            if (!table1.EndsWith(" I", StringComparison.Ordinal))
                table1 += " I";

            return Localization.Format(
                Localization.Doctor,
                language,
                table1,
                table2);
        }

        private static TechTooltipContext BuildGrowthCraftContext(
            string id,
            object craft)
        {
            string seedId;
            string cropId;
            string vendorNativeId;
            string vendorFallbackKey;

            if (string.Equals(
                id,
                "garden_grapes_growing",
                StringComparison.Ordinal))
            {
                seedId = "grapes_seed:1";
                cropId = "fruit:grapes_crop:1";
                vendorNativeId = "npc_merchant";
                vendorFallbackKey = Localization.Merchant;
            }
            else if (string.Equals(
                id,
                "garden_hop_growing",
                StringComparison.Ordinal))
            {
                seedId = "hop_seed:1";
                cropId = "hop_crop:1";
                vendorNativeId = "npc_miller";
                vendorFallbackKey = Localization.Miller;
            }
            else
            {
                return null;
            }

            var language = GetCurrentLanguage();
            var cropName = GetItemDisplayNameById(cropId);
            var seedName = GetItemDisplayNameById(seedId);
            var growingPrefix =
                Localization.Get(Localization.GrowingPrefix, language);
            var grownAtPrefix =
                Localization.Get(Localization.GrownAtPrefix, language);
            var seedsPrefix =
                Localization.Get(Localization.SeedsPrefix, language);
            var vineyard =
                Localization.Get(Localization.Vineyard, language);
            var trellis = LocalizeWithFallback(
                "vineyard_grapes_stick",
                Localization.VineTrellis);
            var vendor = LocalizeWithFallback(
                vendorNativeId,
                vendorFallbackKey);

            if (string.IsNullOrEmpty(cropName)
                || string.IsNullOrEmpty(seedName)
                || string.IsNullOrEmpty(growingPrefix)
                || string.IsNullOrEmpty(grownAtPrefix)
                || string.IsNullOrEmpty(seedsPrefix)
                || string.IsNullOrEmpty(vineyard)
                || string.IsNullOrEmpty(trellis)
                || string.IsNullOrEmpty(vendor))
            {
                return null;
            }

            return new TechTooltipContext
            {
                Craft = craft,
                IsBlueprint = false,
                OverrideName = growingPrefix + cropName,
                IngredientsRow =
                    GetRequirementsPrefix() + seedName + " (x4)",
                LocationRow =
                    grownAtPrefix + vineyard + " — " + trellis,
                ExtraCraftRows = new[]
                {
                    seedsPrefix + vendor
                }
            };
        }

        private static string GetItemDisplayNameById(string id)
        {
            var balance = _gameBalanceMeProperty.GetValue(null, null);
            if (balance == null)
                return null;

            var definition =
                _getItemDefinitionById.Invoke(
                    balance,
                    new object[] { id });
            if (definition == null)
                return null;

            var name =
                _itemDefinitionGetItemName.Invoke(
                    definition,
                    new object[] { true }) as string;

            return string.IsNullOrEmpty(name) ? null : name;
        }

        private static string LocalizeWithFallback(
            string nativeId,
            string fallbackKey)
        {
            var native = Localize(nativeId);
            if (!string.IsNullOrEmpty(native)
                && !string.Equals(native, nativeId, StringComparison.Ordinal))
            {
                return native;
            }

            return Localization.Get(
                fallbackKey,
                GetCurrentLanguage());
        }

        internal static TechTooltipPresentationOverride ApplyPresentationOverride(
            object techUnlock,
            TechTooltipContext context)
        {
            if (techUnlock == null || context == null)
                return null;

            if (string.IsNullOrEmpty(context.OverrideName)
                && !context.CorrectBigGuyStats)
            {
                return null;
            }

            var data = _techUnlockGetData.Invoke(techUnlock, null);
            if (data == null)
                return null;

            var state = new TechTooltipPresentationOverride
            {
                Data = data
            };

            if (!string.IsNullOrEmpty(context.OverrideName))
            {
                state.OriginalName =
                    _techUnlockDataNameField.GetValue(data) as string;
                _techUnlockDataNameField.SetValue(
                    data,
                    context.OverrideName);
                state.NameChanged = true;
            }

            if (context.CorrectBigGuyStats)
            {
                var original =
                    _techUnlockDataDescriptionField.GetValue(data) as string;
                var corrected = TextFormatting.CorrectBigGuyDescription(original);

                if (!string.IsNullOrEmpty(corrected))
                {
                    state.OriginalDescription = original;
                    _techUnlockDataDescriptionField.SetValue(data, corrected);
                    state.DescriptionChanged = true;
                }
            }

            return state.NameChanged || state.DescriptionChanged
                ? state
                : null;
        }

        internal static void RestorePresentationOverride(
            TechTooltipPresentationOverride state)
        {
            if (state == null || state.Data == null)
                return;

            if (state.NameChanged)
            {
                _techUnlockDataNameField.SetValue(
                    state.Data,
                    state.OriginalName);
            }

            if (state.DescriptionChanged)
            {
                _techUnlockDataDescriptionField.SetValue(
                    state.Data,
                    state.OriginalDescription);
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

        private static string FormatLocalizedIds(
            IList ids,
            bool allowBlueprintLocationOverride)
        {
            if (ids == null || ids.Count == 0)
                return null;

            var names = new string[ids.Count];
            var language = GetCurrentLanguage();

            for (var i = 0; i < ids.Count; i++)
            {
                var id = ids[i] as string;
                if (string.IsNullOrEmpty(id))
                    return null;

                var localized = allowBlueprintLocationOverride
                    ? Localization.GetBlueprintBuilderOverride(id, language)
                    : null;

                if (string.IsNullOrEmpty(localized))
                    localized = LocalizeRequired(id);

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
            return Localization.Get(
                Localization.BuildMenu,
                GetCurrentLanguage());
        }

        private static string GetListSeparator()
        {
            return Localization.FormatListSeparator(
                GetCurrentLanguage(),
                Localize(","));
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
            AddTinyText(tooltip, text, _leftAlignment, false);
        }

        private static void AddTinyCenteredText(
            object tooltip,
            string text,
            bool protectQuantityTokens)
        {
            AddTinyText(
                tooltip,
                text,
                _centerAlignment,
                protectQuantityTokens);
        }

        private static void AddTinyText(
            object tooltip,
            string text,
            object alignment,
            bool protectQuantityTokens)
        {
            if (string.IsNullOrEmpty(text))
                return;

            var data = _textDataCtor.Invoke(
                new[] { (object)text, _tinyDescriptionStyle, alignment, -1 });

            if (protectQuantityTokens)
                TechnologyTextWrapRepair.Mark(data);

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
