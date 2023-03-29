using System.Diagnostics;
using BenchmarkDotNet.Running;
using Kunc.RiotGames.Lol.LeagueClientUpdate;
using Kunc.RiotGames.Lor.DeckCodes;
using NotSample;

partial class Program
{
    static ILorDeckEncoder LorDeckEncoder => lorDeckEncoder ??= new LorDeckEncoder();
    static ILorDeckEncoder? lorDeckEncoder;
    static LolLeagueClientUpdate Lcu => lcu ??= InitLcu();
    static LolLeagueClientUpdate? lcu;

    static LolLeagueClientUpdate InitLcu()
    {
        var lcu = new LolLeagueClientUpdate(Lockfile.FromFileAsync().GetAwaiter().GetResult());
        lcu.OnWampDisconnect += (_, _) => Console.WriteLine("OnWampDisconnect");
        lcu.OnWampMessageError += (_, e) => Console.WriteLine($"OnWampMessageError {e.Message}");
        return lcu;
    }

    [Conditional("RELEASE")]
    static void RunBenchmarks(bool exit = true)
    {
        BenchmarkRunner.Run<LorDeckEncoderBenchmark>();
        if (exit)
            Environment.Exit(0);
    }
}
