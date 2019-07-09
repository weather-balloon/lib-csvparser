# lib-csvparser

[![Build Status](https://dev.azure.com/weatherballoon/Weather%20Balloon/_apis/build/status/weather-balloon.lib-csvparser?branchName=master)](https://dev.azure.com/weatherballoon/Weather%20Balloon/_build/latest?definitionId=8&branchName=master)

A C# facade for CSV parsing - essentially a small interface over [CSV Helper](https://joshclose.github.io/CsvHelper/)

## Dev guide

    FullSemVer=$(gitVersion /updateassemblyinfo AssemblyInfo.cs /ensureassemblyinfo |jq .FullSemVer)
    dotnet restore
    dotnet build -c Release /p:Version=$FullSemVer
    dotnet test -c Release --no-build
    dotnet pack -c Release --no-build


### Issues

If your Docker work is having resolution errors, check out 
https://development.robinwinslow.uk/2016/06/23/fix-docker-networking-dns/