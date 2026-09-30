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
            Diamonds,
            Marble,
            IronOreBonus,
            CoalBonus,
            HoneyBonus,
            Butterfly,
            Moth,
            Maggot,
            PyriteNote,
            RemoteControl
        };

        private static readonly Dictionary<string, Dictionary<string, string>> Text =
            new Dictionary<string, Dictionary<string, string>>(StringComparer.Ordinal)
            {
                {
                    "en",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Build menu: " },
                        { Diamonds, "Diamonds can now be mined." },
                        { Marble, "Marble can now be quarried." },
                        { IronOreBonus, "Can now appear while mining or processing iron ore." },
                        { CoalBonus, "Can now appear while mining coal." },
                        { HoneyBonus, "Can now appear while collecting honey." },
                        { Butterfly, "Can now appear while gathering flowers during the day." },
                        { Moth, "Can now appear while gathering flowers at night." },
                        { Maggot, "Can now be produced when processing waste into peat." },
                        { PyriteNote, "Note: not implemented in the current game version." },
                        { RemoteControl, "Use the map to remotely control available workstations. Remote actions in an area require a Soul Receiver." }
                    }
                },
                {
                    "de",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Baumenü: " },
                        { Diamonds, "Diamanten können jetzt abgebaut werden." },
                        { Marble, "Marmor kann jetzt abgebaut werden." },
                        { IronOreBonus, "Kann jetzt beim Abbau oder Verarbeiten von Eisenerz gefunden werden." },
                        { CoalBonus, "Kann jetzt beim Kohleabbau gefunden werden." },
                        { HoneyBonus, "Kann jetzt beim Sammeln von Honig gefunden werden." },
                        { Butterfly, "Kann jetzt beim Sammeln von Blumen am Tag gefunden werden." },
                        { Moth, "Kann jetzt beim Sammeln von Blumen in der Nacht gefunden werden." },
                        { Maggot, "Kann jetzt bei der Verarbeitung von Abfällen zu Torf entstehen." },
                        { PyriteNote, "Hinweis: in der aktuellen Spielversion nicht implementiert." },
                        { RemoteControl, "Auf der Karte kannst du verfügbare Arbeitsstationen fernsteuern. Für Fernaktionen in einem Gebiet wird ein Seelenempfänger benötigt." }
                    }
                },
                {
                    "fr",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu de construction : " },
                        { Diamonds, "Les diamants peuvent désormais être extraits." },
                        { Marble, "Le marbre peut désormais être extrait." },
                        { IronOreBonus, "Peut désormais être obtenu lors de l’extraction ou du traitement du minerai de fer." },
                        { CoalBonus, "Peut désormais être obtenu lors de l’extraction du charbon." },
                        { HoneyBonus, "Peut désormais être obtenu lors de la récolte du miel." },
                        { Butterfly, "Peut désormais être obtenu en cueillant des fleurs pendant la journée." },
                        { Moth, "Peut désormais être obtenu en cueillant des fleurs pendant la nuit." },
                        { Maggot, "Peut désormais être produit lors de la transformation des déchets en tourbe." },
                        { PyriteNote, "Remarque : non implémenté dans la version actuelle du jeu." },
                        { RemoteControl, "La carte permet de contrôler à distance les postes de travail disponibles. Les actions à distance dans une zone nécessitent un récepteur d’âmes." }
                    }
                },
                {
                    "pt-br",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu de construção: " },
                        { Diamonds, "Diamantes agora podem ser minerados." },
                        { Marble, "Mármore agora pode ser extraído." },
                        { IronOreBonus, "Agora pode aparecer ao minerar ou processar minério de ferro." },
                        { CoalBonus, "Agora pode aparecer ao minerar carvão." },
                        { HoneyBonus, "Agora pode aparecer ao coletar mel." },
                        { Butterfly, "Agora pode aparecer ao coletar flores durante o dia." },
                        { Moth, "Agora pode aparecer ao coletar flores durante a noite." },
                        { Maggot, "Agora pode ser produzido ao processar resíduos em turfa." },
                        { PyriteNote, "Observação: não implementado na versão atual do jogo." },
                        { RemoteControl, "O mapa permite controlar estações de trabalho disponíveis à distância. Ações remotas em uma área exigem um receptor de almas." }
                    }
                },
                {
                    "es",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menú de construcción: " },
                        { Diamonds, "Ahora se pueden extraer diamantes." },
                        { Marble, "Ahora se puede extraer mármol." },
                        { IronOreBonus, "Ahora puede aparecer al extraer o procesar mineral de hierro." },
                        { CoalBonus, "Ahora puede aparecer al extraer carbón." },
                        { HoneyBonus, "Ahora puede aparecer al recolectar miel." },
                        { Butterfly, "Ahora puede aparecer al recolectar flores durante el día." },
                        { Moth, "Ahora puede aparecer al recolectar flores durante la noche." },
                        { Maggot, "Ahora puede producirse al procesar residuos para convertirlos en turba." },
                        { PyriteNote, "Nota: no está implementado en la versión actual del juego." },
                        { RemoteControl, "El mapa permite controlar a distancia los puestos de trabajo disponibles. Las acciones remotas en una zona requieren un receptor de almas." }
                    }
                },
                {
                    "ru",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Строительство: " },
                        { Diamonds, "Теперь можно добывать алмазы." },
                        { Marble, "Теперь можно добывать мрамор." },
                        { IronOreBonus, "Теперь может попадаться при добыче и переработке железной руды." },
                        { CoalBonus, "Теперь может попадаться при добыче угля." },
                        { HoneyBonus, "Теперь может попадаться при сборе мёда." },
                        { Butterfly, "Теперь может попадаться при сборе цветов днём." },
                        { Moth, "Теперь может попадаться при сборе цветов ночью." },
                        { Maggot, "Теперь может получаться при переработке отходов в торф." },
                        { PyriteNote, "Примечание: не реализовано в текущей версии игры." },
                        { RemoteControl, "На карте можно удалённо управлять доступными рабочими местами. Для действий в зоне нужен душеприёмник." }
                    }
                },
                {
                    "it",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu costruzione: " },
                        { Diamonds, "Ora è possibile estrarre diamanti." },
                        { Marble, "Ora è possibile estrarre marmo." },
                        { IronOreBonus, "Ora può comparire durante l’estrazione o la lavorazione del minerale di ferro." },
                        { CoalBonus, "Ora può comparire durante l’estrazione del carbone." },
                        { HoneyBonus, "Ora può comparire durante la raccolta del miele." },
                        { Butterfly, "Ora può comparire durante la raccolta di fiori di giorno." },
                        { Moth, "Ora può comparire durante la raccolta di fiori di notte." },
                        { Maggot, "Ora può essere prodotto trasformando i rifiuti in torba." },
                        { PyriteNote, "Nota: non implementato nella versione attuale del gioco." },
                        { RemoteControl, "La mappa permette di controllare a distanza le postazioni di lavoro disponibili. Le azioni remote in un’area richiedono un ricevitore di anime." }
                    }
                },
                {
                    "pl",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "Menu budowy: " },
                        { Diamonds, "Diamenty można teraz wydobywać." },
                        { Marble, "Marmur można teraz wydobywać." },
                        { IronOreBonus, "Może teraz pojawić się podczas wydobywania lub przetwarzania rudy żelaza." },
                        { CoalBonus, "Może teraz pojawić się podczas wydobywania węgla." },
                        { HoneyBonus, "Może teraz pojawić się podczas zbierania miodu." },
                        { Butterfly, "Może teraz pojawić się podczas zbierania kwiatów w dzień." },
                        { Moth, "Może teraz pojawić się podczas zbierania kwiatów w nocy." },
                        { Maggot, "Może teraz powstawać podczas przetwarzania odpadów na torf." },
                        { PyriteNote, "Uwaga: nie zaimplementowano w obecnej wersji gry." },
                        { RemoteControl, "Z mapy można zdalnie sterować dostępnymi stanowiskami pracy. Zdalne działania w danym obszarze wymagają odbiornika dusz." }
                    }
                },
                {
                    "ja",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "建設メニュー：" },
                        { Diamonds, "ダイヤモンドを採掘できるようになります。" },
                        { Marble, "大理石を採掘できるようになります。" },
                        { IronOreBonus, "鉄鉱石の採掘または加工時に入手できるようになります。" },
                        { CoalBonus, "石炭の採掘時に入手できるようになります。" },
                        { HoneyBonus, "ハチミツの採取時に入手できるようになります。" },
                        { Butterfly, "昼間に花を採取すると入手できるようになります。" },
                        { Moth, "夜間に花を採取すると入手できるようになります。" },
                        { Maggot, "廃棄物を泥炭に加工する際に生成されるようになります。" },
                        { PyriteNote, "注：現在のゲームバージョンでは実装されていません。" },
                        { RemoteControl, "マップから利用可能な作業設備を遠隔操作できます。エリア内で遠隔操作するには魂の受信機が必要です。" }
                    }
                },
                {
                    "zh_cn",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "建造菜单：" },
                        { Diamonds, "现在可以开采钻石。" },
                        { Marble, "现在可以开采大理石。" },
                        { IronOreBonus, "现在可在开采或加工铁矿石时获得。" },
                        { CoalBonus, "现在可在开采煤炭时获得。" },
                        { HoneyBonus, "现在可在采集蜂蜜时获得。" },
                        { Butterfly, "现在可在白天采花时获得。" },
                        { Moth, "现在可在夜间采花时获得。" },
                        { Maggot, "现在可在将废料加工成泥炭时获得。" },
                        { PyriteNote, "注意：当前游戏版本中尚未实现。" },
                        { RemoteControl, "可从地图远程控制可用的工作站。要在某区域执行远程操作，需要灵魂接收器。" }
                    }
                },
                {
                    "ko",
                    new Dictionary<string, string>(StringComparer.Ordinal)
                    {
                        { BuildMenu, "건설 메뉴: " },
                        { Diamonds, "이제 다이아몬드를 채굴할 수 있습니다." },
                        { Marble, "이제 대리석을 채굴할 수 있습니다." },
                        { IronOreBonus, "이제 철광석을 채굴하거나 가공할 때 얻을 수 있습니다." },
                        { CoalBonus, "이제 석탄을 채굴할 때 얻을 수 있습니다." },
                        { HoneyBonus, "이제 꿀을 채집할 때 얻을 수 있습니다." },
                        { Butterfly, "이제 낮에 꽃을 채집할 때 얻을 수 있습니다." },
                        { Moth, "이제 밤에 꽃을 채집할 때 얻을 수 있습니다." },
                        { Maggot, "이제 폐기물을 이탄으로 가공할 때 생성될 수 있습니다." },
                        { PyriteNote, "참고: 현재 게임 버전에서는 구현되어 있지 않습니다." },
                        { RemoteControl, "지도에서 이용 가능한 작업대를 원격으로 제어할 수 있습니다. 지역에서 원격 작업을 하려면 영혼 수신기가 필요합니다." }
                    }
                }
            };

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
