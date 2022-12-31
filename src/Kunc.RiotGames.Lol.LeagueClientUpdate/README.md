# Kunc.RiotGames.Lol.LeagueClientUpdate


## How to use
```cs
Lockfile lockfile = await Lockfile.FromFileAsync();
LolLeagueClientUpdate lcu = new LolLeagueClientUpdate(lockfile);
```

### API
To send an API request, you have 2 options:
1. Use the predefined methods (`GetAsync/SendAsync`) that are a wrapper around `HttpClinet`.
2. Use `HttpClient` directly (property `Client`), so you can use many existing methods. 

```cs
var obj = new { challengeIds = new long[] { -1, -1, -1 } };
await lcu.SendAsync(HttpMethod.Post, "lol-challenges/v1/update-player-preferences/", obj);
await lcu.Client.PostAsJsonAsync("lol-challenges/v1/update-player-preferences/", obj);

RootObject obj1 = await lcu.GetAsync<RootObject>("lol-summoner/v1/current-summoner");
RootObject obj2 = await lcu.Client.GetFromJsonAsync<RootObject>("lol-summoner/v1/current-summoner");

class RootObject { /* Properties */ }
```

### WebSocket
To subscribe a lcu event, you have 2 options:
1. Call `Subscribe` with event uri and pass event delegate.
2. Create a `class` with **public** (static) methods and place `LcuEventAttribute` on it, than call `SubscribeAll<T>()`, if the `class` has any dependencies in the constructor, you can call `SubscribeAll<T>(T obj)` and pass the created class.
 
When you create a class or use `Subscibe` with a `System.Delegate`, you can create any method that has any return type and has 0-3 parameters, the parameters can be 
1. `object`/`LolLeagueClientUpdate`
2. `CancelationToken`
3. and anything else will be a lcu event argument

Don't forget to call `ConnectAsync` to start WebSocket.
```cs
lcu.Subscribe<LcuEventArgs<string>>("/lol-gameflow/v1/gameflow-phase", (sender, arg) => Console.WriteLine(arg.Data));

lcu.SubscribeAll<SomeClass>();
var obj = new SomeClassWithDependencies(DateTime.Now);
lcu.SubscribeAll(obj);

await lcu.ConnectAsync();

class SomeClass
{
    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void MyMethod1(object? sender, LcuEventArgs<string> data) 
        => Console.WriteLine(data.Data);
        
    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void MyMethod2() => Console.WriteLine("without params");

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public int MyMethod3() 
    {
        Console.WriteLine("Return int, without params");
        return 6;
    }
}
class SomeClassWithDependencies
{
    public SomeClassWithDependencies(DateTime dt) { }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void MyMethod1(object? sender, LcuEventArgs<string> data) 
        => Console.WriteLine(data.Data);
}
```

## Disclaimer
`Kunc.RiotGames.Lol.LeagueClientUpdate` isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
