# Release Checklist — 1.0.2

Stable publication is blocked until the exact 1.0.2 candidate is runtime-accepted.

## Release-candidate preparation

- [x] 0.1.2 accepted as the gameplay/UI baseline.
- [x] Rejected 1.0.0 and 1.0.1 candidates recorded as immutable test evidence.
- [x] Latin/Korean list spacing accepted in runtime.
- [x] Quantity-token repair accepted in Simplified Chinese runtime.
- [x] Better Save Soul Remote Control explanation accepted in Russian and English.
- [x] Japanese line-start separator defect isolated to DTT CJK list composition.
- [x] CJK separator now carries an invisible post-separator break opportunity without visible Western spacing.
- [x] README, changelog and release notes updated for 1.0.2.
- [ ] Final 1.0.2 candidate CI succeeds with zero build warnings/errors and all localization/formatting tests.
- [ ] Exact source SHA, run, artifact and DLL SHA recorded.
- [ ] Exact 1.0.2 DLL handed to the user.
- [ ] Real-game 1.0.2 CJK smoke test accepted.

## Required runtime acceptance

Only the last CJK typography property needs focused testing:

1. Japanese: revisit the representative requirements list and confirm no wrapped line begins with `、`.
2. Simplified Chinese: one quick sanity check that there is still no visible Western spacing and `(xN)` tokens remain intact.
3. Return the support log; expected marker is `DTT_READY version=1.0.2` with no DTT disable/failure event.

Everything else is already accepted evidence and should not be repeated.

## Stable promotion — BLOCKED until runtime acceptance

After explicit user acceptance:
- [ ] record the exact accepted 1.0.2 identity;
- [ ] create accepted-release metadata for that exact artifact;
- [ ] promote accepted source/docs to `main`;
- [ ] publish GitHub Release `v1.0.2` from the exact accepted CI artifact;
- [ ] verify release asset filename/hash;
- [ ] complete Nexus publication/support setup separately.
