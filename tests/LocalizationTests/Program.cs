// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DetailedTechnologyTooltips;

internal static class Program
{
    private static int Main()
    {
        foreach (var language in Localization.SupportedLanguages)
        {
            foreach (var key in Localization.Keys)
            {
                var value = Localization.Get(key, language);
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.Error.WriteLine(
                        "Missing localization: language=" + language + " key=" + key);
                    return 1;
                }

                if (value.Contains(@"\n"))
                {
                    Console.Error.WriteLine(
                        "Literal newline escape leaked into localization: language="
                        + language + " key=" + key);
                    return 1;
                }
            }
        }

        if (Localization.Get(Localization.BuildMenu, "pt_br") !=
            Localization.Get(Localization.BuildMenu, "pt-br"))
        {
            Console.Error.WriteLine("pt-BR normalization failed.");
            return 1;
        }

        if (Localization.Get(Localization.BuildMenu, "zh-cn") !=
            Localization.Get(Localization.BuildMenu, "zh_cn"))
        {
            Console.Error.WriteLine("zh-CN normalization failed.");
            return 1;
        }

        if (Localization.Get(Localization.BuildMenu, "unknown") != null)
        {
            Console.Error.WriteLine("Unknown language must fail closed.");
            return 1;
        }

        foreach (var language in Localization.SupportedLanguages)
        {
            var formatted = Localization.Format(
                Localization.Doctor,
                language,
                "TABLE_ONE",
                "TABLE_TWO");

            if (string.IsNullOrEmpty(formatted)
                || formatted.IndexOf("{0}", StringComparison.Ordinal) >= 0
                || formatted.IndexOf("{1}", StringComparison.Ordinal) >= 0
                || formatted.IndexOf("→", StringComparison.Ordinal) >= 0
                || (!string.Equals(language, "ru", StringComparison.Ordinal)
                    && (formatted.IndexOf(
                            "TABLE_ONE",
                            StringComparison.Ordinal) < 0
                        || formatted.IndexOf(
                            "TABLE_TWO",
                            StringComparison.Ordinal) < 0)))
            {
                Console.Error.WriteLine(
                    "Doctor localization formatting failed: language=" + language);
                return 1;
            }

            var butcher = Localization.Get(Localization.Butcher, language);
            if (string.IsNullOrEmpty(butcher)
                || butcher.IndexOf("→", StringComparison.Ordinal) >= 0)
            {
                Console.Error.WriteLine(
                    "Butcher natural-language decrease wording failed: language="
                    + language);
                return 1;
            }

            if (Localization.Get("cultist", language) != null)
            {
                Console.Error.WriteLine(
                    "Cultist must remain fully vanilla: language=" + language);
                return 1;
            }

            var alchemyLab =
                Localization.Get(Localization.AlchemyLab, language);
            if (string.IsNullOrEmpty(alchemyLab)
                || Localization.GetBlueprintBuilderOverride(
                    "alchemy_builddesk",
                    language) != alchemyLab
                || Localization.GetBlueprintBuilderOverride(
                    "morgue_builddesk",
                    language) != null)
            {
                Console.Error.WriteLine(
                    "Alchemy Lab builder-location override failed: language="
                    + language);
                return 1;
            }

            var pyrite = Localization.Format(
                Localization.PyriteNote,
                language,
                "NATIVE_PYRITE_NAME");

            if (string.IsNullOrEmpty(pyrite)
                || pyrite.IndexOf(
                    "NATIVE_PYRITE_NAME",
                    StringComparison.Ordinal) < 0
                || pyrite.IndexOf("{0}", StringComparison.Ordinal) >= 0
                || HasQuoteMark(pyrite))
            {
                Console.Error.WriteLine(
                    "Pyrite native-name formatting failed: language=" + language);
                return 1;
            }
        }

        var russianDoctor = Localization.Format(
            Localization.Doctor,
            "ru",
            "IGNORED_TABLE_ONE",
            "IGNORED_TABLE_TWO");
        if (russianDoctor !=
            "На препарационном столе I шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25%. На препарационном столе II — с 25% до 0%.")
        {
            Console.Error.WriteLine(
                "Russian Doctor wording regression.");
            return 1;
        }

        var russianPyrite = Localization.Format(
            Localization.PyriteNote,
            "ru",
            "Серный колчедан");
        if (russianPyrite !=
            "Примечание: в текущей версии игры эта технология не позволяет получать Серный колчедан.")
        {
            Console.Error.WriteLine(
                "Russian Pyrite technical-note wording regression.");
            return 1;
        }

        if (Localization.GetBlueprintBuilderOverride(
                "alchemy_builddesk",
                "ru") != "Алхимическая лаборатория")
        {
            Console.Error.WriteLine(
                "Russian Alchemy Lab location wording regression.");
            return 1;
        }

        var russianQualityI =
            Localization.Get(Localization.QualityFertilizerI, "ru");
        var russianQualityII =
            Localization.Get(Localization.QualityFertilizerII, "ru");
        if (russianQualityI !=
                "Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше."
            || russianQualityII !=
                "Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 2 единицы урожая и 2 семени на одну ступень качества выше.")
        {
            Console.Error.WriteLine(
                "Russian Quality fertilizer wording regression.");
            return 1;
        }

        const string bigGuyVanilla =
            "Heavy work made you bigger and stronger. +1 damage, +1 defense.";
        var bigGuyCorrected =
            TextFormatting.CorrectBigGuyDescription(bigGuyVanilla);
        if (bigGuyCorrected !=
            "Heavy work made you bigger and stronger. +2 damage, +2 defense.")
        {
            Console.Error.WriteLine("Big Guy stat correction failed.");
            return 1;
        }

        if (TextFormatting.CorrectBigGuyDescription(
                "Unexpected +1 damage only.") != null
            || TextFormatting.CorrectBigGuyDescription(
                "Unexpected +1 damage, +1 defense, +1 extra.") != null
            || TextFormatting.CorrectBigGuyDescription(
                "Do not touch +10 damage and +1 defense.") != null
            || TextFormatting.CorrectBigGuyDescription(
                "Do not touch +1.5 damage and +1 defense.") != null)
        {
            Console.Error.WriteLine(
                "Big Guy stat correction must fail closed on unexpected text.");
            return 1;
        }

        if (Localization.FormatListSeparator("de", ",") != ", "
            || Localization.FormatListSeparator("it", ",") != ", "
            || Localization.FormatListSeparator("ko", ",") != ", "
            || Localization.FormatListSeparator("en", ", ") != ", ")
        {
            Console.Error.WriteLine("Latin/Korean list spacing normalization failed.");
            return 1;
        }

        if (Localization.FormatListSeparator("ja", "、") != "、\u200B"
            || Localization.FormatListSeparator("zh_cn", "，") != "，\u200B")
        {
            Console.Error.WriteLine("CJK separator break-opportunity formatting failed.");
            return 1;
        }

        if (Localization.FormatListSeparator("de", ",").IndexOf('\u200B') >= 0
            || Localization.FormatListSeparator("ko", ",").IndexOf('\u200B') >= 0)
        {
            Console.Error.WriteLine("Zero-width CJK break opportunity leaked into non-CJK formatting.");
            return 1;
        }

        var rawQuantity =
            "原料：一块磨光的石头 (x4)，简单的铁件 (x4)";
        var processedQuantity =
            "原料：一块磨光的石头 (x4\n)，简单的铁件 (x4)";
        var repairedQuantity =
            TextFormatting.RepairBrokenQuantityTokens(
                rawQuantity,
                processedQuantity);
        if (repairedQuantity !=
            "原料：一块磨光的石头\n(x4)，简单的铁件 (x4)")
        {
            Console.Error.WriteLine("Broken quantity-token repair failed.");
            return 1;
        }

        var secondBroken =
            TextFormatting.RepairBrokenQuantityTokens(
                rawQuantity,
                "原料：一块磨光的石头 (x4)，简单的铁件 (x4\n)");
        if (secondBroken !=
            "原料：一块磨光的石头 (x4)，简单的铁件\n(x4)")
        {
            Console.Error.WriteLine("Repeated quantity-token ordinal mapping failed.");
            return 1;
        }

        if (TextFormatting.RepairBrokenQuantityTokens(
                rawQuantity,
                rawQuantity) != rawQuantity)
        {
            Console.Error.WriteLine("Intact quantity text must remain unchanged.");
            return 1;
        }

        if (LayoutPolicy.Width(180, 800) != 184 || LayoutPolicy.Width(330.2f, 800) != 335
            || LayoutPolicy.Width(450, 320) != 320 || LayoutPolicy.Width(80, 250) != 150)
            throw new Exception("Material-width floor/ceil/viewport policy regression");
        // Compare physical row edges, independently of native table/pivot placement.
        foreach (float pivot in new[] { 0f, 0.5f, 1f })
        {
            float x = LayoutPolicy.RowX(-100, 100, 200, pivot, 150, false);
            if (x - pivot * 200 != -100 || x + (1 - pivot) * 200 != 100)
                throw new Exception("Row must occupy the bubble span for every native pivot");
            x = LayoutPolicy.RowX(-100, 100, 200, pivot, 150, true);
            if (x - pivot * 200 != -75)
                throw new Exception("Material block must center its shared150-unit content span");
        }
        if (LayoutPolicy.BindQuantity("Простые железные детали (x4)") != "Простые железные детали\u00a0(x4)"
            || LayoutPolicy.BindQuantity("Nails (x8)") != "Nails\u00a0(x8)"
            || LayoutPolicy.BindQuantity("Storage (items)") != "Storage (items)"
            || LayoutPolicy.BindQuantity("Nails\u00a0(x8)") != "Nails\u00a0(x8)")
            throw new Exception("Quantity binding must preserve names/counts and unrelated parentheses");
        Console.WriteLine("Material width/viewport and non-orphan quantity policy validation OK.");

        int purposeCount = 0;
        foreach (var id in BlueprintPurposeCopy.Ids)
        {
            purposeCount++;
            foreach (var language in Localization.SupportedLanguages)
            {
                if (!BlueprintPurposeCopy.SupportsLanguage(language))
                    throw new Exception("Missing supported purpose locale: " + language);
                var purpose = BlueprintPurposeCopy.Get("native_builder:p:" + id + "_place", language);
                var raw = BlueprintPurposeCopy.GetRaw(id, language);
                var en = BlueprintPurposeCopy.GetRaw(id, "en");
                if (string.IsNullOrEmpty(purpose) || purpose.Contains("**")
                    || !purpose.StartsWith("[AA]", StringComparison.Ordinal)
                    || !purpose.EndsWith("[FF]", StringComparison.Ordinal)
                    || CountOccurrences(purpose, "[FF7A70]") != CountOccurrences(purpose, "[-]"))
                    throw new Exception("Invalid blueprint text/markup: " + id + "/" + language);
                if (raw.Contains("{") || raw.Contains("|") || raw.Contains(@"\n") || raw.Contains('\uFFFD')
                    || CountOccurrences(raw, "**") != CountOccurrences(en, "**"))
                    throw new Exception("Unresolved translation/template/emphasis: " + id + "/" + language);
                var symbolPattern = @"\((?:cross|wskull|sci|alc[123])\)";
                var expectedSymbols = new List<string>();
                var actualSymbols = new List<string>();
                foreach (Match match in Regex.Matches(en, symbolPattern)) expectedSymbols.Add(match.Value);
                foreach (Match match in Regex.Matches(raw, symbolPattern)) actualSymbols.Add(match.Value);
                expectedSymbols.Sort(StringComparer.Ordinal); actualSymbols.Sort(StringComparer.Ordinal);
                if (string.Join(",", expectedSymbols) != string.Join(",", actualSymbols))
                    throw new Exception("Translated effect-symbol mismatch: " + id + "/" + language);
                var parts = raw.Split(new[] { "**" }, StringSplitOptions.None);
                for (int i = 1; i < parts.Length; i += 2)
                    if (Regex.IsMatch(parts[i], symbolPattern))
                        throw new Exception("Native metric icon inside red accent: " + id + "/" + language);
                if ((en.StartsWith("(cross)", StringComparison.Ordinal) || en.StartsWith("(wskull)", StringComparison.Ordinal))
                    && Regex.Match(raw, @"\d+").Value != Regex.Match(en, @"\d+").Value)
                    throw new Exception("Translated numeric quality effect changed: " + id + "/" + language);
                if (language != "en" && language != "ru" && raw == en)
                    throw new Exception("English fallback in translated purpose: " + id + "/" + language);
            }
            foreach (var unknown in new[] { "", "unknown", "pt", "zh_tw" })
                if (BlueprintPurposeCopy.Get(id, unknown) != null || BlueprintPurposeCopy.SupportsLanguage(unknown))
                    throw new Exception("Unknown locale must retain native fallback");
            if (BlueprintPurposeCopy.Get(id, "en-US") != BlueprintPurposeCopy.Get(id, "en")
                || BlueprintPurposeCopy.Get(id, "ru_RU") != BlueprintPurposeCopy.Get(id, "ru")
                || BlueprintPurposeCopy.Get(id, "pt_br") != BlueprintPurposeCopy.Get(id, "pt-br")
                || BlueprintPurposeCopy.Get(id, "zh-CN") != BlueprintPurposeCopy.Get(id, "zh_cn"))
                throw new Exception("Purpose language alias regression");
        }
        if (purposeCount != 104 || BlueprintPurposeCopy.Count != 104 || BlueprintPurposeCopy.Get("unknown", "en") != null
            || BlueprintPurposeCopy.Get("pray:prayer_for_faith", "en") != null
            || BlueprintPurposeCopy.Get("wooden_plank", "en") != null)
            throw new Exception("Blueprint coverage escaped selected scope");
        var seenNative = new HashSet<string>(StringComparer.Ordinal);
        int references = 0;
        foreach (var line in File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "Fixtures", "VisibleBlueprintUnlocks.tsv")))
        {
            if (line.StartsWith("#", StringComparison.Ordinal) || line.Length == 0) continue;
            var cells = line.Split('\t');
            if (cells.Length != 2 || cells[0].StartsWith("@", StringComparison.Ordinal))
                throw new Exception("Invalid visible blueprint fixture");
            references++; seenNative.Add(cells[1]);
            foreach (var language in Localization.SupportedLanguages)
                if (BlueprintPurposeCopy.Get(cells[0], language) != BlueprintPurposeCopy.Get(cells[1], language)
                    || BlueprintPurposeCopy.Get(cells[0], language) == null)
                    throw new Exception("Native unlock does not resolve its catalogue row: " + cells[0]);
        }
        if (references != 105 || seenNative.Count != 104 || !seenNative.SetEquals(BlueprintPurposeCopy.Ids))
            throw new Exception("Catalogue must match the complete native visible blueprint set");
        var seenCatalogue = new HashSet<string>(StringComparer.Ordinal);
        foreach (var line in File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "BlueprintPurposeCatalogue.md")))
        {
            var cells = line.Split('|');
            if (cells.Length != 5) continue;
            var match = Regex.Match(cells[1], "`([^`]+)`");
            if (!match.Success) continue;
            string id = match.Groups[1].Value;
            if (!seenCatalogue.Add(id)) throw new Exception("Duplicate authored purpose: " + id);
            if (BlueprintPurposeCopy.Get(id, "en") != BlueprintPurposeCopy.Render(cells[2].Trim())
                || BlueprintPurposeCopy.Get(id, "ru") != BlueprintPurposeCopy.Render(cells[3].Trim()))
                throw new Exception("Compiled EN/RU text differs from reviewed catalogue: " + id);
        }
        if (!seenCatalogue.SetEquals(seenNative)) throw new Exception("Authored/native blueprint coverage drift");
        if (BlueprintPurposeCopy.NativeDescriptionKey("church_builddesk:p:zombie_crafting_table_place") != "zombie_crafting_table_d"
            || BlueprintPurposeCopy.NativeDescriptionKey("mf_furnace_0") != null)
            throw new Exception("Native purpose reuse escaped resurrection-table scope");
        if (BlueprintPurposeCopy.Get("mf_box_stuff", "en").Contains("FF7A70"))
            throw new Exception("Generic item storage must remain unaccented");
        bool rejected = false;
        try { BlueprintPurposeCopy.Render("broken **accent"); } catch (ArgumentException) { rejected = true; }
        if (!rejected) throw new Exception("Unbalanced emphasis must be rejected");
        foreach (var language in Localization.SupportedLanguages)
        {
            if (BlueprintPurposeCopy.Get("unknown", language) != null
                || BlueprintPurposeCopy.Get("pray:prayer_for_faith", language) != null
                || BlueprintPurposeCopy.Get("wooden_plank", language) != null
                || BlueprintPurposeCopy.Get("mf_box_stuff", language).Contains("FF7A70")
                || BlueprintPurposeCopy.Get("well_pump", language).Contains("FF7A70"))
                throw new Exception("Translated purpose escaped scope/sparse accent policy: " + language);
        }
        if (BlueprintPurposeCopy.Get("mf_alchemy_survey", "en").Contains("(sci)"))
            throw new Exception("Technology points must not acquire the science icon");
        Console.WriteLine("Catalogue/native/compiled parity OK:104 blueprints,105 visible references,11 locales; symbol/emphasis/quality checks pass.");

        Console.WriteLine(
            "Localization/formatting validation OK: "
            + Localization.SupportedLanguages.Length
            + " languages x "
            + Localization.Keys.Length
            + " keys.");
        return 0;
    }

    private static bool HasQuoteMark(string text)
    {
        if (string.IsNullOrEmpty(text))
            return false;

        return text.IndexOf('"') >= 0
            || text.IndexOf('«') >= 0
            || text.IndexOf('»') >= 0
            || text.IndexOf('“') >= 0
            || text.IndexOf('”') >= 0
            || text.IndexOf('「') >= 0
            || text.IndexOf('」') >= 0
            || text.IndexOf('『') >= 0
            || text.IndexOf('』') >= 0
            || text.IndexOf('„') >= 0;
    }

    private static int CountOccurrences(string text, string value)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(value))
            return 0;

        var count = 0;
        var index = 0;
        while ((index = text.IndexOf(
            value,
            index,
            StringComparison.Ordinal)) >= 0)
        {
            count++;
            index += value.Length;
        }

        return count;
    }
}
