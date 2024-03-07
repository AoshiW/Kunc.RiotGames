using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public class ApiBase
{
    static readonly IConfiguration Configuration = new ConfigurationManager()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.local.json", true)
        .AddEnvironmentVariables()
        .Build();

    protected static readonly IRiotGamesApi api = new ServiceCollection()
        .AddSingleton(Configuration)
        .AddRiotGamesApi(c => c.ApiKey = Configuration["RGAPIKEY"]!)
        .BuildServiceProvider()
        .GetRequiredService<IRiotGamesApi>();

    protected static readonly string Puuid = Configuration[nameof(Puuid)]!;
    protected static readonly string SummonerId = Configuration[nameof(SummonerId)]!;
    protected static readonly string RiotId = Configuration[nameof(RiotId)]!;
}
