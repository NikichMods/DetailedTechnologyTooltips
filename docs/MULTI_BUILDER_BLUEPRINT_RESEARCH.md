# Multi-builder Technology blueprint research

Target: **Graveyard Keeper 1.407 (PC)**.

Status: **research in progress — production gate BLOCKED pending exact full-population audit**.

## Trigger

The accepted 1.1.3 runtime review exposed a location-coverage gap.

Representative user-observed case:
- Technology tooltip for the Vine press reports the visible blueprint's own builder, Yard;
- the same unlocked Vine press can also be built from the Cellar.

The accepted 1.1.3 Alchemy Lab / Doctor / Pyrite delta remains correct. This is an independent follow-up.

## Verified host semantics

Pinned static source:
`Kupie/GYK_DECOMP@6abf79199d92482af1c7573870dd9a20ec2270b9`.

Relevant 1.407 behavior:

1. `TechDefinition.crafts` contains the authored craft references for a Technology.
2. `TechUnlock(string id,...)` treats a leading `@` as **presentation-only invisibility**:
   - removes the leading `@` from the runtime unlock ID;
   - sets `TechUnlock.visible = false`.
3. `GameSave.UnlockTech(...)` calls `CopyLists(data.crafts, unlocked_crafts)`.
4. `GameSave.CopyLists(...)` also strips a leading `@` before writing the craft ID into `unlocked_crafts`.
5. Therefore an authored `@...` craft entry is still unlocked by the Technology; it is merely omitted from the visible Technology unlock list.
6. `MainGame.OpenBuildObjectGUI(build_desk)` enumerates **all** `GameBalance.craft_obj_data` and includes each `ObjectCraftDefinition` whose `builder_ids` contains the active build desk and whose native visibility/lock predicate passes.

Product implication:
- a visible Technology blueprint can have a hidden sibling `ObjectCraftDefinition` that builds the same `out_obj` through another builder;
- reading only the visible definition's own `builder_ids` under-reports the places unlocked by the Technology.

## Solution-space checkpoint

### A. Same-Technology same-output sibling aggregation — preferred if audit closes

For the visible blueprint:
1. identify the owning Technology;
2. inspect all authored craft references in that same Technology, including `@`-hidden references;
3. resolve only `ObjectCraftDefinition` siblings with the same `out_obj` and same `build_type`;
4. union their `builder_ids` in authored order;
5. localize builders through the existing native path, retaining only the already accepted exact `alchemy_builddesk -> Alchemy Lab` presentation exception.

Strengths:
- follows the Technology's real unlock transaction;
- includes hidden duplicate builder variants without exposing them as separate unlocks;
- does not guess from `sub_zone_id`;
- does not need a manual location table;
- avoids unrelated same-output definitions owned by other progression.

### B. Global same-`out_obj` aggregation

Scan every `ObjectCraftDefinition` with the same output object.

Risk:
- can include builders belonging to another Technology, quest, DLC/story state, or always/conditionally available definition;
- would broaden the tooltip beyond what the current Technology authoritatively unlocks.

Do not use unless the audit proves a required location exists only outside the same Technology and its ownership semantics are separately established.

### C. Manual per-object location table

Rejected by default:
- duplicates native balance data;
- is fragile across variants/locales;
- conflicts with the project's native-data-first direction.

## Exact unknown

Across the complete current 1.407 Technology and `craft_obj_data` population:

1. which **visible Technology blueprints** have same-Technology sibling `ObjectCraftDefinition` entries with the same `out_obj` / `build_type` and additional builder IDs;
2. whether any visible Technology blueprint has an additional same-output builder only in a definition **outside** that Technology.

Until both questions are answered, production behavior is **BLOCKED**.

## Audit harness

Research-only plugin:
- assembly: `DTTBlueprintLocationAudit.dll`
- plugin version: `0.1.0`
- branch: `research/multi-builder-blueprints`
- exact source: `db72056c9da3713bc4f19114c8bb627ab934cb65`
- CI run: `36861904967`
- artifact ID: `11161239871`
- DLL SHA-256: `1856d9c16ad8c8be9cab2821b3e09719d124a9291ea944381b553b04cb1f8c68`
- CI: **SUCCESS, 0 warnings / 0 errors**

The probe runs once after `MainGame.OnGameStartedPlaying` and logs:
- all visible Technology blueprint count;
- every same-Technology multi-builder group;
- every global same-output extra-builder candidate not accounted for by the same Technology;
- definition ownership and lock/visibility metadata for global extras.

It is read-only and does not mutate Technology, craft, build, save or progression data.
