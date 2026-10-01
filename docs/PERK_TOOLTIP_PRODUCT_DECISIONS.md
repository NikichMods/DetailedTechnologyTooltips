# Perk Tooltip Product Decisions

Date: 2026-10-01
Target: Graveyard Keeper 1.407
Status: accepted product-decision ledger. Selected decisions were separately gated, implemented and accepted in stable 1.0.2, and remain current in stable 1.1.6. Exact shipped copy is canonical in `docs/TOOLTIP_COPY_CONTRACT.md`.

Shared mechanics source:
- `NikichMods/GraveyardKeeperResearch/docs/PERK_MECHANICS.md`

## Accepted for tooltip enrichment / correction

- Big Guy / Работяга:
  - correct stale vanilla values to current 1.407 mechanics;
  - current effect: +2 weapon damage and +2 incoming-damage mitigation.

- Wine Master / Мастер вина:
  - clarify red-wine crafting quality: +★0.8;
  - also state qualitatively that alcohol restores more energy;
  - do not invent a universal percentage for the energy effect.

- Jeweler / Ювелир:
  - add a factual clarification because current mechanics differ materially from what the vanilla wording leads the player to expect;
  - accepted semantic wording:
    - `Hardcover book crafting quality: +★0.7.`
    - `Dungeon diamond, gold, and silver sources yield at least +1 more.`
  - the second line deliberately describes the corresponding dungeon sources rather than promising that all three resources are always obtained.

- Writer / Писатель:
  - add a short numeric quality line: +★0.3 on affected writing crafts.

- Playwright / Драматург:
  - add a short numeric quality line: +★0.5 on affected writing crafts.

- Industriousness / Трудолюбие:
  - add a short numeric quality line: +★0.2 on affected crafts;
  - do not imply every craft in the game is affected.

- Engineer / Инженер:
  - add a short numeric quality line: +★0.3 on the verified affected craft family.

- Sword Master / Мастер меча:
  - add a short direct stat line: +5 weapon damage.

- Persistence / Упорство:
  - add a short direct effect line: passively restores 1 energy per running second.

## Explicitly not selected for numeric enrichment at this stage

- Miner / Шахтёр:
  - vanilla description already communicates the useful player-facing idea;
  - the real effect is heterogeneous per drop/source, so exact numbers would add clutter without enough value.

- Mason / Каменщик:
  - do not add +★0.5 or output-count details at this stage;
  - affected quality crafts already surface the active Perk in their native craft UI, and the vanilla perk text is adequate.

- Woodworker / Столяр:
  - same decision as Mason; no extra quality/output-number line at this stage.

## Closed wording decisions

### Butcher / Мясник

Accepted presentation:
- preserve the useful vanilla flavor sentence;
- do not use the internal category label "basic parts";
- enumerate the affected extraction items directly;
- accepted player-facing form uses an explicit verb rather than a special arrow glyph:
  `Chance of error when extracting flesh, blood, fat, skin, skull, and bones decreases from 25% to 0%.`
- do not add the qualifier "base": the Perk itself takes this path to zero, so that qualifier makes the result harder rather than easier to understand.

Verified mechanic, isolating the Perk from the independent Clean Cut buff:
- applicable common extraction mistake chance: 25% -> 0%.

### Doctor / Доктор

Accepted presentation:
- identify brain / heart / intestine directly rather than relying only on the hidden category "important organs";
- show both native preparation-table contexts;
- accepted player-facing form uses an explicit verb rather than a special arrow glyph:
  `At Preparation Place I, chance of error when extracting the brain, heart, and intestine decreases from 50% to 25%. At Preparation Place II, it decreases from 25% to 0%.`
- use the native localized station names in production rather than hard-coded translated station names.

Verified mechanic, isolating the Perk from the independent Clean Cut buff:
- Preparation Place I: 50% -> 25%;
- Preparation Place II: 25% -> 0%.

### Cultist / Сектант

Final product decision: **leave vanilla; do not append DTT text**.

Reason:
- the vanilla Technology description already explains the actual unlock: the player can see the red/white skull values of body parts;
- the real ambiguity arises later in the corpse/extraction UI, where a displayed organ value can be misread as the result of removal rather than the part's current contribution;
- repeating that relationship in the Technology Tree does not solve the problem at the point where the player encounters it and adds redundant text.

If this ambiguity is ever addressed, the correct product surface is the corpse/body-part UI, not Detailed Technology Tooltips.


## Voice / style contract

All DTT additions inside the Technology Tree should read as if they were native game help:

- preserve useful vanilla flavor text where possible;
- prefer neutral factual labels/statements over commentary;
- do not address the player as the mod author;
- avoid meta-language about the mod, implementation, data files, or "the current game version" unless no in-world/system-style wording can express the necessary fact;
- concise mechanical statements such as `Crafting quality: +★0.3`, `Chance: 25% -> 0%`, or `Restores more energy` fit the intended voice.

### Existing 1.0.2 style outlier / accepted exception

The Pyrite unlock is a verified broken-native-data case (`p_t_pyrite` / `p_t_pirit` mismatch). Attempts to rewrite this as ordinary in-world/system behavior ("does not unlock", "unavailable") make the Technology entry more confusing by implying that non-functionality is the intended effect.

Accepted product direction:
- keep an explicit technical note for this exceptional broken mechanic;
- prefer operational wording over speculation about developer intent or version-specific temporariness;
- accepted final semantic: format the active game's native `p_t_pyrite` name into a plain unquoted technical note that describes the Technology itself as non-functional in the current game version, e.g. Russian `Примечание: в текущей версии игры эта технология не позволяет получать Серный колчедан.`
- this is a deliberate exception to the normal "native game help" voice because a non-meta formulation would mislead the player.

This presentation was separately gated, implemented and accepted in stable 1.0.2 and remains current in stable 1.1.6.


## Implemented follow-up status

The former implementation/research tail is closed for the current release line:

- Butcher uses the accepted natural-language decrease statement.
- Blacksmith preserves vanilla flavor and appends the accepted concise output/quality summary.
- Super mushroom preserves vanilla flavor and appends only the red-mushroom gathering statement.
- Grape / hops growth unlocks use the accepted four-line growth presentation with four seeds, Vineyard / vine trellis, and the primary seed vendor; trade-tier/story-access detail remains excluded.
- DTT-owned copy is present for all 11 current Graveyard Keeper 1.407 locales and is mechanically validated in CI.

There is no open production item implied by this ledger. Any future wording/mechanics expansion is a new change and requires its own evidence/product gate.


## Fertilizer tooltip copy

Accepted Russian-oriented semantics for manual-plot fertilizer explanation:

- Peat / Торф:
  `Эффект на один цикл: увеличивает урожай и количество семян при сборе, сокращает время роста на 20%.`
- Boost fertilizer I:
  `Эффект на один цикл: сокращает время роста на 40%.`
- Boost fertilizer II:
  `Эффект на один цикл: сокращает время роста на 60%.`
- Quality fertilizer I:
  `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 1 единицу урожая и 1 семя на одну ступень качества выше.`
- Quality fertilizer II:
  `Эффект на один цикл: увеличивает количество урожая и семян. Дополнительно даёт 2 единицы урожая и 2 семени на одну ступень качества выше.`

The Peat line intentionally does not add a negative clause about not producing next-tier crops/seeds; the distinction is already conveyed by the Quality-fertilizer wording.
