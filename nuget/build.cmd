pushd %~dp0
pushd ..\UntisJson\
msbuild UntisJson.csproj /p:Configuration=Release
popd

nuget pack UntisJson.nuspec