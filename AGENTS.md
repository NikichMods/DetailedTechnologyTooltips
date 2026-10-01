# Project Working Contract

This repository follows the canonical global development rules in `NikichMods/DevRules`.

Before substantive technical work, read:
- `ENGINEERING_RULES.md`
- `CI_POLICY.md`
- `GIT_WORKFLOW.md`
- `PROJECT_BOOTSTRAP.md`
- `RUNTIME_TEST_HARNESS.md` when installed-runtime evidence is relevant
- `LICENSE_POLICY.md`, `CHATGPT_PROJECT_SETUP.md`, and `NEXUS_SUPPORT_WORKFLOW.md` when their subject is relevant

This file contains only project-specific additions, constraints, verified facts, and explicit exceptions.

## Project identity

- Project name: **Detailed Technology Tooltips**
- Repository: `NikichMods/DetailedTechnologyTooltips`
- Target/runtime: **Graveyard Keeper 1.407**, Windows PC, BepInEx 5
- Intended installable DLL: `DetailedTechnologyTooltips.dll`
- Purpose: make Technology-tree unlock tooltips explain concretely what a visible technology unlock gives, what materials it requires when applicable, and where the exact recipe/build option belongs, without changing progression or gameplay.

## Scope

This is a vanilla-friendly informational UI mod.

Product scope / accepted evolution:
- enrich authored-visible Technology **blueprint** unlocks with native build requirements and the owning build desk/menu;
- enrich authored-visible Technology **ordinary recipe** unlocks with native ingredient requirements and the exact recipe station(s);
- preserve useful vanilla title/description information;
- keep Work and Perk vanilla by default, with only separately evidenced and accepted enrichments/corrections;
- for blueprint location rows, list every native builder for the same `out_obj` / `build_type` in the current 1.407 balance, even when a named builder is not yet available in the current save. This is a location-name-only exception: do not render hidden Technology/craft unlock rows or infer their story owner.

Out of scope by default:
- technology prices or progression changes;
- automatic unlocks or save mutation;
- hidden/invisible `@` unlock disclosure;
- guessed recursive dependency graphs such as "requires technology X";
- `sub_zone_id` presented as a player-facing location;
- a separate encyclopedia/details screen;
- hand-maintained station/localization tables when native data is sufficient.

## Mandatory project-specific start-of-work checks

Before substantive implementation:
1. inspect current repository state and this file;
2. inspect `docs/VERIFIED_GAME_DATA.md` and relevant local history/test evidence;
3. inspect the shared Graveyard Keeper research source below;
4. verify the exact owner/final-writer/blast-radius path for each proposed production behavior;
5. keep research/probes separate from production.

Repository evidence and accepted runtime evidence outrank chat memory.

## Shared Graveyard Keeper research

Cross-project Graveyard Keeper 1.407 research is centralized in `NikichMods/GraveyardKeeperResearch`.

Before fresh host-internals research:
1. read this project's canonical docs;
2. read `NikichMods/GraveyardKeeperResearch/docs/RESEARCH_INDEX.md`;
3. follow the linked Technology/crafting/UI research, especially `docs/TECH_TREE_INFORMATION_RESEARCH.md` and `docs/CRAFTING_INVENTORY_AND_TRADING.md`;
4. inspect accepted local/shared evidence before creating a new probe.

Promote reusable host/runtime findings back to the shared research repository. Keep project-specific UX, implementation, candidate and release evidence here.

## Project-specific evidence contract

Accepted shared research already establishes:
- `TechUnlock.GetTooltip` as the semantic detail path used by Technology unlock presentation;
- mouse unlock tooltips and the combined gamepad Technology tooltip consume the same unlock-detail semantics;
- visible recipe/blueprint data ownership in `CraftDefinition` / `ObjectCraftDefinition`;
- native build-menu ownership through `builder_ids`;
- exact recipe station ownership through `CraftDefinition.craft_in`;
- host localization of relevant `ObjectDefinition.id` values through `GJL.L(id)`;
- the current Technology tooltip width/wrap lifecycle for the inspected 1.407 UI family.

Do not generalize these facts beyond their recorded applicability limits.

The initial production implementation is already accepted. For every future materially independent production behavior change, create the normal reviewable DevRules READY/BLOCKED gate before its first source mutation. Accepted existing behavior is not blanket permission to broaden scope.

## Architecture / runtime constraints

Prefer:
- the narrowest verified Technology tooltip seam;
- on-demand composition when a tooltip is requested;
- native `CraftDefinition`, `ObjectCraftDefinition`, `ObjectDefinition`, and localization data;
- fail-closed handling when authored data is absent or special.

Avoid:
- per-frame scanning or polling;
- mutating balance definitions merely for presentation;
- parallel recipe/build databases;
- parsing localized display strings to recover semantic IDs already present natively;
- exposing hidden Technology/craft unlock rows or inferred story ownership. Accepted exception: a blueprint location row may name any native builder proved for the same `out_obj` / `build_type`, even before that builder is available in the current save.

For a blueprint, `builder_ids` answers build-menu ownership; `sub_zone_id` is a placement restriction and is not a substitute player-facing area label.

For an ordinary Technology recipe, use that recipe's own `craft_in` when the UI claims where **that unlock** is crafted. Do not silently substitute the broader output-item `GetItemCraftsIn(...)` aggregate.

## User-facing behavior requirements

The mod must add useful decision-time information without turning Technology tooltips into a wiki dump.

By default preserve:
- technology/unlock visibility;
- technology cost and availability;
- recipe/build availability and mechanics;
- vanilla ordering of visible unlocks;
- active-language native names;
- unrelated tooltip content;
- mouse/gamepad information equivalence.

Exact wording, punctuation, icon use, row composition, and density are product/UX decisions to be accepted against representative real-game tooltips.

## Git / version / acceptance workflow

- `main` is the stable/documentation baseline.
- Research-only work uses `research/<topic>`.
- Build-bearing production work uses `dev/<version>` or a semantic feature branch.
- Research-only work does not consume numbered test/release versions.
- Runtime behavior reaches `main` only after exact candidate/runtime evidence and explicit user acceptance.
- Numbered handed artifacts are immutable.
- Stable public distribution uses GitHub Releases unless deliberately changed.
- Handoff filenames use ASCII hyphens and no spaces; installed DLL remains `DetailedTechnologyTooltips.dll`.

## Licensing

Original project software source uses MPL-2.0 under the global `LICENSE_POLICY.md`. See `LICENSE` and `LICENSING.md`.

Do not commit Graveyard Keeper assemblies, bulk decompiled source, extracted proprietary assets, or full `game_data` dumps. Persist distilled derived facts, identifiers, hashes, bounded evidence, and original project/research tooling only.

## CI / build specifics

This is a public repository. Standard GitHub-hosted runner minutes are not scarce. Use hosted CI when compilation, tests, reproducible artifacts, or research builds are useful.

Do not establish a compiler/package contract by assumption. When production source is introduced, derive the build setup from verified compatible NikichMods Graveyard Keeper/BepInEx practice and the actual source requirements.

## Long-lived sources of truth

- `AGENTS.md`
- `docs/VERIFIED_GAME_DATA.md`
- `docs/CHATGPT_PROJECT_INSTRUCTIONS.md`
- `docs/TEST_BUILD_LOG.md` once numbered handoff builds exist
- `README.md`
- `CHANGELOG.md` once user-facing versions exist

Mutable candidate state belongs in repository docs/history, not ChatGPT Project Instructions.
