# Kunc.RiotGames.Lor.GameClient
[Game Client API](https://developer.riotgames.com/docs/lor#game-client-api)  for Legends of Runeterra

## How to use
```cs
LorGameClient lorGameClient = new LorGameClient();
while (true)
{
    PositionalRectangles positionalRectangles = await lorGameClient.GetPositionalRectanglesAsync();
    // do stuff

    StaticDecklist staticDecklist = await lorGameClient.GetStaticDecklistAsync();
    // do stuff

    GameResult gameResult = await lorGameClient.GetGameResultAsync();
    // do stuff

    ExpeditionsState expeditionsState = await lorGameClient.GetExpeditionsStateAsync();
    // do stuff

    Console.WriteLine();
    await Task.Delay(5000);
}
```

## Disclaimer
`Kunc.RiotGames.Lor.GameClient` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
