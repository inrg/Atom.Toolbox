nuget.exe pack "..\Atom.Module.Base64Url\Atom.Module.Base64Url.csproj" -Build -Properties Configuration=Release
PAUSE
nuget.exe pack "..\Atom.Module.Configuration\Atom.Module.Configuration.csproj" -Build -Properties Configuration=Release
PAUSE
nuget.exe pack "..\Atom.Module.Configuration.Json\Atom.Module.Configuration.Json.csproj" -IncludeReferencedProjects -Build -Properties Configuration=Release
PAUSE
