# Candidate 0.1.1 Scope and Evidence Gates

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

This candidate is the first UX iteration after accepted 0.1.0 mechanism testing.

## Solution-space checkpoint

The product goal remains in-place enrichment of vanilla Technology unlock tooltips.

No new screen, dependency graph, gameplay mutation, or general-purpose Technology encyclopedia is justified. The least-complex adequate family is still the existing `TechUnlock.GetTooltip` seam plus one Technology-only late viewport clamp.

Several independent READY changes may share this candidate because they affect the same tooltip composition and can be distinguished in one representative runtime pass.

## Gate A — clearer Craft rows

- Observable property: visible Technology Craft unlocks use the approved concise labels `Нужно:` / `Requires:`, `Изготовление:` / `Crafted at:`, and blueprint `Строительство:` / `Build menu:`.
- Canonical owner: existing 0.1.0 native `needs`, `craft_in`, and `builder_ids` data; only presentation wording changes.
- Final writer: `TechUnlock.GetTooltip(Tooltip)` enrichment through `Tooltip.AddData`.
- Blast radius: Detailed Technology Tooltips rows only.
- Preserved invariants: exact 0.1.0 data ownership, aggregate-location suppression, native item/station names, progression, recipes, builds, saves, and hidden unlock visibility remain unchanged.
- Acceptance evidence: representative ordinary recipe and blueprint in Russian; verify natural wording and counts.
- Gate state: **READY**.

## Gate B — list separator spacing

- Observable property: generated multi-item/multi-location rows use a readable list separator with a following space, e.g. `, `.
- Canonical owner: mod presentation composition; item/station names remain native-localized.
- Final writer: the same generated Technology detail rows.
- Blast radius: mod-generated lists only.
- Preserved invariants: no host localization table is replaced; no gameplay data changes.
- Acceptance evidence: a three-material blueprint/recipe and any multi-location row.
- Gate state: **READY**.

## Gate C — Technology tooltip viewport safety

- Observable property: a Technology tooltip that would extend below the safe viewport is translated upward; one that would extend above it is translated downward. Horizontal overflow is clamped by the same geometry rule.
- Canonical owner: final live `WidgetsBubbleGUI` geometry after native placement.
- Final writer / commit point: postfix on `WidgetsBubbleGUI.Update()`, restricted to bubbles linked from Technology tooltips marked by this mod; ordered after `nikich.gyk.movegamepadtooltips`.
- Blast radius: Technology tooltips marked by Detailed Technology Tooltips only.
- Preserved invariants: native placement remains the baseline; normal item/dialog bubbles are untouched; Gamepad Tooltip Position Fix placement is respected before final clamp; no tooltip content or gameplay state is changed.
- Acceptance evidence: long mouse and gamepad Technology tooltips near both lower and upper viewport limits when naturally reachable; at minimum confirm the previously observed lower-overflow case and no regression in normal placement.
- Gate state: **READY**. Same host family/late-writer mechanism is already accepted in PrayerClarity; this candidate reuses only the viewport-bound portion, not PrayerClarity-specific selected-unlock avoidance.

## Gate D — sparse Work / Perk enrichment

- Observable property: visible Work/Perk unlocks that have no vanilla description receive one short action/source explanation only where current 1.407 native behavior is proved.
- Canonical owner:
  - Work: native `ObjectGroupDefinition` membership / gated source objects and their drops;
  - gathering-style Perk: native `PerkDefinition.output_res` plus the exact craft/object/drop expressions consuming that player parameter.
- Final writer: `TechUnlock.GetTooltip(Tooltip)` after vanilla has written the title, separator, and empty description row.
- Blast radius: only the specifically proved sparse visible Work/Perk IDs.
- Preserved invariants: ordinary Perks with authored descriptions remain vanilla; no exact chance percentages are exposed; no future uses/dependency graph/story locations are inferred; no `@`-hidden unlocks are surfaced; gameplay parameters are never changed.
- READY IDs:
  - Work: `t_diamond`, `t_marble`;
  - Perk: `p_t_gold_ore`, `p_t_silver_ore`, `p_t_lifestone`, `p_t_sulfur`, `p_t_beeswax`, `p_t_bee`, `p_t_butterfly`, `p_t_moth`, `p_t_maggot`.
- BLOCKED/excluded IDs:
  - `p_t_old_books`: no native consumer found in the audited seams;
  - `p_t_pyrite`: current data writes `p_t_pirit=1` but the coal-drop expression consumes `p_t_pyrite`; the Technology's direct effect therefore does not prove the claimed drop unlock.
- Acceptance evidence: representative Precious Metals, Related Ore, Insects, Decay, Gems/Marble cases; confirm concise wording and that authored Perk descriptions are not duplicated/replaced.
- Gate state: **READY** for the enumerated IDs; **BLOCKED** for the two explicit exclusions.

## Candidate-level acceptance

A single runtime candidate may cover Gates A-D because failures remain attributable by row/content type.

Required checks:
1. ordinary recipe: exact station + `Нужно:`;
2. blueprint: `Строительство:` + readable material list;
3. one long combined gamepad tooltip: viewport-safe;
4. sparse gathering unlocks: gold/silver and one coal-related resource;
5. insect or maggot sparse unlock;
6. `p_t_pyrite` and `p_t_old_books` remain unaltered/sparse;
7. normal item tooltip outside Technology remains vanilla;
8. log contains normal startup and no Detailed Technology Tooltips runtime-disable/error.
