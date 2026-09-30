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

        Console.WriteLine(
            "Localization completeness OK: "
            + Localization.SupportedLanguages.Length
            + " languages x "
            + Localization.Keys.Length
            + " keys.");
        return 0;
    }
}
