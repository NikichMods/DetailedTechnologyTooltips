# Detailed Technology Tooltips 1.1.6 — post-release audit

Date: 2026-10-01  
Target: Graveyard Keeper 1.407 (Steam/Windows), BepInEx 5  
Stable artifact: `v1.1.6`  
Accepted production source: `2a991fde8843c4eea1405091b6e7f9d0f201b501`  
Accepted/released DLL SHA-256: `a6cf0acf44c08c377afccfba4fcebec56c81310956b0fce324be197f71b22849`

Status: **stable runtime behavior accepted; no critical target-1.407 correctness defect found. Several documentation/process/compatibility-hardening findings remain.**

This audit is review-only. It does not approve or mutate new production behavior.

## Documentation-only cleanup follow-up

The post-release cleanup following this audit changed no production source or runtime behavior.

Resolved/reconciled:
- F2: stale pre-production/current-state wording in canonical docs was replaced with the accepted stable state and pointers to the current copy/test contracts;
- the accepted 1.407 host MVID was promoted into `docs/VERIFIED_GAME_DATA.md`;
- the 1.1.6 blueprint builder-name disclosure exception was made explicit in `AGENTS.md` and the canonical ChatGPT Project Instructions;
- Better Save Soul Rebalance local Gratitude research was promoted to `main` and closed as an intentional DTT non-goal rather than left “pending product approval”.

Still open as optional engineering hardening: F1, F3, F4 and F6. F5 remains a watch-only interoperability seam; F7/F8 are coverage/polish observations rather than release blockers. Historical research/dev refs are non-canonical evidence archives and were not rewritten.

## Evidence reviewed

- current `main` source, repository history, branches and stable release;
- local `AGENTS.md`, canonical project docs and candidate/runtime evidence;
- current DevRules contracts;
- shared Graveyard Keeper Technology/crafting/UI research;
- pinned 1.407 decompiled host source used by accepted research;
- accepted 1.1.6 runtime log and screenshots;
- accepted full Technology/object-craft audits;
- stable GitHub Release identity and publication workflow.

The accepted 1.1.6 runtime log contains the expected:
`DTT_READY version=1.1.6 contract=technology-tooltip host_mvid=6f50b8e7-156b-49ac-bbe8-7505894b2364`
and no DTT failure/disable event.

## Overall architecture assessment

The production architecture is appropriately narrow for the product:

- `TechUnlock.GetTooltip` is the verified shared semantic seam for mouse/gamepad Technology detail;
- reflection is centralized in `GameApi.Bind` rather than scattered through patches;
- recipe requirements and exact stations are read on demand from live native definitions;
- blueprint locations use live native object-craft definitions rather than a manual location database;
- temporary title/description corrections are restored in a Harmony finalizer;
- quantity-wrap and viewport fixes are separately contained optional capabilities with fail-safe fallback;
- no balance/progression/save mutation is used for presentation;
- no polling/background synchronizer or mirrored recipe database exists.

The current blueprint implementation performs a bounded scan of the 533-entry 1.407 object-craft collection only while composing blueprint tooltip data. This is preferable to introducing cache ownership/invalidation without a demonstrated performance problem and also allows live balance mutations by other mods to be observed.

## Coverage assessment

The accepted balance evidence covers the complete current Technology population:
- 187 Technologies;
- 342 authored-visible Craft unlocks: 105 blueprints + 237 ordinary recipes;
- 15 visible Work unlocks;
- 38 visible Perk unlocks;
- no serialized Phrase unlocks.

No unhandled current unlock category was found.

Generic Craft behavior covers live `needs` and exact `craft_in`; blueprint behavior covers native requirements and the complete accepted builder-location policy. The previously sparse special craft family is intentionally handled by a combination of generic exact-station information and accepted special presentation (grapes/hops, Remote Control). Work/Perk additions are curated only where mechanics were separately proved.

Known deliberate limits remain:
- whole localized ingredient name + `(xN)` is not forced to wrap atomically; only breaks inside `(xN)` are repaired;
- Better Save Soul Rebalance local Soul Gratitude is not integrated into DTT because it is an external mod-owned currency channel outside `CraftDefinition.needs`;
- 1.1.6 intentionally allows a native builder/location name to be listed before that separately gated builder is available, while still not rendering hidden Technology/craft unlock rows.

These are product decisions, not audit defects.

## Strong points against DevRules

### Data ownership

The implementation normally reads the canonical native owner directly:
- `CraftDefinition.needs`;
- `CraftDefinition.craft_in`;
- `ObjectCraftDefinition.out_obj/build_type/builder_ids`;
- native item/station/builder localization.

The exact Alchemy Lab display override is narrow, explicit and product-approved.

### Final-writer / lifecycle handling

The main semantic hook is at the verified Technology-tooltip composition seam.

Temporary `TechUnlockData` changes are restored by finalizer even when vanilla `GetTooltip` throws.

The viewport clamp runs at the host's recurring bubble-position writer and is scoped to Technology tooltip bubbles via weak markers. Host inspection confirms tooltip bubbles are cloned and destroyed on hide, so the weak bubble marker does not persist into unrelated future tooltip instances.

### Failure containment

Required binding/composition failures disable DTT for the session and fall back to vanilla behavior.

Quantity-wrap and viewport capabilities have independent fallback paths, so failure in optional presentation hardening does not disable semantic tooltip enrichment.

Runtime failure diagnostics are one-shot rather than hot-path spam.

### Release identity

Stable promotion is particularly strong:
- the tested candidate was not rebuilt for release;
- the publication workflow downloads the exact accepted Actions artifact;
- it verifies version/source/hash identity;
- release tag `v1.1.6` targets the exact accepted production source;
- published asset digest exactly equals the accepted candidate digest.

Accepted source -> current `main` contains documentation/release-metadata changes only; production source is unchanged.

### Licensing / repository hygiene

- original source is MPL-2.0 with per-source MPL notices;
- proprietary game assemblies/assets/decompiled payloads are not committed;
- GitHub Actions permissions are narrow for their jobs;
- there are no open PRs/issues at audit time;
- README installation uses the canonical stable DLL filename.

## Findings

### F1 — unverified-host compatibility state is not surfaced

Severity: **medium hardening / support gap; not a 1.407 defect**.

`GameApi.Bind` captures the host module MVID and `DTT_READY` logs it, but production does not compare it with the accepted 1.407 identity or say whether the host is verified.

DevRules now require an unverified host/build that continues best-effort to emit one clear warning. This matters especially because some DTT text is not purely structural data: fertilizer percentages, Perk numbers, Big Guy correction and Pyrite status are facts proved specifically for 1.407.

Current 1.407 behavior is correct. Future hardening should not blanket-disable on a different MVID merely for identity mismatch; the existing structural binding preflight is valuable. A future gate should decide whether an unknown structurally compatible host:
1. keeps generic data-driven recipe/blueprint enrichment best-effort;
2. emits one `DTT_UNVERIFIED_HOST` warning;
3. suppresses version-specific semantic/correction overlays unless separately verified.

The verified 1.407 MVID should also be recorded in canonical verified-data documentation, not only candidate/runtime logs.

### F2 — canonical documentation contains stale pre-production state

Severity: **medium documentation/recovery risk; no runtime impact**.

Examples on current `main`:
- `docs/VERIFIED_GAME_DATA.md` still says the first production behavior has not been mutated and contains a later statement that stable 1.0.2 remains unchanged;
- `docs/PERK_TOOLTIP_PRODUCT_DECISIONS.md` still says several already-shipped decisions await a future candidate/localization/release;
- `AGENTS.md` and `docs/CHATGPT_PROJECT_INSTRUCTIONS.md` state the broad no-hidden/story-information rule without recording the explicit 1.1.6 builder-name disclosure exception.

This can mislead a future recovery pass despite the newer `TOOLTIP_COPY_CONTRACT.md` and test log containing the accepted direction.

The Better Save Soul Rebalance Gratitude investigation is also left on a research branch as “pending product approval”, while the user has now explicitly closed that integration as a non-goal.

Recommended cleanup is documentation-only: reconcile canonical current-state docs, preserve historical candidate records as history, and record the BSSR Gratitude compatibility decision as closed/deferred rather than pending.

### F3 — version identity has multiple manual owners

Severity: **medium release-maintenance risk; released 1.1.6 identity is correct**.

The version is separately hard-coded in:
- `Plugin.PluginVersion`;
- csproj Version / AssemblyVersion / FileVersion;
- `.github/workflows/build.yml` artifact name and `BUILD_IDENTITY.txt` version.

CI does not assert these values agree.

The accepted-release publication workflow is protected by an exact DLL hash, so 1.1.6 was released correctly. However a future partial version bump could create confusing metadata or a wrongly named/identified candidate.

Prefer one canonical version source, or at minimum add a CI equality check deriving candidate naming/identity from that source.

### F4 — `main` verification currently creates alternate bytes under the same semantic version

Severity: **low-to-medium process clarity issue; stable release integrity is unaffected**.

After stable promotion, the normal build workflow ran on `main` and produced:
- artifact `DetailedTechnologyTooltips-1.1.6-9243334c...`;
- DLL SHA-256 `96314035...`.

Those bytes differ from the accepted/released 1.1.6 DLL because assembly informational source revision changed. They were never handed to the user or published, so numbered-handoff immutability was not violated.

Still, retaining another CI artifact carrying semantic version 1.1.6 after acceptance can confuse artifact discovery. Keep compile/test verification on `main`, but consider suppressing candidate artifact upload there or label main verification artifacts distinctly.

### F5 — aggregate vanilla location suppression assumes the vanilla row remains last

Severity: **low-to-medium latent mod-interoperability risk; no observed collision**.

Inside a Technology tooltip, DTT patches `ItemDefinition.GetTooltipData(..., full_detail:false)`. When an exact Technology-owned location row is ready, it removes the final vanilla item-tooltip row because pinned 1.407 source proves that vanilla appends the aggregate `crafted_at` row last.

This is correct for stock 1.407 and has been runtime-accepted alongside a large mod set.

A theoretical collision exists if another Harmony postfix appends an unrelated row to the same result before DTT's postfix executes: DTT could remove that other mod's final row instead of vanilla `crafted_at`.

Do not replace this with localized-string parsing or a broader hook speculatively. Treat it as a compatibility seam to revisit only if an actual consumer conflict appears or a separately proved narrower suppression mechanism is found.

### F6 — initialization failure containment is functionally safe but does not explicitly roll back already-installed required patches

Severity: **low hardening issue**.

If required patch installation fails after an earlier DTT patch was installed, outer initialization sets `RuntimeDisabled=true`. Existing runtime patches then become inert, so the host is functionally contained.

Current DevRules prefer removing an integration's own partially installed hooks when initialization cannot complete. A future hardening pass could call DTT's own `UnpatchSelf` in the outer initialization failure path, provided rollback behavior is separately tested.

This is not a current functional defect.

### F7 — automated tests are strong for copy/formatting but thin at host-integration boundaries

Severity: **low-to-medium test-coverage limitation**.

CI proves:
- clean compile;
- all 38 DTT keys across all 11 locales are present;
- critical accepted Russian copy;
- Pyrite/Doctor formatting constraints;
- Alchemy Lab override;
- Cultist exclusion;
- Big Guy correction fail-closed behavior;
- CJK/list separator behavior;
- quantity-token repair behavior.

CI does not directly exercise:
- reflection binding against the real 1.407 host;
- exact vanilla aggregate-row suppression;
- temporary presentation override lifecycle;
- multi-builder aggregation on host objects;
- viewport lifecycle.

Much of this is appropriately covered by accepted real-game runtime evidence rather than a fake host model. The 1.1.4 static-vs-instance reflection regression demonstrates that compile/copy tests are not a substitute for installed-runtime acceptance.

The cheapest useful automated addition is version/identity consistency checking. Do not build a large synthetic Graveyard Keeper emulator merely to increase test-count metrics.

### F8 — non-Russian localization quality is mechanically validated more strongly than it is human-validated

Severity: **low product-quality risk**.

All 11 current locales have complete DTT-owned copy and formatting validation. Native item/station names remain game-owned. Representative runtime work covered Russian heavily and English/CJK-specific formatting paths during development, but this audit found no evidence of native-speaker literary review for every DTT sentence in every supported locale.

This does not invalidate the release claim that strings exist/support the 11 locales. It limits confidence in idiomatic phrasing outside the languages actually reviewed by humans.

### F9 — historical/research branch hygiene can be tightened

Severity: **low repository hygiene**.

Numbered `dev/*` branches serve as useful frozen candidate references and need not be removed merely for tidiness.

The completed `research/multi-builder-blueprints` branch is obsolete because its reusable result has been distilled into project/shared research. The BSSR Gratitude research branch should either be updated to the now-closed non-goal state or removed after preserving the useful root-cause conclusion.

This is cleanup, not a release blocker.

## Things that should *not* be “cleaned up” merely for aesthetics

The audit does **not** recommend:
- replacing reflection with copied/decompiled host source;
- caching the full blueprint-location index without a measured need;
- splitting `GameApi` into abstractions only to reduce file size;
- adding a recursive Technology dependency graph;
- restoring save-dependent location filtering;
- adding a manual builder/station table;
- forcing BSSR Gratitude compatibility;
- forcing whole item-name + quantity no-break behavior with unproved Unicode characters;
- removing the per-frame viewport final-writer hook solely because it is per-frame; the hook is narrow, cheap and exists at the proved final position writer.

## Recommended order if a hardening/cleanup iteration is opened

1. Reconcile stale canonical docs and close the BSSR Gratitude research state. This can be documentation-only.
2. Add a single version/identity source or CI consistency assertion; prevent confusing same-version candidate artifacts on `main`.
3. Add verified/unverified host classification and one best-effort warning, with a separately decided policy for 1.407-specific semantic overlays on unknown hosts.
4. Consider explicit initialization rollback of DTT-owned Harmony patches.
5. Leave aggregate-row suppression unchanged unless a real interoperability conflict or a clearly superior proved seam appears.
6. Treat full native-speaker localization review as optional product polish, not a correctness blocker.

## Audit conclusion

For the declared target — **Graveyard Keeper 1.407, Windows PC, BepInEx 5** — the released 1.1.6 implementation is coherent, narrow, evidence-backed and correctly promoted. No critical gameplay/save/progression mutation, hidden-unlock rendering leak, artifact-identity failure, or known target-runtime regression was found.

The highest-value remaining work is **not a rewrite**. It is documentation reconciliation plus small release/compatibility hardening around version single-source-of-truth and unverified-host diagnostics.
