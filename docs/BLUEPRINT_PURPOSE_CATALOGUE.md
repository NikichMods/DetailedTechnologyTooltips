# Blueprint purpose copy — grouped editorial catalogue

Target: Graveyard Keeper 1.407. Prepared 2026-10-21. This is a **review draft**, not a runtime implementation or accepted replacement for stable1.1.6.

Coverage:105 authored-visible Technology blueprint references,104 distinct build records. The Church workbench appears in two technologies and shares one description. Hidden `@` references, ordinary item recipes and existing Work/Perk copy are outside this catalogue. This covers the blueprint purpose work requested here, including visible DLC/system upgrades.

## Reading and evidence

English is the semantic source; Russian is the review locale. Bold marks the proposed semantic accent. Names in the first column are review labels; production titles must retain native localization, including special build-name resolution. IDs identify records and are not player-facing text. Unless explicitly noted as accepted below, every sentence remains an editorial proposal.

The user accepted the revised ten-building basis and explicitly requested applying its style to the rest of the catalogue: varied natural openings, concise primary benefit, and parallel wording for related constructions. The first full pass reviewed104 distinct rows in both EN and RU. A subsequent user review prompted the delta-first revision below: higher tiers foreground their new benefit, generic storage has no forced accent, and factual ambiguities in gardening, mining and water copy are corrected. All23 mechanics-check markers remain; new static findings do not silently close the remaining final-owner checks. This is copy preparation, not a production/runtime acceptance claim. Selective native icons with explanatory text are approved; exact placement/rendering remains separate.

The current voice mixes object-enabled action (`Позволяет…`), place-bound action (`Здесь можно…`), natural use/purpose (`Служит для…`, `Используется для…`), storage, direct effects and explicit zombie/automatic actors. Bare repetitive `Для…`, process-only headings and anaphoric `На нём…`/`На них…` are not the general template. Choose voice by role and sentence flow; retain sister-tier wording rather than rotating prefixes by row number. The [language research](TOOLTIP_LANGUAGE_RESEARCH.md) owns those adopted decisions and the PrayerClarity writing-quality terminology.

The [workstation upgrade audit](WORKSTATION_UPGRADE_REVIEW.md) owns supported tier benefits and exceptions. Short copy communicates the main benefit without listing every exception or secondary output. Earlier energy-led DeskII and speed-only distillationII copy remains superseded. New phrasings do not close mechanical flags or justify invented advantages. Qualitative simplification does not authorize unproved percentages or guaranteed outcomes.

Higher-tier copy may refer concisely to the earlier construction or use “also/additionally” when the shared role is clear. Prefer the actual new capability over a repeated base-role catalogue or the empty phrase “improved version.” Do not require opening another tooltip to understand the new benefit. Retain self-contained parallel wording where tiers are complementary (the two alchemy tables), or where a short numeric comparison is already clearer. These are proposed applications of the user's requested direction, not final acceptance of each new sentence.

Accent is optional: a broad word such as “items” does not deserve color merely to fill a template. Emphasize a specific result, distinguishing capability or useful metric. Choose natural word order; neither sentence-final highlighting nor its artificial avoidance is a rule.

Descriptions explain the construction's role, not a promise that every supported recipe becomes available immediately with its blueprint. A higher tier must not imply recipe inheritance or a numeric improvement that has not been proved. Some supported recipes have independent native unlock requirements.

Evidence classes used in the notes:
- **N:** directly inspected native balance/object/craft data supports the stated role or value; this is static evidence, not installed rendering acceptance.
- **S:** existing shared research supports the action/mechanic; see the linked owning document.
- **V:** wording has a version-specific mechanism/benefit still to verify. A dagger **†** identifies these rows. They are complete editorial drafts, but must not enter production unchanged on the strength of this catalogue.

Primary static input: installed1.407 `resources.assets`, SHA-256 `215c7981901a4b72d5db717666ba47ad3cc032527c95f58dc39d8af1293a69ca`; bounded inspection of `game_data`, `lng_en`, `lng_ru` and native font-symbol tables. Raw inputs and bulk extractions stay private. Most direct inspected station/object description keys provide no purpose text, but `zombie_crafting_table_d` does: the resurrection-table row below reuses that native text. The earlier blanket absence statement was too broad. This is still not an exhaustive search of every alias/dialogue/tutorial, nor proof that a native key is currently shown in vanilla Technology UI.

## Metal, firing and precision work

| Review label / ID | English | Russian |
| --- | --- | --- |
| Furnace / `mf_furnace_0` | Used to smelt **iron** and make glass and ceramics. | Служит для выплавки **железа**, изготовления стекла и керамики. |
| Furnace II / `mf_furnace_1` | Also allows you to smelt **steel, silver and gold**. | Дополнительно позволяет выплавлять **сталь, серебро и золото**. |
| Furnace III / `mf_furnace_2` | Adds **steel parts** and yields more graphite from the same coal. | Дополнительно позволяет делать **стальные детали**. Больше графита из того же угля. |
| Wooden anvil / `mf_anvil_1` | Allows you to forge **nails, simple iron parts and basic tools**. | Позволяет ковать **гвозди, простые железные детали и базовые инструменты**. |
| Anvil / `mf_anvil_2` | Also allows you to forge **complex iron parts**. | Дополнительно позволяет ковать **сложные железные детали**. |
| Anvil II / `mf_anvil_3` | Allows you to forge **steel equipment**. More nails and simple parts from the same metal. | Позволяет ковать **стальное снаряжение**. Больше гвоздей и простых деталей из того же металла. |
| Potter's wheel / `mf_potter_wheel_1` | You can shape clay into **ceramic bowls** here. | Здесь можно делать из глины **керамические миски**. |
| Jewelry table / `mf_jewelry` | Used to make **jewelry** and set gems in swords. | Используется для изготовления **украшений** и отделки мечей самоцветами. |

Evidence N: exact station `craft_in`, multiquality outputs and evaluated-yield expressions. Furnace tiers differ by supported recipes; III also increases matching graphite output1->2 for the same coal input. AnvilII increases matching nail/simple-parts output, with equal perk terms. No generic all-products yield increase or universal fuel saving is claimed. TierIII's steel-parts recipe is native; it does not mean the blueprint itself unlocks every metal recipe. See the upgrade audit for the bounded pairs and selection rationale.

## Wood and stone

| Review label / ID | English | Russian |
| --- | --- | --- |
| Sawhorse / `mf_beam_gantry_1` | Allows you to cut logs into **boards**. | Позволяют распиливать брёвна на **доски**. |
| Chopping spot / `mf_chocks_1` | You can make **firewood and wedges** here. | Здесь можно заготавливать **дрова и клинья**. |
| Circular saw / `mf_saw_1` | Allows you to get **more boards** from each log. | Позволяет получать **больше досок** из каждого бревна. |
| Carpenter's workbench / `mf_workbench_1` | You can make **wooden planks** and wooden grave decorations here. | Здесь можно делать **брусья** и деревянные надгробия. |
| Carpenter's workbench II / `mf_workbench_2` | Also allows you to make **lenses and steel equipment**. | Дополнительно позволяет делать **линзы и стальное снаряжение**. |
| Stone cutter / `mf_hammer_0` | Used to work **stone and marble** into building materials and grave decorations. | Используется для обработки **камня и мрамора**, изготовления материалов и надгробий. |
| Stone cutter II / `mf_hammer_1` | Allows you to make **more intricate grave decorations** from stone and marble. | Позволяет делать **более сложные надгробия** из камня и мрамора. |

Evidence N: exact station output families and matched yield expressions. Circular saw billet output4->5+Woodworker and flitch6->7+2*Woodworker for the same log inputs support more output; “more boards” names the flitch improvement as the representative benefit, not a universal multiplier or direct planks recipe; do not infer zombie automation. CarpenterII also supports lenses/steel equipment, now prioritized over the earlier carved-wood-only difference. Review labels for missing direct object-name keys are explanatory only. Base Carpenter copy now names native `wooden_plank` (RU `Брус`) rather than the vague category “wooden parts”; ordinary-craft and grave-output records support the two representative functions. Resolve native names for `jointing`, `wooden_beam`, `flitch`, `wooden_plank` and carved outputs before production. “Intricate” describes the expanded decoration family, not improved quality of every existing output.

## Storage

| Review label / ID | English | Russian |
| --- | --- | --- |
| Timber stockpile / `mf_timber_1` | Storage for **logs**. | Место для хранения **брёвен**. |
| Stone stockpile / `mf_stones_1` | Storage for **stone and marble blocks**. | Место для хранения **каменных и мраморных блоков**. |
| Iron ore stockpile / `mf_ore_1_complete` | Storage for **iron ore blocks**. | Место для хранения **блоков железной руды**. |
| Trunk / `mf_box_stuff` | Storage for items. | Место для хранения предметов. |
| Scrollshelf / `obj_church_scroll_cabinet` | Storage for items. | Место для хранения предметов. |
| Bookshelf / `obj_church_bookcase` | Storage for items. | Место для хранения предметов. |
| Alchemy rack / `rack_alchemy` | Storage for items. | Место для хранения предметов. |
| Mortuary rack / `rack_organs` | Storage for items. | Место для хранения предметов. |

Evidence N: native inventories and existing shared storage semantics. No specialized-only filter is inferred from the shelf/rack name, and no decorative-only role is invented. Numerical inventory sizes are deliberately omitted until slot/stack semantics are separately reviewed. Large-block stockpile filters need final UI confirmation before claiming exclusivity; these sentences do not say “only.”

## Study, writing and printing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Study table / `mf_alchemy_survey` | Used for studying items and earning **technology points**. | Используется для изучения предметов и получения **очков технологий**. |
| Church workbench / `table_book_constr` | You can make **paper, ink and candles** here. | Здесь можно делать **бумагу, чернила и свечи**. |
| Desk / `desk` | Allows you to make **books and prayers**. | Позволяет создавать **книги и молитвы**. |
| Desk II / `desk_2` | **Writing quality bonus** when making books and prayers. | **Бонус к качеству письма** при создании книг и молитв. |
| Paper press / `mf_paper_press` | Used to make **clean paper** from paper glop. | Служит для изготовления **чистой бумаги** из бумажной массы. |
| Printing press / `mf_printing_press` † | Allows you to print **flyers in batches**. | Позволяет печатать **листовки партиями**. |
| Printing press II / `mf_printing_press_2` † | Allows you to print **flyers in batches**. | Позволяет печатать **листовки партиями**. |
| Random text generator / `zombie_pulpit` | A zombie writes **stories**. | Зомби пишет **истории**. |

Evidence N/S: exact outputs, multiquality writing outputs, native zombie-only station flags, and [STUDY_RESOURCE_ECONOMY](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/STUDY_RESOURCE_ECONOMY.md)/[ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). DeskII's quality benefit is the selected headline: matching notes/chapter/hardcover/story/prayer difficulties improve, with different deltas and some unchanged prayer recipes. Energy savings are real but secondary; do not replace quality with that easier measurement. No universal percentage or guaranteed gold result. V: flyer recipe parity does not establish no difference between presses: unlock-gated serialized copying recipes with multiquality parent IDs were missed by the earlier physical-output census. Actual availability and tier scope remain pending; identical provisional flyer text must not be read as a verified whole-station equivalence. Prayer recipe support is a role of the desk blueprint, not permission for DTT to rewrite prayer unlocks. Church-workbench copy names representative outputs, not an exhaustive product list.

## Alchemy

| Review label / ID | English | Russian |
| --- | --- | --- |
| Alchemy workbench / `mf_alchemy_craft_02` | Lets you make potions from **two ingredients**. | Служит для приготовления зелий из **двух ингредиентов**. |
| Alchemy workbench II / `mf_alchemy_craft_03` | Lets you make potions from **three ingredients**. | Служит для приготовления зелий из **трёх ингредиентов**. |
| Hand mixer / `mf_alchemy_stirrer_01` | Allows you to obtain alchemical **solutions** from materials. | Позволяет получать алхимические **растворы** из материалов. |
| Alchemy mill / `mf_alchemy_mill` | Used to grind materials into alchemical **powders**. | Используется для получения алхимических **порошков** из материалов. |
| Distillation cube / `mf_distcube_2_clay` | You can obtain alchemical **extracts** from materials here. | Здесь можно получать алхимические **экстракты** из материалов. |
| Distillation cube II / `mf_distcube_2_cuprum` | Allows you to obtain **more extract** from the same raw materials. | Позволяет получать **больше экстракта** из того же сырья. |
| Zombie alchemy decomposer / `alchemy_table_zombie` | A zombie processes materials into **powders, solutions and extracts**. | Зомби перерабатывает материалы в **порошки, растворы и экстракты**. |
| Zombie alchemy workbench / `alchemy_workbench_zombie` † | A zombie makes potions from **known recipes**. | Зомби готовит зелья по **известным рецептам**. |

Evidence N/S: native station families and [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md), not a guessed output taxonomy. Corrected distillation comparison evaluates output expressions:18 matched material-processing formulas gain+1 extract at equal inputs/perks;8 goo-recovery formulas keep their output. Speed90->60 is also real, but higher material yield is now the selected main benefit. “Raw materials” describes material decomposition, not goo recovery; final copy must not turn this into an all-recipes guarantee. Neither universal double nor an unqualified+1 for every action is supported. The zombie mixed-alchemy known-recipe restriction needs final integration check against its native recipe-picker path; it must not suggest automatic discovery of unknown formulas.

## Gardening and orchards

| Review label / ID | English | Russian |
| --- | --- | --- |
| Empty garden bed / `garden_empty` | Allows you to grow **vegetables and field crops**. | Позволяет выращивать **овощи и полевые культуры**. |
| Garden bed with sticks / `garden_empty_stick` | You can grow **lentils** here. | Здесь можно выращивать **чечевицу**. |
| Vine trellis / `vineyard_grapes_stick` | Used to grow **grapes and hops**. | Служит для выращивания **винограда и хмеля**. |
| Berry bush plot / `bush_berry_garden` | A place to grow **berries**. | Место для выращивания **ягод**. |
| Apple tree plot / `tree_apple_garden` | A place to grow **apples**. | Место для выращивания **яблок**. |
| Compost heap / `v_obj_compost_heap` | Used to turn crop waste into **peat**. | Используется для переработки отходов урожая в **торф**. |
| Bee hive / `beehouse` | Used to collect **honey**. | Служит для сбора **мёда**. |
| Zombie farm / `zombie_garden_desk` | A zombie grows **field crops**. | Зомби выращивает **полевые культуры**. |
| Zombie vineyard / `zombie_vineyard_desk` | A zombie grows **grapes and hops**. | Зомби выращивает **виноград и хмель**. |

Evidence N/S: native growing/compost outputs, authored build families and [FARMING_AND_FERTILIZER](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/FARMING_AND_FERTILIZER.md). The exact `garden_empty_stick` planting census contains only `garden_lentils_planting_1/2/3`, each changing the plot to `garden_lentils`; other crafts at this station are fertilizers. Lentils are therefore the purpose, not an arbitrary exception within an invented broader crop category. These are purpose categories, not unlock lists. No automatic seed multiplication or highest-quality production is promised. Honey wording deliberately avoids promising bees/beeswax without their separately gated perks. Zombie farm/vineyard upgrades are not additional visible blueprint references here; do not add hidden rows to fill out a visually pleasing tier family.

## Drinks and processing

| Review label / ID | English | Russian |
| --- | --- | --- |
| Vine press / `mf_vine_press` | Allows you to press **juice and oil** from crops. | Позволяет выжимать **сок и масло** из урожая. |
| Fermentation barrel / `barrel_brew` | Used to **ferment fruit juice** before distillation. | Служит для **сбраживания фруктового сока** перед перегонкой. |
| Wine making barrel / `mf_barrel_mid` | Used to make **wine** from grape juice. | Служит для приготовления **вина** из виноградного сока. |
| Alcohol distiller / `mf_distcube_3` | You can distil fermented juice into **spirits** here. | Здесь можно получать **крепкий алкоголь** из перебродившего сока. |
| Brewing stand / `brewing_stand` | Used to brew **beer and mead**. | Используется для приготовления **пива и медовухи**. |
| Zombie brewery / `mf_zombie_brewing` | A zombie brews **beer**. | Зомби варит **пиво**. |
| Zombie winery / `mf_zombie_winemaking` | A zombie makes **wine**. | Зомби делает **вино**. |

Evidence N: exact craft inputs, ordinary and multiquality outputs. No sale prices, story buyers or comparative profitability. Native ordinary recipes differ between manual and zombie brewery, so do not mechanically copy the mead claim to the latter.

## Morgue and corpse handling

| Review label / ID | English | Russian |
| --- | --- | --- |
| Preparation place / `mf_preparation_1` | Allows you to remove and replace **body parts**. | Позволяет извлекать и заменять **части тела**. |
| Preparation place II / `mf_preparation_2` † | Bodies **do not decay** on this table. | Тело **не разлагается** на этом столе. |
| Embalming table / `mf_balsamation_1` | You can alter a body’s properties with **injections** here. | Здесь можно менять свойства тел с помощью **инъекций**. |
| Embalming table II / `mf_balsamation_2` † | You can give injections **twice as fast** here. Bodies do not decay on the table. | Здесь можно делать инъекции **вдвое быстрее**. Тело на столе не разлагается. |
| Pallet / `corpse_bed` | Space for **one body**. | Место для **одного тела**. |
| Double pallet / `corpse_bed_big` | Space for **two bodies**. | Место для **двух тел**. |
| Fridge pallet / `corpse_fridge` † | Bodies **do not decay** in storage. Holds two bodies. | Тела **не разлагаются** при хранении. Вмещает два тела. |
| Resurrection table / `zombie_crafting_table` | Make **zombie workers** from bodies here. | Здесь можно создавать **зомби-рабочих** из тел. |
| Place for burning corpses / `mf_pyre_placed` | Used to burn bodies into **ash**. | Служит для сожжения тел и получения **пепла**. |

Evidence N/S: body insertion filters/limits, extraction/injection/resurrection crafts and the native cremation-output research in [ALCHEMY_SYSTEM](https://github.com/NikichMods/GraveyardKeeperResearch/blob/main/docs/ALCHEMY_SYSTEM.md). The resurrection row uses native `zombie_crafting_table_d` EN/RU prose with proposed emphasis; future production should reuse the proved localization lookup rather than duplicate the language corpus. Its Technology display path is not established by string existence. Paired embalming crafts establish time180->90 across8 matching recipes, supporting twice as fast. V: local balance fields alone do not establish decay behavior; the three daggered lines use original paraphrases of the [Corpse](https://graveyardkeeper.fandom.com/wiki/Corpse) and [Preparation place II](https://graveyardkeeper.fandom.com/wiki/Preparation_place_II) explanations and still require exact1.407 decay-owner verification. Surgical-error/table-tier benefits also need exact consumer verification; shared Perk mechanics identifies the risk model, but does not close every tier effect here. Pallet lines currently state only directly confirmed body capacity; consider their decay effect after the same check.

## Zombie extraction and transport

| Review label / ID | English | Russian |
| --- | --- | --- |
| Zombie ore mine: left / `zombie_mine_bench_left` † | A zombie mines **iron ore and coal**. | Зомби добывает **железную руду и уголь**. |
| Zombie stone quarry: right / `zombie_mine_fence_front_stone` † | A zombie quarries **stone blocks**. | Зомби добывает **каменные блоки**. |
| Zombie marble quarry: right / `zombie_mine_fence_front_marble_right` † | A zombie quarries **marble blocks**. | Зомби добывает **мраморные блоки**. |
| Porter station / `porter_station` | A zombie **transports resources** between work areas. | Зомби **переносит ресурсы** между рабочими зонами. |

Evidence N: native zombie assignment and porter GUI action. V: the three mining rows are virtual build records rather than direct `craft_in` stations. Verify the final worker/path/output owner before production; the text intentionally omits a route, mining speed or infinite resources. The functioning `mine_zombie_bench` has iron and coal recipes, linked bidirectionally by `craft_after_finish` (iron:1 ore block; coal:7 coal). `CraftComponent.ProcessFinishedCraft` consumes that next-craft field. Coal is part of the repeating work cycle, not a rare perk byproduct; it is restored in the purpose. Shared research establishes the physical bench start path; exact virtual blueprint-to-placed-worker mapping remains a production check, so the dagger is retained.

## Lighting and water

| Review label / ID | English | Russian |
| --- | --- | --- |
| Lantern network / `lantern_network` † | Enables **lantern installation**. | Позволяет устанавливать **светильники**. |
| Lantern / `lantern` | Used to **light** the surrounding area. | Служит для **освещения** пространства вокруг. |
| Water pump / `well_pump` | **Automatically** draws water from the well. | **Автоматически** набирает воду из колодца. |

Evidence N: `place_well_pump` native FlowScript (resources pathID150843) spawns `well_pump` and starts `water_pumping`. This automatic recipe has no input needs, energy0 and craft_time10; it adds water1 to its own WGO inventory and repeats. `well_pump` has a water-only insertion filter and limit500. The pinned host `SmartExpression.TakeWaterFromPump` removes up to10 water from this object, drops it toward the player and animates `water_well`, without a player-energy charge. This supports drawing water automatically with a local accumulated supply; it does not prove a global replenished water pool or instantaneous production. The revised short copy names the well and keeps the accepted automation accent. The test recipe `water_pumping_test` is not the installed graph's start target. V: determine the network's exact final action and scope before shipping that line; its virtual name alone does not prove whether it enables placement or constructs a fixed network. Lantern purpose is a draft role statement, not a claim of a productivity/quality bonus.

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
| Soul container I / `soul_container` | Space for **two souls**. | Место для **двух душ**. |
| Soul container II / `soul_container_2` | Space for **three souls**. | Место для **трёх душ**. |
| Soul container III / `soul_container_3` | Space for **four souls**. | Место для **четырёх душ**. |
| Organ workbench / `soul_workbench` † | You can alter the **skull values of body parts** here. | Здесь можно менять **число черепов у частей тела**. |
| Soul extractor upgrade II / `soul_extractor_upgrd_to_2` † | Allows you to extract souls with **less damage**. | Позволяет извлекать души с **меньшими повреждениями**. |
| Soul extractor upgrade III / `soul_extractor_upgrd_to_3` † | Allows you to extract souls **without damage**. | Позволяет извлекать души **без повреждений**. |
| Wall crematorium / `mf_crematorium` † | Used to burn bodies into **ash** using fuel. | Используется для сожжения тел в **пепел** с помощью топлива. |
| Soul receiver / `soul_totem_souls` † | Enables **remote crafting** for souls’ gratitude. | Позволяет **удалённо запускать работу** за благодарность душ. |

Evidence N: soul containers' `can_insert_items` accepts harmed/healed souls and direct insertion limits are2/3/4. The prose omits storage decay prevention and room-capacity numerical effects until the owning mechanics are checked. V: workbench special UI, extractor damage, crematorium handling and receiver routing need exact1.407 final-owner verification; the balance placeholder or ordinary fertilizer recipes alone do not prove them. Secondary semantic cross-checks: [Soul extractor III](https://graveyardkeeper.fandom.com/wiki/Soul_extractor_III), [Soul receiver](https://graveyardkeeper.fandom.com/wiki/Soul_Receiver), [Souls room](https://graveyardkeeper.fandom.com/wiki/Souls_room). Do not infer that receiver can automatically execute every recipe or reveal hidden builders/story access.

## Souls room: healing extensions

| Review label / ID | English | Russian |
| --- | --- | --- |
| Healing from pride / `pride_healing_extension` † | Adds **a skin slot** to the soul healer. | Добавляет **ячейку для кожи** в целитель душ. |
| Healing from wrath / `wrath_healing_extension` † | Adds **a blood slot** to the soul healer. | Добавляет **ячейку для крови** в целитель душ. |
| Healing from gluttony / `gluttony_healing_extension` † | Adds **a fat slot** to the soul healer. | Добавляет **ячейку для жира** в целитель душ. |
| Healing from sloth / `sloth_healing_extension` † | Adds **a brain slot** to the soul healer. | Добавляет **ячейку для мозга** в целитель душ. |
| Healing from lust / `lust_healing_extension` † | Adds **a heart slot** to the soul healer. | Добавляет **ячейку для сердца** в целитель душ. |
| Healing from envy / `envy_healing_extension` † | Adds **an intestine slot** to the soul healer. | Добавляет **ячейку для кишечника** в целитель душ. |

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
