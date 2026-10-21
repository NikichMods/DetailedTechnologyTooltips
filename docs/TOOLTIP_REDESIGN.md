# Tooltip purpose and readability revision

Target: Graveyard Keeper1.407. Current production remains accepted1.1.6.

## Adopted design basis — 2026-10-21

The user selected the **icons plus material names** preview as the basis for the next revision. A blueprint tooltip should answer what the unlocked construction does before listing its requirements and build location:

1. Native blueprint title.
2. Short, neutral, in-world purpose explanation, naming its useful action/result.
3. Requirements with native material icons, names and quantities.
4. Build location under the existing accepted native builder-location policy.

Purpose must be evidence-backed, not guessed from the object name. Preserve useful native description information, visibility, progression, costs and save state. Exact copy and implementation/runtime acceptance remain pending. Do not interpret adoption of the layout as acceptance of every draft phrase or all blueprint descriptions.

## Keyword emphasis — proposal under review

The user proposes emphasizing the semantically decisive result/capability in each purpose description, for example powders or solutions. This is a general editorial rule, not a request to color all occurrences of certain Russian words across every surface.

Recommended rule: mark one short result/capability phrase per short explanation, with occasional additional phrase only where the meaning requires it. Use one consistent, readable accent; do not silently turn powder/solution/potion names into a new color-coded category system or imply resource availability. Metadata should follow localized meaning rather than broad localized-string search/replacement.

Draft focus terms: `растворы`, `порошки`; for the table `алхимические составы` is proposed instead of only `зелья`, because the native two-input table also produces paint/other mixtures. Exact highlighted phrase and palette are pending user review.

## Gamepad single-unlock presentation — requested direction, not implemented

The user proposed reusing the PrayerClarity approach so a multi-unlock Technology shows only the selected existing unlock's tooltip. The inspected precedent is `NikichMods/PrayerClarity@ce915344064655cde5273cea8a10ec4ec2beb2e5`, `src/TechnologyPrayerCarousel.cs`, `docs/DESIGN_NOTES.md` (controller navigation), and accepted0.2.23/1.0.33 evidence in `docs/TEST_BUILD_LOG.md`.

Existing accepted PrayerClarity behavior:
- At least two visible unlocks and at least one prayer activate its carousel, in both editions.
- Left/Right traverse the current node's visible unlocks in native order, then fall through to stock tree navigation at the boundary.
- Horizontal entry selects the corresponding boundary unlock; Up/Down remains stock.
- Only the selected child is bright; original icon colors are restored on exit.
- The Technology node remains the actual native navigation/progression object. This is visual selection of an existing child, not new Technology/save/focus objects.
- The selected existing `TechUnlock.GetTooltip` remains the content owner.
- Mouse behavior remains native, with independent child tooltips.

DTT integration has not passed its production readiness gate. In particular, define one navigation/tooltip owner per node when PrayerClarity is installed, rather than adding two competing carousel handlers. The existing implementation is scoped to prayer-bearing nodes and cannot be described as already covering the whole tree. Single-unlock nodes should need no additional child-selection mode. Hidden unlocks remain hidden. Keep viewport containment: one long entry/localization can still exceed available space.

## Evidence and next review

The first preview uses bounded native costs/icons and existing private native font/parchment extractions. Browser layout does not establish Unity text-color, native icon-row or gamepad lifecycle correctness. No new production source, gameplay, version or installed payload is authorized merely by a browser preview.

Next: review keyword emphasis in the adopted named-icon layout; agree on the exact gamepad interaction/scope; establish separate per-change production gates for purpose copy, icon-row layout, keyword styling and navigation/coexistence before production changes. Representative runtime checks must include long single entries, single/multiple unlock counts, mouse/controller switching, close/reopen, hidden-row exclusion and PrayerClarity coexistence.
