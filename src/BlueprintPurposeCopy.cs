// SPDX-License-Identifier: MPL-2.0
using System;
using System.Collections.Generic;
using System.IO;

namespace DetailedTechnologyTooltips
{
    internal static class BlueprintPurposeCopy
    {
        // Curated purpose copy only. Costs, names, icons and build menus remain native.
        private static readonly Dictionary<string, string[]> Copy = new Dictionary<string, string[]>(StringComparer.Ordinal)
        {
            { "mf_furnace_0", new[] { "Used to smelt iron and make glass and ceramics.", "Служит для выплавки железа, изготовления стекла и керамики." } },
            { "mf_furnace_1", new[] { "Also allows you to smelt **steel, silver and gold**.", "Дополнительно позволяет выплавлять **сталь, серебро и золото**." } },
            { "mf_furnace_2", new[] { "Adds **steel parts** and yields more graphite from the same coal.", "Дополнительно позволяет делать **стальные детали**. Больше графита из того же угля." } },
            { "mf_anvil_1", new[] { "Allows you to forge nails, simple iron parts and basic tools.", "Позволяет ковать гвозди, простые железные детали и базовые инструменты." } },
            { "mf_anvil_2", new[] { "Also allows you to forge **complex iron parts**.", "Дополнительно позволяет ковать **сложные железные детали**." } },
            { "mf_anvil_3", new[] { "Allows you to forge **steel equipment**. More nails and simple parts from the same metal.", "Позволяет ковать **стальное снаряжение**. Больше гвоздей и простых деталей из того же металла." } },
            { "mf_potter_wheel_1", new[] { "You can shape clay into ceramic bowls here.", "Здесь можно делать из глины керамические миски." } },
            { "mf_jewelry", new[] { "Used to make jewelry and set gems in swords.", "Используется для изготовления украшений и отделки мечей самоцветами." } },
            { "mf_beam_gantry_1", new[] { "Allows you to cut logs into boards.", "Позволяют распиливать брёвна на доски." } },
            { "mf_chocks_1", new[] { "You can make firewood and wedges here.", "Здесь можно заготавливать дрова и клинья." } },
            { "mf_saw_1", new[] { "Allows you to make **wooden beams**.", "Позволяет делать **деревянные балки**." } },
            { "mf_workbench_1", new[] { "You can make wooden planks and wooden grave decorations here.", "Здесь можно делать брусья и деревянные надгробия." } },
            { "mf_workbench_2", new[] { "Also allows you to make **lenses and steel equipment**.", "Дополнительно позволяет делать **линзы и стальное снаряжение**." } },
            { "mf_hammer_0", new[] { "Used to work stone and marble into building materials and grave decorations.", "Используется для обработки камня и мрамора, изготовления материалов и надгробий." } },
            { "mf_hammer_1", new[] { "Allows you to make **carved stone and marble**.", "Позволяет делать **резной камень и мрамор**." } },
            { "mf_timber_1", new[] { "Storage for **logs**.", "Место для хранения **брёвен**." } },
            { "mf_stones_1", new[] { "Storage for **stone and marble blocks**.", "Место для хранения **каменных и мраморных блоков**." } },
            { "mf_ore_1_complete", new[] { "Storage for **iron ore blocks**.", "Место для хранения **блоков железной руды**." } },
            { "mf_box_stuff", new[] { "Storage for items.", "Место для хранения предметов." } },
            { "obj_church_scroll_cabinet", new[] { "Storage for items.", "Место для хранения предметов." } },
            { "obj_church_bookcase", new[] { "Storage for items.", "Место для хранения предметов." } },
            { "rack_alchemy", new[] { "Storage for items.", "Место для хранения предметов." } },
            { "rack_organs", new[] { "Storage for items.", "Место для хранения предметов." } },
            { "mf_alchemy_survey", new[] { "Used for studying items and earning technology points.", "Используется для изучения предметов и получения очков технологий." } },
            { "table_book_constr", new[] { "You can make paper, ink and candles here.", "Здесь можно делать бумагу, чернила и свечи." } },
            { "desk", new[] { "Allows you to make books and prayers.", "Позволяет создавать книги и молитвы." } },
            { "desk_2", new[] { "**Writing quality bonus** when making books and prayers.", "**Бонус к качеству письма** при создании книг и молитв." } },
            { "mf_paper_press", new[] { "Used to make clean paper from paper glop.", "Служит для изготовления чистой бумаги из бумажной массы." } },
            { "mf_printing_press", new[] { "Allows you to print flyers in batches.", "Позволяет печатать листовки партиями." } },
            { "mf_printing_press_2", new[] { "Allows you to print flyers in batches.", "Позволяет печатать листовки партиями." } },
            { "zombie_pulpit", new[] { "A zombie writes stories.", "Зомби пишет истории." } },
            { "mf_alchemy_craft_02", new[] { "Lets you make potions from **two ingredients**.", "Служит для приготовления зелий из **двух ингредиентов**." } },
            { "mf_alchemy_craft_03", new[] { "Lets you make potions from **three ingredients**.", "Служит для приготовления зелий из **трёх ингредиентов**." } },
            { "mf_alchemy_stirrer_01", new[] { "Allows you to obtain alchemical (alc2) **solutions** from materials.", "Позволяет получать алхимические (alc2) **растворы** из материалов." } },
            { "mf_alchemy_mill", new[] { "Used to grind materials into alchemical (alc1) **powders**.", "Используется для получения алхимических (alc1) **порошков** из материалов." } },
            { "mf_distcube_2_clay", new[] { "You can obtain alchemical (alc3) **extracts** from materials here.", "Здесь можно получать алхимические (alc3) **экстракты** из материалов." } },
            { "mf_distcube_2_cuprum", new[] { "Allows you to obtain (alc3) **more extract** from the same raw materials.", "Позволяет получать (alc3) **больше экстракта** из того же сырья." } },
            { "alchemy_table_zombie", new[] { "A zombie processes materials into (alc1) powders, (alc2) solutions and (alc3) extracts.", "Зомби перерабатывает материалы в (alc1) порошки, (alc2) растворы и (alc3) экстракты." } },
            { "alchemy_workbench_zombie", new[] { "A zombie makes potions from known recipes.", "Зомби готовит зелья по известным рецептам." } },
            { "garden_empty", new[] { "Allows you to grow vegetables.", "Позволяет выращивать овощи." } },
            { "garden_empty_stick", new[] { "You can grow lentils here.", "Здесь можно выращивать чечевицу." } },
            { "vineyard_grapes_stick", new[] { "Used to grow grapes and hops.", "Служит для выращивания винограда и хмеля." } },
            { "bush_berry_garden", new[] { "Allows you to plant berry bushes.", "Позволяет сажать ягодные кусты." } },
            { "tree_apple_garden", new[] { "Allows you to plant apple trees.", "Позволяет сажать яблони." } },
            { "v_obj_compost_heap", new[] { "Used to turn crop waste into peat.", "Используется для переработки отходов урожая в торф." } },
            { "beehouse", new[] { "Used to collect honey and, with a perk, beeswax.", "Служит для сбора мёда; с навыком — и воска." } },
            { "zombie_garden_desk", new[] { "A zombie grows field crops.", "Зомби выращивает полевые культуры." } },
            { "zombie_vineyard_desk", new[] { "A zombie grows grapes and hops.", "Зомби выращивает виноград и хмель." } },
            { "mf_vine_press", new[] { "Allows you to press juice and oil from crops.", "Позволяет выжимать сок и масло из урожая." } },
            { "barrel_brew", new[] { "Used to ferment fruit juice before distillation.", "Служит для сбраживания фруктового сока перед перегонкой." } },
            { "mf_barrel_mid", new[] { "Used to make wine from grape juice.", "Служит для приготовления вина из виноградного сока." } },
            { "mf_distcube_3", new[] { "You can distil fermented juice into spirits here.", "Здесь можно получать крепкий алкоголь из перебродившего сока." } },
            { "brewing_stand", new[] { "Used to brew beer and mead.", "Используется для приготовления пива и медовухи." } },
            { "mf_zombie_brewing", new[] { "A zombie brews beer.", "Зомби варит пиво." } },
            { "mf_zombie_winemaking", new[] { "A zombie makes wine.", "Зомби делает вино." } },
            { "mf_preparation_1", new[] { "Allows you to remove and replace body parts.", "Позволяет извлекать и заменять части тела." } },
            { "mf_preparation_2", new[] { "Bodies **do not decay** on this table.", "Тело **не разлагается** на этом столе." } },
            { "mf_balsamation_1", new[] { "You can alter a body’s properties with injections here.", "Здесь можно менять свойства тел с помощью инъекций." } },
            { "mf_balsamation_2", new[] { "Bodies **do not decay** on the table. Embalming takes half the time.", "Тело **не разлагается** на столе. Бальзамирование вдвое быстрее." } },
            { "corpse_bed", new[] { "Bodies decay more slowly here. Space for **one body**.", "Тело разлагается медленнее. Место для **одного тела**." } },
            { "corpse_bed_big", new[] { "Bodies decay more slowly here. Space for **two bodies**.", "Тела разлагаются медленнее. Место для **двух тел**." } },
            { "corpse_fridge", new[] { "Bodies **do not decay** in storage. Holds two bodies.", "Тела **не разлагаются** при хранении. Вмещает два тела." } },
            { "zombie_crafting_table", new[] { "Make zombie workers from bodies here.", "Здесь можно создавать зомби-рабочих из тел." } },
            { "mf_pyre_placed", new[] { "Used to burn bodies into ash.", "Служит для сожжения тел и получения пепла." } },
            { "zombie_mine_bench_left", new[] { "A zombie mines iron ore and coal.", "Зомби добывает железную руду и уголь." } },
            { "zombie_mine_fence_front_stone", new[] { "A zombie quarries stone blocks.", "Зомби добывает каменные блоки." } },
            { "zombie_mine_fence_front_marble_right", new[] { "A zombie quarries marble blocks.", "Зомби добывает мраморные блоки." } },
            { "porter_station", new[] { "A zombie transports resources between work areas.", "Зомби переносит ресурсы между рабочими зонами." } },
            { "lantern_network", new[] { "Creates lantern building sites in the mine.", "Создаёт места для светильников в шахте." } },
            { "lantern", new[] { "Used to light the surrounding area.", "Служит для освещения пространства вокруг." } },
            { "well_pump", new[] { "Automatically draws water from the well.", "Автоматически набирает воду из колодца." } },
            { "candelabrum_1", new[] { "(cross) **+1 church quality**. Candles increase the bonus.", "(cross) **+1 к качеству церкви**. Свечи усиливают эффект." } },
            { "candelabrum_2", new[] { "(cross) **+2 church quality**. Candles increase the bonus.", "(cross) **+2 к качеству церкви**. Свечи усиливают эффект." } },
            { "candelabrum_3", new[] { "(cross) **+3 church quality**. Candles increase the bonus.", "(cross) **+3 к качеству церкви**. Свечи усиливают эффект." } },
            { "church_bench", new[] { "(cross) **+1 church quality**.", "(cross) **+1 к качеству церкви**." } },
            { "church_bench_2", new[] { "(cross) **+3 church quality**.", "(cross) **+3 к качеству церкви**." } },
            { "church_table_1", new[] { "(cross) **+5 church quality**.", "(cross) **+5 к качеству церкви**." } },
            { "church_table_2", new[] { "(cross) **+8 church quality**.", "(cross) **+8 к качеству церкви**." } },
            { "church_window_1", new[] { "(cross) **+5 church quality**.", "(cross) **+5 к качеству церкви**." } },
            { "church_budka_1", new[] { "(cross) **+5 church quality**. Parishioners may leave confessions.", "(cross) **+5 к качеству церкви**. Прихожане могут оставлять исповеди." } },
            { "church_budka_2", new[] { "(cross) **+7 church quality**. Parishioners may leave confessions.", "(cross) **+7 к качеству церкви**. Прихожане могут оставлять исповеди." } },
            { "c_obj_incense_1", new[] { "(cross) **+1 church quality**. Incense temporarily increases the bonus.", "(cross) **+1 к качеству церкви**. Благовония временно усиливают эффект." } },
            { "c_obj_incense_2", new[] { "(cross) **+3 church quality**. Incense temporarily increases the bonus.", "(cross) **+3 к качеству церкви**. Благовония временно усиливают эффект." } },
            { "pray_stand_wd", new[] { "(wskull) **+2 graveyard quality**.", "(wskull) **+2 к качеству кладбища**." } },
            { "pray_stand_stn", new[] { "(wskull) **+4 graveyard quality**.", "(wskull) **+4 к качеству кладбища**." } },
            { "grass_sward_2x3", new[] { "(wskull) **+2 graveyard quality**.", "(wskull) **+2 к качеству кладбища**." } },
            { "road_marble", new[] { "(wskull) **+3 graveyard quality**.", "(wskull) **+3 к качеству кладбища**." } },
            { "lantern_3", new[] { "(wskull) **+4 graveyard quality**.", "(wskull) **+4 к качеству кладбища**." } },
            { "columbarium_stone", new[] { "(wskull) **+12 graveyard quality**.", "(wskull) **+12 к качеству кладбища**." } },
            { "columbarium_marble", new[] { "(wskull) **+20 graveyard quality**.", "(wskull) **+20 к качеству кладбища**." } },
            { "soul_container", new[] { "Space for **two souls**.", "Место для **двух душ**." } },
            { "soul_container_2", new[] { "Space for **three souls**.", "Место для **трёх душ**." } },
            { "soul_container_3", new[] { "Space for **four souls**.", "Место для **четырёх душ**." } },
            { "soul_workbench", new[] { "You can add white and red skulls to body parts here.", "Здесь можно добавлять частям тела белые и красные черепа." } },
            { "soul_extractor_upgrd_to_2", new[] { "Allows you to extract souls with **less damage**.", "Позволяет извлекать души с **меньшими повреждениями**." } },
            { "soul_extractor_upgrd_to_3", new[] { "Allows you to extract souls **without damage**.", "Позволяет извлекать души **без повреждений**." } },
            { "mf_crematorium", new[] { "Used to burn bodies into ash using fuel.", "Используется для сожжения тел в пепел с помощью топлива." } },
            { "soul_totem_souls", new[] { "Enables remote crafting in its area for souls’ gratitude.", "Позволяет удалённо запускать работу в своей зоне за благодарность душ." } },
            { "pride_healing_extension", new[] { "Adds a **skin** slot to the soul healer.", "Добавляет ячейку для **кожи** в целитель душ." } },
            { "wrath_healing_extension", new[] { "Adds a **blood** slot to the soul healer.", "Добавляет ячейку для **крови** в целитель душ." } },
            { "gluttony_healing_extension", new[] { "Adds a **fat** slot to the soul healer.", "Добавляет ячейку для **жира** в целитель душ." } },
            { "sloth_healing_extension", new[] { "Adds a **brain** slot to the soul healer.", "Добавляет ячейку для **мозга** в целитель душ." } },
            { "lust_healing_extension", new[] { "Adds a **heart** slot to the soul healer.", "Добавляет ячейку для **сердца** в целитель душ." } },
            { "envy_healing_extension", new[] { "Adds an **intestine** slot to the soul healer.", "Добавляет ячейку для **кишечника** в целитель душ." } }
        };
        internal static IEnumerable<string> Ids { get { return Copy.Keys; } }
        internal static int Count { get { return Copy.Count; } }
        // Original authored translations are immutable resources, loaded once. Never cache
        // native localized names, fonts, balance values or save-dependent data here.
        private static readonly Dictionary<string, Dictionary<string, string>> Translations = LoadTranslations();
        private static Dictionary<string, Dictionary<string, string>> LoadTranslations()
        {
            var result = new Dictionary<string, Dictionary<string, string>>(StringComparer.Ordinal);
            foreach (var language in Localization.SupportedLanguages)
            {
                if (language == "en" || language == "ru") continue;
                var rows = new Dictionary<string, string>(StringComparer.Ordinal);
                using (var stream = typeof(BlueprintPurposeCopy).Assembly.GetManifestResourceStream(
                    "Dtt.BlueprintPurposes." + language + ".txt"))
                {
                    if (stream == null) continue;
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal)) continue;
                            int separator = line.IndexOf('|');
                            if (separator <= 0 || separator == line.Length - 1) { rows.Clear(); break; }
                            string id = line.Substring(0, separator);
                            if (!Copy.ContainsKey(id) || rows.ContainsKey(id)) { rows.Clear(); break; }
                            rows.Add(id, line.Substring(separator + 1));
                        }
                    }
                }
                // A malformed/incomplete resource cannot turn an entire locale into mixed English.
                if (rows.Count == Copy.Count) result.Add(language, rows);
            }
            return result;
        }
        private static string NormalizeLanguage(string language)
        {
            var normalized = Localization.NormalizeLanguage(language);
            // Preserve the previously supported EN/RU regional aliases.
            if (normalized.StartsWith("en-", StringComparison.Ordinal)) return "en";
            if (normalized.StartsWith("ru-", StringComparison.Ordinal)) return "ru";
            return normalized;
        }
        internal static bool SupportsLanguage(string language)
        {
            language = NormalizeLanguage(language);
            return language == "en" || language == "ru" || Translations.ContainsKey(language);
        }
        internal static string NativeDescriptionKey(string unlockId)
        {
            return NormalizeId(unlockId) == "zombie_crafting_table" ? "zombie_crafting_table_d" : null;
        }
        private static string NormalizeId(string unlockId)
        {
            if (string.IsNullOrEmpty(unlockId)) return null;
            var id = unlockId.Substring(unlockId.LastIndexOf(':') + 1);
            return id.EndsWith("_place", StringComparison.Ordinal) ? id.Substring(0, id.Length - 6) : id;
        }
        internal static string Get(string unlockId, string language)
        {
            var raw = GetRaw(unlockId, language);
            return raw == null ? null : Render(raw);
        }
        internal static string GetRaw(string unlockId, string language)
        {
            if (string.IsNullOrEmpty(unlockId)) return null;
            language = NormalizeLanguage(language);
            var id = NormalizeId(unlockId);
            string[] pair;
            if (language == "en" || language == "ru")
                return Copy.TryGetValue(id, out pair) ? pair[language == "ru" ? 1 : 0] : null;
            Dictionary<string, string> rows;
            string value;
            return Translations.TryGetValue(language, out rows) && rows.TryGetValue(id, out value) ? value : null;
        }
        internal static string Render(string text)
        {
            var pieces = text.Split(new[] { "**" }, StringSplitOptions.None);
            if (pieces.Length % 2 == 0) throw new ArgumentException("Unbalanced blueprint emphasis");
            var result = "[AA]";
            for (int i = 0; i < pieces.Length; i++)
                result += (i % 2 == 1 ? "[FF][FF7A70]" + pieces[i] + "[-][AA]" : pieces[i]);
            return result + "[FF]";
        }
    }
}
