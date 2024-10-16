using Kunc.RiotGames.Api;
using Kunc.RiotGames.Lol.DataDragon;
using Kunc.RiotGames.Lol.GameClient;
using Kunc.RiotGames.Lol.LeagueClientUpdate;
using Kunc.RiotGames.Lor.DeckCodes;
using Kunc.RiotGames.Lor.GameClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeoSmart.Caching.Sqlite;
using NeoSmart.Caching.Sqlite.AspNetCore;

partial class Program
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
        .AddLolDataDragon()
        .AddSingleton<ILolGameClient, LolGameClient>()
        .AddRiotGamesApi(c => c.ApiKey = Configuration["RGAPIKEY"]!)
        .AddSqliteCache(x =>
        {
            x.CachePath = "cache.sqlite";
        })
        .BuildServiceProvider();

    static ILorDeckEncoder LorDeckEncoder => _service.GetRequiredService<ILorDeckEncoder>();
    static ILorGameClient LorGameClient => _service.GetRequiredService<ILorGameClient>();
    static ILolLeagueClientUpdate Lcu => _service.GetRequiredService<ILolLeagueClientUpdate>();
    static ILolDataDragon LolDataDragon => _service.GetRequiredService<ILolDataDragon>();
    static ILolGameClient LolGameClient => _service.GetRequiredService<ILolGameClient>();
    static IRiotGamesApi Api => _service.GetRequiredService<IRiotGamesApi>();
}
