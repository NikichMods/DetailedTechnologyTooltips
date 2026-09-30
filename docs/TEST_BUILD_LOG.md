# Test Build Log

Canonical record of numbered Detailed Technology Tooltips candidates and their runtime acceptance state.

## 0.1.0 — runtime mechanism confirmed; UX iteration required

### Candidate identity

- Version: `0.1.0`
- Development branch: `dev/0.1.0`
- Exact build source: `20fa919459e8e25f3e2843e1f5d709acb582086a`
- GitHub Actions run: `36705071770`
- CI result: **SUCCESS**
- CI artifact: `DetailedTechnologyTooltips-0.1.0-20fa919459e8e25f3e2843e1f5d709acb582086a`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-0.1.0.dll`
- DLL SHA-256: `b231d55d30116569f091f9857b15786b981d581dd4b7a97445bf4a28a74106be`
- DLL size: 14,848 bytes
- Binary/plugin metadata: `0.1.0`

Numbered candidate bytes are immutable after handoff. Any behavioral source change requires a new candidate version.

### Production evidence gates

#### Native requirements enrichment — READY

- Observable property: visible Technology `Craft` unlocks with non-empty native `needs` gain an ingredients row.
- Canonical owner: `CraftDefinition.needs` (inherited by `ObjectCraftDefinition`).
- Final writer/consumer: `TechUnlock.GetTooltip(Tooltip)` -> `Tooltip.AddData(BubbleWidgetData)`.
- Rendering data: each native `Item.GetItemName()`; label/punctuation from `GJL.L("ingredients")`, `GJL.L(":")`, and `GJL.L(",")`.
- Blast radius: visible Technology `Craft` tooltip composition only.
- Preserved invariants: empty `needs` produces no row; Work/Perk remain vanilla; no recipe/build/progression/save mutation; no hidden-unlock enumeration.
- Acceptance evidence required: representative ordinary recipe + blueprint in real GK 1.407, with visually correct names/counts/wrapping.

#### Exact Technology crafting/build location — READY

- Observable property: ordinary recipe Technology unlocks show that exact recipe's `craft_in`; blueprint unlocks show their exact `builder_ids`.
- Canonical owners: `CraftDefinition.craft_in` and `ObjectCraftDefinition.builder_ids`.
- Existing aggregate writer: `ItemDefinition.GetTooltipData(Item, bool)` appends the item's aggregate `ItemDetails.crafts_in` location last; special sermon path calls `GetTooltipDataCraftAt(Item)`.
- Commit point: while and only while `TechUnlock.GetTooltip` is consuming those item-detail helpers, the aggregate location is suppressed if a successfully composed exact replacement exists; the exact row is then appended through the same `Tooltip`.
- Rendering data: builder/station IDs localized through native `GJL.L(ObjectDefinition.id)`; label/punctuation from native `crafted_at`/comma localization.
- Blast radius: nested item-detail calls made from visible Technology Craft tooltip composition; ordinary item tooltips outside that scope remain vanilla.
- Preserved invariants: if exact location is unavailable/unrenderable, aggregate vanilla location is retained; no gameplay/balance/cache mutation; Work/Perk and hidden unlocks remain vanilla.
- Acceptance evidence required: an ordinary recipe where exact `craft_in` is a strict subset of the item's aggregate locations, a blueprint, and the gamepad combined tooltip path.

### Build evidence

GitHub Actions run `36705071770` completed successfully for exact source SHA `20fa919459e8e25f3e2843e1f5d709acb582086a`:

- restore: success;
- Release build: success;
- identity preparation: success;
- artifact upload: success.

Downloaded artifact was extracted and verified before handoff:

- `BUILD_IDENTITY.txt` source SHA/version matched the intended candidate;
- extracted DLL was non-empty and identified as a Windows PE32 Mono/.NET assembly;
- computed DLL SHA-256 matched `BUILD_IDENTITY.txt`;
- plugin/version identity strings matched `Detailed Technology Tooltips` / `0.1.0`.

### Runtime result — 2026-09-30

User tested the exact 0.1.0 candidate in Graveyard Keeper 1.407 with Russian localization at 2560x1440.

Confirmed:
- ordinary recipe enrichment works and `ingot_metal` shows the exact Furnace location rather than the broader item aggregate;
- blueprint requirements and native builder/menu localization render correctly;
- mouse and gamepad consume the enriched child information;
- useful vanilla description content remains present;
- the supplied log contains the normal Detailed Technology Tooltips startup/binding line and no plugin runtime-disable/error line.

New UX findings:
- long combined gamepad Technology tooltips can extend below the viewport even at 2560x1440;
- native `ingredients` wording is semantically awkward for construction/tool materials in Russian;
- native `crafted_at` wording is awkward for blueprints such as `Yard`;
- native comma localization currently produces visually dense no-space lists in Russian;
- vanilla Work/Perk gathering unlocks such as Precious Metals / Related Ore remain sparse because 0.1.0 intentionally leaves Work/Perk untouched.

Status: the data-owner/mechanism hypothesis is **CONFIRMED**. Candidate 0.1.0 is not the final UX baseline and is not promoted to main.

### Original runtime acceptance matrix

Minimum representative real-game check in Graveyard Keeper 1.407:

1. **Ordinary recipe, exact-location replacement**
   - Open a Technology unlock whose output has broader aggregate crafting locations than the exact recipe (the audited `ingot_metal` case is suitable).
   - Confirm the tooltip keeps useful vanilla output description content.
   - Confirm `Ingredients` reflects that unlock's native `needs`.
   - Confirm `Crafted at` shows only the exact recipe station(s), not the broader item aggregate.

2. **Blueprint**
   - Open a visible build/object unlock with non-empty `needs`.
   - Confirm ingredients/counts are correct.
   - Confirm the shown builder/build desk/menu name is the native localized name.
   - Evaluate whether the reused vanilla `crafted_at` wording is natural enough for a blueprint; wording is a UX acceptance question, not a data-mechanics question.

3. **Gamepad combined tooltip**
   - Focus a Technology node containing Craft unlocks with a gamepad.
   - Confirm the parent combined tooltip includes the same enriched child information without clipping/overlap/unreasonable density.

4. **Blast-radius sanity**
   - Open a normal item tooltip outside the Technology tree for an item with multiple crafting stations.
   - Confirm its vanilla aggregate `Crafted at` behavior is unchanged.

5. **Log**
   - Confirm one normal startup line for Detailed Technology Tooltips and no runtime-disable/error line.

Original matrix is retained as the pre-test plan. The 2026-09-30 result above supersedes its pending status.

## 0.1.1 — UX / Work-Perk enrichment candidate

### Candidate identity

- Version: `0.1.1`
- Development branch: `dev/0.1.1`
- Exact build source: `c0e100a5e1f59b8bd03c057acd11b5cc6b9d5e7b`
- GitHub Actions run: `36718198399`
- CI result: **SUCCESS**
- CI artifact: `DetailedTechnologyTooltips-0.1.1-c0e100a5e1f59b8bd03c057acd11b5cc6b9d5e7b`
- Artifact ID: `11096778233`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-0.1.1.dll`
- DLL SHA-256: `37246259f98a5961ce1c380d1f52bae6cbfbb10770532eb8ac2461e31835e165`
- DLL size: 23,040 bytes
- Binary/plugin metadata: `0.1.1`

The downloaded CI artifact was verified before handoff:
- `BUILD_IDENTITY.txt` matches version `0.1.1` and exact source SHA;
- computed DLL SHA-256 matches the identity file;
- DLL is a non-empty Windows PE32 Mono/.NET assembly;
- embedded product/version strings include `Detailed Technology Tooltips` and `0.1.1`.

### Included READY changes

- approved concise Craft labels for Russian/English:
  - `Нужно:` / `Requires:`
  - `Изготовление:` / `Crafted at:`
  - blueprints: `Строительство:` / `Build menu:`
- readable `, ` separator for Russian/English generated lists;
- Technology-only symmetric safe-area clamp after native bubble placement, including ordering after Gamepad Tooltip Position Fix;
- sparse Work descriptions for diamond and marble;
- sparse gathering-style Perk descriptions for gold ore, silver ore, limestone/lifestone, sulfur, beeswax, bee, butterfly, moth, and maggot.

Explicitly unchanged:
- `p_t_old_books` remains sparse because its exact native consumer is unresolved;
- `p_t_pyrite` remains sparse because current 1.407 data writes `p_t_pirit` while the coal-drop expression reads `p_t_pyrite`;
- ordinary Work/Perk entries with authored descriptions remain vanilla;
- other languages retain the prior native Craft labels and receive no generated sparse Work/Perk prose in this candidate.

### Runtime acceptance requested

1. Ordinary recipe: confirm `Нужно:` + exact `Изготовление:` station.
2. Blueprint: confirm `Нужно:` + `Строительство:` and readable spaced lists.
3. Long combined gamepad Technology tooltip: confirm it remains within the viewport; verify no regression in normal mouse placement.
4. Precious Metals: verify Gold ore and Silver ore receive the concise iron-ore source explanation.
5. Related Ore: verify Limestone and Sulfur receive the coal-source explanation; Pyrite stays sparse.
6. Insects or Decay: verify at least one of Bee/Beeswax/Butterfly/Moth/Maggot receives the intended concise source explanation.
7. Research: verify Old books remains sparse.
8. Normal item tooltip outside Technology: verify vanilla aggregate crafting locations are unchanged.
9. Return `LogOutput.log`; confirm normal `Detailed Technology Tooltips 0.1.1 loaded` and no runtime-disable / viewport-safety error.

Status: **runtime accepted for its intended 0.1.1 gates**.

### Runtime acceptance — 2026-09-30

User tested the exact 0.1.1 candidate in Graveyard Keeper 1.407 at 2560x1440 with PrayerClarity: Rebalanced 0.2.52 and the current mod set.

Accepted:
- Russian `Нужно:`, `Изготовление:`, `Строительство:` wording;
- English `Requires:`, `Crafted at:`, `Build menu:` wording;
- spaced list separators;
- sparse Work/Perk descriptions for the proved gathering cases;
- symmetric Technology tooltip viewport safety: the previously overflowing long gamepad tooltip was translated upward and remained within the viewport; no top/bottom overflow was observed while browsing;
- PrayerClarity Technology presentation showed no observed regression.

New follow-up gaps opened after 0.1.1:
- some recipes with multi-quality/group requirements (representative runtime examples: Carved Wood, Notes, Book) still omit the requirements row;
- mod-generated Craft detail rows are visibly left-aligned inside the combined gamepad tooltip while the native item-detail family is centered;
- Pyrite should receive the separately accepted informational note that it is not implemented in the current game version.

These follow-ups are not regressions in the accepted 0.1.1 mechanisms; they open new 0.1.2 evidence gates.

## 0.1.2 — grouped requirements / alignment / Pyrite note candidate

### Candidate identity

- Version: `0.1.2`
- Development branch: `dev/0.1.2`
- Exact build source: `5aaa3d4affb83d362146536f6f2056e490f3b8b3`
- GitHub Actions run: `36727412677`
- CI result: **SUCCESS**, 0 warnings / 0 errors
- CI artifact: `DetailedTechnologyTooltips-0.1.2-5aaa3d4affb83d362146536f6f2056e490f3b8b3`
- Artifact ID: `11103162487`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-0.1.2.dll`
- DLL SHA-256: `b75d642a9cb26c6d0f15a2775c7cce267f05c4655f7994a34dfadc36e7a53050`
- DLL size: 24,064 bytes
- Binary/plugin metadata: `0.1.2`

Downloaded CI artifact verification:
- `BUILD_IDENTITY.txt` matches version and exact source SHA;
- computed DLL SHA-256 matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded strings include the plugin GUID/name/version and the new Pyrite note.

### Included READY changes

- group/multi-quality requirements now use the vanilla Craft UI's base-name resolution family instead of dropping the whole requirements row when the authored base ID has no direct ItemDefinition;
- generated Craft requirements/location rows use native item-detail `Center` alignment;
- generated Work/Perk descriptions retain `Left` alignment;
- Pyrite receives the accepted Russian/English “not implemented in the current game version” note;
- no PrayerClarity compatibility behavior was changed because accepted 0.1.1 runtime showed no collision.

### Runtime acceptance requested

Only new 0.1.2 properties need testing:

1. Carved Wood: `Нужно:` row appears and resolves the grouped chisel requirement naturally.
2. Notes: `Нужно:` row appears for Story / Pen and Ink / Clean Paper.
3. Book: `Нужно:` row appears for Cover / Chapter.
4. Combined gamepad tooltip: `Нужно:` / `Изготовление:` rows visually center like vanilla item-detail rows.
5. Related Ore: Pyrite shows the implementation-status note; Limestone/Sulfur behavior remains as accepted in 0.1.1.
6. One PrayerClarity Technology tooltip sanity check only if convenient; no repeat of the full prayer acceptance matrix is required.
7. Return `LogOutput.log` and verify no DTT initialization/runtime-disable/viewport-safety error.

Already accepted in 0.1.1 and not necessary to repeat: general RU/EN wording, list separators, ordinary exact station mapping, blueprint builder mapping, sparse proved Work/Perk explanations, and general viewport top/bottom clamping.

### Runtime acceptance — 2026-09-30

Status: **ACCEPTED** for the exact 0.1.2 candidate built from `5aaa3d4affb83d362146536f6f2056e490f3b8b3`.

User acceptance evidence:
- Carved Wood now shows its grouped/multi-quality requirement instead of dropping the `Нужно:` row;
- Notes and Book now show their complete requirement rows;
- generated Craft detail rows are visually centered naturally in the long combined gamepad tooltip;
- Pyrite shows the accepted current-version implementation-status note;
- no new clipping/viewport regression was observed in the checked Technology tooltips.

Support-log evidence from the accepted run:
- Graveyard Keeper 1.407, BepInEx 5.4.23.5, Windows 64-bit;
- DTT 0.1.2 loaded successfully and bound the Technology tooltip contract against Assembly-CSharp MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`;
- no DTT runtime-enrichment disable, viewport-safety disable, or DTT initialization failure appeared during the session;
- PrayerClarity: Rebalanced 0.2.52 loaded and remained active in the same run.

The unrelated Unity/resource/sprite/idle-point errors present in the shared game log are outside DTT ownership and did not coincide with a DTT failure signal.

0.1.2 is now the accepted behavior baseline. Its numbered bytes remain frozen. Any further production behavior change requires a new version.

## 1.0.0 — release candidate

### Candidate identity

- Version: `1.0.0`
- Development branch: `dev/1.0.0`
- Exact build source: `d7dc125498871360c6a7674bb9a316ce5ee746d7`
- GitHub Actions run: `36766500791`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization validation: **11 languages x 10 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.0.0-d7dc125498871360c6a7674bb9a316ce5ee746d7`
- Artifact ID: `11121525665`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.0.0.dll`
- DLL SHA-256: `07928700aaded36f61f7172dc59fcd3b50a18ae874cb4c1cd6b871fcdd566853`
- DLL size: 34,816 bytes
- Binary/plugin metadata: `1.0.0`
- Assembly informational version: `1.0.0+d7dc125498871360c6a7674bb9a316ce5ee746d7`

The extracted CI DLL hash matches the recorded build identity and the binary is a valid non-empty Windows Mono/.NET assembly.

The earlier internal 1.0.0 CI artifact from source `5c2e13e3be57ee37fa9b89c020e6cbb413543527` was superseded before user handoff after the pre-release audit tightened unknown-locale fail-closed behavior. It was never handed to the user and is not an acceptance candidate.

### Delta from accepted 0.1.2

The accepted 0.1.2 gameplay/UI mechanics are unchanged. The 1.0.0 release candidate adds complete DTT-owned text coverage for all 11 current 1.407 languages and stable support-log event IDs. Native item/station/build-desk names remain game-owned.

### Runtime acceptance state

Status: **PENDING**.

Required new evidence is localization-focused:
1. Confirm the normal `DTT_READY version=1.0.0` startup event and no DTT failure/disable event.
2. Cycle through all 11 game languages once.
3. Visually inspect representative DTT text in at least one Latin non-English language and one CJK language.
4. Include a blueprint, a sparse Work/Perk explanation, and Pyrite among those checks.
5. Confirm no conspicuous fallback English, missing glyph/font issue, or new clipping.
6. Return the full BepInEx support log.

Already accepted and not required to repeat exhaustively: exact recipe/blueprint data, grouped requirements, centered Craft rows, Russian/English sparse text, Pyrite semantics, general viewport clamping and PrayerClarity compatibility.

The 1.0.0 numbered candidate is immutable after handoff. Stable publication remains blocked until explicit user acceptance.

### Runtime result — 2026-09-30

Status: **REJECTED** as a stable release candidate.

The exact handed 1.0.0 binary from source `d7dc125498871360c6a7674bb9a316ce5ee746d7` started cleanly in Graveyard Keeper 1.407:
- `DTT_READY version=1.0.0` was present against host MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`;
- no `DTT_INIT_FAILED`, `DTT_RUNTIME_DISABLED` or `DTT_VIEWPORT_DISABLED` event appeared in the submitted session;
- the session exercised all 11 current game languages.

User-visible blockers:
1. DTT-generated lists inherit the game's localized comma token literally. In several non-English/Russian locales this produces no spacing after an ordinary comma (confirmed visually in Italian, German and Korean). Japanese / Simplified Chinese punctuation must retain CJK spacing conventions rather than receiving a blanket Western space.
2. In Simplified Chinese the native NGUI wrapping path can split an `(xN)` quantity cluster and orphan the closing parenthesis on the next visual line.

Additional product-scope candidates raised during this test:
- the Better Save Soul `fake_global_craft` / Remote Control visible unlock is structurally sparse and does not explain that remote workstation control is accessed from the map and depends on a Soul Receiver in the target area;
- Quality-fertilizer technologies may warrant a concise semantic note explaining seed/crop quality improvement, but exact native ownership/effects require additional evidence before production.

The 1.0.0 bytes remain immutable because they were handed to the user. Any corrected candidate must use a new version.

