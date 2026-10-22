# Prerelease candidate1.2.11 — fixed appearance, no calibration UI

## READY before source mutation —2026-10-22

User accepts1.2.10 visual/multilingual presentation and authorizes a prerelease: remove temporary F2, preserve chosen appearance, update documentation, then a short final runtime review. User subsequently explicitly selects prepare only while the game runs. Do not install, publish or promote to main.

Observable change: DTT no longer registers a frame Update/OnGUI callback or consumes F2, and ships no settings window/sliders. The same rendering defaults remain fixed: icons20/Y0, text indent5 spaces, opacity100, title/purpose/location centered and materials left, gaps2/6/6/10. No purpose/translation/material/station/navigation/visibility changes.

Owner/final consumer: Plugin.Update/OnGUI currently forwards to PilotCalibration; its same class also owns essential marked-row alpha/quantity indentation in BubbleWidgetText.Draw prefix and PilotLayout.Drawn in postfix. Deleting the entire class or merely unpatching it would regress layout. Retain this verified marked-row renderer as TooltipAppearance with immutable defaults; remove all IMGUI/input/window/reset/export paths and obsolete plugin callbacks, preserving Draw/Mark/MarkNativeBody/Center/Gap behavior and native final PilotLayout.UpdateSize/Reposition. No new host seam/reflection is introduced; this is extraction of the already accepted renderer from the finished calibration UI.

Blast radius: all rich blueprint/nonprayer recipe rows share the helper, so preserve their exact defaults/output, native font/symbol route, alpha reset, quantity binding and native-body scope. Native prayers/PrayerClarity and unrelated inputs remain untouched; F2 becomes unconsumed by DTT. Rename module/callers/test reflection only for the retained responsibility. Keep existing material icons, copy resources and source data intact. No global balance/config/save changes.

Verification: existing11-language/catalogue/native-reference/composition/prayer/group/body tests; actual compiled DLL checks fixed fields, absence of PilotCalibration/settings/Update/OnGUI methods and absence of InputLegacyModule/IMGUIModule assembly references. Compare authored purpose/translation inputs to accepted1.2.10. Version1.2.11 identifies the final review candidate, not a stable/public release. Build locally and in CI, freeze exact source/hash, retain1.2.10 rollback. Real game later: no F2 window, same alchemy multi-unlock and church/graveyard appearance, fast branch switching and live language change. That final acceptance cannot be inferred from compilation.

## Verification before source freeze

Native-reference SDK8.0.426 Release succeeds with zero warnings/errors. Existing104 purposes/105 native references x11 locales and39 service keys/locale pass. Actual compiled DLL fixture verifies all nine embedded resources, immutable appearance defaults, no legacy calibration type/settings methods/Plugin.Update/OnGUI or InputLegacyModule/IMGUIModule references, and retained native body/recipe/prayer/group behavior. Additional actual BeforeDraw check preserves five-space material indent, full alpha and nonbreaking quantity after repeated draws. Authored BlueprintPurposeCopy and translation resources have no changes from accepted1.2.10. No Unity scene or game input tested by this fixture.

README now distinguishes public stable1.1.6 from development prerelease1.2.11, describes the accepted redesign/all-language support, fixed appearance and prayer ownership without claiming an all-edition compatibility matrix. CHANGELOG records the aggregate redesign and removal of temporary UI. User's prepare-only instruction remains active; installation/final runtime review pending.

## Frozen prerelease — not installed

Version1.2.11.0, source bb45fa2fb1f3838372a6d4584cec60e770026930, ProductVersion1.2.11+sourceSHA. Native-reference Release DLL193024 bytes, SHA256d64f928818ea8959942f3108fcfe87fe6166e165ad616ba80da27cfcc6d36943; frozen artifacts/layout-pilot/DetailedTechnologyTooltips-1.2.11.dll and BUILD_IDENTITY-1.2.11.json. Local build/actual compiled fixtures pass after source commit. CI39722582036/job119639201028 all steps successful, including source/version assertion, build,11-language tests and upload. Later documentation-only edits do not change the candidate's source or bytes.

Installed DLL remains accepted1.2.10 SHA256e2cc5608cc865a4ea32266894a480f36a538554b2f70950499ff02b3e7c6966f, verified after candidate freeze. No game/plugin/config/save write performed. User selected prepare only, so no installation or new closure request is pending. Short final runtime check after later authorized installation: F2 produces no DTT window, same combined alchemy tooltip on controller, one church/graveyard symbol, RU/EN plus one CJK live switch, prompt branch changes. No crafting or full repeat of accepted catalogue review required. Stable/main/public release remains1.1.6.
