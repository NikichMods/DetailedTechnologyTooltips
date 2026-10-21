# Purpose mechanics observer 0.1.0

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
