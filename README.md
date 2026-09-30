# Detailed Technology Tooltips

A vanilla-friendly informational QoL mod for **Graveyard Keeper 1.407** using **BepInEx 5**.

Detailed Technology Tooltips makes visible Technology-tree unlocks explain what they need and where they belong without changing progression, recipes, builds, saves, or hidden content.

## Status

**1.0.2 stable release.**

The accepted gameplay/UI baseline is 0.1.2. Version 1.0.2 carries that behavior forward, completes localization for every language exposed by Graveyard Keeper 1.407, fixes locale-specific list formatting/wrapping found during 1.0.0–1.0.1 testing, and explains the otherwise opaque Better Save Soul Remote Control unlock.

The current stable release is **v1.0.2**.

## What it does

For visible Technology unlocks:

- **ordinary recipes** show their native requirements and the exact crafting station(s) owned by that unlocked recipe;
- **blueprints/build unlocks** show their native build requirements and the owning build menu / build desk;
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

The mod has no configuration options.

## Compatibility

Tested on **Graveyard Keeper 1.407 (Steam, Windows)** with all DLC installed.

Other game versions, storefront builds, operating systems and DLC configurations are currently untested rather than known incompatible.

The accepted runtime was also exercised alongside a large mod set including PrayerClarity: Rebalanced; no Detailed Technology Tooltips collision was observed in the tested Technology tooltip paths.

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
