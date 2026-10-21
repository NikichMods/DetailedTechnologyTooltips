# SPDX-License-Identifier: MPL-2.0
param([Parameter(Mandatory=$true)][string]$GameRoot)
$ErrorActionPreference = 'Stop'
$project = Join-Path $PSScriptRoot 'PurposeMechanicsProbe.csproj'
$repo = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
$dirty = git -C $repo status --porcelain -- research/PurposeMechanicsProbe
if ($dirty) { throw 'Commit probe build inputs before producing a handed artifact.' }
$source = git -C $repo rev-parse HEAD
dotnet build $project -c Release "-p:GameRoot=$GameRoot" -p:NuGetAudit=false --source https://api.nuget.org/v3/index.json
if ($LASTEXITCODE -ne 0) { throw 'Probe build failed' }
[xml]$xml = Get-Content $project
$version = [string]$xml.Project.PropertyGroup.Version
$dll = Join-Path $PSScriptRoot 'bin/Release/net48/PurposeMechanicsProbe.dll'
$assemblyVersion = [Reflection.AssemblyName]::GetAssemblyName($dll).Version.ToString()
if ($assemblyVersion -ne "$version.0") { throw "Version mismatch: $assemblyVersion / $version" }
$artifacts = Join-Path $repo 'artifacts/purpose-mechanics'
New-Item -ItemType Directory -Path $artifacts -Force | Out-Null
$target = Join-Path $artifacts "PurposeMechanicsProbe-$version.dll"
$hash = (Get-FileHash -LiteralPath $dll -Algorithm SHA256).Hash.ToLowerInvariant()
if ((Test-Path -LiteralPath $target) -and (Get-FileHash -LiteralPath $target).Hash.ToLowerInvariant() -ne $hash) { throw 'Immutable artifact already exists with different bytes' }
Copy-Item -LiteralPath $dll -Destination $target
[ordered]@{version=$version; source=$source; sha256=$hash; artifact=$target; sdk=(dotnet --version)} | ConvertTo-Json | Set-Content (Join-Path $artifacts "PurposeMechanicsProbe-$version.json") -Encoding utf8
Write-Output "PROBE_BUILD version=$version source=$source sha256=$hash artifact=$target"
