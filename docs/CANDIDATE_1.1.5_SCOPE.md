# Candidate 1.1.5 scope — startup binding regression fix

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

Status before production-source mutation: **READY**.

## Trigger

Runtime test of the handed 1.1.4 candidate failed during DTT initialization with:

`DTT_INIT_FAILED fallback=vanilla reason=MissingFieldException: Field 'MainGame.me' not found.`

The game itself continued running because DTT correctly fell back to vanilla.

## Root cause

1.1.4 introduced a new reflection binding for static field `MainGame.me`.
The existing helper `RequireField(Type,string)` intentionally searches instance fields only (`AllInstance`), so using it for `MainGame.me` can never succeed.

Static source confirms `MainGame.me` is a public static field. The failure therefore occurs before any 1.1.4 tooltip behavior executes.

## Production evidence gate

**Observable property**

DTT 1.1.5 initializes successfully on Graveyard Keeper 1.407 and reaches `DTT_READY`, while preserving the 1.1.4 multi-builder behavior unchanged.

**Canonical owner**

`GameApi.Bind()` reflection binding for `MainGame.me`.

**Final writer / consumer / commit point**

The binding is consumed by `IsCraftVisibleNow` only when resolving independently available same-output blueprint aliases.

**Blast radius**

Startup binding only. No tooltip wording, aggregation policy, gameplay data, saves, progression or existing reflection helpers change.

**Preserved invariants**

- keep `RequireField` instance-only so all previous instance bindings remain unchanged;
- bind only `MainGame.me` with `AllStatic`;
- preserve all 1.1.4 same-Technology and native-visibility semantics;
- preserve fail-closed behavior if native visibility lookup itself cannot run.

**Acceptance evidence**

- exact source compiles with 0 errors/warnings;
- existing localization/formatting suite remains green;
- runtime log contains `DTT_READY version=1.1.5` and no `DTT_INIT_FAILED`;
- then perform the already-requested 1.1.4 focused location checks.

Gate state: **READY**.
