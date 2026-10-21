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

## Current author judgment, pending user review

Recommend the object-enabled action as the leading manual-workstation candidate, with `Allows you to…` as the English baseline. This follows the user's criterion (action is enabled by the object, not spontaneously performed by it), has both native Russian and documented other-game precedents, and avoids the generic free-standing unlock implication of `Можно…`. The extra word earns its space by expressing that relationship. This is not a claim that its occurrence in other games proves it universally superior.

Do not force every block into that prefix. Storage can use a short storage statement; church/graveyard furnishings keep their direct metric bonus; actual zombie workers can be named actors; genuine automation stays explicit. Tier improvement follows the stable family purpose as a separate concise statement where needed. Benefits must come from the upgrade audit, not from the chosen grammatical template.

Next review: compare this small set's flow in RU/EN before changing all manual descriptions. Mechanically flagged catalogue entries remain flagged. No new runtime behavior, version or release follows from this editorial research.
