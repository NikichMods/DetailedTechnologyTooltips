# Perk Tooltip Product Decisions

Date: 2026-10-01
Target: Graveyard Keeper 1.407
Status: product-scope checkpoint; no production implementation approved by this document alone.

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
  - current verified quality consumer is hardcover/book crafting (+★0.7), plus audited precious-material yield effects;
  - final player-facing wording remains to be selected.

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

## Open wording decisions

### Butcher / Мясник

Do not use the internal category label "basic parts" in player-facing text.

The wording should identify the affected extracted parts directly rather than requiring the player to know the game's hidden classification.

Verified baseline mechanic, ignoring the independent Clean Cut buff:
- applicable common extraction mistake chance: 25% -> 0%.

Final wording still open.

### Doctor / Доктор

Do not rely only on the term "important organs".

The wording should identify brain / heart / intestine directly and distinguish the two preparation-table contexts using native localized station names.

Verified baseline mechanic, ignoring Clean Cut:
- Preparation Place I: 50% -> 25%;
- Preparation Place II: 25% -> 0%.

Final wording still open.

### Cultist / Сектант

Problem to solve:
- vanilla says the player can see red/white skull values of body parts, but does not state the direction of those values;
- while the player is in an extraction UI, it is easy to read the displayed skulls as "what removing this part will do";
- the actual values are the part's contribution while installed in the corpse;
- extraction removes that contribution from the corpse total.

Preferred semantic:
- make explicit that displayed skulls are the part's contribution while it remains in the body;
- optionally add that removing the part removes that contribution.

Final wording still open.
