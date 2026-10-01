// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
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
                || formatted.IndexOf("TABLE_ONE", StringComparison.Ordinal) < 0
                || formatted.IndexOf("TABLE_TWO", StringComparison.Ordinal) < 0
                || formatted.IndexOf("{0}", StringComparison.Ordinal) >= 0
                || formatted.IndexOf("{1}", StringComparison.Ordinal) >= 0
                || formatted.IndexOf("→", StringComparison.Ordinal) >= 0)
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
