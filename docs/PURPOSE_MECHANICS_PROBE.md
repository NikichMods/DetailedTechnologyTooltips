# Purpose mechanics observer — research log

Research only; production DTT remains1.1.6. No gameplay/save/balance mutation.

## Method checkpoint (2026-10-21)

Question: are pressII copying recipes actually visible in the loaded save, and which damage parameters reach real soul extraction at tiersII/III? Static owners and the contradictory keys are recorded in PURPOSE_MECHANICS_REVIEW.md. A screenshot cannot establish effective graph inputs, actual durability deltas or other Harmony owners. A passive observer is sufficient; synthetic stations, recipe unlocking and save edits would add assumptions and are excluded.

Scope: postfix native BaseCraftGUI.CommonOpen for actual filtered press lists; native GetCraftsForObject and IsCraftVisible read-only audit of both presses; prefix/postfix CraftComponent.ProcessFinishedCraft for original soul reference/durability; Flow_GetWGOParam.Invoke for actual graph reads; exact GenerateSoul flow callback for final soul output. All observer callbacks catch their own failures without suppressing host exceptions or changing results. Missing bindings disable that observation; no guessed target fallback.

| Scenario | Hypothesis/setup/native path | Diagnostic / acceptance | Cleanup |
| --- | --- | --- | --- |
| Open either press | Current save, real CommonOpen; query both station definitions with native visibility getter | PRESS_CANDIDATE plus PRESS_MENU actual filtered IDs. Absent copying in this save does not prove universal absence. | None |
| Open extractorII/III | Real SoulExtractorGUI.Open | Effective parameter values and actual UI chance calls; patch owners distinguish modded environment | None |
| Extract once at each tier | Fresh body with extractable soul, ordinary native craft completion and attached graph | SOUL_BEGIN, GRAPH_PARAM, SOUL_OUTPUT, SOUL_END correlated by sequence; before/after same Item identity. Missing generator/getter markers leave the consumer hypothesis unresolved. | Ordinary gameplay only |

Actions are nonpersistent observation. The player's normal crafting/extraction has its usual game effects. No input automation or repeated RNG sampling. No need to construct pressI merely for this check: both recipe populations are queried when either press opens; an actual II menu is still useful. Do not downgrade a station or grind a new save for missing tiers: report what exists first.

Installed BetterSaveSoulRebalance is a known confounder. Record plugin identities and Harmony owners; do not claim vanilla results from a modified consumer. No mod is removed automatically.

## Build and identity

Version owner: research/PurposeMechanicsProbe/PurposeMechanicsProbe.csproj; generated assembly metadata supplies BepInPlugin version. Build Release with .NET SDK8 and installed native references via GameRoot property; no proprietary payload is distributed. Exact source and DLL hash are recorded at handoff below. Runtime evidence pending.

## Current status: baseline loads;0.1.1 installed, load tracing pending

User reported a hang while loading a save after installing0.1.0. Preserved session snapshot: ignored `local/runtime-evidence/purpose-observer-0.1.0/failed-load-20261021.log`, SHA256 `122088209fcaf384c2ddf584efc92110d573fc416b99b65f729f694120f1be52`. Loader confirms observer0.1.0, matching host MVID and six installed hooks. Last lines are scene restoration (`RestoreScene`, `PrepareScene`, Queue Everything mutations and two active-object messages). No observer scenario event or exception identifying the cause is present. This establishes a failed user run, not attribution to a particular hook or another mod.

Host was already closed when inspected. Removed only the hash-verified observer DLL from plugins; retained frozen0.1.0 artifact. Other plugins and saves untouched. Next minimal discriminating check: load the same save with observer absent. Do not install a speculative replacement before that baseline result. If removal restores loading, inspect/isolate hooks and consider explicit post-load activation instead of startup-wide observation; that remains a hypothesis and method choice, not a verified fix. Original press/extractor procedure below is suspended.

User subsequently confirms the same save loads normally without the observer. Preserved baseline snapshot SHA256 `313b133db26c70b6826f8a38fa2c06662fec7a5214697529b3491624e936e1a6`, ignored `local/runtime-evidence/purpose-observer-0.1.0/baseline-load-20261021.log`; native script/NPC activity continues beyond restoration. One failed/passing pair implicates observer presence under this setup, not a particular patch or vanilla mechanics. Installed IL confirms WorldGameObjectComponentBase.get_wgo is a direct backing-field read, excluding a proposed lazy-initialization explanation at that accessor.

### Reopened method checkpoint:0.1.1

Goal: localize the loading regression before resuming mechanic observations. Alternatives: binary splitting six hooks across separate restarts; moving activation after load (may avoid but mask the cause); bounded entry/exit tracing while retaining all six startup bindings. Choose tracing first: no save changes or new native seams; it distinguishes callback entry/filter/return from a failure before reaching managed observer code. Static evidence and the two existing logs cannot identify the stuck callback. This is diagnostic localization, not a fix.

Trace limits: first128 invocations per callback, separate completion prefix/postfix/finalizer counters, monotonic invocation IDs and explicit trace-budget exhaustion. Emit bind-before/after markers and existing Harmony owners at binding. Trace no object serialization, native calls or per-frame scans. Tracer failures are contained separately. If all last observed calls return, or tracing stops at its budget, do not falsely attribute the hang to the last event. Next step then isolates the affected startup hook group.0.1.0 bytes/source remain immutable;0.1.1 is a distinct observer build.

Minimal runtime matrix: same installed mod set/save, observer0.1.1, launch/load only. Success is useful load evidence but not closure of the original defect; a hang requires inspecting paired trace events and any exception. No press/extractor gameplay yet. Observer and user gameplay must remain independent of save mutation.

Frozen0.1.1 source `fe1270d034767c8755eb5595c4b58a84d735890a`; SHA256 `5d39e3618ea848c401228d372082f0ce74dd2f6b7c3858ca79db11bfc73ac252`. Release build zero errors/warnings; clean probe inputs, generated plugin metadata0.1.1 independently checked with Cecil. Installed identical bytes as `PurposeMechanicsProbe.dll` with host closed. No mechanic fix or successful runtime loading is claimed. Requested user action: launch and load the same save once; report loaded/hung, then Codex captures the local log before another launch.

## Frozen local handoff (historical)

- Source: `e3c1b0107e8afca559eaa5f49da99227ccfe76c3`, branch `research/purpose-mechanics-probe`.
- Observer0.1.0 SHA256: `242ba9e3a3e7e6a4c238e6e39aa1d6ec8114239638fd4c3fa4087613177f0272`.
- Release build: SDK8.0.426, zero errors/warnings, installed native references; framework package from local cache. Network vulnerability lookup was unavailable in the preliminary build; final build explicitly disables that lookup, not compilation checks.
- Native Cecil inspection verifies exact five named patch signatures/parameter names plus the GenerateSoul closure/owner/output fields. Assembly/plugin version0.1.0 verified. No host mutation methods are intentionally invoked.
- Installed byte-identically as `BepInEx/plugins/PurposeMechanicsProbe.dll`, host closed at installation. Production DTT payload remains unchanged. No runtime/load success is claimed yet.
- No CI build added: the observer compiles against local proprietary host references which must not be uploaded to a public runner. Local native compilation proves the relevant ABI more directly than a stub build.

## User procedure

1. Launch normally and load the progressed save.
2. Open Printing pressII's crafting menu, then close it. No crafting is needed. If only pressI exists, open that instead and report II absent.
3. At extractorII, place a fresh corpse containing an extractable soul; open its window and complete one extraction. Repeat once at extractorIII if available. Do not use a corpse whose soul has already been extracted, or substitute a sin-shard-only action.
4. If a tier is unavailable, skip it and report which tier was used; do not downgrade, grind materials or edit saves solely for this first observation.
5. Tell Codex the actions are complete. Codex reads local `BepInEx/LogOutput.log`; no manual copying/screenshots required. Avoid another game launch before capture, since the log is replaced.

Normal gameplay actions retain their ordinary effects. The observer itself adds no saved state and requires no in-game cleanup. After evidence collection Codex removes its exact DLL while the game is closed. Vanilla-versus-BetterSaveSoulRebalance attribution remains an analysis step; any controlled comparison needs a separately prepared exact setup.
