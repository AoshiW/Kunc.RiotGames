# Kunc.RiotGames.Lor.GameClient
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lor.GameClient?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lor.GameClient)

[Game Client API](https://developer.riotgames.com/docs/lor#game-client-api) for Legends of Runeterra.

## How to Use
```cs
var options = new LorGameClientOptions();
var lorGameClient = new LorGameClient(options);

PositionalRectangles positionalRectangles = await lorGameClient.GetPositionalRectanglesAsync();
// do stuff

StaticDecklist staticDecklist = await lorGameClient.GetStaticDecklistAsync();
// do stuff

GameResult gameResult = await lorGameClient.GetGameResultAsync();
// do stuff
```

## Disclaimer
`Kunc.RiotGames.Lor.GameClient` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
