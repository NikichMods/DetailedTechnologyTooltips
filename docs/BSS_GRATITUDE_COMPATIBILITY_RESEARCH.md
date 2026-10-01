# Better Save Soul Rebalance Gratitude in Technology tooltips — research

Target: Graveyard Keeper 1.407, Detailed Technology Tooltips 1.1.6 stable, Better Save Soul Rebalance 1.1.1 stable.

Status: **root cause proved; integration intentionally closed as a non-goal for the current DTT release line**.

## Question

Why do Better Save Soul Rebalance physical recipe changes (for example added `sin_shard`) appear automatically in DTT Technology requirements, while the mod's recurring local Soul Gratitude cost does not?

## Research-method checkpoint

No new runtime probe is required.

Existing accepted evidence answers the ownership question directly:
- DTT 1.1.6 composes `Нужно / Requires` from the live `CraftDefinition.needs` list when the Technology tooltip is requested.
- Better Save Soul Rebalance 1.1.1 is the accepted stable implementation of the affected grave recipes.
- Its accepted 1.1.0 regression/1.1.1 fix specifically proves that local Gratitude must **not** be inserted into shared `CraftDefinition.needs` merely for display.
- The user's 1.1.6 runtime screenshots and log confirm the expected interoperability: an added physical `sin_shard` is visible in DTT, while local Gratitude is absent.

Therefore direct source inspection + accepted runtime evidence has fewer assumptions than a new harness.

## Proved ownership split

### Physical ingredients

Better Save Soul Rebalance replaces the affected craft's real `CraftDefinition.needs` with its approved physical-material list.

For the high-tier sculptures that list includes `sin_shard`.

DTT reads that same live `needs` object after the rebalance has initialized. Therefore the Sin Shard appears automatically in the Technology tooltip. This is desired generic mod interoperability: DTT is not using a vanilla snapshot or manual recipe table.

### Local Soul Gratitude

The local Gratitude surcharge is intentionally **not** a physical `CraftDefinition.needs` entry.

Better Save Soul Rebalance owns it separately:
- approved per-craft local values live in the mod's `Graves` / `LocalCosts` data;
- manual eligibility/start/completion are enforced by the rebalance's own patches;
- the native craft field `gratitude_points_craft_cost` is changed to the **combined Remote Craft** cost (stock remote fee + local surcharge), so it is not the local manual amount;
- normal crafting UI displays local Gratitude by injecting the game's `gratitude_as_item` pseudo-item only into copied arguments at the final `BaseItemCellGUI.DrawIngredients(...)` renderer boundary.

That final renderer-only injection never changes shared `CraftDefinition.needs`.

DTT does not consume `BaseItemCellGUI.DrawIngredients`; it builds Technology tooltip text directly from the craft definition. Consequently there is no Gratitude pseudo-item or local manual cost in the semantic input DTT currently reads.

## Why DTT must not simply read another native field

`gratitude_points_craft_cost` cannot be presented as the local requirement.

For the affected rebalance recipes it is deliberately the Remote Craft total:
`stock remote fee + local surcharge`.

Treating that value as the Technology recipe's manual Gratitude requirement would overstate the cost.

Likewise, globally treating `gratitude_as_item` as a normal physical ingredient would contradict the accepted Better Save Soul Rebalance contract and reintroduce the class of shared-list/UI corruption fixed in 1.1.1.

## Solution-space checkpoint

### A. BSSR-owned optional query API — preferred mechanism only if the integration is reopened

Better Save Soul Rebalance remains the canonical owner of the local surcharge and exposes a tiny read-only semantic query, conceptually:

`TryGetLocalGratitudeCost(craftId, out cost)`.

DTT detects the rebalance optionally and queries that owner only for the currently displayed craft.

Advantages:
- exact owner supplies the exact semantic value;
- no duplicated cost table in DTT;
- no inference from Remote Craft totals;
- no mutation of `CraftDefinition.needs`;
- no dependence on renderer internals;
- no effect when BSSR is absent.

If this integration is ever explicitly reopened, required work would be:
- choose a stable optional inter-mod ABI that does not create a hard load dependency;
- prove load/order/lifecycle behavior for a Technology tooltip requested after both plugins initialize;
- decide presentation: append native-localized `gratitude_as_item` to `Нужно / Requires`, or use a separate currency line.

### B. DTT reflects BSSR private fields — rejected as production design

DTT could inspect private `LocalCosts` / internal implementation state.

Rejected because this makes DTT depend on private implementation details rather than an explicit owner contract and is unnecessarily brittle across BSSR versions.

### C. Infer local cost from `gratitude_points_craft_cost` — rejected

The field contains the combined Remote Craft cost, not the local manual surcharge. Recovering the local value would require duplicating stock remote fees or other assumptions.

### D. Put Gratitude into shared `CraftDefinition.needs` — rejected

This conflicts with the accepted BSSR 1.1.1 architecture. The previous display-only mutation of shared `needs` broke Craft UI parallel-list invariants and leaked pseudo-data to other mods.

## Current conclusion

The missing Gratitude line is not a DTT failure to observe live recipe mutations.

DTT **does** observe live physical recipe mutations correctly. The missing value belongs to a separate BSSR-owned currency channel that is intentionally outside `CraftDefinition.needs` and is currently exposed only at the normal crafting renderer boundary.

A robust Technology-tooltip integration would therefore need an explicit optional semantic bridge from Better Save Soul Rebalance rather than more aggressive recipe scraping.

Current product decision: **closed non-goal**. Do not add BSSR-specific local Gratitude to DTT Technology tooltips unless the integration is explicitly reopened as a new product change. Physical ingredients in live `CraftDefinition.needs` continue to interoperate automatically.
