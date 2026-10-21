// SPDX-License-Identifier: MPL-2.0
using System;
using System.Collections.Generic;

namespace DetailedTechnologyTooltips
{
    internal static class PilotPurposeCopy
    {
        // Curated purpose copy only. Costs, names, icons and build menus remain native.
        private static readonly Dictionary<string, string[]> Copy = new Dictionary<string, string[]>(StringComparer.Ordinal)
        {
            { "mf_alchemy_craft_02", new[] { "Lets you make potions from **two ingredients**.", "Служит для приготовления зелий из **двух ингредиентов**." } },
            { "mf_alchemy_craft_03", new[] { "Lets you make potions from **three ingredients**.", "Служит для приготовления зелий из **трёх ингредиентов**." } },
            { "mf_alchemy_stirrer_01", new[] { "Allows you to obtain alchemical **solutions** from materials.", "Позволяет получать алхимические **растворы** из материалов." } },
            { "mf_alchemy_mill", new[] { "Used to grind materials into alchemical **powders**.", "Используется для получения алхимических **порошков** из материалов." } },
            { "mf_distcube_2_clay", new[] { "You can obtain alchemical **extracts** from materials here.", "Здесь можно получать алхимические **экстракты** из материалов." } },
            { "mf_distcube_2_cuprum", new[] { "Allows you to obtain **more extract** from the same raw materials.", "Позволяет получать **больше экстракта** из того же сырья." } },
            { "mf_furnace_0", new[] { "Used to smelt iron and make glass and ceramics.", "Служит для выплавки железа, изготовления стекла и керамики." } },
            { "mf_furnace_1", new[] { "Also allows you to smelt **steel, silver and gold**.", "Дополнительно позволяет выплавлять **сталь, серебро и золото**." } },
            { "mf_furnace_2", new[] { "Adds **steel parts** and yields more graphite from the same coal.", "Дополнительно позволяет делать **стальные детали**. Больше графита из того же угля." } },
            { "candelabrum_1", new[] { "**+1 church quality**. Candles increase the bonus.", "**+1 к качеству церкви**. Свечи усиливают эффект." } },
            { "candelabrum_2", new[] { "**+2 church quality**. Candles increase the bonus.", "**+2 к качеству церкви**. Свечи усиливают эффект." } },
            { "candelabrum_3", new[] { "**+3 church quality**. Candles increase the bonus.", "**+3 к качеству церкви**. Свечи усиливают эффект." } },
            { "mf_box_stuff", new[] { "Storage for items.", "Место для хранения предметов." } }
        };
        internal static IEnumerable<string> Ids { get { return Copy.Keys; } }
        internal static string Get(string unlockId, string language)
        {
            if (string.IsNullOrEmpty(unlockId) || string.IsNullOrEmpty(language)) return null;
            language = language.Trim().ToLowerInvariant().Replace('-', '_').Split('_')[0];
            if (language != "en" && language != "ru") return null;
            var id = unlockId.Substring(unlockId.LastIndexOf(':') + 1);
            if (id.EndsWith("_place", StringComparison.Ordinal)) id = id.Substring(0, id.Length - 6);
            string[] pair;
            return Copy.TryGetValue(id, out pair) ? Render(pair[language == "ru" ? 1 : 0]) : null;
        }
        internal static string Render(string text)
        {
            var pieces = text.Split(new[] { "**" }, StringSplitOptions.None);
            if (pieces.Length % 2 == 0) throw new ArgumentException("Unbalanced pilot emphasis");
            var result = "[AA]";
            for (int i = 0; i < pieces.Length; i++)
                result += (i % 2 == 1 ? "[FF][FF7A70]" + pieces[i] + "[-][AA]" : pieces[i]);
            return result + "[FF]";
        }
    }
}
