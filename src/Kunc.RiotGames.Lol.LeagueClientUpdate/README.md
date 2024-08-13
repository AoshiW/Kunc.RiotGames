# Kunc.RiotGames.Lol.LeagueClientUpdate
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.LeagueClientUpdate?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.LeagueClientUpdate)

Simple client for interacting with the League of Legends LCU.

## How to use
```cs
using Kunc.RiotGames.Lol.LeagueClientUpdate;

ILolLeagueClientUpdate lcu = LolLeagueClientUpdate.Create();
```

### API requests
TODO

```cs
var obj = new { challengeIds = new long[] { -1, -1, -1 } };
await lcu.PostAsJsonAsync("lol-challenges/v1/update-player-preferences/", obj);

RootObject? obj1 = await lcu.GetFromJsonAsync<RootObject>("lol-summoner/v1/current-summoner");

class RootObject { /* Properties */ }
```

### WebSocket
TODO

#### Event delegate
As a delegate you can use __any__ method that has 0-3 parameters (the order of the parameters does not matter).

The parameters must be:
- type sender: `object`, `LolLeagueClientUpdate` ,`ILolLeagueClientUpdate`
- type eventArgs: here you can use __any__ type that represents an object that was sent through WAMP
- `CancellationToken`, token will by cancelled when WAMP is disconnect.

```cs
// Subcire event manually
lcu.Subscribe("/lol-gameflow/v1/gameflow-phase", (/* parameters */) => { /* code */ });
lcu.Subscribe([LcuEvent("/lol-gameflow/v1/gameflow-phase")] (/* parameters */) => { /* code */ });
lcu.Subscribe(new LcuEventAttribute("/lol-gameflow/v1/gameflow-phase"), (/* parameters */) => { /* code */ });

// Subscire all events from a given class
Lcu.SubscribeAll<SomeClass>();

class SomeClass
{
    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void Method1()
    { }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void Method2(LcuEventArgs<string> e)
    { 
        Console.WriteLine(e.Data);
    }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void Method3(object sender, LcuEventArgs<string> e)
    { }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void Method4(LolLeagueClientUpdate sender, LcuEventArgs<string> e, CancellationToken token)
    { }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public async Task Method5(ILolLeagueClientUpdate sender)
    { }
}
```

## Disclaimer
`Kunc.RiotGames.Lol.LeagueClientUpdate` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
