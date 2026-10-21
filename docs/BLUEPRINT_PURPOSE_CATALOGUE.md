# Blueprint purpose copy — grouped editorial catalogue

Target: Graveyard Keeper 1.407. Prepared 2026-10-21. This is a **review draft**, not a runtime implementation or accepted replacement for stable1.1.6.

Coverage:105 authored-visible Technology blueprint references,104 distinct build records. The Church workbench appears in two technologies and shares one description. Hidden `@` references, ordinary item recipes and existing Work/Perk copy are outside this catalogue. This covers the blueprint purpose work requested here, including visible DLC/system upgrades.

## Reading and evidence

English is the semantic source; Russian is the review locale. Bold marks the proposed semantic accent. Names in the first column are review labels; production titles must retain native localization, including special build-name resolution. IDs identify records and are not player-facing text. Unless explicitly noted as accepted below, every sentence remains an editorial proposal.

The user accepted the paired two/three-ingredient potion sentences, the candelabra base-bonus/candle sentences, and the pump's emphasis on automation. Preserve these across further edits. Other pilot entries remain proposals.

Descriptions explain the construction's role, not a promise that every supported recipe becomes available immediately with its blueprint. A higher tier must not imply recipe inheritance or a numeric improvement that has not been proved. Some supported recipes have independent native unlock requirements.

Evidence classes used in the notes:
- **N:** directly inspected native balance/object/craft data supports the stated role or value; this is static evidence, not installed rendering acceptance.
- **S:** existing shared research supports the action/mechanic; see the linked owning document.
- **V:** wording has a version-specific mechanism/benefit still to verify. A dagger **†** identifies these rows. They are complete editorial drafts, but must not enter production unchanged on the strength of this catalogue.

Primary static input: installed1.407 `resources.assets`, SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`; bounded inspection of `game_data`, `lng_en`, `lng_ru` and native font-symbol tables. Raw inputs and bulk extractions stay private. No useful native purpose prose was found at the direct inspected station/object keys; do not interpret this as an exhaustive search of every dialogue/tutorial.

## Metal, firing and precision work

| Review label / ID | English | Russian |
| --- | --- | --- |
| Furnace / `mf_furnace_0` | Smelts **iron** and makes glass and ceramics. | Выплавляет **железо**, делает стекло и керамику. |
| Furnace II / `mf_furnace_1` | Smelts iron, **steel and precious metals**, and makes glass and ceramics. | Выплавляет железо, **сталь и драгоценные металлы**, делает стекло и керамику. |
| Furnace III / `mf_furnace_2` | Smelts metals and makes glass and ceramics. Also makes **steel parts**. | Выплавляет металлы, делает стекло и керамику. Также делает **стальные детали**. |
| Wooden anvil / `mf_anvil_1` | Forges **nails, simple iron parts and basic tools**. | Куёт **гвозди, простые железные детали и базовые инструменты**. |
| Anvil / `mf_anvil_2` | Forges nails, tools and weapons. Also makes **complex iron parts**. | Куёт гвозди, инструменты и оружие. Также делает **сложные железные детали**. |
| Anvil II / `mf_anvil_3` | Forges nails, parts, tools and weapons, including **steel equipment**. | Куёт гвозди, детали, инструменты и оружие, в том числе **стальное снаряжение**. |
| Potter's wheel / `mf_potter_wheel_1` | Shapes clay into **ceramic bowls**. | Делает из глины **керамические миски**. |
| Jewelry table / `mf_jewelry` | Makes **jewelry** and decorates swords with gems. | Делает **украшения** и отделывает мечи самоцветами. |

Evidence N: exact station `craft_in` and physical/multiquality outputs. Furnace tiers differ by supported recipes; the text makes no speed/fuel-efficiency claim. TierIII's steel-parts recipe is native; it does not mean the blueprint itself unlocks every metal recipe.

## Wood and stone

| Review label / ID | English | Russian |
| --- | --- | --- |
| Sawhorse / `mf_beam_gantry_1` | Cuts logs into **flitch and billets**. | Распиливает брёвна на **доски и заготовки**. |
| Chopping spot / `mf_chocks_1` | Splits wood into **firewood and wedges**. | Раскалывает древесину на **дрова и клинья**. |
| Circular saw / `mf_saw_1` | Cuts logs into flitch and billets, and makes **planks and beams**. | Распиливает брёвна на доски и заготовки, делает **брусья и балки**. |
| Carpenter's workbench / `mf_workbench_1` | Makes **planks and wooden grave decorations**. | Делает **брусья и деревянные надгробия**. |
| Carpenter's workbench II / `mf_workbench_2` | Makes planks and wooden grave decorations. Also makes **carved wood**. | Делает брусья и деревянные надгробия. Также делает **резные детали из дерева**. |
| Stone cutter / `mf_hammer_0` | Cuts **stone and marble** into building materials and grave decorations. | Обрабатывает **камень и мрамор** для строительства и надгробий. |
| Stone cutter II / `mf_hammer_1` | Cuts stone and marble into building materials and **intricate grave decorations**. | Обрабатывает камень и мрамор для строительства и **сложных надгробий**. |

Evidence N: exact station output families. The review labels for missing direct object-name keys are explanatory only. Before localization production, resolve native names for `jointing`, `wooden_beam`, `flitch`, `wooden_plank` and carved outputs; do not assume similar English/Russian names are interchangeable. “Intricate” describes the expanded decoration family, not improved quality of every existing output.

## Storage

| Review label / ID | English | Russian |
| --- | --- | --- |
| Timber stockpile / `mf_timber_1` | Stores **logs**. | Хранит **брёвна**. |
| Stone stockpile / `mf_stones_1` | Stores **stone and marble blocks**. | Хранит **каменные и мраморные блоки**. |
| Iron ore stockpile / `mf_ore_1_complete` | Stores **iron ore blocks**. | Хранит **блоки железной руды**. |
| Trunk / `mf_box_stuff` | Provides **item storage**. | Место для **хранения предметов**. |
| Scrollshelf / `obj_church_scroll_cabinet` | Provides **item storage**. | Место для **хранения предметов**. |
| Bookshelf / `obj_church_bookcase` | Provides **item storage**. | Место для **хранения предметов**. |
| Alchemy rack / `rack_alchemy` | Provides **item storage**. | Место для **хранения предметов**. |
| Mortuary rack / `rack_organs` | Provides **item storage**. | Место для **хранения предметов**. |

Evidence N: native inventories and existing shared storage semantics. No specialized-only filter is inferred from the shelf/rack name, and no decorative-only role is invented. Numerical inventory sizes are deliberately omitted until slot/stack semantics are separately reviewed. Large-block stockpile filters need final UI confirmation before claiming exclusivity; these sentences do not say “only.”

## Study, writing and printing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Study table / `mf_alchemy_survey` | Studies items to earn **technology points** and reveal their alchemical properties. | Изучает предметы: даёт **очки технологий** и раскрывает алхимические свойства. |
| Church workbench / `table_book_constr` | Makes **paper, ink and candles**. | Делает **бумагу, чернила и свечи**. |
| Desk / `desk` | Writes **notes, chapters, books and prayers**. | Создаёт **записки, главы, книги и молитвы**. |
| Desk II / `desk_2` | Writes notes, chapters, books and prayers with **lower energy costs**. | Создаёт записки, главы, книги и молитвы с **меньшими затратами энергии**. |
| Paper press / `mf_paper_press` | Presses paper glop into **clean paper**. | Превращает бумажную массу в **чистую бумагу**. |
| Printing press / `mf_printing_press` | Prints **flyers in batches**. | Печатает **листовки партиями**. |
| Printing press II / `mf_printing_press_2` | Prints **flyers in batches**. | Печатает **листовки партиями**. |
| Random text generator / `zombie_pulpit` | A zombie writes **stories**. | Зомби пишет **истории**. |

Evidence N/S: exact outputs, multiquality writing outputs, native zombie-only station flags, and [STUDY_RESOURCE_ECONOMY](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/STUDY_RESOURCE_ECONOMY.md)/[ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). Native notes/chapter energy is20 at Desk versus10 at DeskII; avoid claiming a universal percentage or guaranteed highest quality. The corresponding flyer recipes for the two presses have matching inspected inputs, output10, craft_time3 and energy10. Thus identical descriptions are intentional; no unsupported tier advantage is supplied. Prayer recipe support is a role of the desk blueprint, not permission for DTT to rewrite prayer unlocks. Church-workbench copy names representative outputs, not an exhaustive product list.

## Alchemy

| Review label / ID | English | Russian |
| --- | --- | --- |
| Alchemy workbench / `mf_alchemy_craft_02` | Makes potions from **two ingredients**. | Готовит зелья из **двух ингредиентов**. |
| Alchemy workbench II / `mf_alchemy_craft_03` | Makes potions from **three ingredients**. | Готовит зелья из **трёх ингредиентов**. |
| Hand mixer / `mf_alchemy_stirrer_01` | Processes materials into alchemical **solutions**. | Перерабатывает материалы в алхимические **растворы**. |
| Alchemy mill / `mf_alchemy_mill` | Grinds materials into alchemical **powders**. | Измельчает материалы в алхимические **порошки**. |
| Distillation cube / `mf_distcube_2_clay` | Distils materials into alchemical **extracts**. | Перегоняет материалы в алхимические **экстракты**. |
| Distillation cube II / `mf_distcube_2_cuprum` | Distils materials into alchemical extracts **faster**. | Перегоняет материалы в алхимические экстракты **быстрее**. |
| Zombie alchemy decomposer / `alchemy_table_zombie` | A zombie processes materials into **powders, solutions and extracts**. | Зомби перерабатывает материалы в **порошки, растворы и экстракты**. |
| Zombie alchemy workbench / `alchemy_workbench_zombie` † | A zombie makes potions from **known recipes**. | Зомби готовит зелья по **известным рецептам**. |

Evidence N/S: native station families and [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md), not a guessed output taxonomy. Matching inspected distillation recipes take90 versus60 native craft-time units, supporting “faster” without presenting an assumed real-time duration. The zombie mixed-alchemy known-recipe restriction needs final integration check against its native recipe-picker path; it must not suggest automatic discovery of unknown formulas.

## Gardening and orchards

| Review label / ID | English | Russian |
| --- | --- | --- |
| Empty garden bed / `garden_empty` | Grows **vegetables and other field crops**. | Выращивает **овощи и полевые культуры**. |
| Garden bed with sticks / `garden_empty_stick` | Grows climbing crops, including **lentils**. | Выращивает вьющиеся культуры, в том числе **чечевицу**. |
| Vine trellis / `vineyard_grapes_stick` | Grows **grapes and hops**. | Выращивает **виноград и хмель**. |
| Berry bush plot / `bush_berry_garden` | Grows **berries**. | Выращивает **ягоды**. |
| Apple tree plot / `tree_apple_garden` | Grows **apples**. | Выращивает **яблоки**. |
| Compost heap / `v_obj_compost_heap` | Turns crop waste into **peat and maggots**. | Перерабатывает отходы урожая в **торф и опарышей**. |
| Bee hive / `beehouse` | Produces **honey**. | Даёт **мёд**. |
| Zombie farm / `zombie_garden_desk` | A zombie grows **field crops**. | Зомби выращивает **полевые культуры**. |
| Zombie vineyard / `zombie_vineyard_desk` | A zombie grows **grapes and hops**. | Зомби выращивает **виноград и хмель**. |

Evidence N/S: native growing/compost outputs, authored build families and [FARMING_AND_FERTILIZER](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/FARMING_AND_FERTILIZER.md). These are purpose categories, not unlock lists. No automatic seed multiplication or highest-quality production is promised. Honey wording deliberately avoids promising bees/beeswax without their separately gated perks. Zombie farm/vineyard upgrades are not additional visible blueprint references here; do not add hidden rows to fill out a visually pleasing tier family.

## Drinks and processing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Vine press / `mf_vine_press` | Presses **juice and oil** from crops. | Выжимает **сок и масло** из урожая. |
| Fermentation barrel / `barrel_brew` | Ferments fruit juice for **distillation**. | Сбраживает фруктовый сок для **перегонки**. |
| Wine making barrel / `mf_barrel_mid` | Ferments grape juice into **wine**. | Сбраживает виноградный сок в **вино**. |
| Alcohol distiller / `mf_distcube_3` | Distils fermented juice into **spirits**. | Перегоняет перебродивший сок в **крепкий алкоголь**. |
| Brewing stand / `brewing_stand` | Brews **beer and mead**. | Варит **пиво и медовуху**. |
| Zombie brewery / `mf_zombie_brewing` | A zombie brews **beer**. | Зомби варит **пиво**. |
| Zombie winery / `mf_zombie_winemaking` | A zombie makes **wine**. | Зомби делает **вино**. |

Evidence N: exact craft inputs, ordinary and multiquality outputs. No sale prices, story buyers or comparative profitability. Native ordinary recipes differ between manual and zombie brewery, so do not mechanically copy the mead claim to the latter.

## Morgue and corpse handling

| Review label / ID | English | Russian |
| --- | --- | --- |
| Preparation place / `mf_preparation_1` | Removes and replaces **body parts**. | Извлекает и заменяет **части тела**. |
| Preparation place II / `mf_preparation_2` † | Removes and replaces body parts. **Prevents decay** while the body is on the table. | Извлекает и заменяет части тела. **Останавливает разложение**, пока тело на столе. |
| Embalming table / `mf_balsamation_1` | Applies **injections** to alter a body's properties. | Делает **инъекции**, меняющие свойства тела. |
| Embalming table II / `mf_balsamation_2` † | Applies injections to alter a body's properties. **Prevents decay** while the body is on the table. | Делает инъекции, меняющие свойства тела. **Останавливает разложение**, пока тело на столе. |
| Pallet / `corpse_bed` | Holds **one body**. | Хранит **одно тело**. |
| Double pallet / `corpse_bed_big` | Holds **two bodies**. | Хранит **два тела**. |
| Fridge pallet / `corpse_fridge` † | Holds two bodies and **prevents decay** while they are stored. | Хранит два тела и **останавливает их разложение** на время хранения. |
| Resurrection table / `zombie_crafting_table` | Turns a corpse into a **zombie worker**. | Превращает тело в **зомби-работника**. |
| Place for burning corpses / `mf_pyre_placed` | Burns a body into **ash**. | Сжигает тело, оставляя **пепел**. |

Evidence N/S: body insertion filters/limits, extraction/injection/resurrection crafts and the native cremation-output research in [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). V: local balance fields alone do not establish decay behavior; the three daggered lines use original paraphrases of the [Corpse](https://graveyardkeeper.fandom.com/wiki/Corpse) and [Preparation place II](https://graveyardkeeper.fandom.com/wiki/Preparation_place_II) explanations and still require exact1.407 decay-owner verification. TierII surgical-error and injection-speed benefits also need owner verification before deciding whether they should replace/supplement the proposed difference. Do not hide these open differences merely to keep the text short. Pallet lines currently state only the directly confirmed body capacity; consider their decay effect after the same check.

## Zombie extraction and transport

| Review label / ID | English | Russian |
| --- | --- | --- |
| Zombie ore mine: left / `zombie_mine_bench_left` † | A zombie mines **iron ore**. | Зомби добывает **железную руду**. |
| Zombie stone quarry: right / `zombie_mine_fence_front_stone` † | A zombie quarries **stone blocks**. | Зомби добывает **каменные блоки**. |
| Zombie marble quarry: right / `zombie_mine_fence_front_marble_right` † | A zombie quarries **marble blocks**. | Зомби добывает **мраморные блоки**. |
| Porter station / `porter_station` | A zombie **transports resources** between work areas. | Зомби **переносит ресурсы** между рабочими зонами. |

Evidence N: native zombie assignment and porter GUI action. V: the three mining rows are virtual build records rather than direct `craft_in` stations. Verify the final worker/path/output owner before production; the text intentionally omits a route, mining speed, infinite resources or all possible byproducts.

## Lighting and water

| Review label / ID | English | Russian |
| --- | --- | --- |
| Lantern network / `lantern_network` † | Enables **lantern installation**. | Позволяет устанавливать **светильники**. |
| Lantern / `lantern` | **Lights** the surrounding area. | **Освещает** пространство вокруг. |
| Water pump / `well_pump` | **Automatically** replenishes your water supply. | **Автоматически** пополняет запас воды. |

Evidence N: functioning pump accepts water; its native automatic craft writes water to its inventory. V: determine the network's exact final action and scope before shipping that line; its virtual name alone does not prove whether it enables placement or constructs a fixed network. Lantern purpose is a draft role statement, not a claim of a productivity/quality bonus.

## Church furnishings

| Review label / ID | English | Russian |
| --- | --- | --- |
| Candelabra I / `candelabrum_1` | **+1 church quality**. Candles increase the bonus. | **+1 к качеству церкви**. Свечи усиливают эффект. |
| Candelabra II / `candelabrum_2` | **+2 church quality**. Candles increase the bonus. | **+2 к качеству церкви**. Свечи усиливают эффект. |
| Candelabra III / `candelabrum_3` | **+3 church quality**. Candles increase the bonus. | **+3 к качеству церкви**. Свечи усиливают эффект. |
| Church bench / `church_bench` | **+1 church quality**. | **+1 к качеству церкви**. |
| Soft church bench / `church_bench_2` | **+3 church quality**. | **+3 к качеству церкви**. |
| Wooden church shrine / `church_table_1` | **+5 church quality**. | **+5 к качеству церкви**. |
| Stone church shrine / `church_table_2` | **+8 church quality**. | **+8 к качеству церкви**. |
| Stained glass window / `church_window_1` | **+5 church quality**. | **+5 к качеству церкви**. |
| Confessional / `church_budka_1` | **+5 church quality**. Parishioners may leave confessions. | **+5 к качеству церкви**. Прихожане могут оставлять исповеди. |
| Confessional II / `church_budka_2` | **+7 church quality**. Parishioners may leave confessions. | **+7 к качеству церкви**. Прихожане могут оставлять исповеди. |
| Incense burner / `c_obj_incense_1` † | **+1 church quality**. Incense increases the bonus. | **+1 к качеству церкви**. Благовония усиливают эффект. |
| Incense burner II / `c_obj_incense_2` † | **+3 church quality**. Incense increases the bonus. | **+3 к качеству церкви**. Благовония усиливают эффект. |

Evidence N: native base qualities, builder=church, and candle-bearing variants with higher quality. S: confessional waiting-state owner in [CONFESSION_NOTIFICATION_RESEARCH](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/CONFESSION_NOTIFICATION_RESEARCH.md); “may” preserves native randomness rather than promising daily guaranteed rewards. V: verify incense consumption and effect owner/temporary lifecycle before accepting the two parallel burner sentences. Base quality alone does not prove their second sentence. The accepted candelabra text does not justify blindly copying its mechanic to incense.

## Graveyard furnishings

| Review label / ID | English | Russian |
| --- | --- | --- |
| Wooden prayer station / `pray_stand_wd` | **+2 graveyard quality**. | **+2 к качеству кладбища**. |
| Stone prayer station / `pray_stand_stn` | **+4 graveyard quality**. | **+4 к качеству кладбища**. |
| Flowerbed / `grass_sward_2x3` | **+2 graveyard quality**. | **+2 к качеству кладбища**. |
| Marble paving / `road_marble` | **+3 graveyard quality**. | **+3 к качеству кладбища**. |
| Stone lantern / `lantern_3` | **+4 graveyard quality**. | **+4 к качеству кладбища**. |
| Stone columbarium / `columbarium_stone` | **+12 graveyard quality**. | **+12 к качеству кладбища**. |
| Marble columbarium / `columbarium_marble` | **+20 graveyard quality**. | **+20 к качеству кладбища**. |

Evidence N: object quality and graveyard builder. Columbarium lines deliberately describe their confirmed quality benefit, without treating construction urns as an accessible reusable storage inventory.

## Souls room: storage and equipment

| Review label / ID | English | Russian |
| --- | --- | --- |
| Soul container I / `soul_container` | Holds **two souls**. | Хранит **две души**. |
| Soul container II / `soul_container_2` | Holds **three souls**. | Хранит **три души**. |
| Soul container III / `soul_container_3` | Holds **four souls**. | Хранит **четыре души**. |
| Organ workbench / `soul_workbench` † | Alters the **skull values of body parts**. | Меняет **число черепов у частей тела**. |
| Soul extractor upgrade II / `soul_extractor_upgrd_to_2` † | Extracts souls with **less damage**. | Извлекает души с **меньшими повреждениями**. |
| Soul extractor upgrade III / `soul_extractor_upgrd_to_3` † | Extracts souls **without damage**. | Извлекает души **без повреждений**. |
| Wall crematorium / `mf_crematorium` † | Burns bodies into **ash** using fuel. | Сжигает тела в **пепел**, расходуя топливо. |
| Soul receiver / `soul_totem_souls` † | Enables **remote crafting** for souls' gratitude. | Позволяет **удалённо запускать работу** за благодарность душ. |

Evidence N: soul containers' `can_insert_items` accepts harmed/healed souls and direct insertion limits are2/3/4. The prose omits storage decay prevention and room-capacity numerical effects until the owning mechanics are checked. V: workbench special UI, extractor damage, crematorium handling and receiver routing need exact1.407 final-owner verification; the balance placeholder or ordinary fertilizer recipes alone do not prove them. Secondary semantic cross-checks: [Soul extractor III](https://graveyardkeeper.fandom.com/wiki/Soul_extractor_III), [Soul receiver](https://graveyardkeeper.fandom.com/wiki/Soul_Receiver), [Souls room](https://graveyardkeeper.fandom.com/wiki/Souls_room). Do not infer that receiver can automatically execute every recipe or reveal hidden builders/story access.

## Souls room: healing extensions

| Review label / ID | English | Russian |
| --- | --- | --- |
| Healing from pride / `pride_healing_extension` † | Adds a **skin slot** to the soul healer. | Добавляет в целитель душ **ячейку для кожи**. |
| Healing from wrath / `wrath_healing_extension` † | Adds a **blood slot** to the soul healer. | Добавляет в целитель душ **ячейку для крови**. |
| Healing from gluttony / `gluttony_healing_extension` † | Adds a **fat slot** to the soul healer. | Добавляет в целитель душ **ячейку для жира**. |
| Healing from sloth / `sloth_healing_extension` † | Adds a **brain slot** to the soul healer. | Добавляет в целитель душ **ячейку для мозга**. |
| Healing from lust / `lust_healing_extension` † | Adds a **heart slot** to the soul healer. | Добавляет в целитель душ **ячейку для сердца**. |
| Healing from envy / `envy_healing_extension` † | Adds an **intestine slot** to the soul healer. | Добавляет в целитель душ **ячейку для кишечника**. |

Evidence V: these are visible virtual extensions, not ordinary object-craft output stations. Mapping follows a secondary [Soul healer](https://graveyardkeeper.fandom.com/wiki/Soul_healer) cross-check and remains blocked on native extension-slot owner verification. Native Russian review-name `лечение от уныния` is preserved in titles even though English says sloth. Do not “correct” a native title via an inferred translation. No organ skull recommendations or hidden future-use disclosure is added.

## Selective purpose icons

The user proposed icons with explanatory text in purpose descriptions, following the material-row precedent. Recommendation: use a native semantic icon for a metric/category where it speeds recognition; retain the words. Avoid a picture for every noun or mixing a specific potion/item sprite into a claim about an entire category. Automation remains a text accent; do not invent an automation pictogram.

Static font-symbol inspection in the exact input above proves these mappings in the inspected native UIFont records (for example pathID151301):

| Meaning | Native token | Sprite | Proposed use |
| --- | --- | --- | --- |
| Church HUD quality symbol | `(cross)` | `icon_hud_cross` | Before the church-quality phrase; keep the localized metric name. |
| Graveyard quality symbol | `(wskull)` | `icon_skull_wreath_green` | Before the graveyard-quality phrase; preserve the wreath/skull combination. |
| Science | `(sci)` | `icon_science` | Only when science is actually discussed; not a generic technology-point icon. |
| Powder category | `(alc1)` | `icon_txt_powder` | Adjacent to powders where the layout remains readable. |
| Solution category | `(alc2)` | `icon_txt_oil` | Adjacent to solutions; internal sprite name is not player-facing wording. |
| Extract category | `(alc3)` | `icon_txt_essence` | Adjacent to extracts. |

Proposed candelabra composition: `(cross) **+1 church quality**. Candles increase the bonus.` / `(cross) **+1 к качеству церкви**. Свечи усиливают эффект.` This preserves the accepted wording; the token is illustrative here and is not meant to appear literally in chat or the final game text. Native `world_zones_data` directly assigns church `quality_icon=(cross)` and graveyard `quality_icon=(wskull)`. The bare `(skull)` maps to a different HUD symbol; do not substitute it for the graveyard quality wreath/skull. The native crafting-quality star `(s1)` is also a different metric and must not replace church quality.

Font-symbol existence is static eligibility, not proof of correct tint/baseline/wrapping or every language route. Before implementation acceptance, verify the active Technology UIFont, symbol mode, native meaning at the HUD owner, muted-text contrast and accent span boundaries. Keep icons at native colors if accenting the surrounding text would distort recognition; exact treatment is a visual review choice. No production token replacement has been made.

## Remaining review and production boundary

Every distinct visible blueprint has an editorial row. Daggered claims require further mechanics verification before production. Other entries still require wording acceptance and integration gates; N is not a blanket READY gate. Retain existing vanilla descriptions and native visibility/order. The user's approved family rule does not authorize new prayer content, progression changes, hidden unlock disclosure or invented tier benefits.

Review the grouped families first, then resolve the flagged owners. The next useful technical work is concentrated on virtual build actions, body decay/tier benefits, soul equipment and any native name/icon route required for final presentation; it is not another full game-data dump.
