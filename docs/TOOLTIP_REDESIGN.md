# Tooltip purpose and readability revision

Target: Graveyard Keeper1.407. Current production remains accepted1.1.6.

## Adopted design basis — 2026-10-21

The user selected the **icons plus material names** preview as the basis for the next revision and explicitly approved purpose explanations, one keyword-accent color, and single-unlock gamepad tooltips. A blueprint tooltip should answer what the unlocked construction does before listing its requirements and build location:

1. Native blueprint title.
2. Short, neutral, in-world purpose explanation, naming its useful action/result.
3. Requirements with native material icons, names and quantities.
4. Build location under the existing accepted native builder-location policy.

Purpose must be evidence-backed, not guessed from the object name. Preserve useful native description information, visibility, progression, costs and save state. Exact copy and implementation/runtime acceptance remain pending. Do not interpret adoption of the layout as acceptance of every draft phrase or all blueprint descriptions.

## Keyword emphasis — accepted rule and color family

The user accepted **sparse accents for distinguishing benefits, upgrades and numeric effects** after comparing density variants. Ordinary purpose does not need a colored result noun. A colored phrase in almost every explanation becomes intrusive when reading many unlocks. The accent family remains warm red when used.

Recommended rule: mark a short, decision-relevant result/capability phrase when there is one; zero accents is valid for a generic statement such as item storage. Use occasional additional emphasis only where meaning requires it. Use one consistent, readable accent; do not silently turn powder/solution/potion names into a new color-coded category system or imply resource availability. Metadata should follow localized meaning rather than broad localized-string search/replacement. Accent position follows natural syntax: avoid a mechanical sentence-final pattern, without moving words merely for visual variety.

Equal-weight co-listed benefits must be emphasized together or left plain. Do not color planks while leaving the equally presented grave decorations uncolored without a real semantic reason. Carpenter's purpose leaves both plain.

Automation is **not an independent reason for emphasis**. For the water pump, retain the factual word “automatically” but leave the complete sentence plain: `Automatically draws water from the well.` / `Автоматически набирает воду из колодца.` A future automation accent would need a real decision-relevant comparison, not a rule that every automatic actor receives color. This supersedes the earlier accepted pump automation accent.

Titles, muted body, material icons/names and selective semantic icons already supply structure; color need not carry every scanning task. Apply the sparse principle to the catalogue while keeping semantic copy and evidence status unchanged. Exact shade and host rendering still require visual acceptance. Historical comparison tables/variants illustrate earlier proposals and do not override this current rule.

Accepted refinements: solutions, powders and extracts at the three ordinary alchemy-processing stations retain their useful category accents; sparse emphasis is not a blanket ban on ordinary-purpose keywords. Healing extensions accent only the organ name, not “a skin slot”/“ячейку для кожи” as a whole. These specific choices override the broad first sparse pass.

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

## Body hierarchy and row labels — accepted design

The user prefers the muted-body preview: title stays dark, ordinary purpose/material/location text is quieter, and structural labels can remain darker. Exact colors/contrast across real game fonts and all locales require runtime acceptance.

The user accepted reusing PrayerClarity's red color family rather than introducing blue. Verified source: PrayerClarity `TechnologyTooltipTextStyle.KeyAccent = FF7A70`, reused across structural/named-reward emphasis. The browser proposal uses a readable darker warm red on parchment; it is not proof that a literal NGUI color tag will produce identical final pixels. Final host-rendered shade remains subject to runtime review.

The user explicitly selected **no heading above blueprint materials**, rejecting the author's `Для постройки:` / `Build cost:` recommendation. Native icons, names and quantities form the requirements block directly. The lighter presentation and removal of redundant words are intentional. This decision concerns the blueprint layout; it does not silently remove headings from every existing ordinary-recipe/special tooltip.

Accepted location wording: `Где строить: {native location}` / `Built in: {native location}`. Keep this as one wrappable line group with a darker prefix and muted location; preserve existing native builder coverage and the accepted Alchemy Lab naming exception. Russian `Строится в:` was considered but not preferred because native nominative place/menu labels would require case/preposition adaptation. The interrogative field label permits unmodified native names and multiple locations without an inflection table. Design acceptance does not establish live rendering acceptance.

## Purpose-copy investigation — 2026-10-21

The three alchemy-purpose sentences in the previews are original editorial drafts, not native game strings. Their functional basis was checked against current native station/recipe data; their exact wording has not been accepted.

Bounded read-only inspection of installed 1.407 `resources.assets`, `game_data`, `lng_en` and `lng_ru` found only names under localization keys containing `mf_alchemy_craft_02`, `mf_alchemy_stirrer_01` and `mf_alchemy_mill`, with no corresponding purpose descriptions. No `mf_*_d` descriptions were found in the inspected localization. The station records themselves have no description field. Searching English localization for the wiki's short mix/grind/two-ingredient phrases found no match. This is evidence against a ready description at those direct station keys, not proof that no related tutorial/dialogue text exists anywhere or that all blueprints lack descriptions.

Native neighboring Work/Perk descriptions use multiple voices: short factual source/action statements (for example ore/coal gathering), direct second-person capability explanations, and humorous flavor followed by an effect (writer/scientist). There is no single mandatory sentence template. Existing accepted project research also proves that authored descriptions can be incomplete or stale; existence alone is insufficient for reuse. Preserve useful native flavor, but verify the functional claim against 1.407 before relying on it.

Community wiki cross-checks:
- [Alchemy workbench (tier I)](https://graveyardkeeper.fandom.com/wiki/Alchemy_workbench_(tier_I)): two-input combining; listed products include paint as well as potions.
- [Hand mixer](https://graveyardkeeper.fandom.com/wiki/Hand_mixer): production of solutions and study prerequisite.
- [Alchemy mill](https://graveyardkeeper.fandom.com/wiki/Alchemy_mill): production of powders and study prerequisite.

Wiki text is a secondary explanation source, not developer-authored copy or a version-pinned mechanics authority. Its article paragraphs include details beyond the purpose block. No wiki paragraphs or native localization corpus are imported into the public repository.

Accepted editorial approach (the user approved this approach after reviewing the investigation):
1. Look for useful native description text first; retain/reuse it through a verified native lookup where adequate and accurate.
2. Where incomplete, preserve useful native information and add only the missing purpose. Where absent, author a concise explanation from verified behavior, using wiki explanations as a secondary cross-check.
3. Lead with action and useful result, normally one sentence. Include a differentiating capability such as two versus three ingredients when it explains the tier. Avoid repeating the title, vague praise, a full product catalog or story/recipe spoilers.
4. Match native terminology and approachable in-world voice, without requiring every blueprint to imitate humorous Perk text. Meaning and correctness take priority over copying vanilla omissions or awkward wording.
5. Keep English as semantic source and Russian as review locale. Select the short emphasized result phrase while editing each translation; color must not be the only carrier of meaning.
6. Review a small representative copy set before scaling to all eligible blueprints. Record evidence and native-text availability with each reviewed entry; exact implementation/data format remains open.
7. Edit related tiers as a family. Emphasize the decision-relevant distinction (capacity, automation, quality bonus, etc.), not automatically the output noun. **Adopted direction:** a base tier explains the role; an upgrade foregrounds its verified new benefit and may use a short reference to the previous tier instead of repeating its output catalogue. Use an explicit reference only where it improves comprehension; “improved version” alone adds little. Keep parallel self-contained phrasing for complementary stations (the alchemy tables) and clear short numeric comparisons. The catalogue contains proposed sentences for user review, not final copy acceptance. Similar wording must not imply unproved recipe inheritance or that every capability is identical.

Benefit selection refinement: a useful new product/capability normally outranks a modest quantity increase or time saving. Compare productive recipes rather than raw output-ID sets: recycling/dismantling outputs are not new manufacturing functions, and multiquality parents require their real variants. Circular saw now leads with native Wooden beam / Деревянная балка; Stone cutterII with carved stone/marble. DistillationII still leads with yield because its inspected output set adds no new item. Quality/preservation can remain the headline when they are the meaningful improvement. Judge speed by the actual player wait/work path: embalming is an automatic180->90-second process at normal simulation speed, so a shorter wait is meaningful; the current draft retains it second, after preservation. Shelf/rack location repetition is not the default way to diversify copy because the location row already supplies it. Ordinary garden-bed vegetables are accepted representative shorthand, and orchard plots use parallel planting-capability phrasing.

### Editorial pilot — accepted subset and remaining proposals

The user further specified concise, unambiguous, clear, easily read and elegant sentences. Avoid vague appendages such as “and other alchemical mixtures.” A purpose sentence need not enumerate every product: a meaningful category or representative concrete outputs can convey the function. The user accepted omitting paints from both tier descriptions to make the two/three-input difference immediately scannable, and accepted the candelabra bonus/candle sentences and pump automation wording below; the pump accent was subsequently removed under the current sparse rule. Do not force identical wording at the cost of an important functional difference.

Bold spans below illustrate semantic emphasis, not literal markup or verified host colors. All entries are original editorial text. The paired alchemy purpose and three candelabra sentences are accepted; the pump sentence is now plain under the current accent rule. Other rows remain drafts. English remains the semantic source, with Russian used for review. The complete grouped continuation is [BLUEPRINT_PURPOSE_CATALOGUE.md](BLUEPRINT_PURPOSE_CATALOGUE.md), covering104 distinct visible blueprints/105 references and distinguishing mechanically unverified drafts.

| Native unlock | English draft | Russian draft |
| --- | --- | --- |
| Alchemy workbench / `mf_alchemy_craft_02` | Makes potions from **two ingredients**. | Готовит зелья из **двух ингредиентов**. |
| Hand mixer / `mf_alchemy_stirrer_01` | Processes materials into alchemical **solutions**. | Перерабатывает материалы в алхимические **растворы**. |
| Alchemy mill / `mf_alchemy_mill` | Grinds materials into alchemical **powders**. | Измельчает материалы в алхимические **порошки**. |
| Alchemy workbench II / `mf_alchemy_craft_03` | Makes potions from **three ingredients**. | Готовит зелья из **трёх ингредиентов**. |
| Trunk / `mf_box_stuff` | Storage for items. | Место для хранения предметов. |
| Candelabra I / `candelabrum_1` | **+1 church quality**. Candles increase the bonus. | **+1 к качеству церкви**. Свечи усиливают эффект. |
| Candelabra II / `candelabrum_2` | **+2 church quality**. Candles increase the bonus. | **+2 к качеству церкви**. Свечи усиливают эффект. |
| Candelabra III / `candelabrum_3` | **+3 church quality**. Candles increase the bonus. | **+3 к качеству церкви**. Свечи усиливают эффект. |
| Water pump / `well_pump_place` | Automatically draws water from the well. | Автоматически набирает воду из колодца. |

The accepted paired potions/two-versus-three phrasing is sufficient to explain purpose and makes the tier distinction easier to scan. It does not claim exclusive potion production or that tier II inherits the first table's recipes. Do not append “only” or describe the second table as simply replacing all functions of the first. The pump's automatic operation remains in the wording; the user explicitly removed its color emphasis in the later sparse-accent decision. The accepted candelabra copy replaces the rejected heavy “serves as a candle stand” phrasing. Earlier paint/mixture alternatives are superseded.

The user approved selective native purpose icons with explanatory text. Next visual review: church quality `(cross)` plus words; graveyard quality `(wskull)` plus words; optionally native powder/solution/extract category symbols. Exact native mappings and the distinction from crafting quality are recorded in the catalogue. The principle is accepted; placement, tint and production rendering still require normal visual review.

### Manual-station voice and upgrade benefit review

The user rejected the actor implication of manual workstations “cutting/making” things by themselves and requested alternative formulations. Further review rejects repetitive `Для…`, finds bare process names lifeless, and finds bare `Можно…` insufficiently bound to the workstation. The preferred candidate is object-enabled action (`Позволяет…`), but the user explicitly did not declare it the only correct form. The semantic purpose remains approved where explicitly accepted, but manual surface grammar is reopened. [TOOLTIP_LANGUAGE_RESEARCH.md](TOOLTIP_LANGUAGE_RESEARCH.md) records direct native GK1 examples, documented Stardew/RimWorld/Terraria patterns, the GK2 evidence limit and a small comparison set. Do not mass-rewrite all catalogue rows again before reviewing that set. Keep actual zombie actors/automation explicit.

The user also identified a systematic benefit-selection problem: native evidence must establish what improves and which difference matters to the player, rather than selecting the first easily measurable difference. The ten-family paired-data audit corrects DeskII to quality and distillationII to increased material yield (with goo exceptions), and checks yield/capability/speed/energy/fuel/quality across other workstation families. Community guides/discussions supply relevance hypotheses, native1.407 data decides exact claims. Existing catalogue flags for special/virtual mechanics remain open; improved prose is not proof of them.

The subsequent user direction accepts **mixed voice**, with object-enabled action preferred but not repeated universally. Place-bound `Здесь можно…` is welcome; `На нём…`/`На них…` is not preferred. Occasional `Используется для…`/similar natural purpose constructions remain available. Select words by function and readability, not a rotating prefix schedule; retain parallel sister-tier descriptions. Omit secondary/unfamiliar outputs when they dilute the immediate purpose (the user's example is Sawhorse billets). The requested ten-building RU/EN review set is in the language research; those exact new sentences are still proposals.

The user accepted that set as a strong review basis and requested three/four natural opening patterns in its early rows. Qualitative purpose copy should communicate the main benefit without enumerating every exception; preserve exact exceptions in the mechanics evidence rather than forcing “most products” qualifiers into each short description. The revised DeskII proposal uses PrayerClarity's existing `Бонус к качеству письма` / `Writing quality bonus` terminology. It does not adopt a numeric prayer buff, universal percentage or gold-output guarantee. The refreshed set remains under wording review.

The user accepted the refreshed set and requested applying its style to all remaining descriptions. That first pass reviewed104 EN/RU rows and revised70 while retaining23 mechanics flags. The later delta-first direction is now approved; new exact sentences remain drafts. The [mechanics follow-up](PURPOSE_MECHANICS_REVIEW.md) resolves20 flagged selected claims and retains3 contradictions. Accent density has been reopened above. These are distinct editorial/evidence states; none establishes implementation or installed rendering acceptance.

Bounded static evidence for the additional pilot entries, from installed 1.407 data:
- The four additional entries are authored-visible blueprint records in Advanced alchemy, Improvement, Light of faith and Engineer respectively (visibility still depends on native UI/save rules).
- The non-auxiliary, non-hidden tier-II formula rows inspected have three ingredient entries (20 rows). This supports three-input wording; it does not authorize revealing their recipes.
- `mf_box_stuff` has native inventory storage (inventory size25). The draft deliberately omits a numerical slots/stack interpretation pending the corresponding UI contract.
- `candelabrum_1` has base quality1 under the church builder, and native candle-input crafts change it to candle-bearing variants. The revised draft states the base bonus separately from the unquantified candle enhancement, without claiming a permanent candle bonus or duration.
- Family follow-up: `candelabrum_1/2/3` have base qualities1/2/3. Their native candle crafts consume1/2/3 candles respectively and target variants with qualities2/3/4,4/6/8,6/9/12 according to candle type. This supports the paired base-bonus sentences and “candles increase the bonus.” The purpose block intentionally omits candle-type tables/durations. Quality icon presentation must follow the existing native metric-token contract rather than inventing a Unicode star.
- Both native alchemy tables have potion/elixir outputs in the inspected recipes, so potions can serve as a representative shared purpose. Their different output sets are not equivalent; this does not support describing paints as a tier-II capability or treating ingredient count as the only mechanical distinction.
- The water-pump build record targets `well_pump_place`; its functioning `well_pump` object accepts water, and the native automatic pumping craft writes water into that object's inventory. The draft does not claim pumping speed, unlimited supply or automation of all nearby stations. This is static functional support, not a new runtime acceptance.
- Direct localization inspection found names but no purpose text under the inspected additional object IDs; wording is original. No proprietary data corpus is committed.

This pilot tests production, processing, tier distinction, storage, decoration and automatic supply. Before production, final wording must still pass the relevant purpose-copy gate and representative localization/runtime review. The pilot is not a promise to broaden scope to hidden unlocks or rewrite all existing Work/Perk descriptions.

## Evidence and next review

The first preview uses bounded native costs/icons and existing private native font/parchment extractions. Browser layout does not establish Unity text-color, native icon-row or gamepad lifecycle correctness. No new production source, gameplay, version or installed payload is authorized merely by a browser preview.

Next: review the remaining grouped copy in the catalogue and resolve its flagged mechanics; establish separate per-change production gates for purpose copy, icon-row layout, keyword styling and navigation/coexistence before production changes. The overall layout, warm red accent family, no material heading, location wording, standalone mixed-node behavior, conditional responsibility split and explicitly accepted pilot prose are approved; other purpose sentences and live rendering still need their normal evidence and acceptance. Representative runtime checks must include long single entries, single/multiple unlock counts, mouse/controller switching, close/reopen, hidden-row exclusion, PrayerClarity absent, each supported PrayerClarity edition active, and installed-but-unavailable capability fallback.
