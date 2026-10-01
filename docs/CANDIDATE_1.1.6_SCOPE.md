# Candidate 1.1.6 scope — deterministic complete blueprint locations

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

Status before production-source mutation: **READY** for location behavior; **BLOCKED / deferred** for whole ingredient-name + quantity no-break behavior.

## Runtime result carried forward

The handed 1.1.5 candidate initialized successfully and reached `DTT_READY`. User runtime review confirmed:
- the Alchemy Lab location wording still renders correctly;
- Vine press lists both Yard and Cellar;
- the audited Yard/Quarry multi-builder blueprints render their additional location correctly;
- the expanded Trunk location row renders all currently admitted locations and remains readable.

## Change A — deterministic complete blueprint locations

### Observable property

For every visible Technology blueprint, `Build menu / Строительство` lists the complete set of native builder locations found anywhere in current 1.407 `GameBalance.craft_obj_data` for the same `out_obj` and `build_type`, independent of the current save/progression state.

### Canonical owner

`ObjectCraftDefinition.out_obj`, `build_type`, and `builder_ids` across the full native `GameBalance.craft_obj_data` population.

The accepted full runtime audit proved:
- 105 visible Technology blueprints, 0 unresolved;
- five same-Technology multi-builder groups;
- only three additional same-output/build-type groups outside the owning Technology.

### Final writer / consumer / commit point

`GameApi.BuildBlueprintLocationIds -> GameApi.BuildLocationRow -> TechUnlock.GetTooltip`.

### Blast radius

Blueprint location rows only. Ordinary recipe station rows are untouched.

The behavior change versus 1.1.5 is limited to outside-Technology same-output aliases that were previously admitted only when `GameSave.IsCraftVisible` returned true. Their locations now display immediately and deterministically.

### Preserved invariants

- visible blueprint requirements still come only from the visible authored blueprint;
- authored hidden `@` unlocks are not rendered as separate Technology entries;
- no Technology/craft/build/save/progression state is modified;
- no `sub_zone_id` guessing;
- no manual station table;
- native builder localization remains authoritative, with only the already accepted exact Alchemy Lab display override;
- list order is native `craft_obj_data` first-seen order with duplicate builder IDs removed.

### Acceptance evidence

Automated:
- exact source compiles with 0 warnings / 0 errors;
- existing 11-language formatting/localization suite remains green.

Runtime:
- Vine press remains Yard + Cellar;
- Yard/Quarry duplicates remain correct;
- Trunk shows the complete seven-location list regardless of current save state;
- separately gated same-output cases may now name their additional native builder immediately, by explicit product decision;
- ordinary single-location blueprints and recipe station rows remain unchanged;
- no DTT failure marker.

Gate state: **READY**.

## Change B — keep entire localized ingredient name attached to `(xN)`

User-visible issue: NGUI can wrap an intact quantity token onto a line by itself.

The existing DTT repair is deliberately narrow: it only repairs a line break *inside* the native `(xN)` token.

Candidate mechanisms for keeping the entire localized item name + quantity atomic:
- Unicode NBSP/word-joiner: rejected for now because exact font/wrap support is not proven and a prior unsupported-glyph regression makes this a real compatibility risk;
- processed-text parsing and forced rewrap of the entire ingredient segment: deferred because it adds locale-sensitive wrap heuristics beyond the current proven repair;
- separate UI rows/chunks per ingredient: rejected because it materially changes tooltip density/layout.

Given the user's explicit preference to leave this cosmetic issue unchanged rather than add fragile code, production behavior remains unchanged in 1.1.6.

Gate state: **BLOCKED / DEFERRED — NO PRODUCTION MUTATION**.
