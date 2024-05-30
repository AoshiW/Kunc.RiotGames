# Kunc.RiotGames.Lol.LeagueClientUpdate
[![Nuget](https://img.shields.io/nuget/v/Kunc.RiotGames.Lol.LeagueClientUpdate?logo=NuGet&logoColor=blue&style=flat-square)](https://www.nuget.org/packages/Kunc.RiotGames.Lol.LeagueClientUpdate)

Simple client for interacting with the League of Legends LCU.

## How to use
```cs
using Kunc.RiotGames.Lol.LeagueClientUpdate;

LolLeagueClientUpdate lcu = new LolLeagueClientUpdate(new FileLockfileProvieder());
```

### API requests
To send an API request, you have 2 options:
1. Use the predefined methods (`GetAsync/SendAsync`) that are a wrapper around `HttpClinet`.
1. Use `HttpClient` directly (property `Client`), so you can use many existing methods. 

```cs
var obj = new { challengeIds = new long[] { -1, -1, -1 } };
await lcu.SendAsync(HttpMethod.Post, "lol-challenges/v1/update-player-preferences/", obj);
await lcu.Client.PostAsJsonAsync("lol-challenges/v1/update-player-preferences/", obj);

RootObject obj1 = await lcu.GetAsync<RootObject>("lol-summoner/v1/current-summoner");
RootObject obj2 = await lcu.Client.GetFromJsonAsync<RootObject>("lol-summoner/v1/current-summoner");

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
Lcu.Subscribe("/lol-gameflow/v1/gameflow-phase", (/* parameters */) => { /* code */ });
Lcu.Subscribe([LcuEvent("/lol-gameflow/v1/gameflow-phase")] (/* parameters */) => { /* code */ });
Lcu.Subscribe(new LcuEventAttribute("/lol-gameflow/v1/gameflow-phase"), (/* parameters */) => { /* code */ });

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
