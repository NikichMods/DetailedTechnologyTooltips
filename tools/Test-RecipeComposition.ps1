# SPDX-License-Identifier: MPL-2.0
param([Parameter(Mandatory=$true)][string]$PluginPath, [Parameter(Mandatory=$true)][string]$GameRoot)
$ErrorActionPreference='Stop'
$game=(Resolve-Path -LiteralPath $GameRoot).Path
foreach($p in @("$game\Graveyard Keeper_Data\Managed\UnityEngine.CoreModule.dll", "$game\Graveyard Keeper_Data\Managed\UnityEngine.dll", "$game\BepInEx\core\0Harmony.dll", "$game\BepInEx\core\BepInEx.dll")) { [Reflection.Assembly]::LoadFrom($p) | Out-Null }
$assembly=[Reflection.Assembly]::LoadFrom((Resolve-Path -LiteralPath $PluginPath).Path)
$purpose=$assembly.GetType('DetailedTechnologyTooltips.BlueprintPurposeCopy',$true)
$static=[Reflection.BindingFlags]'Static,NonPublic'
$languages=$assembly.GetType('DetailedTechnologyTooltips.Localization',$true).GetField('SupportedLanguages',$static).GetValue($null)
$ids=$purpose.GetProperty('Ids',$static).GetValue($null)
$resources=@($assembly.GetManifestResourceNames() | Where-Object { $_ -like 'Dtt.BlueprintPurposes.*.txt' })
if($resources.Count -ne 9) { throw 'Translations must be embedded in the production DLL, not satellite assemblies' }
foreach($language in $languages) {
 if(-not $purpose.GetMethod('SupportsLanguage',$static).Invoke($null,@($language))) { throw "Unsupported production locale: $language" }
 foreach($id in $ids) {
  if([string]::IsNullOrEmpty($purpose.GetMethod('Get',$static).Invoke($null,@($id,$language)))) { throw "Missing production purpose: $language/$id" }
 }
}
'Actual production DLL: 9 embedded resources, 104 purposes x 11 languages PASS.'
Add-Type @'
using System.Collections.Generic;
public sealed class DttFixtureText {
 public string Text;
 public DttFixtureText(string text, object style, object alignment, int width) { Text=text; }
}
public sealed class DttFixtureGap { public DttFixtureGap() {} }
public sealed class DttFixtureTooltip {
 public List<object> Rows=new List<object>();
 public DttFixtureContainer Data=new DttFixtureContainer();
 public void AddData(object data) { Rows.Add(data); }
}
public sealed class DttFixtureContainer { public List<object> DataList=new List<object>(); }
public enum DttFixtureItemType { Ordinary=0, Preach=20 }
public sealed class DttFixtureDefinition { public DttFixtureItemType Type; }
public sealed class DttFixtureNeed { public string Id; public DttFixtureNeed(string id) { Id=id; } }
public sealed class DttFixtureCraft { public List<DttFixtureNeed> Output=new List<DttFixtureNeed>(); }
public sealed class DttFixtureBalance {
 public Dictionary<string,DttFixtureDefinition> Items=new Dictionary<string,DttFixtureDefinition>();
 public Dictionary<string,List<string>> Groups=new Dictionary<string,List<string>>();
 public DttFixtureDefinition Get(string id) { DttFixtureDefinition d; return Items.TryGetValue(id,out d)?d:null; }
 public List<string> Variants(string id) { List<string> v; return Groups.TryGetValue(id,out v)?v:new List<string>(); }
}
'@
$flags=[Reflection.BindingFlags]'Static,NonPublic,Public'
$api=$assembly.GetType('DetailedTechnologyTooltips.GameApi',$true)
$ctxType=$assembly.GetType('DetailedTechnologyTooltips.TechTooltipContext',$true)
$materialType=$assembly.GetType('DetailedTechnologyTooltips.PilotMaterial',$true)
$layout=$assembly.GetType('DetailedTechnologyTooltips.PilotLayout',$true)
$api.GetField('_textDataCtor',$flags).SetValue($null,[DttFixtureText].GetConstructors()[0])
$api.GetField('_tooltipAddData',$flags).SetValue($null,[DttFixtureTooltip].GetMethod('AddData'))
$layout.GetField('blankCtor',$flags).SetValue($null,[DttFixtureGap].GetConstructors()[0])
function Compose([bool]$body,[string]$purpose,[string[]]$materials,[string]$location,[string[]]$extras) {
 $ctx=[Activator]::CreateInstance($ctxType,$true)
 $ctxType.GetField('Craft').SetValue($ctx,[object]::new())
 $ctxType.GetField('UseRichLayout').SetValue($ctx,$true)
 $ctxType.GetField('HasNativeBody').SetValue($ctx,$body)
 $ctxType.GetField('PilotPurpose').SetValue($ctx,$purpose)
 $ctxType.GetField('LocationRow').SetValue($ctx,$location)
 $ctxType.GetField('ExtraCraftRows').SetValue($ctx,$extras)
 $array=[Array]::CreateInstance($materialType,$materials.Count)
 for($i=0;$i -lt $materials.Count;$i++) {
  $m=[Activator]::CreateInstance($materialType,$true)
  $materialType.GetField('Name').SetValue($m,$materials[$i])
  $materialType.GetField('Icon').SetValue($m,'native-icon')
  $array.SetValue($m,$i)
 }
 $ctxType.GetField('PilotMaterials').SetValue($ctx,$array)
 $tooltip=[DttFixtureTooltip]::new()
 $api.GetMethod('AppendDetails',$flags).Invoke($null,@($tooltip,$ctx)) | Out-Null
 return ,$tooltip.Rows
}
$rows=Compose $true '' @('Flitch (x2)','Nails (x1)') 'Crafted at: Carpenter' @()
if($rows.Count -ne 5 -or $rows[0] -isnot [DttFixtureGap] -or $rows[1].Text -ne '[AA]      Flitch (x2)[FF]' -or $rows[2].Text -ne '[AA]      Nails (x1)[FF]' -or $rows[3] -isnot [DttFixtureGap] -or $rows[4].Text -ne '[AA]Crafted at: Carpenter[FF]') { throw 'Actual recipe composition lost material rows/quantity/exact location/gaps' }
$rows=Compose $false '' @() 'Exact station' @()
if($rows.Count -ne 1 -or $rows[0] -isnot [DttFixtureText]) { throw 'Empty resources must not insert empty block or extra gaps' }
$rows=Compose $false '[AA]Purpose[FF]' @() 'Native builder' @()
if($rows.Count -ne 3 -or $rows[1] -isnot [DttFixtureGap]) { throw 'Existing no-cost blueprint composition regressed' }
$rows=Compose $false '' @('Grape seeds (x4)') 'Vineyard' @('Seeds: Merchant')
if($rows.Count -ne 4 -or $rows[0].Text -notmatch '\(x4\)' -or $rows[3].Text -ne '[AA]Seeds: Merchant[FF]') { throw 'Growing four-seed/vendor correction lost' }
$api.GetField('_outputField',$flags).SetValue($null,[DttFixtureCraft].GetField('Output'))
$api.GetField('_itemIdField',$flags).SetValue($null,[DttFixtureNeed].GetField('Id'))
$api.GetField('_itemDefinitionTypeField',$flags).SetValue($null,[DttFixtureDefinition].GetField('Type'))
$api.GetField('_preachEnumValue',$flags).SetValue($null,[DttFixtureItemType]::Preach)
$api.GetField('_getItemDefinitionById',$flags).SetValue($null,[DttFixtureBalance].GetMethod('Get'))
$api.GetField('_getItemsOfBaseName',$flags).SetValue($null,[DttFixtureBalance].GetMethod('Variants'))
$balance=[DttFixtureBalance]::new()
$plain=[DttFixtureDefinition]::new()
$prayer=[DttFixtureDefinition]::new(); $prayer.Type=[DttFixtureItemType]::Preach
$balance.Items.Add('plank',$plain); $balance.Items.Add('sermon:1',$prayer); $balance.Items.Add('chapter:1',$plain)
$balance.Groups.Add('sermon',[Collections.Generic.List[string]]@('sermon:1'))
$balance.Groups.Add('chapter',[Collections.Generic.List[string]]@('chapter:1'))
foreach($case in @(@('plank',$false),@('sermon:1',$true),@('sermon',$true),@('unknown',$false))) {
 $craft=[DttFixtureCraft]::new(); $craft.Output.Add([DttFixtureNeed]::new($case[0]))
 $actual=$api.GetMethod('HasPrayerOutput',$flags).Invoke($null,@($balance,$craft))
 if($actual -ne $case[1]) { throw "Prayer classification mismatch for $($case[0])" }
}
$resolved=$api.GetMethod('ResolveMaterialDefinition',$flags).Invoke($null,@($balance,'chapter'))
if(-not [object]::ReferenceEquals($resolved,$plain)) { throw 'Grouped ingredient must resolve through the native variant list' }
$layout.GetField('textDataType',$flags).SetValue($null,[DttFixtureText])
$layout.GetField('tooltipData',$flags).SetValue($null,[DttFixtureTooltip].GetField('Data'))
$layout.GetField('dataList',$flags).SetValue($null,[DttFixtureContainer].GetField('DataList'))
$layout.GetField('installed',$flags).SetValue($null,$true)
$calibration=$assembly.GetType('DetailedTechnologyTooltips.TooltipAppearance',$true)
$pluginType=$assembly.GetType('DetailedTechnologyTooltips.Plugin',$true)
$declared=[Reflection.BindingFlags]'Public,NonPublic,Instance,Static,DeclaredOnly'
if($assembly.GetType('DetailedTechnologyTooltips.PilotCalibration',$false) -or $pluginType.GetMethod('Update',$declared) -or $pluginType.GetMethod('OnGUI',$declared)) { throw 'Temporary calibration type or frame/UI callback remains' }
foreach($method in @('Contents','Slider','Close','Update','Draw')) {
 if($calibration.GetMethod($method,$declared)) { throw "Temporary settings method remains: $method" }
}
foreach($reference in $assembly.GetReferencedAssemblies()) {
 if($reference.Name -in @('UnityEngine.InputLegacyModule','UnityEngine.IMGUIModule')) { throw 'Input/IMGUI dependency remains after calibration removal' }
}
$defaults=@{IconSize=20;IconY=0;TextSpaces=5;Opacity=100;TitleCenter=$true;PurposeCenter=$true;MaterialCenter=$false;LocationCenter=$true;TitleGap=2;PurposeGap=6;MaterialGap=6;EntryGap=10}
foreach($key in $defaults.Keys) {
 $field=$calibration.GetField($key,$flags)
 if(-not $field -or -not $field.IsLiteral -or $field.GetRawConstantValue() -ne $defaults[$key]) { throw "Accepted appearance is not fixed: $key" }
}
'Actual production DLL: fixed accepted defaults; no calibration type, F2 callbacks or Input/IMGUI references PASS.'
$calibration.GetField('text',$flags).SetValue($null,[DttFixtureText].GetField('Text'))
$calibration.GetField('ready',$flags).SetValue($null,$true)
$preview=[DttFixtureTooltip]::new()
$earlier=[DttFixtureText]::new('Earlier unlock',$null,$null,-1)
$title=[DttFixtureText]::new('Current title',$null,$null,-1)
$body=[DttFixtureText]::new('Native (wskull)1 body',$null,$null,-1)
$preview.Data.DataList.Add($earlier); $preview.Data.DataList.Add($title)
$preview.Data.DataList.Add([DttFixtureGap]::new()); $preview.Data.DataList.Add($body)
for($i=0;$i -lt 2;$i++) {
 if(-not $layout.GetMethod('MarkNativeBody',$flags).Invoke($null,@($preview,1))) { throw 'Native body not recognized' }
}
foreach($row in @($earlier,$title,$body)) { $calibration.GetMethod('BeforeDraw',$flags).Invoke($null,@($row)) | Out-Null }
if($earlier.Text -ne 'Earlier unlock' -or $title.Text -ne 'Current title' -or $body.Text -ne '[FF]Native (wskull)1 body[FF]') { throw 'Cached-type native-body marking changed an earlier/title row or lost native symbol' }
$material=[DttFixtureText]::new('[AA]      Nails (x8)[FF]',$null,$null,-1)
$calibration.GetMethod('Mark',$flags).Invoke($null,@($material,$true)) | Out-Null
for($i=0;$i -lt 2;$i++) { $calibration.GetMethod('BeforeDraw',$flags).Invoke($null,@($material)) | Out-Null }
if($material.Text -ne "[FF]     Nails$([char]0x00a0)(x8)[FF]") { throw 'Fixed material indent/opacity/quantity binding changed or accumulated' }
'Actual compiled composition/prayer/group/native-body-scope checks PASS; UI rendering not exercised.'

