# 1.0.2 Candidate Scope

Baseline:
- gameplay/UI baseline: runtime-accepted 0.1.2;
- 1.0.0 and 1.0.1 were handed test candidates and remain immutable;
- 1.0.1 passed all focused release checks except one Japanese line-start separator defect.

## Gate A — CJK separator break opportunity

- Observable property: a DTT-generated Japanese/Simplified-Chinese list never begins a visual line with its native separator.
- Canonical owner: DTT list composition; the visible punctuation glyph still comes from `GJL.L(",")`.
- Final consumer: native NGUI wrapping in `BubbleWidgetText -> UILabel`.
- Mechanism: append a zero-width break opportunity after the native CJK separator so wrapping can occur after, rather than before, the separator without adding a visible Western space.
- Blast radius: DTT-generated lists for `ja` and `zh_cn` only.
- Preserved invariants:
  - no visible extra whitespace is added to CJK text;
  - item/station names, order and quantities stay native;
  - Latin/Korean separator behavior remains the accepted 1.0.1 behavior;
  - quantity-token repair remains unchanged;
  - tooltip width/position and unrelated labels are untouched.
- Acceptance evidence:
  - mechanical formatter test proves the invisible break opportunity is present only for the two CJK locales;
  - runtime reproduction of the Japanese `鉄インゴット (x2)、鋼鉄インゴット...` case shows no line starting with `、`;
  - quick Simplified-Chinese sanity check confirms no new visible spacing or quantity-token regression.
- Gate state: **READY**.

No other player-facing behavior change belongs in 1.0.2.

The fertilizer/seed-quality semantic expansion remains separately BLOCKED pending exact native-data evidence.
