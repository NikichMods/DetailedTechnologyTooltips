// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;

namespace DetailedTechnologyTooltips
{
    internal static class Localization
    {
        internal const string BuildMenu = "build_menu";
        internal const string AlchemyLab = "alchemy_lab";
        internal const string Diamonds = "diamonds";
        internal const string Marble = "marble";
        internal const string IronOreBonus = "iron_ore_bonus";
        internal const string CoalBonus = "coal_bonus";
        internal const string HoneyBonus = "honey_bonus";
        internal const string Butterfly = "butterfly";
        internal const string Moth = "moth";
        internal const string Maggot = "maggot";
        internal const string PyriteNote = "pyrite_note";
        internal const string RemoteControl = "remote_control";

        internal const string PeatEffect = "peat_effect";
        internal const string BoostFertilizerI = "boost_fertilizer_i";
        internal const string BoostFertilizerII = "boost_fertilizer_ii";
        internal const string QualityFertilizerI = "quality_fertilizer_i";
        internal const string QualityFertilizerII = "quality_fertilizer_ii";
        internal const string GrowingPrefix = "growing_prefix";
        internal const string GrownAtPrefix = "grown_at_prefix";
        internal const string SeedsPrefix = "seeds_prefix";
        internal const string Vineyard = "vineyard";
        internal const string VineTrellis = "vine_trellis";
        internal const string Merchant = "merchant";
        internal const string Miller = "miller";
        internal const string PreparationPlace = "preparation_place";
        internal const string PreparationPlaceII = "preparation_place_ii";
        internal const string SuperMushroom = "super_mushroom";
        internal const string Jeweler = "jeweler";
        internal const string WineMaster = "wine_master";
        internal const string Writer = "writer";
        internal const string Playwright = "playwright";
        internal const string Industriousness = "industriousness";
        internal const string Engineer = "engineer";
        internal const string SwordMaster = "sword_master";
        internal const string Persistence = "persistence";
        internal const string Butcher = "butcher";
        internal const string Doctor = "doctor";
        internal const string Blacksmith = "blacksmith";

        internal static readonly string[] SupportedLanguages =
        {
            "en",
            "de",
            "fr",
            "pt-br",
            "es",
            "ru",
            "it",
            "pl",
            "ja",
            "zh_cn",
            "ko"
        };

        internal static readonly string[] Keys =
        {
            BuildMenu,
            AlchemyLab,
            Diamonds,
            Marble,
            IronOreBonus,
            CoalBonus,
            HoneyBonus,
            Butterfly,
            Moth,
            Maggot,
            PyriteNote,
            RemoteControl,
            PeatEffect,
            BoostFertilizerI,
            BoostFertilizerII,
            QualityFertilizerI,
            QualityFertilizerII,
            GrowingPrefix,
            GrownAtPrefix,
            SeedsPrefix,
            Vineyard,
            VineTrellis,
            Merchant,
            Miller,
            PreparationPlace,
            PreparationPlaceII,
            SuperMushroom,
            Jeweler,
            WineMaster,
            Writer,
            Playwright,
            Industriousness,
            Engineer,
            SwordMaster,
            Persistence,
            Butcher,
            Doctor,
            Blacksmith
        };

        private static readonly Dictionary<string, Dictionary<string, string>> Text =
            new Dictionary<string, Dictionary<string, string>>(StringComparer.Ordinal)
            {
                {
                    "en",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Build menu: " },
                        { AlchemyLab, "Alchemy Lab" },
                        { Diamonds, "Diamonds can now be mined." },
                        { Marble, "Marble can now be quarried." },
                        { IronOreBonus, "Can now appear while mining or processing iron ore." },
                        { CoalBonus, "Can now appear while mining coal." },
                        { HoneyBonus, "Can now appear while collecting honey." },
                        { Butterfly, "Can now appear while gathering flowers during the day." },
                        { Moth, "Can now appear while gathering flowers at night." },
                        { Maggot, "Can now be produced when processing waste into peat." },
                        { PyriteNote, "Note: in the current version of the game, this technology does not allow obtaining {0}." },
                        { RemoteControl, "Use the map to remotely control available workstations. Remote actions in an area require a Soul Receiver." },
                        { PeatEffect, "Effect for one crop cycle: increases crop and seed yields and reduces growth time by 20%." },
                        { BoostFertilizerI, "Effect for one crop cycle: reduces growth time by 40%." },
                        { BoostFertilizerII, "Effect for one crop cycle: reduces growth time by 60%." },
                        { QualityFertilizerI, "Effect for one crop cycle: increases crop and seed yields. Additionally produces 1 crop and 1 seed one quality tier higher." },
                        { QualityFertilizerII, "Effect for one crop cycle: increases crop and seed yields. Additionally produces 2 crops and 2 seeds one quality tier higher." },
                        { GrowingPrefix, "Growing: " },
                        { GrownAtPrefix, "Grown at: " },
                        { SeedsPrefix, "Seeds: " },
                        { Vineyard, "Vineyard" },
                        { VineTrellis, "Vine trellis" },
                        { Merchant, "Merchant" },
                        { Miller, "Miller" },
                        { PreparationPlace, "Preparation Place" },
                        { PreparationPlaceII, "Preparation Place II" },
                        { SuperMushroom, "Unlocks gathering red mushrooms." },
                        { Jeweler, "Hardcover book crafting quality: (s1)+0.7.\nDungeon diamond, gold, and silver sources yield at least 1 more." },
                        { WineMaster, "Red wine crafting quality: (s1)+0.8.\nAlcohol restores more energy." },
                        { Writer, "Writing quality: (s1)+0.3." },
                        { Playwright, "Writing quality: (s1)+0.5." },
                        { Industriousness, "Crafting quality for affected recipes: (s1)+0.2." },
                        { Engineer, "Crafting quality for carved wood, carved marble, and steel chisels: (s1)+0.3." },
                        { SwordMaster, "Weapon damage: +5." },
                        { Persistence, "Passively restores 1 energy per second." },
                        { Butcher, "Chance of error when extracting flesh, blood, fat, skin, skull, and bones decreases from 25% to 0%." },
                        { Doctor, "At {0}, chance of error when extracting the brain, heart, and intestine decreases from 50% to 25%. At {1}, it decreases from 25% to 0%." },
                        { Blacksmith, "Crafting nails and metal parts produces more items. Steel chisel quality: (s1)+0.1." }
                    }
                },
                {
                    "de",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Baumenü: " },
                        { AlchemyLab, "Alchemielabor" },
                        { Diamonds, "Diamanten können jetzt abgebaut werden." },
                        { Marble, "Marmor kann jetzt abgebaut werden." },
                        { IronOreBonus, "Kann jetzt beim Abbau oder Verarbeiten von Eisenerz gefunden werden." },
                        { CoalBonus, "Kann jetzt beim Kohleabbau gefunden werden." },
                        { HoneyBonus, "Kann jetzt beim Sammeln von Honig gefunden werden." },
                        { Butterfly, "Kann jetzt beim Sammeln von Blumen am Tag gefunden werden." },
                        { Moth, "Kann jetzt beim Sammeln von Blumen in der Nacht gefunden werden." },
                        { Maggot, "Kann jetzt bei der Verarbeitung von Abfällen zu Torf entstehen." },
                        { PyriteNote, "Hinweis: In der aktuellen Spielversion ermöglicht diese Technologie nicht, {0} zu erhalten." },
                        { RemoteControl, "Auf der Karte kannst du verfügbare Arbeitsstationen fernsteuern. Für Fernaktionen in einem Gebiet wird ein Seelenempfänger benötigt." },
                        { PeatEffect, "Effekt für einen Erntezyklus: erhöht Ernte- und Samenertrag und verkürzt die Wachstumszeit um 20 %." },
                        { BoostFertilizerI, "Effekt für einen Erntezyklus: verkürzt die Wachstumszeit um 40 %." },
                        { BoostFertilizerII, "Effekt für einen Erntezyklus: verkürzt die Wachstumszeit um 60 %." },
                        { QualityFertilizerI, "Effekt für einen Erntezyklus: erhöht die Ernte- und Samenausbeute. Zusätzlich entstehen 1 Erntegut und 1 Samen mit einer um eine Stufe höheren Qualität." },
                        { QualityFertilizerII, "Effekt für einen Erntezyklus: erhöht die Ernte- und Samenausbeute. Zusätzlich entstehen 2 Erntegüter und 2 Samen mit einer um eine Stufe höheren Qualität." },
                        { GrowingPrefix, "Anbau: " },
                        { GrownAtPrefix, "Anbauort: " },
                        { SeedsPrefix, "Samen: " },
                        { Vineyard, "Weinberg" },
                        { VineTrellis, "Weinrebe" },
                        { Merchant, "Händler" },
                        { Miller, "Müller" },
                        { PreparationPlace, "Präparationstisch" },
                        { PreparationPlaceII, "Präparationstisch II" },
                        { SuperMushroom, "Ermöglicht das Sammeln roter Pilze." },
                        { Jeweler, "Herstellungsqualität von Büchern mit festem Einband: (s1)+0,7.\nDiamant-, Gold- und Silberquellen im Dungeon liefern mindestens 1 Einheit mehr." },
                        { WineMaster, "Herstellungsqualität von Rotwein: (s1)+0,8.\nAlkohol stellt mehr Energie wieder her." },
                        { Writer, "Qualität von Schriftstücken: (s1)+0,3." },
                        { Playwright, "Qualität von Schriftstücken: (s1)+0,5." },
                        { Industriousness, "Herstellungsqualität betroffener Rezepte: (s1)+0,2." },
                        { Engineer, "Herstellungsqualität von geschnitztem Holz, geschnitztem Marmor und Stahlmeißeln: (s1)+0,3." },
                        { SwordMaster, "Waffenschaden: +5." },
                        { Persistence, "Stellt passiv 1 Energie pro Sekunde wieder her." },
                        { Butcher, "Die Fehlerchance beim Entfernen von Fleisch, Blut, Fett, Haut, Schädel und Knochen sinkt von 25 % auf 0 %." },
                        { Doctor, "Am {0} sinkt die Fehlerchance beim Entfernen von Gehirn, Herz und Darm von 50 % auf 25 %. Am {1} sinkt sie von 25 % auf 0 %." },
                        { Blacksmith, "Beim Herstellen von Nägeln und Metallteilen entstehen mehr Gegenstände. Qualität von Stahlmeißeln: (s1)+0,1." }
                    }
                },
                {
                    "fr",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu de construction : " },
                        { AlchemyLab, "Laboratoire d’alchimie" },
                        { Diamonds, "Les diamants peuvent désormais être extraits." },
                        { Marble, "Le marbre peut désormais être extrait." },
                        { IronOreBonus, "Peut désormais être obtenu lors de l’extraction ou du traitement du minerai de fer." },
                        { CoalBonus, "Peut désormais être obtenu lors de l’extraction du charbon." },
                        { HoneyBonus, "Peut désormais être obtenu lors de la récolte du miel." },
                        { Butterfly, "Peut désormais être obtenu en cueillant des fleurs pendant la journée." },
                        { Moth, "Peut désormais être obtenu en cueillant des fleurs pendant la nuit." },
                        { Maggot, "Peut désormais être produit lors de la transformation des déchets en tourbe." },
                        { PyriteNote, "Remarque : dans la version actuelle du jeu, cette technologie ne permet pas d’obtenir {0}." },
                        { RemoteControl, "La carte permet de contrôler à distance les postes de travail disponibles. Les actions à distance dans une zone nécessitent un récepteur d’âmes." },
                        { PeatEffect, "Effet pour un cycle de culture : augmente le rendement des récoltes et des graines et réduit le temps de croissance de 20 %." },
                        { BoostFertilizerI, "Effet pour un cycle de culture : réduit le temps de croissance de 40 %." },
                        { BoostFertilizerII, "Effet pour un cycle de culture : réduit le temps de croissance de 60 %." },
                        { QualityFertilizerI, "Effet pour un cycle de culture : augmente la quantité de récolte et de graines. Produit en plus 1 unité de récolte et 1 graine d’un niveau de qualité supérieur." },
                        { QualityFertilizerII, "Effet pour un cycle de culture : augmente la quantité de récolte et de graines. Produit en plus 2 unités de récolte et 2 graines d’un niveau de qualité supérieur." },
                        { GrowingPrefix, "Culture : " },
                        { GrownAtPrefix, "Cultivé à : " },
                        { SeedsPrefix, "Graines : " },
                        { Vineyard, "Vignoble" },
                        { VineTrellis, "Treille" },
                        { Merchant, "Marchand" },
                        { Miller, "Meunier" },
                        { PreparationPlace, "Table de préparation" },
                        { PreparationPlaceII, "Table de préparation II" },
                        { SuperMushroom, "Permet de récolter les champignons rouges." },
                        { Jeweler, "Qualité de fabrication des livres à couverture rigide : (s1)+0,7.\nLes sources de diamants, d’or et d’argent du donjon donnent au moins 1 unité de plus." },
                        { WineMaster, "Qualité de fabrication du vin rouge : (s1)+0,8.\nL’alcool restaure davantage d’énergie." },
                        { Writer, "Qualité des écrits : (s1)+0,3." },
                        { Playwright, "Qualité des écrits : (s1)+0,5." },
                        { Industriousness, "Qualité de fabrication des recettes concernées : (s1)+0,2." },
                        { Engineer, "Qualité de fabrication du bois sculpté, du marbre sculpté et des burins en acier : (s1)+0,3." },
                        { SwordMaster, "Dégâts de l’arme : +5." },
                        { Persistence, "Restaure passivement 1 point d’énergie par seconde." },
                        { Butcher, "Le risque d’erreur lors de l’extraction de la chair, du sang, de la graisse, de la peau, du crâne et des os passe de 25 % à 0 %." },
                        { Doctor, "À {0}, le risque d’erreur lors de l’extraction du cerveau, du cœur et de l’intestin passe de 50 % à 25 %. À {1}, il passe de 25 % à 0 %." },
                        { Blacksmith, "La fabrication de clous et de pièces métalliques produit davantage d’objets. Qualité des burins en acier : (s1)+0,1." }
                    }
                },
                {
                    "pt-br",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu de construção: " },
                        { AlchemyLab, "Laboratório de alquimia" },
                        { Diamonds, "Diamantes agora podem ser minerados." },
                        { Marble, "Mármore agora pode ser extraído." },
                        { IronOreBonus, "Agora pode aparecer ao minerar ou processar minério de ferro." },
                        { CoalBonus, "Agora pode aparecer ao minerar carvão." },
                        { HoneyBonus, "Agora pode aparecer ao coletar mel." },
                        { Butterfly, "Agora pode aparecer ao coletar flores durante o dia." },
                        { Moth, "Agora pode aparecer ao coletar flores durante a noite." },
                        { Maggot, "Agora pode ser produzido ao processar resíduos em turfa." },
                        { PyriteNote, "Observação: na versão atual do jogo, esta tecnologia não permite obter {0}." },
                        { RemoteControl, "O mapa permite controlar estações de trabalho disponíveis à distância. Ações remotas em uma área exigem um receptor de almas." },
                        { PeatEffect, "Efeito por um ciclo de cultivo: aumenta a produção da colheita e de sementes e reduz o tempo de crescimento em 20%." },
                        { BoostFertilizerI, "Efeito por um ciclo de cultivo: reduz o tempo de crescimento em 40%." },
                        { BoostFertilizerII, "Efeito por um ciclo de cultivo: reduz o tempo de crescimento em 60%." },
                        { QualityFertilizerI, "Efeito por um ciclo de cultivo: aumenta a quantidade de colheita e sementes. Além disso, produz 1 unidade de colheita e 1 semente um nível de qualidade acima." },
                        { QualityFertilizerII, "Efeito por um ciclo de cultivo: aumenta a quantidade de colheita e sementes. Além disso, produz 2 unidades de colheita e 2 sementes um nível de qualidade acima." },
                        { GrowingPrefix, "Cultivo: " },
                        { GrownAtPrefix, "Cultivado em: " },
                        { SeedsPrefix, "Sementes: " },
                        { Vineyard, "Vinhedo" },
                        { VineTrellis, "Treliça de videira" },
                        { Merchant, "Mercador" },
                        { Miller, "Moleiro" },
                        { PreparationPlace, "Mesa de preparação" },
                        { PreparationPlaceII, "Mesa de preparação II" },
                        { SuperMushroom, "Libera a coleta de cogumelos vermelhos." },
                        { Jeweler, "Qualidade de criação de livros de capa dura: (s1)+0,7.\nFontes de diamante, ouro e prata na masmorra rendem pelo menos 1 unidade a mais." },
                        { WineMaster, "Qualidade de criação de vinho tinto: (s1)+0,8.\nÁlcool restaura mais energia." },
                        { Writer, "Qualidade da escrita: (s1)+0,3." },
                        { Playwright, "Qualidade da escrita: (s1)+0,5." },
                        { Industriousness, "Qualidade de criação das receitas afetadas: (s1)+0,2." },
                        { Engineer, "Qualidade de criação de madeira entalhada, mármore entalhado e cinzéis de aço: (s1)+0,3." },
                        { SwordMaster, "Dano da arma: +5." },
                        { Persistence, "Restaura passivamente 1 de energia por segundo." },
                        { Butcher, "A chance de erro ao extrair carne, sangue, gordura, pele, crânio e ossos cai de 25% para 0%." },
                        { Doctor, "Em {0}, a chance de erro ao extrair cérebro, coração e intestino cai de 50% para 25%. Em {1}, cai de 25% para 0%." },
                        { Blacksmith, "Criar pregos e peças metálicas produz mais itens. Qualidade dos cinzéis de aço: (s1)+0,1." }
                    }
                },
                {
                    "es",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menú de construcción: " },
                        { AlchemyLab, "Laboratorio de alquimia" },
                        { Diamonds, "Ahora se pueden extraer diamantes." },
                        { Marble, "Ahora se puede extraer mármol." },
                        { IronOreBonus, "Ahora puede aparecer al extraer o procesar mineral de hierro." },
                        { CoalBonus, "Ahora puede aparecer al extraer carbón." },
                        { HoneyBonus, "Ahora puede aparecer al recolectar miel." },
                        { Butterfly, "Ahora puede aparecer al recolectar flores durante el día." },
                        { Moth, "Ahora puede aparecer al recolectar flores durante la noche." },
                        { Maggot, "Ahora puede producirse al procesar residuos para convertirlos en turba." },
                        { PyriteNote, "Nota: en la versión actual del juego, esta tecnología no permite obtener {0}." },
                        { RemoteControl, "El mapa permite controlar a distancia los puestos de trabajo disponibles. Las acciones remotas en una zona requieren un receptor de almas." },
                        { PeatEffect, "Efecto durante un ciclo de cultivo: aumenta el rendimiento de la cosecha y de las semillas y reduce el tiempo de crecimiento un 20 %." },
                        { BoostFertilizerI, "Efecto durante un ciclo de cultivo: reduce el tiempo de crecimiento un 40 %." },
                        { BoostFertilizerII, "Efecto durante un ciclo de cultivo: reduce el tiempo de crecimiento un 60 %." },
                        { QualityFertilizerI, "Efecto durante un ciclo de cultivo: aumenta la cantidad de cosecha y semillas. Además, produce 1 unidad de cosecha y 1 semilla un nivel de calidad superior." },
                        { QualityFertilizerII, "Efecto durante un ciclo de cultivo: aumenta la cantidad de cosecha y semillas. Además, produce 2 unidades de cosecha y 2 semillas un nivel de calidad superior." },
                        { GrowingPrefix, "Cultivo: " },
                        { GrownAtPrefix, "Se cultiva en: " },
                        { SeedsPrefix, "Semillas: " },
                        { Vineyard, "Viñedo" },
                        { VineTrellis, "Emparrado" },
                        { Merchant, "Mercader" },
                        { Miller, "Molinero" },
                        { PreparationPlace, "Mesa de preparación" },
                        { PreparationPlaceII, "Mesa de preparación II" },
                        { SuperMushroom, "Permite recolectar setas rojas." },
                        { Jeweler, "Calidad de creación de libros de tapa dura: (s1)+0,7.\nLas fuentes de diamantes, oro y plata de la mazmorra dan al menos 1 unidad más." },
                        { WineMaster, "Calidad de creación del vino tinto: (s1)+0,8.\nEl alcohol restaura más energía." },
                        { Writer, "Calidad de escritura: (s1)+0,3." },
                        { Playwright, "Calidad de escritura: (s1)+0,5." },
                        { Industriousness, "Calidad de creación de las recetas afectadas: (s1)+0,2." },
                        { Engineer, "Calidad de creación de madera tallada, mármol tallado y cinceles de acero: (s1)+0,3." },
                        { SwordMaster, "Daño del arma: +5." },
                        { Persistence, "Restaura pasivamente 1 de energía por segundo." },
                        { Butcher, "La probabilidad de error al extraer carne, sangre, grasa, piel, cráneo y huesos baja del 25 % al 0 %." },
                        { Doctor, "En {0}, la probabilidad de error al extraer cerebro, corazón e intestino baja del 50 % al 25 %. En {1}, baja del 25 % al 0 %." },
                        { Blacksmith, "Fabricar clavos y piezas metálicas produce más objetos. Calidad de los cinceles de acero: (s1)+0,1." }
                    }
                },
                {
                    "ru",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Строительство: " },
                        { AlchemyLab, "Алхимическая лаборатория" },
                        { Diamonds, "Теперь можно добывать алмазы." },
                        { Marble, "Теперь можно добывать мрамор." },
                        { IronOreBonus, "Теперь может попадаться при добыче и переработке железной руды." },
                        { CoalBonus, "Теперь может попадаться при добыче угля." },
                        { HoneyBonus, "Теперь может попадаться при сборе мёда." },
                        { Butterfly, "Теперь может попадаться при сборе цветов днём." },
                        { Moth, "Теперь может попадаться при сборе цветов ночью." },
                        { Maggot, "Теперь может получаться при переработке отходов в торф." },
                        { PyriteNote, "Примечание: в текущей версии игры эта технология не позволяет получать {0}." },
                        { RemoteControl, "На карте можно удалённо управлять доступными рабочими местами. Для действий в зоне нужен душеприёмник." },
                        { PeatEffect, "Эффект на один цикл: увеличивает урожай и количество семян при сборе, сокращает время роста на 20%." },
                        { BoostFertilizerI, "Эффект на один цикл: сокращает время роста на 40%." },
                        { BoostFertilizerII, "Эффект на один цикл: сокращает время роста на 60%." },
                        { QualityFertilizerI, "Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше." },
                        { QualityFertilizerII, "Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 2 единицы урожая и 2 семени на одну ступень качества выше." },
                        { GrowingPrefix, "Выращивание: " },
                        { GrownAtPrefix, "Выращивается: " },
                        { SeedsPrefix, "Семена: " },
                        { Vineyard, "Виноградник" },
                        { VineTrellis, "Опора под лозу" },
                        { Merchant, "Торговец" },
                        { Miller, "Мельник" },
                        { PreparationPlace, "Препарационный стол" },
                        { PreparationPlaceII, "Препарационный стол II" },
                        { SuperMushroom, "Открывает сбор красных грибов." },
                        { Jeweler, "Качество книг в твёрдом переплёте: (s1)+0,7.\nИсточники алмазов, золота и серебра в подземелье дают как минимум на 1 ресурс больше." },
                        { WineMaster, "Качество красного вина: (s1)+0,8.\nАлкоголь восстанавливает больше энергии." },
                        { Writer, "Качество письменных работ: (s1)+0,3." },
                        { Playwright, "Качество письменных работ: (s1)+0,5." },
                        { Industriousness, "Качество изготовления для соответствующих рецептов: (s1)+0,2." },
                        { Engineer, "Качество резного дерева, резного мрамора и стальных резцов: (s1)+0,3." },
                        { SwordMaster, "Урон оружием: +5." },
                        { Persistence, "Пассивно восстанавливает 1 энергию в секунду." },
                        { Butcher, "Шанс ошибки при извлечении мяса, крови, жира, кожи, черепа и костей снижается с 25% до 0%." },
                        { Doctor, "На {0} шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25%. На {1} — с 25% до 0%." },
                        { Blacksmith, "При изготовлении гвоздей и металлических деталей получается больше изделий. Качество стальных резцов: (s1)+0,1." }
                    }
                },
                {
                    "it",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu costruzione: " },
                        { AlchemyLab, "Laboratorio di alchimia" },
                        { Diamonds, "Ora è possibile estrarre diamanti." },
                        { Marble, "Ora è possibile estrarre marmo." },
                        { IronOreBonus, "Ora può comparire durante l’estrazione o la lavorazione del minerale di ferro." },
                        { CoalBonus, "Ora può comparire durante l’estrazione del carbone." },
                        { HoneyBonus, "Ora può comparire durante la raccolta del miele." },
                        { Butterfly, "Ora può comparire durante la raccolta di fiori di giorno." },
                        { Moth, "Ora può comparire durante la raccolta di fiori di notte." },
                        { Maggot, "Ora può essere prodotto trasformando i rifiuti in torba." },
                        { PyriteNote, "Nota: nella versione attuale del gioco, questa tecnologia non consente di ottenere {0}." },
                        { RemoteControl, "La mappa permette di controllare a distanza le postazioni di lavoro disponibili. Le azioni remote in un’area richiedono un ricevitore di anime." },
                        { PeatEffect, "Effetto per un ciclo di coltivazione: aumenta la resa del raccolto e dei semi e riduce del 20% il tempo di crescita." },
                        { BoostFertilizerI, "Effetto per un ciclo di coltivazione: riduce del 40% il tempo di crescita." },
                        { BoostFertilizerII, "Effetto per un ciclo di coltivazione: riduce del 60% il tempo di crescita." },
                        { QualityFertilizerI, "Effetto per un ciclo di coltivazione: aumenta la quantità di raccolto e semi. Inoltre produce 1 unità di raccolto e 1 seme di un livello di qualità superiore." },
                        { QualityFertilizerII, "Effetto per un ciclo di coltivazione: aumenta la quantità di raccolto e semi. Inoltre produce 2 unità di raccolto e 2 semi di un livello di qualità superiore." },
                        { GrowingPrefix, "Coltivazione: " },
                        { GrownAtPrefix, "Si coltiva a: " },
                        { SeedsPrefix, "Semi: " },
                        { Vineyard, "Vigneto" },
                        { VineTrellis, "Pergolato per viti" },
                        { Merchant, "Mercante" },
                        { Miller, "Mugnaio" },
                        { PreparationPlace, "Tavolo di preparazione" },
                        { PreparationPlaceII, "Tavolo di preparazione II" },
                        { SuperMushroom, "Sblocca la raccolta dei funghi rossi." },
                        { Jeweler, "Qualità di creazione dei libri con copertina rigida: (s1)+0,7.\nLe fonti di diamanti, oro e argento nel dungeon forniscono almeno 1 unità in più." },
                        { WineMaster, "Qualità di creazione del vino rosso: (s1)+0,8.\nL’alcol ripristina più energia." },
                        { Writer, "Qualità della scrittura: (s1)+0,3." },
                        { Playwright, "Qualità della scrittura: (s1)+0,5." },
                        { Industriousness, "Qualità di creazione delle ricette interessate: (s1)+0,2." },
                        { Engineer, "Qualità di creazione di legno intagliato, marmo intagliato e scalpelli d’acciaio: (s1)+0,3." },
                        { SwordMaster, "Danno dell’arma: +5." },
                        { Persistence, "Ripristina passivamente 1 energia al secondo." },
                        { Butcher, "La probabilità di errore nell’estrazione di carne, sangue, grasso, pelle, cranio e ossa scende dal 25% allo 0%." },
                        { Doctor, "Al {0}, la probabilità di errore nell’estrazione di cervello, cuore e intestino scende dal 50% al 25%. Al {1}, scende dal 25% allo 0%." },
                        { Blacksmith, "La creazione di chiodi e parti metalliche produce più oggetti. Qualità degli scalpelli d’acciaio: (s1)+0,1." }
                    }
                },
                {
                    "pl",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu budowy: " },
                        { AlchemyLab, "Laboratorium alchemiczne" },
                        { Diamonds, "Diamenty można teraz wydobywać." },
                        { Marble, "Marmur można teraz wydobywać." },
                        { IronOreBonus, "Może teraz pojawić się podczas wydobywania lub przetwarzania rudy żelaza." },
                        { CoalBonus, "Może teraz pojawić się podczas wydobywania węgla." },
                        { HoneyBonus, "Może teraz pojawić się podczas zbierania miodu." },
                        { Butterfly, "Może teraz pojawić się podczas zbierania kwiatów w dzień." },
                        { Moth, "Może teraz pojawić się podczas zbierania kwiatów w nocy." },
                        { Maggot, "Może teraz powstawać podczas przetwarzania odpadów na torf." },
                        { PyriteNote, "Uwaga: w obecnej wersji gry ta technologia nie pozwala zdobywać {0}." },
                        { RemoteControl, "Z mapy można zdalnie sterować dostępnymi stanowiskami pracy. Zdalne działania w danym obszarze wymagają odbiornika dusz." },
                        { PeatEffect, "Efekt na jeden cykl uprawy: zwiększa plony i liczbę nasion oraz skraca czas wzrostu o 20%." },
                        { BoostFertilizerI, "Efekt na jeden cykl uprawy: skraca czas wzrostu o 40%." },
                        { BoostFertilizerII, "Efekt na jeden cykl uprawy: skraca czas wzrostu o 60%." },
                        { QualityFertilizerI, "Efekt na jeden cykl uprawy: zwiększa ilość plonów i nasion. Dodatkowo daje 1 sztukę plonu i 1 nasiono o jeden poziom jakości wyżej." },
                        { QualityFertilizerII, "Efekt na jeden cykl uprawy: zwiększa ilość plonów i nasion. Dodatkowo daje 2 sztuki plonu i 2 nasiona o jeden poziom jakości wyżej." },
                        { GrowingPrefix, "Uprawa: " },
                        { GrownAtPrefix, "Miejsce uprawy: " },
                        { SeedsPrefix, "Nasiona: " },
                        { Vineyard, "Winnica" },
                        { VineTrellis, "Podpora pod winorośl" },
                        { Merchant, "Kupiec" },
                        { Miller, "Młynarz" },
                        { PreparationPlace, "Stół preparacyjny" },
                        { PreparationPlaceII, "Stół preparacyjny II" },
                        { SuperMushroom, "Odblokowuje zbieranie czerwonych grzybów." },
                        { Jeweler, "Jakość tworzenia książek w twardej oprawie: (s1)+0,7.\nŹródła diamentów, złota i srebra w lochu dają co najmniej 1 jednostkę więcej." },
                        { WineMaster, "Jakość tworzenia czerwonego wina: (s1)+0,8.\nAlkohol przywraca więcej energii." },
                        { Writer, "Jakość pisania: (s1)+0,3." },
                        { Playwright, "Jakość pisania: (s1)+0,5." },
                        { Industriousness, "Jakość wytwarzania w objętych premią przepisach: (s1)+0,2." },
                        { Engineer, "Jakość wytwarzania rzeźbionego drewna, rzeźbionego marmuru i stalowych dłut: (s1)+0,3." },
                        { SwordMaster, "Obrażenia broni: +5." },
                        { Persistence, "Pasywnie przywraca 1 energię na sekundę." },
                        { Butcher, "Szansa błędu przy wyjmowaniu mięsa, krwi, tłuszczu, skóry, czaszki i kości spada z 25% do 0%." },
                        { Doctor, "Przy {0} szansa błędu przy wyjmowaniu mózgu, serca i jelita spada z 50% do 25%. Przy {1} spada z 25% do 0%." },
                        { Blacksmith, "Wytwarzanie gwoździ i metalowych części daje więcej przedmiotów. Jakość stalowych dłut: (s1)+0,1." }
                    }
                },
                {
                    "ja",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "建設メニュー：" },
                        { AlchemyLab, "錬金術研究室" },
                        { Diamonds, "ダイヤモンドを採掘できるようになります。" },
                        { Marble, "大理石を採掘できるようになります。" },
                        { IronOreBonus, "鉄鉱石の採掘または加工時に入手できるようになります。" },
                        { CoalBonus, "石炭の採掘時に入手できるようになります。" },
                        { HoneyBonus, "ハチミツの採取時に入手できるようになります。" },
                        { Butterfly, "昼間に花を採取すると入手できるようになります。" },
                        { Moth, "夜間に花を採取すると入手できるようになります。" },
                        { Maggot, "廃棄物を泥炭に加工する際に生成されるようになります。" },
                        { PyriteNote, "注：現在のゲームバージョンでは、この技術を取得しても{0}を入手できません。" },
                        { RemoteControl, "マップから利用可能な作業設備を遠隔操作できます。エリア内で遠隔操作するには魂の受信機が必要です。" },
                        { PeatEffect, "1回の栽培サイクルに有効：収穫量と種の数が増え、成長時間が20%短縮されます。" },
                        { BoostFertilizerI, "1回の栽培サイクルに有効：成長時間が40%短縮されます。" },
                        { BoostFertilizerII, "1回の栽培サイクルに有効：成長時間が60%短縮されます。" },
                        { QualityFertilizerI, "1回の栽培サイクルに有効：作物と種の収穫量が増えます。さらに、品質が1段階高い作物1個と種1個が得られます。" },
                        { QualityFertilizerII, "1回の栽培サイクルに有効：作物と種の収穫量が増えます。さらに、品質が1段階高い作物2個と種2個が得られます。" },
                        { GrowingPrefix, "栽培：" },
                        { GrownAtPrefix, "栽培場所：" },
                        { SeedsPrefix, "種：" },
                        { Vineyard, "ブドウ畑" },
                        { VineTrellis, "ブドウ棚" },
                        { Merchant, "商人" },
                        { Miller, "粉ひき屋" },
                        { PreparationPlace, "準備台" },
                        { PreparationPlaceII, "準備台 II" },
                        { SuperMushroom, "赤キノコを採取できるようになります。" },
                        { Jeweler, "ハードカバー本の製作品質：(s1)+0.7。\nダンジョンのダイヤモンド、金、銀の採取源から最低でも1個多く得られます。" },
                        { WineMaster, "赤ワインの製作品質：(s1)+0.8。\nアルコールで回復するエネルギーが増えます。" },
                        { Writer, "文章の製作品質：(s1)+0.3。" },
                        { Playwright, "文章の製作品質：(s1)+0.5。" },
                        { Industriousness, "対象レシピの製作品質：(s1)+0.2。" },
                        { Engineer, "彫刻木材、彫刻大理石、鋼のノミの製作品質：(s1)+0.3。" },
                        { SwordMaster, "武器ダメージ：+5。" },
                        { Persistence, "1秒ごとにエネルギーを1自動回復します。" },
                        { Butcher, "肉、血、脂肪、皮、頭蓋骨、骨の摘出時の失敗率が25%から0%に低下します。" },
                        { Doctor, "{0}では、脳、心臓、腸の摘出時の失敗率が50%から25%に低下します。{1}では、25%から0%に低下します。" },
                        { Blacksmith, "釘や金属部品の製作数が増えます。鋼のノミの品質：(s1)+0.1。" }
                    }
                },
                {
                    "zh_cn",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "建造菜单：" },
                        { AlchemyLab, "炼金实验室" },
                        { Diamonds, "现在可以开采钻石。" },
                        { Marble, "现在可以开采大理石。" },
                        { IronOreBonus, "现在可在开采或加工铁矿石时获得。" },
                        { CoalBonus, "现在可在开采煤炭时获得。" },
                        { HoneyBonus, "现在可在采集蜂蜜时获得。" },
                        { Butterfly, "现在可在白天采花时获得。" },
                        { Moth, "现在可在夜间采花时获得。" },
                        { Maggot, "现在可在将废料加工成泥炭时获得。" },
                        { PyriteNote, "注意：在当前游戏版本中，这项技术无法让你获得{0}。" },
                        { RemoteControl, "可从地图远程控制可用的工作站。要在某区域执行远程操作，需要灵魂接收器。" },
                        { PeatEffect, "一个种植周期内生效：提高作物和种子产量，并将生长时间缩短20%。" },
                        { BoostFertilizerI, "一个种植周期内生效：将生长时间缩短40%。" },
                        { BoostFertilizerII, "一个种植周期内生效：将生长时间缩短60%。" },
                        { QualityFertilizerI, "一个种植周期内生效：提高作物和种子的产量。另外获得1个高一档品质的作物和1粒高一档品质的种子。" },
                        { QualityFertilizerII, "一个种植周期内生效：提高作物和种子的产量。另外获得2个高一档品质的作物和2粒高一档品质的种子。" },
                        { GrowingPrefix, "种植：" },
                        { GrownAtPrefix, "种植地点：" },
                        { SeedsPrefix, "种子：" },
                        { Vineyard, "葡萄园" },
                        { VineTrellis, "葡萄架" },
                        { Merchant, "商人" },
                        { Miller, "磨坊主" },
                        { PreparationPlace, "尸体处理台" },
                        { PreparationPlaceII, "尸体处理台 II" },
                        { SuperMushroom, "解锁采集红蘑菇。" },
                        { Jeweler, "精装书制作质量：(s1)+0.7。\n地牢中的钻石、黄金和白银来源至少多产出1个。" },
                        { WineMaster, "红葡萄酒制作质量：(s1)+0.8。\n酒类恢复更多能量。" },
                        { Writer, "写作质量：(s1)+0.3。" },
                        { Playwright, "写作质量：(s1)+0.5。" },
                        { Industriousness, "受影响配方的制作质量：(s1)+0.2。" },
                        { Engineer, "雕刻木材、雕刻大理石和钢凿的制作质量：(s1)+0.3。" },
                        { SwordMaster, "武器伤害：+5。" },
                        { Persistence, "每秒被动恢复1点能量。" },
                        { Butcher, "取出肉、血液、脂肪、皮肤、头骨和骨头时的失误概率从25%降至0%。" },
                        { Doctor, "在{0}，取出大脑、心脏和肠道时的失误概率从50%降至25%。在{1}，从25%降至0%。" },
                        { Blacksmith, "制作钉子和金属零件时产量更高。钢凿质量：(s1)+0.1。" }
                    }
                },
                {
                    "ko",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "건설 메뉴: " },
                        { AlchemyLab, "연금술 연구실" },
                        { Diamonds, "이제 다이아몬드를 채굴할 수 있습니다." },
                        { Marble, "이제 대리석을 채굴할 수 있습니다." },
                        { IronOreBonus, "이제 철광석을 채굴하거나 가공할 때 얻을 수 있습니다." },
                        { CoalBonus, "이제 석탄을 채굴할 때 얻을 수 있습니다." },
                        { HoneyBonus, "이제 꿀을 채집할 때 얻을 수 있습니다." },
                        { Butterfly, "이제 낮에 꽃을 채집할 때 얻을 수 있습니다." },
                        { Moth, "이제 밤에 꽃을 채집할 때 얻을 수 있습니다." },
                        { Maggot, "이제 폐기물을 이탄으로 가공할 때 생성될 수 있습니다." },
                        { PyriteNote, "참고: 현재 게임 버전에서는 이 기술로 {0}을(를) 얻을 수 없습니다." },
                        { RemoteControl, "지도에서 이용 가능한 작업대를 원격으로 제어할 수 있습니다. 지역에서 원격 작업을 하려면 영혼 수신기가 필요합니다." },
                        { PeatEffect, "한 번의 재배 주기 동안 적용: 수확량과 씨앗 획득량이 증가하고 성장 시간이 20% 감소합니다." },
                        { BoostFertilizerI, "한 번의 재배 주기 동안 적용: 성장 시간이 40% 감소합니다." },
                        { BoostFertilizerII, "한 번의 재배 주기 동안 적용: 성장 시간이 60% 감소합니다." },
                        { QualityFertilizerI, "한 번의 재배 주기 동안 적용: 작물과 씨앗의 수확량이 증가합니다. 추가로 품질이 한 단계 높은 작물 1개와 씨앗 1개를 얻습니다." },
                        { QualityFertilizerII, "한 번의 재배 주기 동안 적용: 작물과 씨앗의 수확량이 증가합니다. 추가로 품질이 한 단계 높은 작물 2개와 씨앗 2개를 얻습니다." },
                        { GrowingPrefix, "재배: " },
                        { GrownAtPrefix, "재배 장소: " },
                        { SeedsPrefix, "씨앗: " },
                        { Vineyard, "포도밭" },
                        { VineTrellis, "포도 덩굴 지지대" },
                        { Merchant, "상인" },
                        { Miller, "방앗간 주인" },
                        { PreparationPlace, "시체 준비대" },
                        { PreparationPlaceII, "시체 준비대 II" },
                        { SuperMushroom, "빨간 버섯 채집을 해금합니다." },
                        { Jeweler, "양장본 제작 품질: (s1)+0.7.\n던전의 다이아몬드, 금, 은 획득원에서 최소 1개 더 얻습니다." },
                        { WineMaster, "적포도주 제작 품질: (s1)+0.8.\n술이 더 많은 에너지를 회복합니다." },
                        { Writer, "글쓰기 품질: (s1)+0.3." },
                        { Playwright, "글쓰기 품질: (s1)+0.5." },
                        { Industriousness, "해당 레시피의 제작 품질: (s1)+0.2." },
                        { Engineer, "조각 목재, 조각 대리석, 강철 끌의 제작 품질: (s1)+0.3." },
                        { SwordMaster, "무기 피해: +5." },
                        { Persistence, "초당 에너지 1을 지속적으로 회복합니다." },
                        { Butcher, "살, 피, 지방, 피부, 두개골, 뼈 추출 시 실수 확률이 25%에서 0%로 감소합니다." },
                        { Doctor, "{0}에서는 뇌, 심장, 장 추출 시 실수 확률이 50%에서 25%로 감소합니다. {1}에서는 25%에서 0%로 감소합니다." },
                        { Blacksmith, "못과 금속 부품 제작 시 더 많은 아이템을 얻습니다. 강철 끌 품질: (s1)+0.1." }
                    }
                }
            };

        internal static string GetBlueprintBuilderOverride(
            string builderId,
            string language)
        {
            if (!string.Equals(
                    builderId,
                    "alchemy_builddesk",
                    StringComparison.Ordinal))
            {
                return null;
            }

            return Get(AlchemyLab, language);
        }

        internal static string Get(string key, string language)
        {
            var normalized = NormalizeLanguage(language);
            Dictionary<string, string> languageText;
            string value;

            if (string.IsNullOrEmpty(normalized)
                || !Text.TryGetValue(normalized, out languageText)
                || !languageText.TryGetValue(key, out value)
                || string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value;
        }

        internal static string Format(
            string key,
            string language,
            params object[] args)
        {
            var value = Get(key, language);
            if (string.IsNullOrEmpty(value))
                return null;

            try
            {
                return string.Format(value, args);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        internal static string FormatListSeparator(
            string language,
            string nativeSeparator)
        {
            var normalized = NormalizeLanguage(language);

            if (normalized == "ja" || normalized == "zh_cn")
            {
                return string.IsNullOrEmpty(nativeSeparator)
                    ? ",\u200B"
                    : nativeSeparator + "\u200B";
            }

            if (string.IsNullOrWhiteSpace(nativeSeparator))
                return ", ";

            return nativeSeparator.TrimEnd() + " ";
        }

        internal static string NormalizeLanguage(string language)
        {
            if (string.IsNullOrEmpty(language))
                return string.Empty;

            var normalized = language.Trim().ToLowerInvariant().Replace('_', '-');
            if (normalized == "zh-cn")
                return "zh_cn";
            if (normalized == "pt-br")
                return "pt-br";

            return normalized;
        }
    }
}
