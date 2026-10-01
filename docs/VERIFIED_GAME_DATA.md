# Verified Game Data

Target: **Graveyard Keeper 1.407 (PC)**.

This document is the canonical project ledger for host/runtime facts that production decisions in Detailed Technology Tooltips may rely on. Reusable cross-project facts belong in `NikichMods/GraveyardKeeperResearch`; this file records the subset and product implications needed by this mod.

## Evidence baseline

Primary shared research:
- `NikichMods/GraveyardKeeperResearch/docs/TECH_TREE_INFORMATION_RESEARCH.md`
- `NikichMods/GraveyardKeeperResearch/docs/CRAFTING_INVENTORY_AND_TRADING.md`
- `NikichMods/GraveyardKeeperResearch/docs/UI_INPUT_TIME_AND_ENVIRONMENT.md`
- `NikichMods/GraveyardKeeperResearch/docs/GAME_INTERNALS.md`
- `NikichMods/GraveyardKeeperResearch/docs/FARMING_AND_FERTILIZER.md`
- `NikichMods/GraveyardKeeperResearch/docs/PERK_MECHANICS.md`

Pinned static host source used by the shared research:
- `Kupie/GYK_DECOMP@6abf79199d92482af1c7573870dd9a20ec2270b9`

Full-balance audit inputs supplied from Graveyard Keeper 1.407:
- `resources.assets` SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`
- `Assembly-CSharp.dll` SHA-256 `e72e4270e4b88dd0a87ca23c9cf1750aec4c4a0fedb40b6d2dae7902fc9c7fd8`

The raw game files and full extracted balance payload are research inputs only and are not repository content.

## Product problem

Community evidence and host inspection support a recurring Technology-tree information gap: before spending technology points, players may see the name/icon of an unlock without enough concrete information to know its materials, exact crafting/build location, or practical form.

The intended product response is contextual enrichment of the existing Technology tooltip, not a new encyclopedia or gameplay system.

## Technology population

Accepted full 1.407 balance audit:
- 187 technologies;
- 395 authored-visible unlock references total;
- 342 visible Craft unlocks;
- 15 visible Work unlocks;
- 38 visible Perk unlocks;
- no current serialized Technology Phrase unlocks.

No current Technology exceeds the vanilla maximum of three visible unlocks:
- 53 technologies have one;
- 60 have two;
- 74 have three.

Of the 342 visible Craft unlocks:
- 105 are `ObjectCraftDefinition` blueprints;
- 237 are ordinary `CraftDefinition` recipes.

The only unresolved authored Craft reference found by the audit is `@stone_plate_3b` under `Stone carving`; it is explicitly authored invisible and therefore outside the visible UI scope.

## Technology tooltip ownership

Verified 1.407 paths:

Mouse:
`TechTreeGUIItem.Draw -> TechTreeGUIUnlockItem.Draw(... init_tooltip:true) -> TechUnlock.GetTooltip`

Gamepad:
`TechTreeGUIItem.InitGamepadTooltip -> visible TechUnlock.GetTooltip results -> combined parent tooltip`

Therefore `TechUnlock.GetTooltip` is a shared semantic detail seam for visible Technology unlock information across mouse and gamepad interaction.

The accepted Technology tooltip UI research also establishes the inspected label/bubble sizing path and finite `UILabel.overflowWidth` wrap ceiling. Reuse only within this verified tooltip family.

## Vanilla blueprint-detail omission

For Craft unlocks, `TechUnlock.GetData()` can recognize blueprint-style IDs and resolve `ObjectCraftDefinition`.

However, the current `TechUnlock.GetTooltip()` path:
1. tries ordinary `CraftDefinition`;
2. when that fails for a blueprint-style ID, resolves `ObjectCraftDefinition` but discards the returned value;
3. leaves the ordinary craft variable null;
4. returns without composing build details.

This is a verified static host-level cause of sparse blueprint Technology tooltips.

## Blueprint data coverage

For all **105/105 visible Technology blueprints**:
- `out_obj` is non-empty;
- exactly one `builder_id` is present;
- that builder ID resolves to an existing `ObjectDefinition`.

Build materials:
- 102/105 have non-empty inherited `needs`;
- three special entries have empty `needs` and should simply omit a requirements row.

Only 13/105 have non-empty `sub_zone_id`. Host build logic consumes it as a placement/sub-zone restriction; it is not the build-menu owner.

Fifteen visible blueprints use `BuildType.None` for special systems/upgrades rather than ordinary placement. Product wording should therefore describe the authoritative builder/menu ownership rather than assume every blueprint is a normal placeable construction.

The host already localizes `ObjectDefinition.id` through `GJL.L(id)` in player-facing object/crafting-location paths. A separate manual builder-name/localization table is unnecessary for the audited scope.

## Ordinary recipe data coverage

For the 237 visible ordinary recipe unlocks:
- 221/237 have non-empty `needs`;
- 236/237 have non-empty `craft_in`;
- all 33 unique visible `craft_in` station IDs resolve to existing `ObjectDefinition` records;
- 232/237 have non-empty `output`.

Empty `needs` cases include heterogeneous special mechanics such as extraction, growing/automatic production, and a fake/global craft. Generic presentation must therefore be data-driven: show requirements only when authored `needs` exist.

Eight visible ordinary recipe records do not resolve to the normal physical-output item tooltip path. Handle such special records conservatively rather than forcing a normal-item assumption.

## Exact recipe station versus generic item station

For ordinary Craft unlocks, vanilla `TechUnlock.GetTooltip` delegates detail to the first physical output item's tooltip.

That output-item tooltip obtains `crafted_at` from `GameBalance.GetItemCraftsIn(output_item_id)`, which aggregates all eligible stations across recipes producing the item.

The Technology unlock itself owns an exact `CraftDefinition.craft_in`.

Across 229 comparable visible Technology recipe unlocks:
- 91 exact `craft_in` station lists equal the item-level aggregate;
- 138/229 (60.3%) are strict subsets of the aggregate;
- no compared case was disjoint/contradictory.

Example:
- Technology `Iron -> ingot_metal`: exact recipe station is `mf_furnace_0`;
- generic item crafting-location aggregate includes `mf_furnace_0`, `mf_furnace_1`, `mf_furnace_2`.

Product implication: when Detailed Technology Tooltips states where **this unlocked recipe** is crafted, use that recipe's own `craft_in`, not the broader generic item-location aggregate.

## Sparse visible craft path size

The audit identified **113/342 (33.0%)** visible Craft unlocks that currently reach a structurally sparse/title-only Technology-tooltip path:
- all 105 blueprints;
- eight special ordinary recipes.

This supports the product need independently of subjective wording quality.


## Work / Perk runtime enrichment evidence

Accepted read-only runtime audit on Graveyard Keeper 1.407:

- 15 authored-visible Work unlocks; 2 have no authored description;
- 38 authored-visible Perk unlocks; 11 have no authored description.

Sparse Work entries:
- `t_diamond` resolves to a gated diamond source dropping `faceted_diamond`;
- `t_marble` resolves to gated marble sources dropping `marble`.

Sparse gathering-style Perks with direct current-data consumers:
- `p_t_gold_ore`: gold nuggets in iron processing and iron mining;
- `p_t_silver_ore`: silver nuggets in iron processing and iron mining;
- `p_t_lifestone`: limestone/lifestone from coal mining;
- `p_t_sulfur`: sulfur from coal mining;
- `p_t_beeswax`: beeswax from bee-house / bee-tree harvest sources;
- `p_t_bee`: bees from bee-house / bee-tree harvest sources;
- `p_t_butterfly`: butterflies from flowers during daytime;
- `p_t_moth`: moths from flowers during nighttime;
- `p_t_maggot`: maggots from the native `peat_from_waste` craft.

Two sparse Perks are intentionally excluded:
- `p_t_old_books`: exact native consumer is unresolved;
- `p_t_pyrite`: runtime data is internally inconsistent — Perk `output_res` writes `p_t_pirit=1` while the coal-drop expression reads `Ppar("p_t_pyrite")`. The presentation mod must not claim that this Technology enables pyrite drops and must not fix the gameplay data.

Product implication: preserve authored Work/Perk descriptions; add a short action/source explanation only for the explicitly proved sparse IDs above. Do not expose exact chance percentages, future uses, guessed locations, hidden `@` unlocks, or the two unresolved/mismatched cases.

Canonical shared evidence: `NikichMods/GraveyardKeeperResearch/docs/TECH_TREE_INFORMATION_RESEARCH.md`, runtime diagnostic source `64a3751a67e3a1950c2ccfb9970e7991fb304daf`.

## Preserved invariants

Unless separately approved and evidenced, the mod must not change:
- technology costs, visibility, availability, or unlock state;
- recipes/build definitions or their availability;
- save data;
- progression/story/DLC gating;
- item/crafting/build mechanics;
- authored invisible unlocks;
- unrelated tooltip surfaces.

## Initial implementation gate

Research feasibility is **SUPPORTED FOR PRODUCTION BOOTSTRAP**, but the first production behavior has not yet been mutated.

Before production C# is added for tooltip enrichment, explicitly choose the least-complex concrete composition strategy and record a DevRules evidence gate for that behavior:
- observable property;
- canonical owner;
- final writer/consumer;
- blast radius;
- preserved invariants;
- mechanical/runtime acceptance;
- **READY** or **BLOCKED**.

The next unknown is primarily product/UI composition and real-game density, not whether the native data exists.

## Multi-quality/group requirement presentation

Pinned Graveyard Keeper 1.407 host inspection proves that an authored Craft requirement can carry a base/group item ID that has no direct `ItemDefinition`.

The native Craft UI handles this without a manual mapping:

- `BaseItemCellGUI.DrawItem` first tries the exact `ItemDefinition`;
- when that lookup fails, it calls `GameBalance.GetItemsOfBaseName(item_id)`;
- it uses the first returned concrete variant's `ItemDefinition` as the representative display identity;
- `BaseItemCellGUI.DrawIngredients` separately treats multi-quality requirements as a group rather than requiring one particular quality.

Therefore Technology requirements should not interpret a missing direct `ItemDefinition` as “no requirements”. The least-complex presentation fallback is to reuse the same native base-name resolution family, keep the authored quantity from `CraftDefinition.needs`, and fail closed only if no concrete native variant resolves.

## Current 1.407 language coverage

Accepted runtime language-selector evidence establishes these 11 current PC locale codes:

`en`, `de`, `fr`, `pt-br`, `es`, `ru`, `it`, `pl`, `ja`, `zh_cn`, `ko`.

Release implication:
- DTT-owned strings must cover all 11 for the 1.0.0 “all current game languages” claim;
- item/station/build-desk names remain native and therefore continue to follow Graveyard Keeper's own active localization;
- unknown future locale codes remain unverified and should fail closed instead of silently substituting a guessed translation.

The reusable host fact is also recorded in `NikichMods/GraveyardKeeperResearch/docs/UI_INPUT_TIME_AND_ENVIRONMENT.md`.


## Fertilizer semantic-explanation research

The exact Graveyard Keeper 1.407 fertilizer mechanics are now closed in shared research; see `NikichMods/GraveyardKeeperResearch/docs/FARMING_AND_FERTILIZER.md`.

Product-relevant conclusions:

- manual plots store independent `grow_qual` and `grow_time` axes, and those fertilizer effects reset after the crop cycle;
- peat writes both axes at tier 1; Quality I/II write only `grow_qual=2/3`; Boost I/II write only `grow_time=2/3`;
- manual Boost reduces the native growth duration by 40% / 60% for Boost I / II and does not alter the inspected harvest-drop formulas;
- manual Quality increases yield; for bronze/silver quality crops, Quality I guarantees one next-tier crop plus one next-tier seed, while Quality II guarantees two of each; gold-quality crops retain the bonus at gold quality rather than degrading;
- fertilizer writes replace the same axis rather than stacking, so applying peat after a stronger fertilizer can downgrade that axis;
- zombie farms/vineyards and Game of Crone refugee garden beds are a different mechanic: Quality fertilizer is consumed in 12-unit permanent station upgrades that change `lvl`, unlock higher-quality automatic recipes and improve station speed; they do not perform manual next-tier seed conversion.

The community/product problem is therefore mechanically supported, but **no additional DTT fertilizer tooltip behavior is approved yet**. Placement, scope, wording and whether the information belongs in the Technology tree remain product decisions. Until those decisions are made and a production evidence gate is opened, the released 1.0.2 behavior remains unchanged.


## Special semantic candidates discovered during farming UX review

Representative real-game Technology screenshots and current 1.407 data expose two additional information-quality cases.

### Grape / hops growth unlocks

`Grape farming` visibly unlocks `garden_grapes_growing` and `garden_hop_growing`. These are internal automatic growth crafts, while the actual player actions are separate planting recipes on `vineyard_grapes_stick` that consume four corresponding seeds and chain into those growth crafts.

Product implication: the current generic `Create: Grapes / Hops` presentation is semantically weak. A growth-oriented label, and potentially the planting requirements/location derived through the native `craft_after_finish` relationship, is a candidate DTT correction. No production behavior is approved yet.

### Super mushroom Work unlock

`The master gathering -> t_mushroom2` already has an authored flavor description, but the accepted audit proves its concrete current action is gating the `mushroom_2` source, which drops `shr_agaric` ("Красный гриб" in the inspected Russian runtime).

Product implication: this is evidence that an authored Work description can still omit the practical meaning of the unlock. Augmenting authored Work descriptions would broaden the current DTT policy beyond sparse-only Work enrichment and therefore requires its own product decision/evidence gate. Future-use information such as study/alchemy should not be added merely because it is discoverable in the data.


## Authored Perk numeric-mechanics research

Exact current Graveyard Keeper 1.407 mechanics for the authored-description Perks are now recorded in shared research:
`NikichMods/GraveyardKeeperResearch/docs/PERK_MECHANICS.md`.

Product-relevant conclusions:

- native multi-quality Perk values are **star-score contributions**, not percentages, and vanilla Craft UI already presents them in the same `★0.0` scale;
- Writer = +★0.3; Playwright = +★0.5; Industriousness = +★0.2 on their authored linked craft sets;
- Engineer = +★0.3 on current carved-wood, carved-marble and steel-chisel quality consumers;
- Jeweler = +★0.7 on current hardcover/book quality consumers and +1 minimum yield at the audited dungeon diamond/gold/silver sources; the vanilla jewelry wording does not describe that quality consumer set literally;
- Wine Master = +★0.8 on red-wine crafting quality, not all alcohol craft quality; current alcohol item definitions also give heterogeneous `p_wine_master` energy-on-consumption additions, so there is no one verified universal percentage suitable for a tooltip;
- Blacksmith adds +3 nails, +1 simple iron part, +1 complex iron part, +2 steel parts, and +★0.1 to current steel-chisel quality crafts;
- Mason / Woodworker have both exact output bonuses and +★0.5 quality consumers;
- Butcher changes the common/basic surgery-mistake path 25% -> 0% (ignoring the independent Clean Cut buff);
- Doctor changes important-organ mistake chance 50% -> 25% at Preparation Place I and 25% -> 0% at Preparation Place II (again isolating the Perk from Clean Cut);
- Big Guy currently writes and consumes +2 weapon damage / +2 armor mitigation; the authored Russian description's +1/+1 numbers are stale for 1.407;
- Sword Master gives +5 weapon damage;
- Persistence passively restores 1 energy per running second through its hidden conditional buff;
- Miner has multiple per-source changes rather than one universal percentage; for iron mining, once the corresponding unlocks are active, gold nugget chance is 5% -> 10% and silver 10% -> 20%;
- Cultist reveals each body part's red/white skull **contribution while installed**; removing the part reverses that contribution in the corpse total.

These findings invalidate the previous shortcut “authored Perk description exists, therefore it is sufficiently informative.” Some descriptions are directionally adequate, some omit important numerical mechanics, and a few are stale or materially overbroad.

No production behavior is approved by this section. Any authored-description augmentation/replacement is a separate product decision and requires its own READY/BLOCKED production gate before source mutation. The stable 1.0.2 behavior remains unchanged.
