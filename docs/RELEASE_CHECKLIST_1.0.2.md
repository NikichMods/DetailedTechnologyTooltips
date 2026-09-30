# Release Checklist — 1.0.2

The exact 1.0.2 candidate was runtime-accepted and published as the first stable release.

## Release-candidate preparation

- [x] 0.1.2 accepted as the gameplay/UI baseline.
- [x] Rejected 1.0.0 and 1.0.1 candidates recorded as immutable test evidence.
- [x] Latin/Korean list spacing accepted in runtime.
- [x] Quantity-token repair accepted in Simplified Chinese runtime.
- [x] Better Save Soul Remote Control explanation accepted in Russian and English.
- [x] Japanese line-start separator defect isolated to DTT CJK list composition.
- [x] CJK separator now carries an invisible post-separator break opportunity without visible Western spacing.
- [x] README, changelog and release notes updated for 1.0.2.
- [x] Final 1.0.2 candidate CI succeeds with zero build warnings/errors and all localization/formatting tests.
- [x] Exact source SHA, run, artifact and DLL SHA recorded.
- [x] Exact 1.0.2 DLL handed to the user.
- [x] Real-game 1.0.2 CJK smoke test accepted.

## Runtime acceptance — COMPLETE

The focused 1.0.2 runtime pass is accepted:

- Japanese wrapped lists no longer begin a line with `、`;
- Simplified Chinese keeps native-looking CJK spacing and intact `(xN)` quantity tokens;
- the support log contains `DTT_READY version=1.0.2` and no DTT initialization/runtime/viewport/wrap-repair disable marker.

No further 1.0.2 runtime repetition is required.

## Stable promotion — COMPLETE

After explicit user acceptance:
- [x] record the exact accepted 1.0.2 identity;
- [x] create accepted-release metadata for that exact artifact;
- [x] promote accepted source/docs to `main`;
- [x] publish GitHub Release `v1.0.2` from the exact accepted CI artifact;
- [x] verify release asset filename/hash;
- [ ] complete Nexus publication/support setup separately.
