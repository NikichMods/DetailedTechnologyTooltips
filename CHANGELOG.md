# Changelog

## 1.2.11 — prerelease candidate, 2026-10-22

This development candidate is not a published stable release. It preserves the 1.2.10 presentation accepted in game and removes the temporary calibration UI for final review.

- Adds concise purpose descriptions for 104 distinct visible blueprints (105 Technology references), translated into all 11 current game languages.
- Uses native material icons with names/quantities, active-language material-based width, and common mouse/gamepad alignment and spacing for blueprint and nonprayer recipe unlocks.
- Adds selective native church/graveyard-quality and alchemy-category symbols, preserving words and sparse warm-red emphasis.
- Preserves native item descriptions, native quantities and exact recipe stations; blueprint locations retain complete native builder coverage.
- Leaves prayer unlocks to vanilla/PrayerClarity, while continuing to enrich other unlocks in mixed technologies. No DTT carousel is introduced.
- Avoids repeated native type discovery during branch preparation; the reported branch-switch delay was corrected and accepted in 1.2.9.
- Removes the F2 window, input/UI callbacks, sliders and session settings export. Keeps accepted icon size 20, Y 0, indent 5 spaces, opacity 100%, centered title/purpose/location, left materials and gaps 2/6/6/10 as fixed defaults.
- Progression, recipes, construction mechanics, hidden content and saves remain unchanged.

## 1.1.6 — 2026-10-01

- Blueprint location rows are now deterministic: DTT lists every native build menu in the current 1.407 balance that builds the same `out_obj` / `build_type`, regardless of current save progression.
- Removes the 1.1.5 save-dependent `GameSave.IsCraftVisible` location filter and its MainGame/GameSave reflection bindings.
- Hidden blueprint records are still not rendered as separate Technology unlocks; only their native builder location names can contribute to the complete location list.
- Ingredient quantity wrapping remains unchanged; DTT still only repairs a quantity token when NGUI splits the `(xN)` token itself.

## 1.1.5 — candidate

- Fixes the 1.1.4 startup regression by binding the static `MainGame.me` field through the correct static reflection path.
- Multi-builder blueprint-location behavior is otherwise unchanged from 1.1.4.

## 1.1.4 — candidate

- Blueprint Technology tooltips now aggregate all build menus that the same Technology unlocks for the same construction, including authored `@`-hidden sibling blueprint records.
- If the same construction is already independently available from another build menu in the current save, that currently visible native location is included as well.
- Independently locked or story-gated same-output variants remain hidden until the game itself reports them visible.
- Requirements still come from the visible Technology blueprint; ordinary recipe locations, progression, build data and saves are unchanged.

## 1.0.2 — 2026-10-01

First stable release.

- Enriches visible Technology recipe unlocks with native requirements and the exact crafting station(s) for that unlocked recipe.
- Enriches visible Technology blueprint/build unlocks with native build requirements and the owning build menu.
- Preserves vanilla-visible unlock ordering and useful existing descriptions.
- Adds concise explanations for specifically verified sparse Work/Perk unlocks.
- Explains Better Save Soul Remote Control: access is from the map, while remote actions in an area require a Soul Receiver.
- Marks Pyrite as not implemented in the current game version instead of implying that its broken vanilla path produces drops.
- Handles grouped/multi-quality recipe requirements using the same native base-name resolution family used by the game's Craft UI.
- Normalizes DTT list spacing for Latin/Korean locales.
- Preserves native Japanese/Simplified-Chinese punctuation and adds an invisible break opportunity after CJK separators so they do not start wrapped lines.
- Repairs native NGUI wrapping only when it would split a DTT `(xN)` quantity token internally.
- Keeps Technology tooltips inside the visible viewport on the accepted mouse/gamepad paths.
- Supports all 11 languages exposed by Graveyard Keeper 1.407.
- Keeps progression, recipes, builds, save data, hidden unlocks and unrelated tooltip surfaces unchanged.

Development candidates 0.1.0–0.1.2 and rejected 1.0.0/1.0.1 release candidates were test builds and were not public stable releases.
