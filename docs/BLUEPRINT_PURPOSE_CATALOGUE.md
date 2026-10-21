# Blueprint purpose copy — grouped editorial catalogue

Target: Graveyard Keeper 1.407. Prepared 2026-10-21. This is a **review draft**, not a runtime implementation or accepted replacement for stable1.1.6.

Coverage:105 authored-visible Technology blueprint references,104 distinct build records. The Church workbench appears in two technologies and shares one description. Hidden `@` references, ordinary item recipes and existing Work/Perk copy are outside this catalogue. This covers the blueprint purpose work requested here, including visible DLC/system upgrades.

## Reading and evidence

English is the semantic source; Russian is the review locale. Bold marks the proposed semantic accent. Names in the first column are review labels; production titles must retain native localization, including special build-name resolution. IDs identify records and are not player-facing text. Unless explicitly noted as accepted below, every sentence remains an editorial proposal.

The user accepted the paired two/three-ingredient potion semantics, the candelabra base-bonus/candle sentences, and the pump's emphasis on automation. The later manual-station actor objection reopens grammatical presentation of manual work: the purpose-phrase versions below are a comparison draft, not acceptance of a new global template. Preserve the approved semantics. Selective native icons with explanatory text are now approved; exact placement/rendering still needs visual review. Other pilot entries remain proposals.

The benefit revision incorporates the [workstation upgrade audit](WORKSTATION_UPGRADE_REVIEW.md) and corrects key tier distinctions. Its63 purpose-phrase rows are now **a semantic inventory, not the recommended final voice**: the user rejected repetitive `Для…` and bare process names, and finds bare `Можно…` insufficiently tied to the station. The [language comparison](TOOLTIP_LANGUAGE_RESEARCH.md) proposes object-enabled actions (`Позволяет…` / `Allows you to…`) without treating that candidate as finally accepted or mass-converting the catalogue. Earlier energy-led DeskII and speed-only distillationII copy remains superseded. Mechanical flags are not resolved by wording changes.

Current accepted language direction is mixed voice, led by object-enabled action and supplemented by natural place-bound/use/effect sentences. The language research contains the requested ten-building review set and records the preference against `На нём…`/`На них…`, plus the decision to omit Sawhorse billets from the short purpose. Its new sentences await review; this whole catalogue has not been mass-converted again.

Descriptions explain the construction's role, not a promise that every supported recipe becomes available immediately with its blueprint. A higher tier must not imply recipe inheritance or a numeric improvement that has not been proved. Some supported recipes have independent native unlock requirements.

Evidence classes used in the notes:
- **N:** directly inspected native balance/object/craft data supports the stated role or value; this is static evidence, not installed rendering acceptance.
- **S:** existing shared research supports the action/mechanic; see the linked owning document.
- **V:** wording has a version-specific mechanism/benefit still to verify. A dagger **†** identifies these rows. They are complete editorial drafts, but must not enter production unchanged on the strength of this catalogue.

Primary static input: installed1.407 `resources.assets`, SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`; bounded inspection of `game_data`, `lng_en`, `lng_ru` and native font-symbol tables. Raw inputs and bulk extractions stay private. Most direct inspected station/object description keys provide no purpose text, but `zombie_crafting_table_d` does: the resurrection-table row below reuses that native text. The earlier blanket absence statement was too broad. This is still not an exhaustive search of every alias/dialogue/tutorial, nor proof that a native key is currently shown in vanilla Technology UI.

## Metal, firing and precision work

| Review label / ID | English | Russian |
| --- | --- | --- |
| Furnace / `mf_furnace_0` | For smelting **iron**, making glass and firing ceramics. | Для выплавки **железа**, изготовления стекла и обжига керамики. |
| Furnace II / `mf_furnace_1` | For smelting iron, **steel and precious metals**, making glass and firing ceramics. | Для выплавки железа, **стали и драгоценных металлов**, изготовления стекла и обжига керамики. |
| Furnace III / `mf_furnace_2` | For smelting metals and making glass and ceramics. **Steel parts and more graphite**. | Для выплавки металлов, изготовления стекла и керамики. **Стальные детали и больше графита**. |
| Wooden anvil / `mf_anvil_1` | For forging **nails, simple iron parts and basic tools**. | Для ковки **гвоздей, простых железных деталей и базовых инструментов**. |
| Anvil / `mf_anvil_2` | For forging nails, tools, weapons and **complex iron parts**. | Для ковки гвоздей, инструментов, оружия и **сложных железных деталей**. |
| Anvil II / `mf_anvil_3` | For forging parts and **steel equipment**. More nails and simple iron parts from the same metal. | Для ковки деталей и **стального снаряжения**. Больше гвоздей и простых деталей из того же металла. |
| Potter's wheel / `mf_potter_wheel_1` | For shaping clay into **ceramic bowls**. | Для изготовления **керамических мисок** из глины. |
| Jewelry table / `mf_jewelry` | For making **jewelry** and setting gems in swords. | Для изготовления **украшений** и отделки мечей самоцветами. |

Evidence N: exact station `craft_in`, multiquality outputs and evaluated-yield expressions. Furnace tiers differ by supported recipes; III also increases matching graphite output1->2 for the same coal input. AnvilII increases matching nail/simple-parts output, with equal perk terms. No generic all-products yield increase or universal fuel saving is claimed. TierIII's steel-parts recipe is native; it does not mean the blueprint itself unlocks every metal recipe. See the upgrade audit for the bounded pairs and selection rationale.

## Wood and stone

| Review label / ID | English | Russian |
| --- | --- | --- |
| Sawhorse / `mf_beam_gantry_1` | For cutting logs into **flitch and billets**. | Для распиловки брёвен на **доски и заготовки**. |
| Chopping spot / `mf_chocks_1` | For splitting wood into **firewood and wedges**. | Для заготовки **дров и клиньев**. |
| Circular saw / `mf_saw_1` | For cutting logs into flitch, billets and planks. **More wood from each log**. | Для распиловки брёвен на доски, заготовки и брусья. **Больше древесины из каждого бревна**. |
| Carpenter's workbench / `mf_workbench_1` | For making **wooden parts and grave decorations**. | Для изготовления **деревянных деталей и надгробий**. |
| Carpenter's workbench II / `mf_workbench_2` | For making wooden parts and grave decorations. Also **lenses and steel equipment**. | Для изготовления деревянных деталей и надгробий. Также **линзы и стальное снаряжение**. |
| Stone cutter / `mf_hammer_0` | For working **stone and marble** into building materials and grave decorations. | Для обработки **камня и мрамора**, изготовления материалов и надгробий. |
| Stone cutter II / `mf_hammer_1` | For working stone and marble into building materials and **intricate grave decorations**. | Для обработки камня и мрамора, изготовления материалов и **сложных надгробий**. |

Evidence N: exact station output families and matched yield expressions. Circular saw billet output4->5+Woodworker and flitch6->7+2*Woodworker for the same log inputs support more output; do not infer zombie automation. CarpenterII also supports lenses/steel equipment, now prioritized over the earlier carved-wood-only difference. Review labels for missing direct object-name keys are explanatory only. Resolve native names for `jointing`, `wooden_beam`, `flitch`, `wooden_plank` and carved outputs before production. “Intricate” describes the expanded decoration family, not improved quality of every existing output.

## Storage

| Review label / ID | English | Russian |
| --- | --- | --- |
| Timber stockpile / `mf_timber_1` | For storing **logs**. | Для хранения **брёвен**. |
| Stone stockpile / `mf_stones_1` | For storing **stone and marble blocks**. | Для хранения **каменных и мраморных блоков**. |
| Iron ore stockpile / `mf_ore_1_complete` | For storing **iron ore blocks**. | Для хранения **блоков железной руды**. |
| Trunk / `mf_box_stuff` | For **item storage**. | Для **хранения предметов**. |
| Scrollshelf / `obj_church_scroll_cabinet` | For **item storage**. | Для **хранения предметов**. |
| Bookshelf / `obj_church_bookcase` | For **item storage**. | Для **хранения предметов**. |
| Alchemy rack / `rack_alchemy` | For **item storage**. | Для **хранения предметов**. |
| Mortuary rack / `rack_organs` | For **item storage**. | Для **хранения предметов**. |

Evidence N: native inventories and existing shared storage semantics. No specialized-only filter is inferred from the shelf/rack name, and no decorative-only role is invented. Numerical inventory sizes are deliberately omitted until slot/stack semantics are separately reviewed. Large-block stockpile filters need final UI confirmation before claiming exclusivity; these sentences do not say “only.”

## Study, writing and printing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Study table / `mf_alchemy_survey` | For studying items: **technology points** and alchemical properties. | Для изучения предметов: **очки технологий** и алхимические свойства. |
| Church workbench / `table_book_constr` | For making **paper, ink and candles**. | Для изготовления **бумаги, чернил и свечей**. |
| Desk / `desk` | For writing **books and prayers**. | Для написания **книг и молитв**. |
| Desk II / `desk_2` | For writing books and prayers. **Quality bonus** for most products. | Для написания книг и молитв. **Бонус к качеству** у большинства изделий. |
| Paper press / `mf_paper_press` | For making **clean paper** from paper glop. | Для изготовления **чистой бумаги** из бумажной массы. |
| Printing press / `mf_printing_press` † | For printing **flyers in batches**. | Для печати **листовок партиями**. |
| Printing press II / `mf_printing_press_2` † | For printing **flyers in batches**. | Для печати **листовок партиями**. |
| Random text generator / `zombie_pulpit` | A zombie writes **stories**. | Зомби пишет **истории**. |

Evidence N/S: exact outputs, multiquality writing outputs, native zombie-only station flags, and [STUDY_RESOURCE_ECONOMY](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/STUDY_RESOURCE_ECONOMY.md)/[ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). DeskII's quality benefit is the selected headline: matching notes/chapter/hardcover/story/prayer difficulties improve, with different deltas and some unchanged prayer recipes. Energy savings are real but secondary; do not replace quality with that easier measurement. No universal percentage or guaranteed gold result. V: flyer recipe parity does not establish no difference between presses: unlock-gated serialized copying recipes with multiquality parent IDs were missed by the earlier physical-output census. Actual availability and tier scope remain pending; identical provisional flyer text must not be read as a verified whole-station equivalence. Prayer recipe support is a role of the desk blueprint, not permission for DTT to rewrite prayer unlocks. Church-workbench copy names representative outputs, not an exhaustive product list.

## Alchemy

| Review label / ID | English | Russian |
| --- | --- | --- |
| Alchemy workbench / `mf_alchemy_craft_02` | For making potions from **two ingredients**. | Для приготовления зелий из **двух ингредиентов**. |
| Alchemy workbench II / `mf_alchemy_craft_03` | For making potions from **three ingredients**. | Для приготовления зелий из **трёх ингредиентов**. |
| Hand mixer / `mf_alchemy_stirrer_01` | For processing materials into alchemical **solutions**. | Для получения алхимических **растворов** из материалов. |
| Alchemy mill / `mf_alchemy_mill` | For grinding materials into alchemical **powders**. | Для получения алхимических **порошков** из материалов. |
| Distillation cube / `mf_distcube_2_clay` | For distilling alchemical **extracts** from materials. | Для получения алхимических **экстрактов** из материалов. |
| Distillation cube II / `mf_distcube_2_cuprum` | For distilling alchemical extracts. **Higher yield from raw materials**. | Для получения алхимических экстрактов. **Больше реагента из сырья**. |
| Zombie alchemy decomposer / `alchemy_table_zombie` | A zombie processes materials into **powders, solutions and extracts**. | Зомби перерабатывает материалы в **порошки, растворы и экстракты**. |
| Zombie alchemy workbench / `alchemy_workbench_zombie` † | A zombie makes potions from **known recipes**. | Зомби готовит зелья по **известным рецептам**. |

Evidence N/S: native station families and [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md), not a guessed output taxonomy. Corrected distillation comparison evaluates output expressions:18 matched material-processing formulas gain+1 extract at equal inputs/perks;8 goo-recovery formulas keep their output. Speed90->60 is also real, but higher material yield is now the selected main benefit. “Raw materials” describes material decomposition, not goo recovery; final copy must not turn this into an all-recipes guarantee. Neither universal double nor an unqualified+1 for every action is supported. The zombie mixed-alchemy known-recipe restriction needs final integration check against its native recipe-picker path; it must not suggest automatic discovery of unknown formulas.

## Gardening and orchards

| Review label / ID | English | Russian |
| --- | --- | --- |
| Empty garden bed / `garden_empty` | For growing **vegetables and field crops**. | Для выращивания **овощей и полевых культур**. |
| Garden bed with sticks / `garden_empty_stick` | For growing climbing crops, including **lentils**. | Для выращивания вьющихся культур, в том числе **чечевицы**. |
| Vine trellis / `vineyard_grapes_stick` | For growing **grapes and hops**. | Для выращивания **винограда и хмеля**. |
| Berry bush plot / `bush_berry_garden` | For growing **berries**. | Для выращивания **ягод**. |
| Apple tree plot / `tree_apple_garden` | For growing **apples**. | Для выращивания **яблок**. |
| Compost heap / `v_obj_compost_heap` | For making **peat and maggots** from crop waste. | Для получения **торфа и опарышей** из отходов урожая. |
| Bee hive / `beehouse` | For collecting **honey**. | Для сбора **мёда**. |
| Zombie farm / `zombie_garden_desk` | A zombie grows **field crops**. | Зомби выращивает **полевые культуры**. |
| Zombie vineyard / `zombie_vineyard_desk` | A zombie grows **grapes and hops**. | Зомби выращивает **виноград и хмель**. |

Evidence N/S: native growing/compost outputs, authored build families and [FARMING_AND_FERTILIZER](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/FARMING_AND_FERTILIZER.md). These are purpose categories, not unlock lists. No automatic seed multiplication or highest-quality production is promised. Honey wording deliberately avoids promising bees/beeswax without their separately gated perks. Zombie farm/vineyard upgrades are not additional visible blueprint references here; do not add hidden rows to fill out a visually pleasing tier family.

## Drinks and processing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Vine press / `mf_vine_press` | For pressing **juice and oil** from crops. | Для получения **сока и масла** из урожая. |
| Fermentation barrel / `barrel_brew` | For fermenting fruit juice before **distillation**. | Для сбраживания фруктового сока перед **перегонкой**. |
| Wine making barrel / `mf_barrel_mid` | For making **wine** from grape juice. | Для приготовления **вина** из виноградного сока. |
| Alcohol distiller / `mf_distcube_3` | For distilling fermented juice into **spirits**. | Для получения **крепкого алкоголя** из перебродившего сока. |
| Brewing stand / `brewing_stand` | For brewing **beer and mead**. | Для приготовления **пива и медовухи**. |
| Zombie brewery / `mf_zombie_brewing` | A zombie brews **beer**. | Зомби варит **пиво**. |
| Zombie winery / `mf_zombie_winemaking` | A zombie makes **wine**. | Зомби делает **вино**. |

Evidence N: exact craft inputs, ordinary and multiquality outputs. No sale prices, story buyers or comparative profitability. Native ordinary recipes differ between manual and zombie brewery, so do not mechanically copy the mead claim to the latter.

## Morgue and corpse handling

| Review label / ID | English | Russian |
| --- | --- | --- |
| Preparation place / `mf_preparation_1` | For removing and replacing **body parts**. | Для извлечения и замены **частей тела**. |
| Preparation place II / `mf_preparation_2` † | For removing and replacing body parts. **Prevents decay** while the body is on the table. | Для извлечения и замены частей тела. **Без разложения**, пока тело на столе. |
| Embalming table / `mf_balsamation_1` | For **injections** that alter a body’s properties. | Для **инъекций**, меняющих свойства тела. |
| Embalming table II / `mf_balsamation_2` † | For injections that alter a body’s properties. **Twice as fast; no decay** while the body is on the table. | Для инъекций, меняющих свойства тела. **Вдвое быстрее; без разложения** на столе. |
| Pallet / `corpse_bed` | For storing **one body**. | Для хранения **одного тела**. |
| Double pallet / `corpse_bed_big` | For storing **two bodies**. | Для хранения **двух тел**. |
| Fridge pallet / `corpse_fridge` † | For storing two bodies **without decay** while they remain here. | Для хранения двух тел **без разложения** на время хранения. |
| Resurrection table / `zombie_crafting_table` | Make **zombie workers** from bodies here. | Здесь можно создавать **зомби-рабочих** из тел. |
| Place for burning corpses / `mf_pyre_placed` | For burning bodies into **ash**. | Для сожжения тел и получения **пепла**. |

Evidence N/S: body insertion filters/limits, extraction/injection/resurrection crafts and the native cremation-output research in [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). The resurrection row uses native `zombie_crafting_table_d` EN/RU prose with proposed emphasis; future production should reuse the proved localization lookup rather than duplicate the language corpus. Its Technology display path is not established by string existence. Paired embalming crafts establish time180->90 across8 matching recipes, supporting twice as fast. V: local balance fields alone do not establish decay behavior; the three daggered lines use original paraphrases of the [Corpse](https://graveyardkeeper.fandom.com/wiki/Corpse) and [Preparation place II](https://graveyardkeeper.fandom.com/wiki/Preparation_place_II) explanations and still require exact1.407 decay-owner verification. Surgical-error/table-tier benefits also need exact consumer verification; shared Perk mechanics identifies the risk model, but does not close every tier effect here. Pallet lines currently state only directly confirmed body capacity; consider their decay effect after the same check.

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
| Lantern / `lantern` | For **lighting** the surrounding area. | Для **освещения** пространства вокруг. |
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
| Soul container I / `soul_container` | For storing **two souls**. | Для хранения **двух душ**. |
| Soul container II / `soul_container_2` | For storing **three souls**. | Для хранения **трёх душ**. |
| Soul container III / `soul_container_3` | For storing **four souls**. | Для хранения **четырёх душ**. |
| Organ workbench / `soul_workbench` † | For altering the **skull values of body parts**. | Для изменения **числа черепов у частей тела**. |
| Soul extractor upgrade II / `soul_extractor_upgrd_to_2` † | Extracts souls with **less damage**. | Извлекает души с **меньшими повреждениями**. |
| Soul extractor upgrade III / `soul_extractor_upgrd_to_3` † | Extracts souls **without damage**. | Извлекает души **без повреждений**. |
| Wall crematorium / `mf_crematorium` † | For burning bodies into **ash** using fuel. | Для сожжения тел в **пепел** с помощью топлива. |
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

The user approved selective icons with explanatory text in purpose descriptions, following the material-row precedent. Use a native semantic icon for a metric/category where it speeds recognition; retain the words. Avoid a picture for every noun or mixing a specific potion/item sprite into a claim about an entire category. Automation remains a text accent; do not invent an automation pictogram. Exact placement, color and line wrapping still require visual acceptance.

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
