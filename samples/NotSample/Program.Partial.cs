using System.Diagnostics;
using BenchmarkDotNet.Running;
using Kunc.RiotGames.Lol.LeagueClientUpdate;
using Kunc.RiotGames.Lor.DeckCodes;
using Kunc.RiotGames.Lor.GameClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotSample;

partial class Program
{
    static readonly IConfiguration Configuration = new ConfigurationManager()
        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName)
        .AddJsonFile("appsettings.json", true, true)
        .Build();

    static readonly IServiceProvider _service = new ServiceCollection()
        .AddSingleton(Configuration)
        .AddLogging(x => x.AddConfiguration(Configuration.GetSection("Logging")).AddSimpleConsole())
        .AddSingleton(x => File.Exists(Lockfile.DefaulthPath) ? Lockfile.FromFileAsync().GetAwaiter().GetResult() : Lockfile.Empty)
        .AddSingleton<ILolLeagueClientUpdate, LolLeagueClientUpdate>()
        //.AddSingleton<IWamp, NullWamp>() // testing
        .AddSingleton<ILorDeckEncoder, LorDeckEncoder>()
        .AddSingleton<ILorGameClient, LorGameClient>()
        .BuildServiceProvider();

    static ILorDeckEncoder LorDeckEncoder => _service.GetRequiredService<ILorDeckEncoder>();
    static ILorGameClient LorGameClient => _service.GetRequiredService<ILorGameClient>();
    static ILolLeagueClientUpdate Lcu => _service.GetRequiredService<ILolLeagueClientUpdate>();
    static T Get<T>() where T : class => _service.GetRequiredService<T>();

    [Conditional("RELEASE")]
    static void RunBenchmarks(bool exit = true)
    {
        BenchmarkRunner.Run<LorDeckEncoderBenchmark>();
        if (exit)
            Environment.Exit(0);
    }
}
