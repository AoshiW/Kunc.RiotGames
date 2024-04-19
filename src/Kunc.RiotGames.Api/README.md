﻿# Kunc.RiotGames.Api
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Api?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Api)

## Features
The rate limiter is automatically set according to your api key.

## How to Use
```cs
var api = RiotGamesApi.Create(c => c.ApiKey = "RGAPI-...");
// or
using var services = new ServiceCollection()
    .AddRiotGamesApi(c => c.ApiKey = "RGAPI-...")
    .BuildServiceProvider();
var api = services.GetRequiredService<IRiotGamesApi>();

var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, "AoshiW", "IRON");
// or
//var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, "AoshiW#IRON");
Console.WriteLine($"Account: {account.GetRiotId()}");

var summoner = await api.LolSummonerV4.GetSummonerByPuuidAsync(Regions.EUN1, account.Puuid);
Console.WriteLine();
Console.WriteLine("Ranks:");
var entries = await api.LolLeagueV4.LeagueEntriesForSummonerAsync(Regions.EUN1, summoner.Id);
foreach (var entry in entries)
{
    Console.WriteLine($"{entry.QueueType}: {entry.ToRank()}");
}
```

## Disclaimer
`Kunc.RiotGames.Api` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
