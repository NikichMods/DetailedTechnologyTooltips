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
}
