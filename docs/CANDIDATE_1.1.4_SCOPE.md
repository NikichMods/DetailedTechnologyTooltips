# Candidate 1.1.4 scope — multi-builder blueprint locations

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

Status before production-source mutation: **READY**.

## Runtime audit result

Read-only audit `DTTBlueprintLocationAudit 0.1.0` ran successfully against the current game balance:
- Technology definitions: 187;
- object-craft definitions: 533;
- visible Technology blueprints: 105;
- unresolved visible blueprints: 0;
- same-Technology same-output multi-builder groups: 5;
- global same-output extra-builder groups: 3.

Same-Technology groups:
1. `The idea of the stone`
   - visible: `mf_wood_builddesk:p:mf_stones_1_place`
   - builders unlocked by that Technology: `mf_wood_builddesk`, `mining_builddesk`.
2. `Stone processing`
   - visible: `mf_wood_builddesk:p:mf_hammer_0_place`
   - builders unlocked by that Technology: `mf_wood_builddesk`, `mining_builddesk`.
3. `Mining`
   - visible: `mf_wood_builddesk:p:mf_ore_1_complete`
   - builders unlocked by that Technology: `mf_wood_builddesk`, `mining_builddesk`.
4. `Improvement`
   - visible: `garden_builddesk:p:mf_box_stuff_place`
   - builders unlocked by that Technology: `garden_builddesk`, `mining_builddesk`, `vineyard_builddesk`, `graveyard_builddesk`, `cremation_builddesk`.
5. `Winemaking`
   - visible: `mf_wood_builddesk:p:mf_vine_press_place`
   - builders unlocked by that Technology: `mf_wood_builddesk`, `cellar_builddesk`.

Global extra groups:
- trunk output also has always-visible definitions at `cellar_builddesk` and `mf_wood_builddesk`;
- pallet/corpse-bed output also has `souls_builddesk:p:corpse_bed_place`, which is separately lock-controlled;
- porter station output also has `vineyard_builddesk:p:porter_station`, which is separately lock-controlled.

Static host evidence establishes:
- leading `@` on `TechDefinition.crafts` hides only the Technology unlock icon;
- `GameSave.UnlockTech` / `CopyLists` still unlocks those craft IDs;
- build menus enumerate `GameBalance.craft_obj_data` by `builder_ids` and `GameSave.IsCraftVisible`.

## Production evidence gate

**Observable property**

A visible Technology blueprint's `Строительство / Build menu` row lists every builder location that is either:
1. unlocked by that same Technology for the same `out_obj` and `build_type`, including authored `@`-hidden sibling blueprint entries; or
2. already independently visible/unlocked in the current save for that same `out_obj` and `build_type`.

**Canonical owner**

- same-Technology future availability: `TechDefinition.crafts` + resolved `ObjectCraftDefinition.out_obj/build_type/builder_ids`;
- independently available variants: `GameBalance.craft_obj_data` + native `GameSave.IsCraftVisible(ObjectCraftDefinition)`;
- player-facing names: native ObjectDefinition localization, retaining only the already accepted exact `alchemy_builddesk -> Alchemy Lab` DTT presentation override.

**Final writer / consumer / commit point**

- DTT `GameApi.BuildLocationRow` composes the final blueprint location row immediately before `TechUnlock.GetTooltip` output is appended.

**Blast radius**

- blueprint location rows only;
- no ordinary recipe station behavior changes;
- no unlock ordering/icon changes;
- no gameplay data mutation.

**Preserved invariants**

- visible blueprint requirements remain those of the visible authored blueprint;
- `@`-hidden sibling blueprints are never rendered as separate unlock rows;
- independently locked/story-gated variants are not disclosed before native `IsCraftVisible` says they are available;
- no `sub_zone_id` guessing;
- no manual station/location table;
- existing Alchemy Lab naming exception remains exact and narrow;
- Technology progression, craft/build state, recipes, saves and balance are untouched.

**Acceptance evidence**

Automated/build:
- exact source compiles with 0 errors/warnings;
- existing localization/formatting suite remains green.

Runtime:
- Vine press shows both Yard and Cellar;
- at least one wood/mining duplicate (Stone stockpile, Stone cutter I, or Iron ore stockpile) shows both corresponding build menus;
- Trunk lists its same-Technology locations plus independently native-visible locations without duplicate names;
- no new DTT failure marker;
- ordinary recipe location rows remain unchanged.

Gate state: **READY**.
