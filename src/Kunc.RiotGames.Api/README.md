﻿# Kunc.RiotGames.Api
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Api?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Api)

## Usage
```cs

var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, "AoshiW#IRON");
//var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, "AoshiW", "IRON");
Console.WriteLine($"Account: {account.GetRiotID()}");

var summoner = await api.LolSummonerV4.GetSummonerByPuuidAsync(Regions.EUN1, account.Puuid);
Console.WriteLine();
Console.WriteLine("Ranks:");
var le = await api.LolLeagueV4.LeagueEntriesForSummonerAsync(Regions.EUN1, summoner.Id);
foreach (var entry in le)
{
    Console.WriteLine($"{entry.QueueType}: {entry.ToRank()}");
}
```

## Disclaimer
`Kunc.RiotGames.Api` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
