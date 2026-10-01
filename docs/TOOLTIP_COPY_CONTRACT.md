# Tooltip Copy Contract

Target: **Graveyard Keeper 1.407**
Date: **2026-10-01**
Status: **accepted EN/RU semantic source for the next production candidate**

This document consolidates the product decisions in `PERK_TOOLTIP_PRODUCT_DECISIONS.md`.
English is the semantic source for translation; Russian is the accepted primary review locale.

## Presentation rules

- Preserve useful vanilla flavor/description text unless a correction explicitly replaces it.
- When DTT appends a clarification to an authored Work/Perk description, separate the vanilla text and DTT clarification by one blank line; do not use brackets or italics.
- DTT additions read as neutral game help, not commentary from the mod author.
- Use the game's native quality icon token `(s1)` for the quality-score metric; do not render a literal Unicode star.
- Native item, station and NPC names should come from game localization where the implementation has a proved native ID.
- Probability changes are shown as before/after values, not as ambiguous relative percentages.
- Do not expose future quest/story ownership merely because later uses are known.

## Farming and fertilizer

| Unlock / ID | English | Russian |
| --- | --- | --- |
| Peat / `peat_from_waste` | `Effect for one crop cycle: increases crop and seed yields and reduces growth time by 20%.` | `Эффект на один цикл: увеличивает урожай и количество семян при сборе, сокращает время роста на 20%.` |
| Boost fertilizer I / `sack_clock_silver` | `Effect for one crop cycle: reduces growth time by 40%.` | `Эффект на один цикл: сокращает время роста на 40%.` |
| Boost fertilizer II / `sack_clock_gold` | `Effect for one crop cycle: reduces growth time by 60%.` | `Эффект на один цикл: сокращает время роста на 60%.` |
| Quality fertilizer I / `sack_star_silver` | `Effect for one crop cycle: increases crop and seed yields. Additionally produces 1 crop and 1 seed one quality tier higher.` | `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше.` |
| Quality fertilizer II / `sack_star_gold` | `Effect for one crop cycle: increases crop and seed yields. Additionally produces 2 crops and 2 seeds one quality tier higher.` | `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 2 единицы урожая и 2 семени на одну ступень качества выше.` |

### Grape / hops growth unlocks

The generic vanilla `Create` title is replaced for these two internal growth crafts.

**Grapes / `garden_grapes_growing`**

English:
- `Growing: Grapes`
- `Requires: Grape seeds (x4)`
- `Grown at: Vineyard — Vine trellis`
- `Seeds: Merchant`

Russian:
- `Выращивание: Виноград`
- `Нужно: Семена винограда (x4)`
- `Выращивается: Виноградник — Опора под лозу`
- `Семена: Торговец`

**Hops / `garden_hop_growing`**

English:
- `Growing: Hops`
- `Requires: Hops seeds (x4)`
- `Grown at: Vineyard — Vine trellis`
- `Seeds: Miller`

Russian:
- `Выращивание: Хмель`
- `Нужно: Семена хмеля (x4)`
- `Выращивается: Виноградник — Опора под лозу`
- `Семена: Мельник`

Use native localized item/station/NPC names where available. `Vineyard` is location information only; do not explain how story access is obtained.

## Work

### Super mushroom / `t_mushroom2`

Preserve the vanilla authored description.

Append:
- EN: `Unlocks gathering red mushrooms.`
- RU: `Открывает сбор красных грибов.`

Do not mention the later Infusion recipe, Vagner/Ms. Charm quest context, or later-use ownership.

## Perks

Unless noted otherwise, preserve the vanilla authored description and append the following line(s). Cultist / `p_cultist` is deliberately left fully vanilla and therefore does not appear in the table.

| Perk / ID | English addition | Russian addition |
| --- | --- | --- |
| Jeweler / `p_jevelery` | `Hardcover book crafting quality: (s1)+0.7.\nDungeon diamond, gold, and silver sources yield at least +1 more.` | `Качество книг в твёрдом переплёте: (s1)+0,7.\nИсточники алмазов, золота и серебра в подземелье дают как минимум на 1 ресурс больше.` |
| Wine Master / `p_wine_master` | `Red wine crafting quality: (s1)+0.8.\nAlcohol restores more energy.` | `Качество красного вина: (s1)+0,8.\nАлкоголь восстанавливает больше энергии.` |
| Writer / `p_writer` | `Writing quality: (s1)+0.3.` | `Качество письменных работ: (s1)+0,3.` |
| Playwright / `p_good_writer` | `Writing quality: (s1)+0.5.` | `Качество письменных работ: (s1)+0,5.` |
| Industriousness / `p_industriousness` | `Crafting quality for affected recipes: (s1)+0.2.` | `Качество изготовления для соответствующих рецептов: (s1)+0,2.` |
| Engineer / `p_engineer` | `Crafting quality for carved wood, carved marble, and steel chisels: (s1)+0.3.` | `Качество резного дерева, резного мрамора и стальных резцов: (s1)+0,3.` |
| Sword Master / `p_sword_master` | `Weapon damage: +5.` | `Урон оружием: +5.` |
| Persistence / `p_persistence` | `Passively restores 1 energy per second.` | `Пассивно восстанавливает 1 энергию в секунду.` |
| Butcher / `p_butcher` | `Chance of error when extracting flesh, blood, fat, skin, skull, and bones decreases from 25% to 0%.` | `Шанс ошибки при извлечении мяса, крови, жира, кожи, черепа и костей снижается с 25% до 0%.` |
| Doctor / `p_doctor` | `Chance of error when extracting the brain, heart, and intestine decreases from 50% to 25% at Preparation Place and from 25% to 0% at Preparation Place II.` | `Шанс ошибки при извлечении мозга, сердца и кишечника снижается с 50% до 25% на препарационном столе и с 25% до 0% на препарационном столе II.` |
| Blacksmith / `p_blacksmith` | `Crafting nails and metal parts produces more items. Steel chisel quality: (s1)+0.1.` | `При изготовлении гвоздей и металлических деталей получается больше изделий. Качество стальных резцов: (s1)+0,1.` |

### Big Guy / `p_big_guy`

This is a correction rather than an appended clarification.

The native localized authored description is preserved, but its stale stat values are corrected from **+1 damage / +1 defense** to **+2 damage / +2 defense**.

Russian expected result:
`Тяжелая работа закалила тебя, ты стал больше и сильнее. +2 урон, +2 защита.`

Implementation must fail closed if the expected two stale numeric tokens cannot be identified safely in the active native description.

## Pyrite

Do not hardcode the mineral name. Format the note with the same native localization key, `p_t_pyrite`, that vanilla uses for the visible gathering-unlock name.

Semantic source:
- EN: `Note: {native name} does not drop while mining coal.`
- RU: `Примечание: {native name} не выпадает при добыче угля.`

Do not add quotation marks around the native mineral name. This keeps the note visually consistent with the surrounding Technology unlock names while still guaranteeing terminology identical to the active game locale (for example, Russian `Серный колчедан` rather than a separately translated `пирит`). The note remains an accepted explicit technical-note exception because an in-world formulation would imply that non-functionality is the intended Technology effect.

## Explicit non-changes

No new detail is added at this stage to:
- Farmer;
- Miner;
- Mason;
- Woodworker;
- Old books;
- Cultist;
- unrelated Work/Perk entries.

Gameplay data, progression, unlock state, recipes, builds, saves and authored-hidden unlocks remain unchanged.
