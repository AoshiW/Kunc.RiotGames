﻿# Kunc.RiotGames.Api
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Api?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Api)

## Features
- Rate limiting (The rate limiter is automatically set according to your api key.)
- Caching (By default it's disabled; More info [here](#caching).)
## How to Use
```cs
using  Kunc.RiotGames.Api;

var api = RiotGamesApi.Create(c => c.ApiKey = "RGAPI-...");
// or
using var services = new ServiceCollection()
    .AddRiotGamesApi(c => c.ApiKey = "RGAPI-...")
    .BuildServiceProvider();
var api = services.GetRequiredService<IRiotGamesApi>();

var account = await api.RiotAccountV1.GetAccountByRiotIdAsync(Regions.EUROPE, "AoshiW#IRON");
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

> [!IMPORTANT]  
> If you created an instance of `RiotGamesApi` using the `RiotGamesApi.Create(...)` method, then save the instance and reuse it. If you keep creating new instances then some features may not work properly.


### Caching
The `HybridCache` is used as the caching provider, so by default it is only cached in memory, if you want an out-of-process cache, register [IDistributedCache service](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed#establish-distributed-caching-services) to `ServiceCollection`.
**It's also disabled by default in this project, so you have to enable it first.** (Why is it disabled? Short answer: there is no universal setting, so it is better to let everyone set it up themselves.)

How to enable caching:
1. you can enable it globally for all endpoints by setting `DefaultCacheEntryOptions`. 
2. you can enable/modify it only for some endpoints using `MethodCacheEntryOptions[]` (per endpoint setting takes precedence over global)

```cs
Services.AddRiotGamesApi(c =>
{
    c.ApiKey = "RGAPI-...";
    
    // global
    c.DefaultCacheEntryOptions = new HybridCacheEntryOptions() { ... };
    
    // per endpoint (the endpoint url is used as the key)
    c.MethodCacheEntryOptions["/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}"] = new HybridCacheEntryOptions() { ... };
})
```

## Disclaimer
`Kunc.RiotGames.Api` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
