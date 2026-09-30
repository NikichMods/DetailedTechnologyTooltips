# Verified Game Data

Target: **Graveyard Keeper 1.407 (PC)**.

This document is the canonical project ledger for host/runtime facts that production decisions in Detailed Technology Tooltips may rely on. Reusable cross-project facts belong in `NikichMods/GraveyardKeeperResearch`; this file records the subset and product implications needed by this mod.

## Evidence baseline

Primary shared research:
- `NikichMods/GraveyardKeeperResearch/docs/TECH_TREE_INFORMATION_RESEARCH.md`
- `NikichMods/GraveyardKeeperResearch/docs/CRAFTING_INVENTORY_AND_TRADING.md`
- `NikichMods/GraveyardKeeperResearch/docs/UI_INPUT_TIME_AND_ENVIRONMENT.md`
- `NikichMods/GraveyardKeeperResearch/docs/GAME_INTERNALS.md`

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
