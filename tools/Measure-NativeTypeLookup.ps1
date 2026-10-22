# SPDX-License-Identifier: MPL-2.0
# Desktop CLR microbenchmark, not a game-Mono branch-time measurement.
param([Parameter(Mandatory=$true)][string]$GameRoot, [ValidateRange(1,500)][int]$Iterations=50)
$ErrorActionPreference='Stop'
$game=(Resolve-Path -LiteralPath $GameRoot).Path
foreach($p in Get-ChildItem "$game\Graveyard Keeper_Data\Managed" -Filter '*.dll') {
 try { [Reflection.Assembly]::LoadFrom($p.FullName) | Out-Null } catch {}
}
$harmony=[Reflection.Assembly]::LoadFrom("$game\BepInEx\core\0Harmony.dll")
$method=$harmony.GetType('HarmonyLib.AccessTools').GetMethod('TypeByName')
$expected=$method.Invoke($null,@('BubbleWidgetTextData'))
if($expected -eq $null) { throw 'Native type lookup failed' }

$timer=[Diagnostics.Stopwatch]::StartNew()
for($i=0;$i -lt $iterations;$i++) {
 $found=$method.Invoke($null,@('BubbleWidgetTextData'))
 if($found -ne $expected) { throw 'Inconsistent native type result' }
}
$timer.Stop(); $lookup=$timer.Elapsed.TotalMilliseconds
$timer.Restart()
for($i=0;$i -lt $iterations;$i++) { $found=$expected; if($found -ne $expected) { throw 'Cached type differs' } }
$timer.Stop()
[pscustomobject]@{runtime=[System.Runtime.InteropServices.RuntimeInformation]::FrameworkDescription; assemblies=[AppDomain]::CurrentDomain.GetAssemblies().Count; iterations=$iterations; searchMs=[math]::Round($lookup,3); cachedMs=[math]::Round($timer.Elapsed.TotalMilliseconds,3); type=$expected.FullName} | ConvertTo-Json

