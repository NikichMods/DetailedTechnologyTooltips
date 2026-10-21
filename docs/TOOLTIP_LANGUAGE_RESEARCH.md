# Tooltip language: object-enabled actions

Research/review date:2026-10-21. Editorial evidence and proposals only; no production code or new global wording acceptance.

## Question and current user direction

The user rejected repetitive purpose phrases (`Для…`) and found bare process names lifeless. Bare player capability (`Можно…`) also loses the explicit connection to the workstation. The preferred candidate is object-enabled action (`Позволяет…`): the object supplies the means, while the player performs the work. The user did not select that as the only permitted construction and requested comparison with other games and native Graveyard Keeper language.

This supersedes the author's previous recommendation to lead with purpose phrases. The full catalogue's63 purpose-phrase rows remain a semantic/benefit inventory, not a currently recommended surface style. Do not mass-convert the catalogue again before the small comparison set is reviewed. Accepted alchemy ingredient counts, candelabra benefits, pump automation emphasis, icon principle and family consistency remain binding; grammatical presentation of manual work remains open.

## Provenance and bounded findings

Distinguish actual game text from a wiki editor's explanation. A wiki item-tooltip/description field is a documented transcription, not independent observation of the installed game's current screen. Native GK1 localization is direct authored-text evidence; whether a given key is actually presented on a Technology tooltip is a separate owner check. The sample is deliberately small and purposive; it does not establish that one phrase is statistically dominant or inherently best because a popular game uses it.

| Game / source | Verified text pattern | Relevance and limits |
| --- | --- | --- |
| GK1 installed1.407: `zombie_crafting_table_d` | EN imperative with `here`; RU `Здесь можно…` | Direct native localization supplies an actual workstation-purpose sentence. It explicitly ties capability to the station, without making the table a worker. This was missed in the previous catalogue's native-text availability conclusion. Presence in localization does not prove that vanilla Technology UI displays it. |
| GK1 installed1.407: `witchers_eye_d` | RU `Позволяет…`; English describes what the item provides to its bearer | Direct authored example of the proposed Russian capability wording. It is an item description, not a workstation-family template. |
| GK1 installed1.407 Work/Perk descriptions | EN `You can…`, `Can be…`; Russian direct player speech and impersonal source statements | Native voice varies by surface. Work/Perk flavor is useful context but is not a reason to write a joke or address the player personally in every blueprint. |
| [Stardew Valley Mill](https://stardewvalleywiki.com/Mill) | `Allows you to…` | The building description lists what milling enables. Strong object-capability precedent; it does not by itself identify whether work is manual or automatic. |
| [Stardew Valley Workbench](https://stardewvalleywiki.com/Workbench) | `When crafting here…` | The item description binds player action to this workstation, then states its specific benefit. Do not confuse the separate wiki prose below it with the quoted description. |
| [RimWorld stonecutter's table](https://rimworldwiki.com/wiki/Stonecutter%27s_table) | Work-table noun plus purpose | Description supplied in the item infobox, separate from the subsequent wiki introduction. Establishes object context directly, but maps to the noun/purpose style the user finds less appealing. |
| [Terraria work benches](https://terraria.wiki.gg/wiki/Work_Benches) | Tooltip field: `Used for…` | Concise neutral purpose. Useful evidence for passive wording, not a reason to insist on a disliked `Для…` style. |
| [Stardew Valley Furnace](https://stardewvalleywiki.com/Crafting) | Actor-style conversion verb | An automatically processing machine can reasonably be described this way. Do not transfer it mechanically to GK manual workstations. |

Direct native input: resources.assets SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`; `lng_en`/`lng_ru`. A bounded search of description-key suffixes found31 capability/use-related short strings, and the existing105-reference blueprint extraction contains one non-empty direct `_d` purpose entry: the resurrection table. This is a result within that key lookup, not proof no related aliases/tutorials exist elsewhere. No localization corpus or proprietary assets are committed.

### Graveyard Keeper2 applicability limit

Checked the [official Steam page](https://store.steampowered.com/app/4358690/Graveyard_Keeper_2/) and publicly indexed station/reference material, including a [woodworking-workbench article](https://graveyardkeeperwiki.com/gk2/facilities/woodworking-workbench-i/). The official store copy is marketing text; the article's prose is not identified as a native tooltip transcription. Neither establishes the developers' actual workstation-tooltip grammar. No authenticated native text corpus or legible corresponding in-game tooltip was recovered in this bounded pass. GK2 therefore supplies no accepted tooltip-language example here. Do not rebrand fan reference prose as developer language.

## Small comparison set

All following lines are original DTT proposals, not quotes from another game. Bold is a proposed semantic accent; exact color/icons remain a host-rendering decision.

| Construction | Object-enabled action | Object-bound player capability |
| --- | --- | --- |
| Козлы / Sawhorse | Позволяют распиливать брёвна на **доски и заготовки**. | На них можно распиливать брёвна на **доски и заготовки**. |
| Место для рубки / Chopping spot | Позволяет заготавливать **дрова и клинья**. | Здесь можно заготавливать **дрова и клинья**. |
| Алхимический стол / Alchemy workbench | Позволяет готовить зелья из **двух ингредиентов**. | На нём можно готовить зелья из **двух ингредиентов**. |
| Алхимический столII / Alchemy workbenchII | Позволяет готовить зелья из **трёх ингредиентов**. | На нём можно готовить зелья из **трёх ингредиентов**. |

Plural `Козлы` takes `Позволяют`/`на них`; do not apply a literal singular prefix to every localized title. This is authored grammar, not justification for a runtime localized-string parser.

English options for the same first row:
- `Allows you to cut logs into **flitch and billets**.` — familiar neutral game-help wording; strongest evidenced comparison for the current user goal.
- `Lets you cut logs into **flitch and billets**.` — shorter, more conversational; a candidate, not a claim about GK's native wording.
- `You can cut logs into **flitch and billets** here.` — explicitly place-bound; natural, but the trailing here is less useful before construction and longer than the capability prefix.

## Accepted mixed-voice direction and ten-building review set

The user prefers object-enabled action but rejects using one repeated prefix everywhere. Mix capability, place-bound action (`Здесь можно…`) and occasional natural use/purpose constructions (`Используется для…`, `Служит для…`). Bare repetitive `Для…` and process headings are not the preferred general voice. Avoid anaphoric `На нём…`/`На них…`; the issue is the phrase's feel and binding, not a request for a runtime blacklist of pronouns. Keep the natural object relationship without copying exact words mechanically.

The user also prioritizes intelligibility and elegance over output enumeration: Sawhorse can explain boards without listing unfamiliar billets. This follows the already accepted representative-output principle; omission must not hide the main reason to choose a higher tier.

Distribution recommendation: choose a voice by the building's role and natural sentence rhythm, and keep related tiers parallel. Do not rotate prefixes by row number or vary sister-tier grammar merely to avoid repetition. Capability remains the default candidate; a recognizable workplace can use here; a vessel/process can use a purpose clause; numeric benefits and actual automation can stand directly. Translation may choose its own natural syntax while preserving meaning/emphasis.

The user accepted the ten-building set as a strong basis, then requested more variation in its early rows without sacrificing other qualities. It remains **a review basis**, not final copy acceptance or a complete rewrite of the104-row catalogue. Bold marks candidate accent spans; icon principle is accepted but exact placement/rendering remains separate.

The user explicitly prioritizes the main player benefit over listing all exceptions in the short purpose. Keep verified exceptions in the research; a concise qualitative benefit label need not enumerate them. This does not permit invented universal percentages, guarantees or unsupported mechanics. The short DeskII quality label below intentionally omits the awkward “most products” qualification while its exact recipe differences remain in the upgrade audit.

| Building / context | Russian proposal | English proposal |
| --- | --- | --- |
| Sawhorse / Workyard | Позволяют распиливать брёвна на **доски**. | Allows you to cut logs into **boards**. |
| Chopping spot / Workyard | Здесь можно заготавливать **дрова и клинья**. | You can make **firewood and wedges** here. |
| Alchemy workbench / Alchemy lab | Служит для приготовления зелий из **двух ингредиентов**. | Lets you make potions from **two ingredients**. |
| Study table / Alchemy lab | Используется для изучения предметов и получения **очков технологий**. | Used for studying items and earning **technology points**. |
| DeskII / Alchemy lab | **Бонус к качеству письма** при создании книг и молитв. | **Writing quality bonus** when making books and prayers. |
| Wine making barrel / Cellar | Служит для приготовления **вина** из виноградного сока. | Used to make **wine** from grape juice. |
| Resurrection table / Morgue | Здесь можно создавать **зомби-рабочих** из тел. | Make **zombie workers** from bodies here. |
| CandelabraI / Church | **+1 к качеству церкви**. Свечи усиливают эффект. | **+1 church quality**. Candles increase the bonus. |
| Compost heap / Garden | Используется для переработки отходов урожая в **торф**. | Used to turn crop waste into **peat**. |
| Water pump / Workyard | Автоматически набирает воду из колодца. | Automatically draws water from the well. |

Semantic evidence: existing native blueprint/craft study, the paired upgrade review and accepted candelabra/pump/alchemy semantics. Resurrection reuses the direct native localization text; actual localization/rendering owner still needs its normal integration proof. DeskII uses the shared PrayerClarity quality term as a qualitative benefit, not a claim that every recipe improves or that gold is guaranteed. Other practical outputs such as billets or maggots are omitted from this set as secondary to the stated purpose, not denied as supported outputs. English Sawhorse purpose uses ordinary-category “boards” for readability; it does not claim direct `wooden_plank` production or rename the native Flitch item in an actual item/material row. No new gameplay behavior is inferred.

Author critique: mixed voice is useful when driven by meaning, but arbitrary synonym rotation can weaken the very family comparisons the user requested. Keep alchemyI/II identical apart from the accepted ingredient count: the tierII counterpart now reads `Служит для приготовления зелий из **трёх ингредиентов**.` Sawhorse's omitted billet term helps an unfamiliar player; keep wedges at the chopping spot because they communicate a distinct practical output and the sentence remains short. The latest DeskII proposal leads with its quality benefit; church/water rows do not need a capability prefix because their effect already answers the question. The table incorporates the subsequent DeskII/pump revisions; those revised sentences remain proposals rather than retroactive acceptance of exact wording.

### PrayerClarity wording precedent

Inspected the existing local PrayerClarity source checkout at `ce91534`, without changing it. [lang/ru.json](https://github.com/NikichMods/PrayerClarity/blob/ce91534/lang/ru.json) uses `tech.effect.imagination_intro` = `Повышает качество письма.` and `active.pen` = `Бонус к качеству письма: +{0:0.##}`. Its English equivalents in [lang/en.json](https://github.com/NikichMods/PrayerClarity/blob/ce91534/lang/en.json) are `Improves writing quality.` and `Writing quality bonus: +{0:0.##}`. The inspected Rebalanced override does not replace those keys. These supply a terminology precedent, not permission to copy a prayer's numeric bonus onto a station. No number is invented for DeskII because its recipe differences are heterogeneous. `Письмо / writing` keeps consistency with the existing mod rather than introducing a longer new label solely to encode exceptions.

## Current author judgment

Object-enabled action remains the preferred base, with `Allows you to…` as an English candidate, within the accepted mixed-voice direction above. It meets the user's criterion (action enabled by the object, not spontaneously performed by it), has native Russian and documented other-game precedents, and avoids a generic free-standing unlock implication. This is not a universal prefix requirement or a claim that occurrence in other games proves superiority.

Do not force every block into that prefix. Storage can use a short storage statement; church/graveyard furnishings keep their direct metric bonus; actual zombie workers can be named actors; genuine automation stays explicit. Tier improvements should remain recognizable as part of a family; the latest delta-first proposals can omit a repeated base-role list. Benefits must come from the upgrade audit, not from the chosen grammatical template.

## Full-catalogue application

The user accepted the revised ten-building basis and requested applying this style to the remaining descriptions. Completed the full EN/RU editorial pass in [BLUEPRINT_PURPOSE_CATALOGUE.md](BLUEPRINT_PURPOSE_CATALOGUE.md):104 distinct blueprint rows reviewed,70 changed, all ten basis rows preserved verbatim in both columns, and all23 existing mechanics-check markers preserved. Unchanged rows intentionally include already suitable numeric benefits, zombie actors and native resurrection text; a complete review does not require inventing a different sentence for every row.

The first pass above is historical. The user's subsequent full-catalogue review requested less repetition of known functions in higher tiers, optional accents and more natural accent placement. The current catalogue now proposes delta-first descriptions for verified upgrades: state the new metals, equipment, yield or quality benefit directly; retain an explicit reference to the earlier tier only if useful. Avoid a whole repeated base-role catalogue and the uninformative phrase “improved version.” Complementary alchemy tables still use the parallel two/three-input form; storage/effect tiers retain short comparable quantities. Never imply unproved recipe inheritance.

An accent must earn its place: generic “items” in unrestricted storage stays plain; logs in a timber stockpile remains informative. There is no minimum accent count or fixed position. Prefer natural syntax and remove nonessential old benefits before rearranging a sentence; do not add a trailing phrase merely to move color away from its end. The updated DeskII sentence puts the quality bonus first without losing its connection to writing. Other sister families may legitimately keep matching accent positions.

The same review corrected concrete ambiguities: Carpenter's workbench now names planks (RU native `Брус`) instead of “wooden parts”; the stick bed names lentils directly; the zombie mine includes coal; pump copy names automatic drawing from the well rather than an ambiguous replenished personal/global supply. Native evidence and unresolved boundaries are recorded in the catalogue. The two presses still retain matching provisional purpose while tier scope is unresolved. These revisions are editorial proposals responding to feedback, not final acceptance of each sentence or live behavior.

Current accent policy supersedes the earlier highlighted comparison examples: the user accepted sparse distinctions/improvements/numeric effects, and explicitly removed the pump automation accent. Automation remains factual wording, not a color trigger by itself. The current catalogue applies that policy; equal-weight co-listed results share emphasis or remain plain.
