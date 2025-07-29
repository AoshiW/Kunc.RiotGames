# Kunc.RiotGames
[![Daily Build/Test Check](https://github.com/AoshiW/Kunc.RiotGames/actions/workflows/daily_check.yml/badge.svg?branch=dev)](https://github.com/AoshiW/Kunc.RiotGames/actions/workflows/daily_check.yml)

`Kunc.RiotGames` is a collection of libraries to help you work with the RiotGames API, and things like DDragon, LCU , etc.

**Each package has its own README with more detailed information about its purpose and use.** If you want to know more about each one of these, please refer to the [packages](#packages) list.

## Packages
All packages are available through [NuGet](https://www.nuget.org/packages?q=Kunc.RiotGames.).

Package + README link                  |NuGet| Description
---------------------------------------|-----|------------
[`Kunc.RiotGames.Core`](/src/Kunc.RiotGames.Core/README.md)                 | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Core?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Core) | Core package for other packages.|
[`Kunc.RiotGames.Api`](/src/Kunc.RiotGames.Api/README.md)                   | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Api?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Api) | Client for the [Riot Games API](https://developer.riotgames.com/apis).|
[`Kunc.RiotGames.Lol.DataDragon`](/src/Kunc.RiotGames.Lol.DataDragon/README.md)        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.DataDragon?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.DataDragon) |Simple client for [League of Legends DataDragon](https://developer.riotgames.com/docs/lol#data-dragon).|
[`Kunc.RiotGames.Lol.GameClient`](src/Kunc.RiotGames.Lol.GameClient/README.md)        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.GameClient) |Simple client for [League of Legends Game Client API](https://developer.riotgames.com/docs/lol#game-client-api_live-client-data-api)|
[`Kunc.RiotGames.Lol.LeagueClientUpdate`](/src/Kunc.RiotGames.Lol.LeagueClientUpdate/README.md)| [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.LeagueClientUpdate?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.LeagueClientUpdate) |Simple client for interacting with the League of Legends LCU.|
[`Kunc.RiotGames.Lor.DeckCodes`](/src/Kunc.RiotGames.Lor.DeckCodes/README.md)         | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.DeckCodes?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.DeckCodes) | Encode/Decode [Legends of Runeterra decks](https://developer.riotgames.com/docs/lor#deck-codes) to/from simple strings.|
[`Kunc.RiotGames.Lor.GameClient`](/src/Kunc.RiotGames.Lor.GameClient/README.md)        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.GameClient) |Simple client for [Legends of Runeterra Game Client API](https://developer.riotgames.com/docs/lor#game-client-api)|


## How to Use
This example requires downloading 2 packages: `Kunc.RiotGames.Api` and `Kunc.RiotGames.Lol.DataDragon`
```cs
using Kunc.RiotGames.Api;
using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Kunc.RiotGames.Api.LolLeagueV4;
using Kunc.RiotGames.Api.LolSummonerV4;
using Kunc.RiotGames.Api.RiotAccountV1;
using Kunc.RiotGames.Lol.DataDragon;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddRiotGamesApi(x => x.ApiKey = "RGAPI-...")
    .AddLolDataDragon()
    .BuildServiceProvider();

var api = services.GetRequiredService<IRiotGamesApi>();
var lolDataDragon = services.GetRequiredService<ILolDataDragon>();

var riotId = "AoshiW#NULL";
string smallRegion = Regions.EUN1;
string bigRegion = Regions.EUROPE;

AccountDto? account = await api.RiotAccountV1.GetAccountByRiotIdAsync(bigRegion, riotId);
SummonerDto? summoner = await api.LolSummonerV4.GetSummonerByPuuidAsync(smallRegion, account!.Puuid);
Console.WriteLine($"Account: {account.GetRiotId()}");
Console.WriteLine($"Region: {smallRegion}");
Console.WriteLine($"Level: {summoner.Level}");

LeagueEntryDto[] entries = await api.LolLeagueV4.LeagueEntriesForSummonerAsync(smallRegion, summoner.Puuid);
Console.WriteLine();
Console.WriteLine($"Rank:");
foreach (var entry in entries)
{
    Console.WriteLine($"{entry.QueueType}: {entry.ToRank()}");
}

const int count = 5;
ChampionMasteryDto[] masteries = await api.LolChampionMasteryV4.GetAllChampionMasteryEntriesAsync(smallRegion, account.Puuid);
Dictionary<string, ChampionBaseDto> champions = await lolDataDragon.GetChampionsBaseAsync("latest", "en_US");
Console.WriteLine();
Console.WriteLine($"Top {count} champions:");
foreach (var mastery in masteries.Take(count))
{
    var champion = champions.First(c => c.Value.Key == mastery.ChampionId).Value;
    Console.WriteLine($"{champion.Name,-13} Level:{mastery.ChampionLevel,3}, Points:{mastery.ChampionPoints,7}");
}
```
Example output:
```
Account: AoshiW#NULL
Region: eun1
Level: 591

Rank:
RankedFlexSR: Gold I 56LP
RankedSolo5x5: Gold II 86LP

Top 5 champions:
Zoe           Level: 63, Points: 693502
Soraka        Level: 40, Points: 443427
Heimerdinger  Level: 29, Points: 335509
Cassiopeia    Level: 12, Points: 144221
Morgana       Level: 11, Points: 137580

```
## Disclaimer
`Kunc.RiotGames` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
