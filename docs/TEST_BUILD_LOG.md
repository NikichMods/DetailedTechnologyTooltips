# Test Build Log

Canonical record of numbered Detailed Technology Tooltips candidates and their runtime acceptance state.

## 0.1.0 — awaiting installed-runtime acceptance

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

### Runtime acceptance matrix — PENDING

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

Status remains **PENDING** until exact candidate `0.1.0` is tested in the installed game and explicitly accepted.
