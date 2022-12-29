using Kunc.RiotGames.Lol.LeagueClientUpdate;

Console.WriteLine("Hello, Kunc.RiotGames!");

var lcu = new LolLeagueClientUpdate(await Lockfile.FromFileAsync());
lcu.Subscribe("/lol-gameflow/v1/gameflow-phase", () => Console.WriteLine("sync"));
lcu.Subscribe("/lol-gameflow/v1/gameflow-phase", async () => Console.WriteLine("async"));
lcu.SubscribeAll<NoDep>();
lcu.SubscribeAll(new Dep(new()));
await lcu.ConnectAsync();
await Task.Delay(-1);
class NoDep
{
    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public static void S(LcuEventArgs<string> e)
    {
        Console.WriteLine("Static No Dep");
    }
    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public void T(LcuEventArgs<string> e)
    {
        Console.WriteLine(" No Dep");
    }
}
class Dep
{
    public Dep(DateTime dateTime)
    {

    }

    [LcuEvent("/lol-gameflow/v1/gameflow-phase")]
    public static void T(LcuEventArgs<string> e)
    {
        Console.WriteLine("Dep");
    }
}
