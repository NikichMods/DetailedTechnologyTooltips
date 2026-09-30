# 1.0.0 Release Candidate Scope

Target: Graveyard Keeper 1.407, Windows PC, BepInEx 5.

Baseline: runtime-accepted 0.1.2 candidate built from `5aaa3d4affb83d362146536f6f2056e490f3b8b3`.

## Gate A — complete current-game localization

- Observable property: every DTT-authored user-facing string is available in every language exposed by the current Graveyard Keeper 1.407 language selector.
- Verified language codes from the accepted runtime: `en`, `de`, `fr`, `pt-br`, `es`, `ru`, `it`, `pl`, `ja`, `zh_cn`, `ko`.
- Canonical language owner: `GameSettings.GetCurrentLanguage()`.
- Native-content owner: item/station names and native generic labels continue to come from `GJL` / game data.
- DTT-owned text: build-menu label, sparse Work/Perk explanations, and the Pyrite implementation-status note.
- Final consumer: the already accepted `BubbleWidgetTextData` rows in `TechUnlock.GetTooltip`.
- Blast radius: text selection only; no recipe/build/progression/save mutation and no new tooltip lifecycle patch.
- Preserved invariants:
  - accepted Russian and English wording stays unchanged;
  - exact item/station names remain native;
  - `p_t_old_books` remains intentionally untouched;
  - unsupported/unknown language codes fail closed rather than inventing a translation;
  - layout/alignment/viewport behavior remains the accepted 0.1.2 mechanism.
- Acceptance evidence:
  - mechanical localization completeness test covers every DTT key × every verified language code;
  - one runtime language-cycle sanity pass;
  - representative CJK/Latin screenshots if visual clipping or font behavior looks suspicious.
- Gate state: **READY**.

## Gate B — release preparation

Documentation/build/release plumbing only; no new player-facing mechanics.

Required before 1.0.0 handoff:
- version metadata and CI artifact identity set to `1.0.0`;
- README reflects actual implemented behavior, supported languages, install/update instructions, compatibility and non-goals;
- CHANGELOG / release notes prepared;
- exact accepted-artifact publication workflow prepared but not activated until runtime acceptance;
- licensing checked against the current MPL-2.0 policy;
- no game binaries/assets/decompiled payload committed;
- CI builds Release cleanly and runs localization completeness validation;
- candidate DLL identity/hash recorded before handoff.

No GitHub Release, tag, Nexus publication, or `main` promotion occurs before explicit runtime acceptance.
