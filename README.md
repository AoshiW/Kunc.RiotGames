# Kunc.RiotGames
`Kunc.RiotGames` is a collection of libraries to help you work with the RiotGames API, and things like DDragon, LCU , etc.

TODO 

## Packages
All packages are available through [NuGet](https://www.nuget.org/packages?q=Kunc.RiotGames.).

Package                                |NuGet| Description
---------------------------------------|-----|------------
`Kunc.RiotGames.Core`                  | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Core?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Core) | Core package for other packages.|
`Kunc.RiotGames.Api`                   | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Api?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Api) | Client for the [Riot Games API](https://developer.riotgames.com/apis).|
`Kunc.RiotGames.Lol.DataDragon`        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.DataDragon?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.DataDragon) |Simple client for [League of Legends DataDragon](https://developer.riotgames.com/docs/lol#data-dragon).|
`Kunc.RiotGames.Lol.GameClient`        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.GameClient) |Simple client for [League of Legends Game Client API](https://developer.riotgames.com/docs/lol#game-client-api_live-client-data-api)|
`Kunc.RiotGames.Lol.LeagueClientUpdate`| [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.LeagueClientUpdate?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.LeagueClientUpdate) |Simple client for interacting with the League of Legends LCU.|
`Kunc.RiotGames.Lor.DeckCodes`         | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.DeckCodes?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.DeckCodes) | Encode/Decode [Legends of Runeterra decks](https://developer.riotgames.com/docs/lor#deck-codes) to/from simple strings.|
`Kunc.RiotGames.Lor.GameClient`        | [![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.GameClient) |Simple client for [Legends of Runeterra Game Client API](https://developer.riotgames.com/docs/lor#game-client-api)|


## How to Use
```cs
var api = RiotGamesApi.Create(x => x.ApiKey = "RGAPI-...");
var lolDataDragon = new LolDataDragon(new LolDataDragonOptions());
string bigRegion = Regions.EUROPE;
string smallRegion = Regions.EUN1;
var riotId = "AoshiW#IRON";

AccountDto? account = await api.RiotAccountV1.GetAccountByRiotIdAsync(bigRegion, riotId);
SummonerDto summoner = await api.LolSummonerV4.GetSummonerByPuuidAsync(smallRegion, account!.Puuid);
Console.WriteLine($"Account: {account.GetRiotId()}");
Console.WriteLine($"Region: {smallRegion}");
Console.WriteLine($"Level: {summoner.Level}");

LeagueEntryDto[] entries = await api.LolLeagueV4.LeagueEntriesForSummonerAsync(smallRegion, summoner.Id);
Console.WriteLine();
Console.WriteLine($"Rank:");
foreach (var entry in entries)
{
    Console.WriteLine($"{entry.QueueType}: {entry.ToRank()}");
}

const int count = 5;
ChampionMasteryDto[] masteries = await api.LolChampionMasteryV4.GetAllChampionMasteryEntriesAsync(smallRegion, account.Puuid);
Dictionary<string, ChampionBaseDto> champions = await lolDataDragon.GetAllChampionsBaseAsync("latest", "en_US");
Console.WriteLine();
Console.WriteLine($"Top {count} champions:");
foreach (var mastery in masteries.Take(count))
{
    var champion = champions.First(c => c.Value.Key == mastery.ChampionId).Value;
    Console.WriteLine($"{champion.Name,-13} Level:{mastery.ChampionLevel,3}, Points:{mastery.ChampionPoints,7}");
}
```
Output:
```
Account: AoshiW#IRON
Region: eun1
Level: 591

Rank:
Cherry: Unranked
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
