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

The user requested ten different buildings across families/areas. These are **review proposals**, not final copy acceptance or a complete rewrite of the104-row catalogue. Bold marks candidate accent spans; icon principle is accepted but exact placement/rendering remains separate.

| Building / context | Russian proposal | English proposal |
| --- | --- | --- |
| Sawhorse / Workyard | Позволяют распиливать брёвна на **доски**. | Allows you to cut logs into **boards**. |
| Chopping spot / Workyard | Здесь можно заготавливать **дрова и клинья**. | You can make **firewood and wedges** here. |
| Alchemy workbench / Alchemy lab | Позволяет готовить зелья из **двух ингредиентов**. | Allows you to make potions from **two ingredients**. |
| Study table / Alchemy lab | Здесь можно изучать предметы и получать **очки технологий**. | You can study items here to earn **technology points**. |
| DeskII / Alchemy lab | Позволяет создавать книги и молитвы. **Бонус к качеству большинства работ**. | Allows you to make books and prayers. **Quality bonus** for most recipes. |
| Wine making barrel / Cellar | Служит для приготовления **вина** из виноградного сока. | Used to make **wine** from grape juice. |
| Resurrection table / Morgue | Здесь можно создавать **зомби-рабочих** из тел. | Make **zombie workers** from bodies here. |
| CandelabraI / Church | **+1 к качеству церкви**. Свечи усиливают эффект. | **+1 church quality**. Candles increase the bonus. |
| Compost heap / Garden | Используется для переработки отходов урожая в **торф**. | Used to turn crop waste into **peat**. |
| Water pump / Workyard | **Автоматически** пополняет запас воды. | **Automatically** replenishes your water supply. |

Semantic evidence: existing native blueprint/craft study, the paired upgrade review and accepted candelabra/pump/alchemy semantics. Resurrection reuses the direct native localization text; actual localization/rendering owner still needs its normal integration proof. DeskII's scoped quality clause intentionally avoids claiming every recipe improves or guaranteeing gold. Other practical outputs such as billets or maggots are omitted from this set as secondary to the stated purpose, not denied as supported outputs. English Sawhorse purpose uses ordinary-category “boards” for readability; it does not claim direct `wooden_plank` production or rename the native Flitch item in an actual item/material row. No new gameplay behavior is inferred.

Author critique: mixed voice is useful when driven by meaning, but arbitrary synonym rotation can weaken the very family comparisons the user requested. Keep alchemyI/II identical apart from the accepted ingredient count. Sawhorse's omitted billet term helps an unfamiliar player; keep wedges at the chopping spot because they communicate a distinct practical output and the sentence remains short. DeskII is deliberately longer because its reason for upgrading matters more than matching a one-line quota. Church/water rows do not need a capability prefix: their effect already answers the question.

## Current author judgment

Object-enabled action remains the preferred base, with `Allows you to…` as an English candidate, within the accepted mixed-voice direction above. It meets the user's criterion (action enabled by the object, not spontaneously performed by it), has native Russian and documented other-game precedents, and avoids a generic free-standing unlock implication. This is not a universal prefix requirement or a claim that occurrence in other games proves superiority.

Do not force every block into that prefix. Storage can use a short storage statement; church/graveyard furnishings keep their direct metric bonus; actual zombie workers can be named actors; genuine automation stays explicit. Tier improvement follows the stable family purpose as a separate concise statement where needed. Benefits must come from the upgrade audit, not from the chosen grammatical template.

Next review: judge the ten-building set's flow and useful information before carrying its final wording across all manual descriptions. Mechanically flagged catalogue entries remain flagged. No new runtime behavior, version or release follows from this editorial work.
