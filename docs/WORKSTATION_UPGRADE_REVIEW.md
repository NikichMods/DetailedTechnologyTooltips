# Workstation purpose and upgrade audit — 2026-10-21

Status: static research and editorial revision. No production changes or installed acceptance. Owning copy catalogue: [BLUEPRINT_PURPOSE_CATALOGUE.md](BLUEPRINT_PURPOSE_CATALOGUE.md).

Current follow-up: [PURPOSE_MECHANICS_REVIEW.md](PURPOSE_MECHANICS_REVIEW.md) establishes the native body-decay owner and resolves20 of23 formerly flagged selected claims. PrintingII's distinguishing benefit and extractorII/III damage remain unresolved for explicit reasons there. Historical “pending” statements in the paired-audit table below are superseded where that follow-up supplies the missing owner; no new claim of copying availability or surgical-risk reduction follows.

## Corrected question and method

The first catalogue established many supported outputs, but often selected the easiest measurable tier difference rather than the benefit a player needs to understand. In particular, DeskII energy savings obscured its quality improvement, and the distillation comparison omitted evaluated output expressions. The user rejected manual-station wording that makes the object sound like an automatic actor, approved selective native purpose icons, and requested externally informed benefit research.

For each family, separate:
1. purpose shared by the family;
2. new capabilities/recipes;
3. output yield and input economy;
4. quality and its scope;
5. operational differences such as speed, energy, fuel, decay and risk;
6. the player-relevant distinction to put in the short tooltip.

All categories must be checked before prioritizing one. This is a checklist for research, not six required tooltip rows. A secondary efficiency difference must not displace a more important quality/yield/capability difference just because it is simpler to prove. Conversely, energy/fuel may matter for some stations; the user's rejection of energy as the DeskII headline does not mean it is universally irrelevant.

Match actual recipe variants by input identity/counts and output identity before comparison; include min/max output expressions, multiquality branches, difficulty, linked perks, craft-time, energy, fuel and unlock/condition fields. Do not use serialized Item.value as evaluated yield. Do not infer availability from a recipe existing in the balance: `needs_unlock`, hidden references, scripting and UI ownership remain separate.

Primary input remains exact1.407 resources SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`. The existing shared [multiquality model](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/PERK_MECHANICS.md#native-multi-quality-model) establishes difficulty/perk contributions; improved quality score is not a universal percentage or guaranteed gold output.

## External triangulation

Sources are community explanations and historical player experience, not pinned1.407 mechanics authorities. They identify useful hypotheses and what players consider important; current native inspection adjudicates the applicable claim. Original paraphrases only; no article corpus imported.

| Source | What it changes in this review | Limit |
| --- | --- | --- |
| [Desk II](https://graveyardkeeper.fandom.com/wiki/Desk_II) and [Writing](https://graveyardkeeper.fandom.com/wiki/Writing) | Quality is a main benefit, not just lower energy. | The pages contain differing historical figures; do not import a blanket20% bonus. |
| [Gold Stories? — Steam discussion](https://steamcommunity.com/app/599140/discussions/0/1734336452564676628/) | Players recommend DeskII for higher-quality output. | 2018 discussion; qualitative relevance, not exact modern values. |
| [Onion](https://graveyardkeeper.fandom.com/wiki/Onion) and [Pumpkin](https://graveyardkeeper.fandom.com/wiki/Pumpkin) | DistillationII examples show2->3 extract, disproving a universal “double” claim. | Verify formulas and perk terms in native data rather than extrapolating two examples. |
| [Question about tier2 buildings — Steam](https://steamcommunity.com/app/599140/discussions/0/3276824488714313076/) | Recipe retention and whether the old station can be removed are player concerns. | Broad old claims are not accepted as universal native equivalence. |
| [Simple Mistakes to Avoid — Steam guide](https://steamcommunity.com/sharedfiles/filedetails/?id=2285231626) | Explicit warning to keep both alchemy tables: two/three-input tables are complementary. | Does not establish every other station's behavior. |
| [Advanced Starting Tips — Steam guide](https://steamcommunity.com/sharedfiles/filedetails/?id=1482661523) | Carved stone/decorations, lenses and steel equipment are practical motivations for station progression. | Some recommendations and bug statements are historical; not imported as mechanics facts. |
| [Printing press II](https://graveyardkeeper.fandom.com/wiki/Printing_press_II) and [Printing Press Missing Recipes — Steam](https://steamcommunity.com/app/599140/discussions/3/1734336452581918474/) | Missing advertised recipes are a known source of disappointment. | Neither old bugs nor the wiki's “no known advantage” proves current recipe availability. |

## Native findings and editorial consequences

| Family | Checked native finding | Proposed emphasis / remaining limit |
| --- | --- | --- |
| DeskI/II | Matching notes difficulty0.8->0.7; chapters0.9->0.8; hardcover books0.5->0.3; stories-0.7->-1.0. Many prayer recipes improve by0.2; two inspected prayer families have no difficulty change. Energy also changes for some recipes. | **Better chances of high-quality writing and most prayers**. Omit energy from the short purpose headline. No universal+20%, no guarantee and no improvement claim for every prayer. |
| DistillationI/II |26 matching visible non-auxiliary recipes:18 material-decomposition formulas gain exactly+1 extract at equal inputs and equal Scientist perk;8 four-goo recovery formulas keep the same output. All inspected paired craft_time90->60. | **More extract from materials** first, speed second. Neither universal double nor+1 on goo. If numerical prose is used, say “+1 extract when processing materials,” with recovery explicitly outside that claim. |
| FurnaceI/II/III | Additional supported metal/glass/steel-part recipes; matching outputs differ in craft-time/fuel. Graphite atII->III has equal coal inputs and output1->2. Some individual fuel costs increase, e.g. a glass recipe15->25. | Metal capability atII; steel parts and **more graphite** atIII. Reject universal “less fuel” or “every recipe faster/cheaper.” |
| Wooden anvil/Anvil/AnvilII | New complex-parts/weapons/steel-tool recipes. At Anvil->AnvilII, nails8+perk*3 ->9+perk*3 and simple parts4+perk ->5+perk for matching inputs. | New equipment plus **more nails/simple parts**. Do not infer a universal yield increase for all products. |
| CarpenterI/II | Upper tier adds lens, steel armor, jointing/carved-wood recipes. A matching multiquality steel-chisel variant difficulty0->-0.3. Existing recipes are not uniformly different. | **Lenses and steel equipment** are useful concrete added capabilities. Do not headline only carved wood or imply universal quality gain. |
| Stone cutterI/II | Expanded grave-decoration family; matching basic stone/marble processing is present at both tiers, with some time/energy differences. | Expanded **stone and marble grave decorations**; do not falsely imply first marble processing requires tierII. Exact higher-decoration recipes still have independent unlocks. |
| Sawhorse/Circular saw | Matching billet output4->5+Woodworker; flitch6->7+2*Woodworker; upper station also supports direct plank production. | **More wood from each log** and direct planks. Do not conflate the automation of a zombie workstation with the manual saw. |
| PrintingI/II | Flyer variants match input/output/time/energy. Additional serialized `printng_notes`, `printng_notes_2`, `printng_chapter` definitions exist, need unlocks and use multiquality parent outputs. | Earlier “no advantage” inference was too broad. Keep **flyers** as supported purpose; mark tier comparison pending the actual unlock/UI path. Do not advertise chapter copying from balance existence alone. |
| EmbalmingI/II |8 paired injection recipes have native craft_time180->90 with matching ordinary inputs. | **Faster injections** is proved. Wiki also identifies stopped decay atII; exact decay owner is still pending. Do not replace the more important preservation/risk benefit with speed without reviewing that owner. |
| PreparationI/II | The generic physical-output pair audit does not describe the special body-operation path. Existing shared [Perk mechanics](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/PERK_MECHANICS.md) covers surgery-risk ownership; wiki describes tierII decay/risk benefits. | Need exact table-tier consumer proof for decay/error reduction; no guessed percentage or universal zero-error claim. Keep the catalogue flag. |

The paired data audit is complete for these ten families, but this is not a universal availability/UI audit and does not resolve the catalogue's virtual-build/soul-equipment flags. The ordinary-output-name census used for the first draft omitted multiquality parent IDs absent from the physical item lookup; output families must also resolve `multiquality_items` before conclusions about missing products or a station's sole use.

## Manual-station voice options

These are historical comparison drafts; no global surface template has been selected by the user. Subsequent feedback rejects repetitive `Для…` and bare process names, and finds unbound `Можно…` insufficient. Current object-enabled action candidates and source research are in [TOOLTIP_LANGUAGE_RESEARCH.md](TOOLTIP_LANGUAGE_RESEARCH.md). Approved alchemy/candelabra/pump semantics remain binding while manual-station grammar is reviewed.

| Pattern | Sawhorse | DeskII | Strength / cost |
| --- | --- | --- | --- |
| Action noun without prefix | Распиловка брёвен на **доски и заготовки**. | Написание книг и молитв. **Бонус к качеству** у большинства изделий. | The leanest option; can sound like a process/menu heading rather than a description. |
| Purpose phrase | Для распиловки брёвен на **доски и заготовки**. | Для записей, книг и молитв. **Выше шанс высокого качества**. | Short, neutral; repeated “Для” and noun-heavy phrasing can feel like labels. |
| Player capability | Можно распиливать брёвна на **доски и заготовки**. | Можно писать книги и молитвы с **большим шансом высокого качества**. | Clear human action, but repetition and longer lines. Scope of “most prayers” needs care. |
| Place/action | Здесь можно распиливать брёвна на **доски и заготовки**. | Здесь можно писать книги и молитвы с **большим шансом высокого качества**. | Natural in-world language, but “здесь” is slightly awkward before construction and costs a word. |
| Impersonal result | Из брёвен получаются **доски и заготовки**. | Записи и большинство молитв получаются **более высокого качества**. | Concise, but can sound guaranteed and may obscure manual work; the quality line needs probability wording. |

The author's earlier purpose-phrase recommendation is superseded by the user's rejection of that style. Current recommendation for comparison is object-enabled action (`Позволяет…` / `Allows you to…`), supported and qualified in the language research. Actual automation should remain explicit (`Automatically…`, `A zombie…`). Storage/quality-bonus rows need not be forced into the same grammatical shape.

## Benefit selection and next review

For the short line, prefer the difference that changes the player's decision: new capability, yield, quality, preservation or risk, as supported for that family. Speed/energy can be secondary or omitted. This is editorial prioritization, not a claim that one ranking suits every construction. Keep the family purpose recognizable and vary only the relevant distinction, but do not trade correctness for symmetry.

The user accepted the mixed-voice ten-building basis and authorized applying it across the catalogue. That EN/RU editorial pass is now complete; the old purpose-phrase-only presentation is superseded. Exact owner checks for flagged tier/virtual/soul behaviors remain separate. No production change, version or runtime acceptance is implied.
