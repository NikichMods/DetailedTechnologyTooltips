# Changelog

## 1.0.1 — Unreleased

First stable release candidate.

- Enriches visible Technology recipe unlocks with native requirements and the exact crafting station(s) for that unlocked recipe.
- Enriches visible Technology blueprint/build unlocks with native build requirements and the owning build menu.
- Preserves vanilla-visible unlock ordering and useful existing descriptions.
- Adds concise explanations for specifically verified sparse Work/Perk unlocks.
- Explains Better Save Soul Remote Control: access is from the map, while remote actions in an area require a Soul Receiver.
- Marks Pyrite as not implemented in the current game version instead of implying that its broken vanilla path produces drops.
- Handles grouped/multi-quality recipe requirements using the same native base-name resolution family used by the game's Craft UI.
- Normalizes DTT list spacing for Latin/Korean locales while preserving native Japanese/Simplified-Chinese punctuation behavior.
- Repairs native NGUI wrapping only when it would split a DTT `(xN)` quantity token internally.
- Keeps Technology tooltips inside the visible viewport on the accepted mouse/gamepad paths.
- Supports all 11 languages exposed by Graveyard Keeper 1.407.
- Keeps progression, recipes, builds, save data, hidden unlocks and unrelated tooltip surfaces unchanged.

Development candidates 0.1.0–0.1.2 and the rejected 1.0.0 release candidate were test builds and were not public stable releases.
