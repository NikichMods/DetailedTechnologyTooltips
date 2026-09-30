# 1.0.1 Candidate Scope

Baseline:
- behavior baseline: runtime-accepted 0.1.2;
- rejected release candidate: exact 1.0.0 build from `d7dc125498871360c6a7674bb9a316ce5ee746d7`;
- 1.0.0 remains immutable after handoff.

## Gate A — locale-aware DTT list separators

- Observable property: DTT-generated requirement/location lists use readable spacing in current Latin/Korean locales while Japanese/Simplified Chinese keep native CJK punctuation behavior.
- Canonical owner: DTT list composition; punctuation glyph source remains `GJL.L(",")`.
- Final consumer: DTT-owned `BubbleWidgetTextData` requirement/location rows.
- Blast radius: DTT-composed lists only.
- Preserved invariants: item/station names, order, quantities, native CJK punctuation, accepted RU/EN appearance.
- Acceptance evidence: mechanical locale test plus IT/DE/KO and JA/ZH screenshots.
- Gate state: **READY**.

## Gate B — atomic `(xN)` quantity tokens

- Observable property: native NGUI wrapping never leaves part of a DTT quantity token such as `(x4)` on a separate visual line.
- Canonical owner: DTT requirement text; final wrap owner is the native `UILabel.processedText` produced by `BubbleWidgetText.Draw`.
- Final writer / commit point: postfix at `BubbleWidgetText.Draw(BubbleWidgetTextData)`, after native NGUI has computed final wrapping.
- Blast radius: DTT-owned requirements rows only, and only when the final processed text proves a quantity token was split internally.
- Preserved invariants: names/counts/text stay unchanged; no global NGUI policy, tooltip width, station rows, vanilla item tooltips, or unrelated labels are changed.
- Acceptance evidence: reproduce the Simplified-Chinese long requirement case from rejected 1.0.0 and verify no internal `(xN)` split; sanity-check another locale and support log.
- Gate state: **READY**.

Evidence reuse: the exact `BubbleWidgetText -> UILabel.text/processedText` seam and post-native-wrap repair pattern are already runtime-accepted on the same Graveyard Keeper 1.407 host family by PrayerClarity.

## Gate C — Better Save Soul Remote Control explanation

- Observable property: visible Craft unlock `fake_global_craft` receives one concise explanation of where remote control is accessed and why remote actions can be unavailable in an area.
- Canonical owners:
  - `save.has_global_craft_control` gates the map control;
  - `ZoneControlItem` opens `GlobalCraftControlGUI` from the map;
  - `GlobalCraftControlGUI` enumerates eligible work objects;
  - `WorldZone.HasSoulsTotemInZone()` / `CraftControlItem.interactable` gate remote interaction in the selected zone.
- Final consumer: `TechUnlock.GetTooltip` for the already-visible `fake_global_craft` unlock.
- Blast radius: that one visible DLC Craft unlock.
- Preserved invariants: no hidden/story data, gratitude costs, workstation lists, progression mutation, save mutation or future-use spoilers.
- Acceptance evidence: RU wording/layout plus one non-RU locale and clean log.
- Gate state: **READY**.

Candidate wording intent:
- explain that remote workstation control is accessed from the map;
- explain that remote actions in an area require a Soul Receiver;
- do not turn the tooltip into a guide.

## Deferred — fertilizer / crop-quality explanation

User need is credible, but current accepted evidence does not yet prove the exact 1.407 fertilizer-to-seed/crop-quality ownership path.

- Exact unknown: which native data/consumer owns the effects of `sack_star_silver`, `sack_star_gold` and related fertilizer application on returned seed/produce quality.
- Gate state: **BLOCKED**.
- No production wording is added in 1.0.1.

## Product-scope rule

A semantic note belongs in Detailed Technology Tooltips only when all are true:
1. it explains a concrete visible Technology unlock;
2. vanilla Technology presentation leaves the unlock materially opaque;
3. the effect/access path is proved by current native code/data;
4. it can be explained briefly without optimal-strategy advice or exact hidden chances;
5. it does not reveal hidden/story-gated information beyond the visible unlock.

This keeps the mod informational without becoming an in-game wiki.
