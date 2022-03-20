﻿# Kunc.RiotGames.Lol.DataDragon

## How to use
```cs
LolDataDragon lolDataDragon = new LolDataDragon();
var versions = await lolDataDragon.GetVersionsAsync();
var lastVersion = versions[0];
var chapions = await lolDataDragon.GetAllChampionsAsync(lastVersion, "en_US");
foreach (var item in chapions.Where((ch, index) => (index + 1 % 10) == 0)) // select every 10th champion 
{
    Console.WriteLine($"{item.Name} - {item.Title}");
}
```

## Disclaimer
`Kunc.RiotGames.Lol.DataDragon` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
