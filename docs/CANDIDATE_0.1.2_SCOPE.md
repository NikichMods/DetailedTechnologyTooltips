# Candidate 0.1.2 Scope and Evidence Gates

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

This candidate is a narrow follow-up to runtime-accepted 0.1.1.

## Gate A — multi-quality/group Craft requirements

- Observable property: a visible Technology Craft unlock whose authored `needs` contains a base/group item without a direct `ItemDefinition` still shows a `Нужно:` / `Requires:` row instead of silently losing the whole requirements row.
- Canonical owner: `CraftDefinition.needs`; for display resolution, the same native base-name cache used by `BaseItemCellGUI.DrawItem`: exact `ItemDefinition` first, then `GameBalance.GetItemsOfBaseName(item_id)` and the first resolvable variant.
- Final writer: Detailed Technology Tooltips' generated requirements row appended through `Tooltip.AddData`.
- Blast radius: only mod-generated requirements rows inside visible Technology Craft tooltips.
- Preserved invariants: no recipe mutation; no quality selection; no inventory/state query; no manual item mapping; authored quantity remains unchanged; exact ordinary requirements keep the 0.1.1 path; unresolved items still fail closed.
- Acceptance evidence: representative runtime checks for Carved Wood, Notes and Book, confirming that the row appears with sensible native names/counts.
- Gate state: **READY**.

## Gate B — native-style Craft row alignment

- Observable property: mod-generated Craft detail rows visually follow vanilla item-detail alignment in combined gamepad Technology tooltips.
- Canonical owner: `BubbleWidgetTextData.alignment`.
- Final writer: the `BubbleWidgetTextData` objects created for requirements/location rows.
- Verified host reference: `ItemDefinition.GetTooltipData(...)` and `GetTooltipDataCraftAt(...)` create ordinary item-detail text, including `crafted_at`, with `NGUIText.Alignment.Center`; vanilla Technology Work/Perk descriptions use `Left`.
- Blast radius: generated Craft requirements/location rows only.
- Preserved invariants: sparse Work/Perk descriptions remain left-aligned; titles, PrayerClarity rows, bubble placement/width and all native rows are untouched.
- Acceptance evidence: one long combined gamepad tooltip plus ordinary mouse tooltip; verify the Craft rows visually integrate without changing outer placement.
- Gate state: **READY**.

## Gate C — Pyrite implementation-status note

- Observable property: the visible Pyrite gathering unlock explains that the feature is not implemented in the current game version instead of implying that pyrite can be obtained.
- Canonical evidence: current 1.407 runtime data writes player parameter `p_t_pirit` while the coal-drop expression consumes `p_t_pyrite`; accepted external game/community references independently describe Pyrite as unimplemented/not obtainable.
- Final writer: the existing sparse Work/Perk description augmentation in `TechUnlock.GetTooltip`.
- Blast radius: visible Perk ID `p_t_pyrite` only, Russian and English.
- Preserved invariants: no gameplay-data correction; no parameter mutation; no claim about exact historical cause; no change to `p_t_old_books`; other languages remain vanilla for this mod-authored note.
- Accepted wording:
  - RU: `Примечание: не реализовано в текущей версии игры.`
  - EN: `Note: not implemented in the current game version.`
- Acceptance evidence: inspect Related Ore in Russian or English and confirm the note appears only under Pyrite.
- Gate state: **READY**.

## Compatibility checkpoint

PrayerClarity: Rebalanced 0.2.52 and Detailed Technology Tooltips 0.1.1 were runtime-tested together. Both loaded against the same verified 1.407 Assembly-CSharp MVID and no user-visible collision was observed.

No new compatibility patch is included in 0.1.2:
- DTT augments visible Technology unlock content generically;
- PrayerClarity post-processes only prayer-related Technology content;
- PrayerClarity's gamepad prayer carousel reinvokes the native `TechUnlock.GetTooltip` seam, so DTT composition naturally participates;
- both viewport helpers are bounded to marked Technology bubbles, and the accepted combined runtime exhibited correct placement.

Do not broaden patch ordering or introduce cross-plugin dependencies without a concrete regression.
