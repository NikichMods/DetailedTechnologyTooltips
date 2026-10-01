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

## 1.0.1 — corrected release candidate

### Candidate identity

- Version: `1.0.1`
- Development branch: `dev/1.0.1`
- Exact build source: `cedabaf0de8d2fc323b9a747020d163fe9a2af1d`
- GitHub Actions run: `36774008316`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 11 DTT keys — PASS**, including Latin/Korean spacing, CJK separator preservation and deterministic quantity-token repair cases.
- CI artifact: `DetailedTechnologyTooltips-1.0.1-cedabaf0de8d2fc323b9a747020d163fe9a2af1d`
- Artifact ID: `11125070491`
- Artifact ZIP digest: `sha256:286c4f3e28306755772d54f2ac23645e8d5831f20790a34151eac3aa4567ab1b`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.0.1.dll`
- DLL SHA-256: `5d7db4770ebc5caa7c696c01ca8da7ae73b7a713e4bf7986624530410368772f`
- DLL size: 40,960 bytes
- Binary/plugin metadata: `1.0.1`
- Assembly informational version: `1.0.1+cedabaf0de8d2fc323b9a747020d163fe9a2af1d`

The exact CI ZIP was downloaded and extracted before handoff. The extracted DLL hash matches `BUILD_IDENTITY.txt`; the DLL is a non-empty Windows PE32 Mono/.NET assembly and its embedded plugin identity/version match this record.

### Delta from rejected 1.0.0

- normalizes DTT list spacing for Latin/Korean locales while preserving Japanese/Simplified-Chinese punctuation behavior;
- repairs only DTT-owned requirement rows when native NGUI proves an `(xN)` token was split internally;
- adds the verified Better Save Soul Remote Control explanation in all 11 current languages;
- updates release documentation and version-independent exact-artifact publishing plumbing.

Fertilizer/seed-quality explanation remains intentionally deferred behind a separate evidence gate and is not part of this candidate.

### Runtime acceptance state

Status: **PENDING**.

Focused 1.0.1 test only:
1. Italian/German/Korean: ordinary comma-separated DTT lists have readable spacing.
2. Japanese/Simplified Chinese: natural CJK punctuation remains, with no injected Western space.
3. Revisit the previously failing long Simplified-Chinese requirements tooltip and confirm no line break occurs inside `(xN)`.
4. Remote Control: verify the new explanation in Russian plus one non-Russian locale.
5. Confirm no conspicuous clipping, missing glyphs or fallback-English text.
6. Return the full `BepInEx\\LogOutput.log`; expected startup marker is `DTT_READY version=1.0.1`, with no `DTT_INIT_FAILED`, `DTT_RUNTIME_DISABLED`, `DTT_VIEWPORT_DISABLED` or `DTT_WRAP_REPAIR_DISABLED`.

All 0.1.2-accepted mechanics remain reusable evidence and do not need exhaustive repetition.

### Runtime result — 2026-10-01

Status: **REJECTED for stable promotion due to one remaining CJK typography defect**.

Accepted from the exact 1.0.1 candidate:
- Italian, German, Polish and other checked Latin-script DTT lists have readable spacing after ordinary commas;
- Simplified Chinese no longer splits inside an `(xN)` token;
- Remote Control explanation is accepted in Russian and English;
- no clipping, missing glyphs, fallback-English regression or DTT runtime failure was observed;
- support log contains only the normal `DTT_READY version=1.0.1` DTT event and no DTT disable/failure event.

Remaining blocker found by review of the Japanese screenshot:
- a DTT list line can begin with the Japanese separator `、` (representative: the second ingredient after `鉄インゴット (x2)`).
- This is readable but typographically undesirable and should be corrected before the stable release.

The handed 1.0.1 bytes remain immutable. The correction moves to 1.0.2.

## 1.0.2 — final CJK typography release candidate

### Candidate identity

- Version: `1.0.2`
- Development branch: `dev/1.0.2`
- Exact build source: `9653174c320f0d7139d9e49a2a041527e5530bd2`
- GitHub Actions run: `36784735410`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 11 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.0.2-9653174c320f0d7139d9e49a2a041527e5530bd2`
- Artifact ID: `11129376780`
- Artifact ZIP digest: `sha256:106db57299a5da14132d3cc17966b206be29babfc8d72b3190b9ba7038199e0a`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.0.2.dll`
- DLL SHA-256: `986a41e660db7d816ee896a6c624f009063274ad93eb4bb1d212f3dd712f8f5f`
- DLL size: 40,960 bytes
- Binary/plugin metadata: `1.0.2`
- Assembly informational version: `1.0.2+9653174c320f0d7139d9e49a2a041527e5530bd2`

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, exact source SHA and DLL hash;
- extracted DLL hash matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded plugin identity/version and `DTT_READY version=1.0.2` marker match this record.

### Delta from rejected 1.0.1

No gameplay/data semantics changed.

The only player-facing behavior change is the CJK list separator formatting:
- Japanese/Simplified-Chinese DTT separators retain their native visible punctuation;
- an invisible zero-width break opportunity is appended after the separator, allowing NGUI to wrap after the punctuation instead of placing it at the start of the next line;
- Latin/Korean spacing and the accepted quantity-token repair are unchanged.

### Runtime acceptance state

Status: **PENDING**.

Required focused evidence:
1. Japanese representative list: no wrapped line begins with `、`.
2. Simplified-Chinese sanity check: no visible Western spacing is introduced and `(xN)` remains intact.
3. Support log contains `DTT_READY version=1.0.2` and no DTT failure/disable marker.

Everything else remains covered by accepted prior runtime evidence.

### Runtime acceptance — 2026-10-01

Status: **ACCEPTED** for stable promotion.

User reviewed the exact 1.0.2 candidate built from `9653174c320f0d7139d9e49a2a041527e5530bd2` in Graveyard Keeper 1.407.

Accepted visual evidence:
- Japanese DTT lists no longer start a wrapped line with `、`; the separator stays with the preceding item while the following item may wrap naturally.
- Simplified Chinese keeps native-looking CJK punctuation with no injected visible Western spacing.
- Simplified-Chinese `(xN)` quantity clusters remain internally intact in the previously failing long tooltip.
- Korean, English, Spanish and the additional checked layouts remain visually coherent; no new clipping, missing glyphs or fallback-language text was observed.
- Long embalming/injection Technology tooltips remain within the visible viewport.

Support-log evidence:
- `Detailed Technology Tooltips 1.0.2` is loaded by BepInEx;
- `DTT_READY version=1.0.2 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364` is present;
- no DTT initialization/runtime/viewport/wrap-repair disable marker appears in the submitted session;
- the run exercised Japanese, Simplified Chinese, Korean and the other current game locales during the Technology-tree checks.

The exact 1.0.2 production bytes are now the accepted stable-release artifact. No further production-source mutation is permitted under version 1.0.2.


## Stable promotion — 1.0.2 — 2026-10-01

Status: **PUBLISHED**.

- Accepted production source: `9653174c320f0d7139d9e49a2a041527e5530bd2`.
- Accepted CI run: `36784735410`.
- Accepted CI artifact: `DetailedTechnologyTooltips-1.0.2-9653174c320f0d7139d9e49a2a041527e5530bd2` (artifact ID `11129376780`).
- Accepted DLL SHA-256: `986a41e660db7d816ee896a6c624f009063274ad93eb4bb1d212f3dd712f8f5f`.
- Stable-promotion metadata/main commit: `b3b6265924530c744cd7a06513d925944ee64b2f`.
- Publish workflow run: `36786460026` — **SUCCESS**.
- Post-promotion main build run: `36786460044` — **SUCCESS**.
- GitHub Release: `v1.0.2` (release ID `400486378`), target `9653174c320f0d7139d9e49a2a041527e5530bd2`.
- Stable asset: `DetailedTechnologyTooltips.dll`, 40,960 bytes.
- Published asset digest: `sha256:986a41e660db7d816ee896a6c624f009063274ad93eb4bb1d212f3dd712f8f5f`.

The published stable asset digest exactly matches the runtime-accepted 1.0.2 DLL. No production-source mutation occurred after the accepted source; the intervening commits contain acceptance documentation and release metadata only.


## 1.1.0 — semantic Technology tooltip expansion candidate

### Candidate identity

- Version: `1.1.0`
- Development branch: `dev/1.1.0`
- Exact build source: `813dc29bc905267288ad83d3f85df5274810b680`
- GitHub Actions run: `36802495848`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 38 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.1.0-813dc29bc905267288ad83d3f85df5274810b680`
- Artifact ID: `11136522564`
- Artifact ZIP digest: `sha256:728ca10529e559941063605cf7a06ad312ab9386a00b390cc3240fae0814dc49`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.1.0.dll`
- DLL SHA-256: `bdf58c241c120fd2767849c863347bc3f1744d019d72992753c1b457fb1c64ee`
- DLL size: 80,384 bytes
- Binary/plugin metadata: `1.1.0`
- Assembly informational version: `1.1.0+813dc29bc905267288ad83d3f85df5274810b680`

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, exact source SHA and DLL hash;
- computed DLL SHA-256 matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded plugin identity/version and representative new semantic strings match this candidate.

### Included READY changes

- manual-plot fertilizer explanations:
  - Peat: crop/seed yield increase plus 20% growth-time reduction for one crop cycle;
  - Boost I/II: 40% / 60% growth-time reduction for one crop cycle;
  - Quality I/II: increased yield plus 1 / 2 next-quality crop(s) and seed(s);
- Grape/Hops growth unlocks:
  - replace misleading generic `Create` title with growth semantics;
  - show four-seed requirement;
  - show Vineyard / vine-trellis location;
  - show Merchant / Miller as the primary seed vendor;
- Super mushroom: preserve authored flavor and add that red-mushroom gathering is unlocked;
- accepted authored-Perk clarifications for Jeweler, Wine Master, Writer, Playwright, Industriousness, Engineer, Sword Master, Persistence, Butcher, Doctor, Cultist and Blacksmith;
- Big Guy: temporarily correct the stale authored `+1/+1` presentation to current 1.407 `+2/+2` only while the Technology tooltip is being composed, then restore the cached vanilla string; unexpected localized text fails closed to vanilla;
- Pyrite note: remove the misleading temporary-version qualifier and state only that obtaining pyrite while mining coal does not work;
- all new DTT-owned semantic text is present for all 11 current game languages;
- prior 1.0.2 CJK/list/wrap/viewport behavior remains unchanged.

### Runtime acceptance requested

Focus only on the new 1.1.0 properties; stable 1.0.2 mechanics do not need exhaustive repetition.

1. **Fertilizers, Russian, gamepad**
   - Peat: confirm the one-cycle yield/seeds/+20%-time explanation is readable.
   - Simple fertilizers: confirm Boost I and Quality I explanations both appear in the combined tooltip.
   - Complex fertilizers: confirm Boost II and Quality II explanations both appear and the combined tooltip remains usable.

2. **Grape farming, Russian, gamepad**
   - Grapes/Hops use `Выращивание`, not `Создать`.
   - each shows 4 matching seeds;
   - location reads as Vineyard / vine trellis;
   - Grapes point to Merchant, Hops to Miller;
   - combined tooltip has no clipping/overlap or unreasonable density.

3. **Authored Work/Perk enrichment, Russian**
   - Super mushroom keeps its vanilla flavor and adds `Открывает сбор красных грибов.`
   - Big Guy shows only the corrected `+2 урон, +2 защита` values.
   - Check representative appended Perks: Jeweler, Wine Master, Doctor, Cultist and Blacksmith.
   - Verify native `(s1)` quality-icon markup renders as the normal quality star rather than literal text.

4. **Pyrite, Russian**
   - note reads: `Примечание: получение пирита при добыче угля не работает.`

5. **Localization sanity**
   - English: inspect one quality-score Perk and Grape farming.
   - Japanese or Simplified Chinese: inspect one new long Perk/fertilizer tooltip for readable wrapping, native icon rendering, no fallback English and no missing glyphs.
   - No need to repeat the full 1.0.2 CJK separator test unless a new regression is visible.

6. **Support log**
   - expected startup marker: `DTT_READY version=1.1.0 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364`;
   - no `DTT_INIT_FAILED`, `DTT_RUNTIME_DISABLED`, `DTT_VIEWPORT_DISABLED` or `DTT_WRAP_REPAIR_DISABLED`.

Status: **PENDING USER RUNTIME ACCEPTANCE**.

The 1.1.0 numbered candidate bytes are immutable after handoff. Stable 1.0.2 remains the published baseline until explicit acceptance and later promotion.


### Runtime result — 2026-10-01 — 1.1.0

Status: **SUPERSEDED FOR PRESENTATION/COPY POLISH**. The exact 1.1.0 bytes remain immutable; stable 1.0.2 remains published.

Accepted from the user’s Graveyard Keeper 1.407 runtime review:
- DTT started normally as `1.1.0` against host MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`; no DTT failure/disable marker was found in the returned support log.
- Peat presentation is accepted.
- fertilizer effect presentation is mechanically correct; the Russian Quality wording needs only a natural-language polish.
- Grape/Hops growth presentation, four-seed requirements, Vineyard/trellis location and Merchant/Miller seed-source rows are accepted visually.
- native quality-star markup renders correctly in Russian, English and Simplified Chinese for checked perk rows.
- Big Guy’s stale vanilla values are corrected successfully to `+2 damage, +2 defense`.
- Simplified-Chinese DTT additions render coherently with no missing glyph/fallback problem in the checked Playwright, Peat and Grape-farming examples.

Observed polish issues moved to 1.1.1:
1. Butcher/Doctor before/after probabilities read less clearly without the earlier arrow notation.
2. appended DTT explanations visually merge with authored vanilla lore; one blank line is preferred over brackets/italics.
3. Russian Quality-fertilizer wording `семя следующего качества` is awkward.
4. Russian Pyrite note hardcodes `пирит` while the native visible unlock name is `Серный колчедан`; the note should reuse the native localized `p_t_pyrite` name in every locale.
5. Simplified Chinese shows a line beginning with the normal full stop `。` inside the vanilla Playwright paragraph. This is a native paragraph-wrap typography artifact, not a missing glyph and not caused by the DTT-added quality row. It is intentionally left outside 1.1.1 scope.

Cultist was not checked in this runtime pass and remains on the next focused checklist.


## 1.1.1 — runtime copy-polish candidate

### Candidate identity

- Version: `1.1.1`
- Development branch: `dev/1.1.1`
- Exact build source: `1cbc36d5815bbb28a64047d84257174c39ab7da4`
- GitHub Actions run: `36839388438`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 38 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.1.1-1cbc36d5815bbb28a64047d84257174c39ab7da4`
- Artifact ID: `11150338334`
- Artifact ZIP digest: `sha256:1086b9af66ad5afe43b6bfa16ffbec98b0c2fa10fc1b91fa4827e074bd939292`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.1.1.dll`
- DLL SHA-256: `88f02edb4d4bc1e7ddcfb8d19db18042ddd5f8b393f1e89dc08b7b209db45e11`
- DLL size: 80,384 bytes
- Binary/plugin metadata: `1.1.1`
- Assembly informational version: `1.1.1+1cbc36d5815bbb28a64047d84257174c39ab7da4`

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, exact source SHA and DLL hash;
- computed DLL SHA-256 matches the identity file;
- binary contains the 1.1.1 DTT readiness marker;
- representative English/Russian before→after strings, Russian Quality-fertilizer wording and native-name Pyrite template are present in the exact DLL.

### Delta from 1.1.0

No gameplay/progression/data semantics changed.

- Butcher and Doctor now use explicit before→after notation with `→` in every supported DTT locale.
- authored Work/Perk descriptions that receive a DTT clarification get one blank line between vanilla text and the DTT addition; untouched authored perks remain visually unchanged.
- Russian Quality fertilizer I/II wording now says the seed is of the same quality as the next-quality crop rather than the awkward `семя следующего качества`.
- Pyrite note no longer owns a translated mineral name. It formats the active game’s native `GJL.L("p_t_pyrite")` name into the note, so terminology must match the visible gathering-unlock title in every locale.
- the Simplified-Chinese full stop observed at the start of a wrapped vanilla Playwright line is deliberately unchanged: it is a vanilla paragraph-wrap typography artifact, not a DTT glyph/localization failure.

### Focused runtime acceptance requested

Only the 1.1.1 polish needs rechecking:

1. **Russian Butcher + Doctor**
   - confirm one blank line visually separates vanilla lore from the DTT clarification;
   - confirm `25% → 0%` and Doctor’s two before→after pairs are immediately understandable;
   - confirm the `→` glyph renders normally.

2. **Russian Quality fertilizer I**
   - confirm the revised `...урожая следующего качества и 1 семя того же качества` wording reads naturally.
   - Quality II can be checked only if convenient; it uses the same wording pattern.

3. **Russian Pyrite**
   - the visible gathering name and the note must use the same native term;
   - expected current Russian shape: `Примечание: «Серный колчедан» не выпадает при добыче угля.`

4. **Cultist**
   - inspect once in Russian because it was missed in the 1.1.0 pass;
   - confirm the clarification is understandable and separated from vanilla text by one blank line.

5. **One CJK arrow sanity check**
   - Chinese or Japanese Butcher/Doctor: confirm `→` is a real glyph, with no square/fallback/missing character.
   - no need to repeat Peat/Grape/Playwright unless a new regression is visible.

6. **Support log**
   - expected: `DTT_READY version=1.1.1 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364`;
   - no DTT initialization/runtime/viewport/wrap-repair disable marker.

Status: **PENDING USER RUNTIME ACCEPTANCE**.

The numbered 1.1.1 bytes are immutable after handoff. Stable 1.0.2 remains the published baseline until explicit acceptance/promotion of the semantic expansion.


### Runtime result — 2026-10-01 — 1.1.1

Status: **SUPERSEDED FOR FINAL COPY POLISH**. Exact 1.1.1 bytes remain immutable; stable 1.0.2 remains published.

User runtime evidence on Graveyard Keeper 1.407:
- DTT loaded as `1.1.1` with expected verified host MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`.
- the blank line separating vanilla authored text from DTT-added mechanics is accepted.
- native quality-star icon rendering remains correct.
- Butcher/Doctor arrow glyph `→` does **not render** in the game font in the tested English, German, Russian and Simplified-Chinese locales; the numeric values remain visible without the arrow. Therefore the arrow approach is rejected.
- Russian Quality-fertilizer wording using `того же качества` is rejected as awkward/ambiguous.
- Pyrite native-name reuse works, but quotation marks around the native mineral name are visually inconsistent and rejected.
- Cultist was not runtime-tested because the user’s current save has not unlocked it and the user does not want spoiler-oriented test tooling. Product review concluded that DTT should not append any Cultist clarification: the ambiguity belongs to the corpse/body-part UI, not the Technology Tree.

Accepted final copy direction for the next candidate:
1. Butcher: use a natural-language decrease statement, no special arrow glyph.
   - RU: `Шанс ошибки при извлечении мяса, крови, жира, кожи, черепа и костей снижается с 25% до 0%.`
2. Doctor: same natural-language pattern, using native localized preparation-table names.
   - RU semantic: `Шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25% на препарационном столе и с 25% до 0% на препарационном столе II.`
3. Quality fertilizer I:
   - RU: `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше.`
4. Quality fertilizer II:
   - RU: `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 2 единицы урожая и 2 семени на одну ступень качества выше.`
5. Pyrite: reuse the native localized `p_t_pyrite` name but **without quotation marks**.
   - RU semantic: `Примечание: Серный колчедан не выпадает при добыче угля.`
6. Cultist: leave fully vanilla; remove the DTT-added clarification.
7. Keep the accepted one-blank-line separation between vanilla authored descriptions and DTT-added clarification text.

No remaining product wording decision is intentionally open at this checkpoint. The next chat should recover repository state first, then implement/build a fresh candidate (expected 1.1.2) from these accepted decisions. Do not mutate or relabel the handed 1.1.1 artifact.


## 1.1.2 — final copy-polish candidate

### Candidate identity

- Version: `1.1.2`
- Development branch: `dev/1.1.2`
- Exact build source: `284187c4af4c8a5d0d0125d19d0ad9eedf21e544`
- GitHub Actions run: `36848879751`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 37 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.1.2-284187c4af4c8a5d0d0125d19d0ad9eedf21e544`
- Artifact ID: `11154128646`
- Artifact ZIP digest: `sha256:1ac9f7267bd955e4edb8c0eba68a375a46a128e8f882491c03ff20c5b018a5fe`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.1.2.dll`
- DLL SHA-256: `aece8265213910762f26bff1a8ad0a15edf75dd54a11c43abc820702f074cfc9`
- DLL size: 80,384 bytes
- Binary/plugin metadata: `1.1.2`
- Assembly informational version: `1.1.2+284187c4af4c8a5d0d0125d19d0ad9eedf21e544`

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, exact source SHA and DLL hash;
- computed DLL SHA-256 matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded strings contain the 1.1.2 readiness marker, exact semantic copy changes and exact informational source identity.

### Delta from 1.1.1

No gameplay, progression, recipe/build data, unlock state, saves, hidden unlocks, viewport behavior, CJK separator handling or quantity-token handling changed.

- Butcher and Doctor no longer use the unsupported `→` glyph; all 11 DTT locales use ordinary natural-language before/after wording.
- Doctor still resolves the two preparation-table names from native game localization, with the existing DTT fallback only if the native name is unavailable.
- Quality fertilizer I/II now state both effects separately: increased crop/seed quantity, plus exactly 1/2 crop(s) and 1/2 seed(s) one quality tier higher.
- Pyrite still reuses the active native `p_t_pyrite` display name, but no quotation marks are added around it.
- Cultist is fully vanilla again: it has no DTT localization key, no DTT description branch and no DTT blank-line separation branch.
- The accepted one-blank-line separation remains for the other authored Work/Perk entries that receive a DTT clarification.

### Automated evidence

The final candidate run compiled the exact build source successfully with 0 compiler warnings and 0 errors.

Localization/formatting validation passed for all 11 supported game languages and additionally asserts:
- Doctor native-name placeholders resolve and no arrow glyph remains;
- Butcher contains no arrow glyph;
- Cultist has no DTT-owned localization entry;
- Pyrite native-name templates contain no quotation marks;
- the exact accepted Russian Quality I/II wording is present;
- previously accepted list-separator, CJK break-opportunity, quantity-token repair and Big Guy fail-closed tests remain passing.

### Focused runtime acceptance requested

Only the changed 1.1.2 copy/presentation needs rechecking. Previously accepted 1.0.2/1.1.x mechanics do not need exhaustive repetition.

1. **Russian Butcher + Doctor**
   - one blank line still separates vanilla text from the DTT clarification;
   - there is no missing-glyph gap where the rejected arrow used to be;
   - the natural-language decrease statements are easy to read;
   - Doctor shows the active native preparation-table names.

2. **Russian Quality fertilizer I**
   - confirm the accepted two-sentence wording reads naturally in the real tooltip:
     `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше.`
   - Quality II uses the same pattern with 2 and only needs a separate check if convenient.

3. **Russian Pyrite**
   - visible unlock name and note use the same native mineral term;
   - there are no quotation marks around the mineral name;
   - expected current Russian shape: `Примечание: Серный колчедан не выпадает при добыче угля.`

4. **Cultist**
   - no runtime test is requested. The user does not have this unlock and spoiler-oriented test tooling is explicitly unwanted; source and automated tests prove that DTT no longer owns any Cultist clarification path.

5. **Support log**
   - expected: `DTT_READY version=1.1.2 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364`;
   - no DTT initialization/runtime/viewport/wrap-repair disable marker.

Status: **PENDING USER RUNTIME ACCEPTANCE**.

The numbered 1.1.2 bytes are immutable after handoff. Stable 1.0.2 remains the published baseline until explicit runtime acceptance and promotion of the semantic expansion.


### Runtime result — 2026-10-01 — 1.1.2

Status: **SUPERSEDED FOR FINAL LOCATION/COPY POLISH**. Exact 1.1.2 bytes remain immutable; stable 1.0.2 remains published.

User runtime evidence on Graveyard Keeper 1.407:
- DTT loaded as `1.1.2` with expected host MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`; the submitted support log contains the expected `DTT_READY` marker and no DTT init/runtime/viewport/wrap-repair disable marker.
- Russian Quality fertilizer wording is accepted as clear and unambiguous.
- Grape/Hops presentation was rechecked and remains accepted.
- Doctor's natural-language probability wording is readable and the one-blank-line separation remains visually good.
- Three presentation issues remain:
  1. blueprint location `Строительство: Алхимия` is semantically awkward because the native `alchemy_builddesk` display label names the discipline rather than the actual build location;
  2. Doctor should make the station pair explicit as `Препарационный стол I` / `Препарационный стол II` and use a shorter two-sentence composition;
  3. Pyrite's `не выпадает при добыче угля` wording can imply another working acquisition source, so the note should instead state explicitly that the Technology does not enable obtaining the mineral in the current game version.

Accepted 1.1.3 direction:
- exact `alchemy_builddesk` blueprint location override: RU `Алхимическая лаборатория`, EN `Alchemy Lab`; other builders remain native;
- RU Doctor: `На препарационном столе I шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25%. На препарационном столе II — с 25% до 0%.`
- Pyrite: keep the active native mineral name but use the technical-note semantic `в текущей версии игры эта технология не позволяет получать {native name}`.


## 1.1.3 — accepted location/copy polish candidate

### Candidate identity

- Version: `1.1.3`
- Development branch: `dev/1.1.3`
- Exact build source: `18134e549613200cbc19f20213db4064a80cbbfc`
- GitHub Actions run: `36851265438`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 38 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.1.3-18134e549613200cbc19f20213db4064a80cbbfc`
- Artifact ID: `11156320019`
- Artifact ZIP digest: `sha256:284d70b2465b6bf88db16be1653c66fdd938def9d217544237eb88c36ab6e7fd`
- Installed DLL basename: `DetailedTechnologyTooltips.dll`
- Numbered handoff filename: `DetailedTechnologyTooltips-1.1.3.dll`
- DLL SHA-256: `1dfc13d499c2bd712bb8eb683a6ac0c51de8c4a74228360fbf8639829f89f6fb`
- DLL size: 81,920 bytes
- Binary/plugin metadata: `1.1.3`
- Assembly informational version contains exact source `18134e549613200cbc19f20213db4064a80cbbfc`.

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, exact source SHA and DLL hash;
- computed DLL SHA-256 matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded strings contain the exact 1.1.3 Russian Alchemy Lab, Doctor and Pyrite wording plus the 1.1.3 readiness marker/source identity.

### Delta from 1.1.2

No gameplay/progression/save/recipe/build/unlock data changed.

- For blueprint location rows only, exact builder ID `alchemy_builddesk` gets a DTT-owned location-name override. Russian now reads `Строительство: Алхимическая лаборатория`; English uses `Alchemy Lab`. Every other blueprint builder and every ordinary recipe station still uses the existing native localization path.
- Doctor explicitly distinguishes table I from table II. Russian uses the accepted fully inflected two-sentence wording; other DTT locales keep native preparation-table names and append `I` to the first table name while retaining the native second-table name.
- Pyrite still inserts the active native `p_t_pyrite` mineral name, but the note now says that in the current game version this Technology does not enable obtaining that mineral.
- Accepted fertilizer, grape/hops, blank-line separation, CJK/list wrapping, quantity-token repair, viewport clamp, Cultist exclusion and all other 1.1.x behavior remain unchanged.

### Automated evidence

The exact build source compiled successfully with 0 warnings and 0 errors.

Localization/formatting validation passed for all 11 supported game languages and asserts:
- all 38 DTT-owned keys are present;
- `alchemy_builddesk` resolves to the dedicated Alchemy Lab override while unrelated builders do not;
- Doctor contains no rejected arrow glyph;
- the exact accepted Russian Doctor sentence is present;
- Pyrite templates still contain the native-name placeholder, contain no quotation marks, and the exact accepted Russian technical-note wording is present;
- Cultist remains fully vanilla;
- prior Quality-fertilizer, Big Guy, CJK separator and quantity-token checks remain passing.

### Focused runtime acceptance requested

Only these 1.1.3 deltas need checking:

1. **Russian alchemy blueprints**
   - one representative blueprint such as Alchemy Workbench / Hand Mixer / Alchemy Mill;
   - location row should read `Строительство: Алхимическая лаборатория`;
   - requirements and the rest of the tooltip remain unchanged.

2. **Russian Doctor**
   - expected text:
     `На препарационном столе I шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25%. На препарационном столе II — с 25% до 0%.`
   - verify the two sentences read cleanly;
   - especially check that `I` / `II` do not end up visually stranded from the table name in the actual tooltip at the user's current resolution.

3. **Russian Pyrite**
   - expected semantic shape:
     `Примечание: в текущей версии игры эта технология не позволяет получать Серный колчедан.`
   - the mineral term must still match the native visible unlock name.

4. **Support log**
   - expected: `DTT_READY version=1.1.3 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364`;
   - no `DTT_INIT_FAILED`, `DTT_RUNTIME_DISABLED`, `DTT_VIEWPORT_DISABLED` or `DTT_WRAP_REPAIR_DISABLED`.

No repeat test is requested for fertilizers, grape/hops, Butcher, Cultist, CJK separator behavior or other already accepted properties unless a new regression is visible.

Status: **PENDING USER RUNTIME ACCEPTANCE**.

The numbered 1.1.3 bytes are immutable after handoff. Stable 1.0.2 remains the published baseline until explicit acceptance/promotion of the semantic expansion.


### Runtime result — 2026-10-01 — 1.1.3

Status: **ACCEPTED FOR THE 1.1.3 DELTA; SUPERSEDED BY NEW MULTI-BUILDER LOCATION WORK BEFORE STABLE PROMOTION**.

User runtime evidence on Graveyard Keeper 1.407:
- the exact handed 1.1.3 candidate loaded successfully against host MVID `6f50b8e7-156b-49ac-bbe8-7505894b2364`;
- all three 1.1.3 changes were explicitly accepted in game:
  - `alchemy_builddesk` blueprint rows display `Алхимическая лаборатория` correctly;
  - Doctor's Preparation Table I/II wording and presentation are correct;
  - the revised Pyrite technical note is correct;
- submitted support log contains `DTT_READY version=1.1.3` and no reported DTT initialization/runtime/viewport/wrap-repair failure marker.

A new independent product gap was observed immediately afterward: some buildable objects are unlocked through multiple authored `ObjectCraftDefinition` entries for different builders, while the current DTT location row only reads the visible Technology blueprint's own `builder_ids`. Representative accepted runtime observation: the Vine press tooltip reports Yard, while the same unlocked Vine press is also buildable from the Cellar.

Do not promote 1.1.3 to stable while this newly accepted follow-up is being resolved. Exact 1.1.3 bytes remain immutable.


## 1.1.4 — multi-builder blueprint-location candidate

### Research closure

Read-only runtime audit on the user's Graveyard Keeper 1.407 installation completed successfully.

Observed population:
- 187 Technology definitions;
- 533 object-craft definitions;
- 105 visible Technology blueprints;
- 0 unresolved visible blueprints;
- 5 same-Technology multi-builder blueprint groups;
- 3 additional global same-output builder groups outside the owning Technology.

Same-Technology groups proved by the audit:
- `The idea of the stone` / stone stockpile: Yard + Quarry build desks;
- `Stone processing` / first stone cutter: Yard + Quarry build desks;
- `Mining` / iron ore stockpile: Yard + Quarry build desks;
- `Improvement` / trunk: Garden + Quarry + Vineyard + Graveyard + Cremation build desks;
- `Winemaking` / vine press: Yard + Cellar build desks.

The audit also proved why a blind global same-`out_obj` union is unsafe:
- trunk has two additional always-visible global aliases;
- corpse pallet has a separately lock-controlled Souls builder alias;
- porter station has a separately lock-controlled Vineyard alias.

Static 1.407 host semantics establish that authored leading `@` hides only the Technology unlock presentation while `GameSave.UnlockTech` still unlocks the referenced craft ID. Native `GameSave.IsCraftVisible` remains the authoritative current-save gate for independent aliases.

### Candidate behavior

Blueprint location rows now:
1. include all same-Technology same-`out_obj` / same-`build_type` sibling blueprint builders, including `@`-hidden sibling records;
2. include outside-Technology same-output/build-type aliases only when native `GameSave.IsCraftVisible` reports them currently available in the active save;
3. preserve first-seen order and de-duplicate builder IDs.

Preserved:
- visible blueprint requirements still come from the visible authored blueprint;
- hidden sibling blueprints are not rendered as separate Technology unlocks;
- independently locked/story-gated aliases are not exposed early;
- ordinary recipe station rows are unchanged;
- no `sub_zone_id` location guessing;
- the accepted exact `alchemy_builddesk -> Alchemy Lab` presentation override remains unchanged;
- no progression, recipe, build, save or balance data is mutated.

### Candidate identity

- Version: `1.1.4`
- Development branch: `dev/1.1.4`
- Exact build source: `09ca4dc62b92d8578278b63150a4a050fc653ebd`
- GitHub Actions run: `36863419114`
- CI result: **SUCCESS**
- Release build: **0 warnings / 0 errors**
- Localization/formatting validation: **11 languages x 38 DTT keys — PASS**
- CI artifact: `DetailedTechnologyTooltips-1.1.4-09ca4dc62b92d8578278b63150a4a050fc653ebd`
- Artifact ID: `11162412259`
- Artifact ZIP digest: `sha256:1a2d429704e9f41cd6a1339535f5219e52f40956ed6da6b5a905c8dec7d1a3e1`
- Handed DLL filename: `DetailedTechnologyTooltips-1.1.4.dll`
- DLL SHA-256: `8c593b7dcd1855227e30c84dc3713d77fd9042dc30116915b9b1ee29ccb19f08`
- DLL size: 83,968 bytes
- Binary/plugin metadata: `1.1.4`
- Assembly informational version contains exact source `09ca4dc62b92d8578278b63150a4a050fc653ebd`.

Downloaded-artifact verification:
- `BUILD_IDENTITY.txt` matches version, source SHA and DLL hash;
- independently computed DLL SHA-256 matches the identity file;
- binary is a non-empty Windows PE32 Mono/.NET assembly;
- embedded strings contain the `DTT_READY version=1.1.4` marker and exact informational source identity.

### Focused runtime acceptance requested

The research-only `DTTBlueprintLocationAudit.dll` is no longer required and should be removed before this candidate test.

Only the changed blueprint-location behavior needs checking:

1. **Winemaking / Vine press**
   - expected: both Yard and Cellar are listed in the one `Строительство` row.

2. **One Yard/Quarry duplicate**
   - Stone stockpile, first Stone cutter, or Iron ore stockpile;
   - expected: both corresponding native build-menu names are listed.

3. **Improvement / Trunk**
   - expected: all same-Technology locations are present;
   - additionally, already-native-visible independent trunk locations in the current save are included;
   - names must not duplicate;
   - long wrapping must remain readable.

4. **Regression sanity**
   - one ordinary recipe tooltip still shows its exact recipe station as before;
   - one ordinary single-location blueprint still shows one location;
   - no new `DTT_INIT_FAILED`, `DTT_RUNTIME_DISABLED`, `DTT_VIEWPORT_DISABLED` or `DTT_WRAP_REPAIR_DISABLED` marker.

Status: **PENDING USER RUNTIME ACCEPTANCE**.

Exact 1.1.4 handed bytes are immutable after handoff. Stable 1.0.2 remains the published baseline until explicit acceptance/promotion.
