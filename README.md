# Detailed Technology Tooltips

A vanilla-friendly informational QoL mod for **Graveyard Keeper 1.407**.

## Status

**Pre-release / project bootstrap.** No public binary has been released yet.

The project is based on a completed static audit of Graveyard Keeper's Technology, recipe, and blueprint data. Production tooltip composition and the first runtime candidate are the next development step.

## Goal

Make Technology-tree unlock tooltips answer the practical questions that matter before spending technology points.

Planned initial scope:
- blueprint unlocks: show native build requirements and the owning build desk/menu;
- ordinary recipe unlocks: show native ingredient requirements and the exact crafting station(s);
- preserve useful vanilla title/description content;
- use the game's own data and localization instead of a hand-maintained wiki table.

## Non-goals

Detailed Technology Tooltips is informational only. It is not intended to change:
- technology costs or progression;
- unlock state;
- recipes or build mechanics;
- save data;
- story/DLC gating;
- hidden/invisible unlock visibility.

It also does not aim to build a recursive "you also need technology X" dependency graph in the initial version.

## Runtime / research

Target: Graveyard Keeper 1.407 on Windows PC with BepInEx 5.

Cross-project host/runtime research is maintained in `NikichMods/GraveyardKeeperResearch`. Project-specific accepted facts and product implications are recorded in `docs/VERIFIED_GAME_DATA.md`.

## License

Original project software source is licensed under the Mozilla Public License 2.0. See `LICENSE` and `LICENSING.md`.
