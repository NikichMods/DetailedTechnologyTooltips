# Changelog

## 1.1.6 — candidate

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
