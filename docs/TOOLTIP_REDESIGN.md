# Tooltip purpose and readability revision

Target: Graveyard Keeper1.407. Current production remains accepted1.1.6.

## Adopted design basis — 2026-10-21

The user selected the **icons plus material names** preview as the basis for the next revision and explicitly approved purpose explanations, one keyword-accent color, and single-unlock gamepad tooltips. A blueprint tooltip should answer what the unlocked construction does before listing its requirements and build location:

1. Native blueprint title.
2. Short, neutral, in-world purpose explanation, naming its useful action/result.
3. Requirements with native material icons, names and quantities.
4. Build location under the existing accepted native builder-location policy.

Purpose must be evidence-backed, not guessed from the object name. Preserve useful native description information, visibility, progression, costs and save state. Exact copy and implementation/runtime acceptance remain pending. Do not interpret adoption of the layout as acceptance of every draft phrase or all blueprint descriptions.

## Keyword emphasis — accepted rule, palette under review

The user approved emphasizing the semantically decisive result/capability in each purpose description, for example powders or solutions. This is a general editorial rule, not a request to color all occurrences of certain Russian words across every surface.

Recommended rule: mark one short result/capability phrase per short explanation, with occasional additional phrase only where the meaning requires it. Use one consistent, readable accent; do not silently turn powder/solution/potion names into a new color-coded category system or imply resource availability. Metadata should follow localized meaning rather than broad localized-string search/replacement.

Draft focus terms: `растворы`, `порошки`; for the table `алхимические составы` is proposed instead of only `зелья`, because the native two-input table also produces paint/other mixtures. Exact highlighted phrase and palette are pending user review.

## Gamepad single-unlock presentation — approved direction, not implemented

The user proposed reusing the PrayerClarity approach so a multi-unlock Technology shows only the selected existing unlock's tooltip. The inspected precedent is `NikichMods/PrayerClarity@ce915344064655cde5273cea8a10ec4ec2beb2e5`, `src/TechnologyPrayerCarousel.cs`, `docs/DESIGN_NOTES.md` (controller navigation), and accepted0.2.23/1.0.33 evidence in `docs/TEST_BUILD_LOG.md`.

Existing accepted PrayerClarity behavior:
- At least two visible unlocks and at least one prayer activate its carousel, in both editions.
- Left/Right traverse the current node's visible unlocks in native order, then fall through to stock tree navigation at the boundary.
- Horizontal entry selects the corresponding boundary unlock; Up/Down remains stock.
- Only the selected child is bright; original icon colors are restored on exit.
- The Technology node remains the actual native navigation/progression object. This is visual selection of an existing child, not new Technology/save/focus objects.
- The selected existing `TechUnlock.GetTooltip` remains the content owner.
- Mouse behavior remains native, with independent child tooltips.

DTT integration has not passed its production readiness gate. The existing PrayerClarity implementation is scoped to prayer-bearing nodes and cannot be described as already covering the whole tree. Single-unlock nodes should need no additional child-selection mode. Hidden unlocks remain hidden. Keep viewport containment: one long entry/localization can still exceed available space.

### Accepted mixed-node ownership

The user explicitly chose the following after reviewing the mixed-node consequence:
- With PrayerClarity's carousel actually active on a prayer-bearing Technology, PrayerClarity owns gamepad switching and prayer explanation.
- DTT preserves its explanations for non-prayer blueprints/recipes/perks in that same node.
- DTT does not add requirements/details to prayer unlocks themselves.
- Do not exclude the entire Technology from DTT content merely because one visible unlock is a prayer.
- Without PrayerClarity, DTT owns single-unlock gamepad selection across all applicable Technologies, including mixed prayer/blueprint/perk nodes. Non-prayer entries receive DTT content; prayer content stays vanilla under the accepted no-prayer-enrichment scope. A prayer-bearing node is not excluded from DTT navigation just because of its content.
- Never run two competing carousel controllers on one node. Detect actual carousel ownership/capability, not merely a DLL/plugin's presence. If PrayerClarity is installed but its carousel is unavailable/disabled/fails, DTT should retain its standalone behavior when it can establish exclusive ownership safely; otherwise use a contained native fallback rather than competing handlers. Exact failure-containment and device-switch paths must be proved under the compatibility gate. PrayerClarity is not a hard dependency.

Evidence for retaining non-prayer content: bounded native1.407 data inspection, using PrayerClarity's known item families and linked `pray:` family correspondence, identifies mixed nodes including Embalming (one prayer and two blueprint crafts), Engineer (one prayer, a well-pump craft and p_engineer), and Martial skills (two prayers and p_big_guy). Whole-node content exclusion would remove DTT coverage, including existing accepted special explanations/corrections. This is static authored-data evidence, not a claim about a particular save's live visibility. The exploratory ID-prefix-only lookup was rejected because Technology craft IDs name prayer-item recipes rather than directly starting with `pray:`; production classification must resolve the semantic link.

## Body hierarchy and row labels — design review

The user prefers the muted-body preview: title stays dark, ordinary purpose/material/location text is quieter, and structural labels can remain darker. Exact colors/contrast across real game fonts and all locales require runtime acceptance.

The user proposed reusing PrayerClarity's existing red accent rather than introducing blue. Verified source: PrayerClarity `TechnologyTooltipTextStyle.KeyAccent = FF7A70`, reused across structural/named-reward emphasis. The browser proposal uses a readable darker warm red on parchment; it is not proof that a literal NGUI color tag will produce identical final pixels. Final red shade remains under review.

Compare three blueprint-only material-label proposals on the same layout: no label; `Материалы:` / `Materials:`; `Для постройки:` / `Build cost:`. Author recommendation: the last option distinguishes one-time construction requirements from the station's operating ingredients. No label is visually lighter but saves only one line now that gamepad shows one unlock at a time.

Location wording proposal: `Где строить: {native location}` / `Built in: {native location}`. Keep this as one wrappable line group with a darker prefix and muted location; preserve existing native builder coverage and the accepted Alchemy Lab naming exception. Russian `Строится в:` was considered but not preferred because native nominative place/menu labels would require case/preposition adaptation. The interrogative field label permits unmodified native names and multiple locations without an inflection table. These wording/palette choices remain proposals, not accepted localization edits.

## Evidence and next review

The first preview uses bounded native costs/icons and existing private native font/parchment extractions. Browser layout does not establish Unity text-color, native icon-row or gamepad lifecycle correctness. No new production source, gameplay, version or installed payload is authorized merely by a browser preview.

Next: finish palette/material-label/location-wording review; establish separate per-change production gates for purpose copy, icon-row layout, keyword styling and navigation/coexistence before production changes. The overall revision, standalone mixed-node behavior and conditional responsibility split are approved; exact prose and live rendering still need their normal evidence and acceptance. Representative runtime checks must include long single entries, single/multiple unlock counts, mouse/controller switching, close/reopen, hidden-row exclusion, PrayerClarity absent, each supported PrayerClarity edition active, and installed-but-unavailable capability fallback.
