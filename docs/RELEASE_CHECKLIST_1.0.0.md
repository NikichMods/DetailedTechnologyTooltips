# Release Checklist — 1.0.0

Stable publication is blocked until the exact 1.0.0 candidate is runtime-accepted.

## Release-candidate preparation

- [x] 0.1.2 accepted as the behavior baseline.
- [x] Current Graveyard Keeper 1.407 language set verified from runtime evidence.
- [x] DTT-authored text localized for all current game languages.
- [x] Native item/station/build-desk names remain game-owned.
- [x] Unknown language codes fail closed.
- [x] `p_t_old_books` remains untouched because its native consumer is unresolved.
- [x] 1.0.0 version metadata prepared.
- [x] README, changelog and release notes prepared.
- [x] MPL-2.0 repository/license scope rechecked.
- [x] Exact accepted-artifact publication workflow prepared without enabling publication.
- [ ] Candidate CI succeeds in Release with localization completeness validation.
- [ ] Exact candidate source SHA, workflow run, artifact and DLL SHA recorded.
- [ ] Exact candidate DLL handed to the user.
- [ ] Real-game 1.0.0 release-candidate acceptance completed.

## Required runtime acceptance for 1.0.0

The accepted 0.1.2 mechanics do not need a full repeat. The new behavior is localization coverage.

1. Start the exact 1.0.0 candidate and confirm normal DTT startup with no DTT failure/disable line.
2. Cycle through all 11 game languages once while the Technology screen is available.
3. Inspect a representative ordinary recipe, blueprint, sparse Work/Perk explanation and Pyrite note.
4. Include at least one Latin non-English language and one CJK language in the visual check.
5. Confirm no conspicuous clipping, font or fallback-English issue caused by DTT.
6. Return the complete BepInEx LogOutput.log.

Already accepted and not required to repeat exhaustively:
- recipe/blueprint data ownership and exact locations;
- multi-quality/group requirements;
- centered Craft rows;
- sparse Russian/English Work/Perk behavior;
- Pyrite semantics;
- general mouse/gamepad viewport clamping;
- PrayerClarity compatibility baseline.

## Stable promotion — BLOCKED until runtime acceptance

After explicit user acceptance:

- [ ] Record exact accepted 1.0.0 identity in `docs/TEST_BUILD_LOG.md`.
- [ ] Record the exact accepted source SHA, run ID, artifact name and DLL SHA-256 for publication.
- [ ] Promote accepted source/docs to `main` without changing accepted production bytes.
- [ ] Publish GitHub Release `v1.0.0` from the exact accepted CI artifact.
- [ ] Verify release asset filename and hash.
- [ ] Mark CHANGELOG 1.0.0 as released.
- [ ] Complete Nexus publication/support setup separately using the canonical DevRules support workflow and manual Nexus-side steps.
