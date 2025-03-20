using Kunc.RiotGames.Api;
using Kunc.RiotGames.Lol.DataDragon;
using Kunc.RiotGames.Lol.GameClient;
using Kunc.RiotGames.Lol.LeagueClientUpdate;
using Kunc.RiotGames.Lor.DeckCodes;
using Kunc.RiotGames.Lor.GameClient;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeoSmart.Caching.Sqlite;

static partial class Program
{
    static readonly IConfiguration Configuration = new ConfigurationManager()
        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile("appsettings.local.json", true, true)
        .Build();

    static readonly IServiceProvider _service = new ServiceCollection()
        .AddSingleton(Configuration)
        .AddLogging(c => c.AddConfiguration(Configuration.GetSection("Logging")).AddSimpleConsole())
        .AddLolLeagueClientUpdate()
        .AddSingleton<ILorDeckEncoder, LorDeckEncoder>()
        .AddLorGameClient()
        .AddLolDataDragon(c =>
        {
            c.LatestVersionCacheEntryOptions = new()
            {
                Flags = HybridCacheEntryFlags.DisableDistributedCache,
                LocalCacheExpiration = TimeSpan.FromMinutes(5),
            };
            c.DefaultCacheEntryOptions = new()
            {
                Expiration = TimeSpan.FromDays(7),
            };
        })
        .AddSingleton<ILolGameClient, LolGameClient>()
        .AddRiotGamesApi(c =>
        {
            c.ApiKey = Configuration["RGAPIKEY"]!;
        })
        .AddSqliteCache(x =>
        {
            x.CachePath = "cache.sqlite";
        })
        .Configure<HybridCacheOptions>(c =>
        {
            c.MaximumPayloadBytes *= 4; // the biggest json file for LolDataDragon is 2.5 MB
        })
        .ApplaySomePrivateLocalSetting()
        .BuildServiceProvider();

    static ILorDeckEncoder LorDeckEncoder => _service.GetRequiredService<ILorDeckEncoder>();
    static ILorGameClient LorGameClient => _service.GetRequiredService<ILorGameClient>();
    static ILolLeagueClientUpdate Lcu => _service.GetRequiredService<ILolLeagueClientUpdate>();
    static ILolDataDragon LolDataDragon => _service.GetRequiredService<ILolDataDragon>();
    static ILolGameClient LolGameClient => _service.GetRequiredService<ILolGameClient>();
    static IRiotGamesApi Api => _service.GetRequiredService<IRiotGamesApi>();

    static IServiceCollection ApplaySomePrivateLocalSetting(this IServiceCollection services)
    {
        SomePrivateLocalSetting(services);
        return services;
    }

    // these methodsa are defined in Program.Local.cs (this file isn't uploaded to GH)
    static partial void SomePrivateLocalSetting(IServiceCollection services);
    static partial void SomePrivateLocalCode();
}
