# Kunc.RiotGames.Lol.GameClient
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.GameClient)

[Game Client API](https://developer.riotgames.com/docs/lol#game-client-api_live-client-data-api) for Legends of Legends.

## How to Use
```cs
var client = new LolGameClient();

AllGameDataDto allGameData = await client.LiveClientData.GetAllGameDataAsync();
```

## Disclaimer
`Kunc.RiotGames.Lol.GameClient` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
