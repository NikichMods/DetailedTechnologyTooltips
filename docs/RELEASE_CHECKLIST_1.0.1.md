# Release Checklist — 1.0.1

Stable publication is blocked until the exact 1.0.1 candidate is runtime-accepted.

## Release-candidate preparation

- [x] 0.1.2 accepted as the gameplay/UI baseline.
- [x] Rejected 1.0.0 candidate recorded as immutable test evidence.
- [x] Locale-aware spacing policy implemented for all current game languages.
- [x] DTT-owned `(xN)` rows use a final-native-wrap repair only when NGUI proves the token was split.
- [x] Better Save Soul Remote Control native access/receiver path proved and documented.
- [x] Fertilizer-quality semantic expansion deferred behind its own evidence gate.
- [x] DTT-authored text localized for all current game languages.
- [x] README, changelog and release notes updated for 1.0.1.
- [x] Exact accepted-artifact publication workflow made version-independent.
- [x] Final 1.0.1 candidate CI succeeds with zero build warnings/errors and all localization/formatting tests.
- [x] Exact source SHA, run, artifact and DLL SHA recorded.
- [x] Exact 1.0.1 DLL handed to the user.
- [x] Real-game 1.0.1 review completed — stable promotion rejected for remaining Japanese line-start separator.

## Required runtime acceptance

Only the new 1.0.1 properties require focused testing:

1. Italian/German/Korean DTT lists have a readable space after an ordinary comma.
2. Japanese and Simplified Chinese keep natural CJK punctuation without an inserted Western space.
3. The previously failing Simplified-Chinese long requirements row never splits inside `(xN)`.
4. Remote Control shows its new explanation naturally in Russian and at least one non-Russian language.
5. No conspicuous clipping, missing glyphs or fallback-language text appears.
6. The support log contains `DTT_READY version=1.0.1` and no DTT init/runtime/viewport/wrap-repair disable event.

Already accepted and not required to repeat exhaustively: exact recipe/blueprint data, grouped requirements, Craft-row centering, existing Work/Perk semantics, Pyrite semantics, general viewport clamping and PrayerClarity coexistence.

## Stable promotion — BLOCKED until runtime acceptance

After explicit user acceptance:
- [ ] record the exact accepted 1.0.1 identity;
- [ ] create accepted-release metadata for that exact artifact;
- [ ] promote the accepted source to `main`;
- [ ] publish GitHub Release `v1.0.1` from the exact accepted CI artifact;
- [ ] verify release asset filename/hash;
- [ ] complete Nexus publication/support setup separately.
