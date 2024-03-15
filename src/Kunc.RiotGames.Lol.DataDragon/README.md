# Kunc.RiotGames.Lol.DataDragon
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.DataDragon?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.DataDragon)

## How to Use
```cs
var options = new LolDataDragonOptions();
var lolDataDragon = new LolDataDragon(options);
// or
using var services= new ServiceCollection()
    .AddLolDataDragon()
    .BuildServiceProvider();
var api = services.GetRequiredService<ILolDataDragon>();

int count = 5;
var language = "en_US";
var versions = await lolDataDragon.GetVersionsAsync();
var lastVersion = versions[0];

Dictionary<string, ChampionDto> champions = await lolDataDragon.GetAllChampionsAsync(lastVersion, language);

Console.WriteLine($"Top {count} champions with the biggest attack range:");
foreach (var champion in champions.Values.OrderByDescending(c => c.Stats.AttackRange).Take(count))
{
    Console.WriteLine($"{champion.Name}  {champion.Stats.AttackRange}");
}
```

## Disclaimer
`Kunc.RiotGames.Lol.DataDragon` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
