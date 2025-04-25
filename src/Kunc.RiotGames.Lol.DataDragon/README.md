# Kunc.RiotGames.Lol.DataDragon
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.DataDragon?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.DataDragon)

Simple client for League of Legends DataDragon.

## How to Use
```cs
using Kunc.RiotGames.Lol.DataDragon;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection()
    .AddLolDataDragon()
    .BuildServiceProvider();
ILolDataDragon lolDataDragon = service.GetRequiredService<ILolDataDragon>();
// or
ILolDataDragon lolDataDragon = LolDataDragon.Create();

int count = 5;
var language = "en_US";
var versions = await lolDataDragon.GetVersionsAsync();
var lastVersion = versions[0]; // or "latest"

Dictionary<string, ChampionDto> champions = await lolDataDragon.GetChampionsAsync(lastVersion, language);

Console.WriteLine($"Top {count} champions with the largest attack range:");
foreach (var champion in champions.Values.OrderByDescending(c => c.Stats.AttackRange).Take(count))
{
    Console.WriteLine($"{champion.Name}  {champion.Stats.AttackRange}");
}
```

## Features

###  Support for `"latest"` version
automatically converts the string `"latest"` to the latest version e.g.:`"15.1.1"`

### Caching
The `HybridCache` is used as the caching provider, so by default it is only cached in memory, if you want an out-of-process cache, register [IDistributedCache service](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed#establish-distributed-caching-services) to `ServiceCollection`.
```cs
// optionally adding some IDistributedCache .. for example Redish 
Services.AddStackExchangeRedisCache(o => 
{
    o.Configuration = "connection string";
});

Services.AddLolDataDragon>(c =>
{
    c.DefaultCacheEntryOptions = new HybridCacheEntryOptions() { ... };
});
```

### Other useful things

#### Customizing JSON deserialization
The library allows to access the `JsonSerializerOptions` instance which is used for deserializing JSON into a class.
So if there is some problem with the deserialization (e.g.: the property is of type `int` but Riot returns a number in decimal format: `5.0`),
you can change it with:
```cs
Services.AddLolDataDragon>(c =>
{
    c.JsonSerializerOptions = new JsonSerializerOptions()
    {
        Converters = { new DoubleToIntConverter() }
    };
});
```

## Disclaimer
`Kunc.RiotGames.Lol.DataDragon` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
