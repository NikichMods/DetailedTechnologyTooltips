# Detailed Technology Tooltips

A vanilla-friendly informational QoL mod for **Graveyard Keeper 1.407** using **BepInEx 5**.

Detailed Technology Tooltips makes visible Technology-tree unlocks explain what they offer, what materials they need and where they belong without changing progression, recipes, builds, saves, or hidden content.

## Status

**[v1.2.11 stable release](https://github.com/NikichMods/DetailedTechnologyTooltips/releases/tag/v1.2.11).** Adds concise blueprint purposes and native icon-based material rows, with consistent mouse/gamepad presentation in all 11 game languages.

## What it does

For visible Technology unlocks:

- **blueprints/build unlocks** add concise purpose descriptions, with related upgrades highlighting their main difference;
- **ordinary recipes** preserve useful native item descriptions and show native requirements plus the exact crafting station(s) owned by that unlocked recipe;
- material rows combine native icons, names and quantities; tooltip width follows the current language's material rows, subject to the viewport limit;
- sparse warm-red accents emphasize useful differences and effects; native symbols identify church/graveyard quality and alchemy categories alongside explanatory text;
- blueprint locations list every native build menu / build desk that owns the same construction variant in the current 1.407 balance;
- mouse and gamepad share alignment and spacing; gamepad keeps the combined native tooltip;
- useful existing vanilla descriptions are preserved;
- sparse Work/Perk unlocks receive a short explanation only where the current 1.407 data path has been specifically verified;
- Pyrite is marked as not implemented in the current game version rather than implying that the broken vanilla unlock produces drops;
- Better Save Soul's Remote Control unlock explains that the feature is accessed from the map and that remote actions require a Soul Receiver in the target area;
- authored hidden `@` unlocks remain hidden.

The mod uses native game data for item quantities, item names, crafting stations and build-desk names. It does not maintain a separate recipe/location database.

## Languages

Detailed Technology Tooltips supports all languages exposed by the current Graveyard Keeper 1.407 PC language selector:

- English
- German
- French
- Brazilian Portuguese
- Spanish
- Russian
- Italian
- Polish
- Japanese
- Simplified Chinese
- Korean

Native item/station names continue to come directly from Graveyard Keeper's active localization. DTT translates only its own added labels and explanatory text.

## Installation

1. Install BepInEx 5 for Graveyard Keeper.
2. Copy `DetailedTechnologyTooltips.dll` into `Graveyard Keeper\BepInEx\plugins`.
3. Start the game.

When updating, replace the existing `DetailedTechnologyTooltips.dll`. Do not keep multiple versioned copies beside it.

The mod uses a fixed appearance and has no configuration window or F2 shortcut. No separate translation files are needed.

## Compatibility

Tested on **Graveyard Keeper 1.407 (Steam, Windows)** with all DLC installed.

Other game versions, storefront builds, operating systems and DLC configurations are currently untested rather than known incompatible.

The accepted runtime was also exercised alongside a large mod set including PrayerClarity: Rebalanced; no Detailed Technology Tooltips collision was observed in the tested Technology tooltip paths.

In the redesign, DTT leaves prayer unlock descriptions to the game or PrayerClarity. It still enriches blueprints and nonprayer recipes in mixed technologies. PrayerClarity keeps ownership of its own navigation; DTT adds no carousel. This division does not require PrayerClarity to be installed. A full compatibility matrix for every PrayerClarity edition has not been established.

## Scope and non-goals

Detailed Technology Tooltips is informational only. It does not modify:

- technology prices, availability or unlock state;
- recipes, build definitions or crafting/build mechanics;
- save data;
- story/DLC gating;
- authored invisible unlocks;
- unrelated tooltip surfaces.

It deliberately does not construct a recursive dependency graph or guess hidden prerequisites/locations from fields such as `sub_zone_id`.

## Development / evidence

Canonical project evidence is kept in:

- `docs/VERIFIED_GAME_DATA.md`
- `docs/TEST_BUILD_LOG.md`
- current candidate/release documents under `docs/`

Reusable Graveyard Keeper host/runtime research is maintained in `NikichMods/GraveyardKeeperResearch`.

## License

Original project software source is licensed under the Mozilla Public License 2.0. See `LICENSE` and `LICENSING.md`.

Graveyard Keeper binaries, assets, localization and decompiled game material are not part of this repository and remain under their respective rights.
