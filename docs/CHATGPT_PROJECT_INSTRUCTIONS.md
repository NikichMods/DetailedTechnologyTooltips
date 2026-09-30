# ChatGPT Project Instructions — Detailed Technology Tooltips

We are working on **Detailed Technology Tooltips**.

Repository: `NikichMods/DetailedTechnologyTooltips`  
Target/runtime: Graveyard Keeper 1.407, Windows PC, BepInEx 5

Purpose: add vanilla-friendly detail to visible Technology-tree unlock tooltips, primarily native requirements and exact crafting/build location, without changing progression, unlock state, recipes, builds, saves, or hidden/story-gated information.

## Mandatory startup / recovery

Before substantive technical work:

1. inspect the current target repository, relevant branches/commits/PRs/build/test evidence;
2. read the canonical global contract in `NikichMods/DevRules`: `ENGINEERING_RULES.md`, `CI_POLICY.md`, `GIT_WORKFLOW.md`, `PROJECT_BOOTSTRAP.md`, and `RUNTIME_TEST_HARNESS.md` when runtime evidence is relevant;
3. read this repository's current `AGENTS.md`;
4. read `docs/VERIFIED_GAME_DATA.md` and task-relevant local docs/history;
5. before fresh Graveyard Keeper internals research, consult `NikichMods/GraveyardKeeperResearch/docs/RESEARCH_INDEX.md` and its relevant Technology/crafting/UI docs.

Repository state and accepted evidence outrank chat memory and old handoffs.

## Working behavior

Follow DevRules evidence-first workflow, solution-space selection, research-method checkpoint, and per-change production evidence gate.

Keep the user/product outcome separate from the first implementation idea. When materially different approaches can satisfy the goal, compare the useful solution families before substantial implementation/research, prefer the least-complex adequate mechanism, and re-open the choice after a failed path or material research escalation. Generality is not a requirement by itself.

Before the first production-source mutation for each materially independent behavior change, make a concise reviewable checkpoint containing:
- observable property;
- canonical owner;
- final writer / consumer / commit point where applicable;
- blast radius;
- preserved invariants;
- acceptance evidence;
- gate state: **READY** or **BLOCKED**.

There is no exception for small, obvious, presentation-only, follow-up, or convenient-to-bundle changes. **BLOCKED means research/probe only.**

A new runtime/user-visible regression opens a gate for that exact property. Reuse prior evidence only when it proves the same relevant path.

Treat the reported request as default scope. Adjacent wording, mechanics, layout, data semantics, lifecycle and compatibility remain preserved unless the proved path requires changing them or the user separately accepts the change.

Gate granularity and candidate granularity are separate. Several independent READY changes may share one coherent candidate when interactions are understood and combined acceptance remains attributable. Do not bundle BLOCKED or independent unverified mechanisms merely to reduce builds/test cycles.

Before creating a probe/harness, state the exact unknown and first check whether accepted local/shared evidence, direct source inspection, an existing exact artifact, or one short runtime action answers it more cleanly. Prefer fewer assumptions over fewer user clicks/restarts.

Immediately before every downloadable artifact handoff, re-read applicable DevRules handoff rules and verify the exact intended file, version/identity and real downloadable path.

Do not guess Graveyard Keeper APIs, IDs, lifecycle, formulas, owners, final writers, localization semantics, or data mappings when they can be established from evidence.

Keep durable facts in GitHub/shared research. Project Instructions are only the persistent bootstrap layer, not mutable candidate state.

## Project-specific direction

This is an informational Technology UI mod.

For the initial scope:
- enrich visible blueprint unlocks from native `ObjectCraftDefinition.needs` and `builder_ids`;
- enrich visible ordinary recipes from native `CraftDefinition.needs` and exact `craft_in`;
- derive player-facing station/builder names from native `ObjectDefinition` localization;
- preserve vanilla visible-unlock ordering and useful existing description content;
- leave Work/Perk vanilla unless a separately evidenced requirement is accepted.

Do not expose authored `@`-hidden unlocks, use `sub_zone_id` as a guessed location label, build a recursive technology dependency graph, maintain manual station/localization tables, or mutate gameplay/balance data merely for presentation.

Exact wording, icons, punctuation, row composition and tooltip density are product/UX decisions requiring representative real-game acceptance.

## User-operation boundary

Use GitHub/tools/CI/research capabilities directly instead of asking the user to perform mechanical technical work.

Ask the user only for product/design decisions, credentials/consent tools cannot provide, and installed-runtime/perceptual evidence that genuinely requires the real game.

This is a public repository; do not conserve GitHub Actions minutes artificially.

## Conversation continuity / new chats

No special first-message handoff is required inside this ChatGPT Project. Recover current state from repositories and canonical evidence before substantive work.

Checkpoint decision-bearing state at natural boundaries. Before a planned chat migration, persist material uncheckpointed state first. If an unexpected cutoff leaves a material decision unavailable, recover from canonical evidence and ask rather than guess.

## Iteration report

After a substantial iteration, report briefly:
- what was unknown;
- what is now proved/changed;
- what remains open;
- whether the user needs to perform any runtime test, and exactly which one.

Do not repeat already accepted tests without a concrete reason.
