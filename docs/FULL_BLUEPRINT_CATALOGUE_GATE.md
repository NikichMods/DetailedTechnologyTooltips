# Full blueprint catalogue candidate —1.2.7

## READY gates before source changes —2026-10-22

User explicitly authorizes full catalogue integration after adopting1.2.6 visual defaults. Observable outcome: all104 distinct authored-visible blueprint records (105 Technology references, Church workbench repeated) receive the same EN/RU purpose/material/location format. Other languages keep stable native-text behavior. Ordinary recipes, Work/Perk and prayer content remain unchanged; no carousel, progression/save changes or release promotion.

### Catalogue coverage and copy

Existing owner: GameApi.TryCreateCraftContext recognizes native ObjectCraftDefinition only after an ordinary craft lookup fails; the GetTooltip context is already scoped to authored-visible presentation. ContextPilotPurpose/Materials are consumed by AppendDetails; native GetTooltip title, existing exact needs/builders and final PilotLayout own presentation. Broaden only the authored purpose dictionary from13 to104 entries. Rename its class/file BlueprintPurposeCopy to reflect scope; keep the proven layout/calibration/icon implementation. Per-entry lookup still requires current native blueprint context and EN/RU, not a global localization change. Normalize exact craft tail and optional _place suffix only as previously proved. Direct existing auditall-purpose-private.json (105 visible references) and fresh installed balance check match every catalogue ID and tail mapping. Add bounded derived native-ID fixture105refs, original EN/RU catalogue parity tests and visibility/locale/markup checks. Public fixture contains identifiers only, not proprietary balance/assets.

Reconcile research commit31d4af54f5d3cfbeab31fc25ef63c74cc9544875 without merging observer source. PrintingII uses supported batch-flyer role; no upgrade advantage is invented. ExtractorII/III use explicit user-selected qualitative damage sentences, supported by native displayed values/wiki/user experience. Research observerIII recorded no added durability loss; II comparative consumer behavior remains unmeasured and static parameter-key mismatch unresolved. READY here accepts the deliberately chosen qualitative/UI-facing wording under that recorded product decision, without exact percentages, numerical guarantees or claiming the mechanism contradiction closed. Keep engineering dagger/evidence notes and normal visual acceptance. No diagnostic source enters this branch.

### Native existing purpose reuse

Resurrection table's native zombie_crafting_table_d exact EN/RU sentences match catalogue. When that selected blueprint/localized route is active, ask existing GJL.L(string) through GameApi.Localize for the native description, then use the same purpose renderer. Retain catalogue text only as fallback if native lookup is absent. GetTooltip native title/other useful content ownership is unchanged. Test native-key selection is exact and unrelated IDs do not acquire it.

### Empty material blocks

Fresh bounded installed balance inspection finds three visible blueprints without needs: lantern_network, lantern and empty garden bed; all other selected needs IDs have native ItemDefinitions/icons under existing path. BuildPilotMaterials returns an empty array for these non-null lists. AppendDetails must not insert a purpose→materials gap for an absent material block; put one PurposeGap before location instead. MaterialGap remains for nonempty resources. No blank resource heading or fabricated cost row. F2 defaults stay20/0/5/100, centers title/purpose/location, left materials, gaps2/6/6/10.

### Acceptance and boundaries

Local native-reference Release and hosted CI validate exact source/version,104 dictionary rows, lossless EN/RU catalogue parity,105 fixture references/native tail mapping, unknown/prayer/other-language fallback, sparse accents and existing formatting/width/pivot policies. No new game probe needed for an editorial dictionary expansion. Runtime acceptance remains focused human review: a no-material blueprint, long-material upgraded station, graveyard/church furnishings, zombie/soul unlocks and mixed PrayerClarity Technology on mouse/controller. Native costs/names/icons remain data-driven; no broad visual acceptance inferred from unit tests. Freeze1.2.7 with source/hash; retain1.2.6 rollback. Leave F2 for this test candidate; release removal is later.
Bounded static density audit: maximum selected blueprint material rows per single unlock is3; maximum combined count is9 in The Beginning Of Alchemy (3blueprints), followed by Stone praying stand7 (3), Writer inspiration/Transplanting/Winemaking6 (2). This helps choose representative runtime cases, but does not prove rendered height or viewport fit for every text/language.
