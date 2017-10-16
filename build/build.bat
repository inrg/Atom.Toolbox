@ECHO OFF
SETLOCAL

::SET version=7.0.1023.1

FOR /F %%f IN (packages.txt) DO (
    nuget.exe pack ..\%%~nxf\%%~nxf.csproj -IncludeReferencedProjects -Build -Properties Configuration=Release
)

PAUSE

::XCOPY *.nupkg "%destination%" /D /Y
::DEL *.nupkg

PAUSE
