using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public abstract class ApiBase<TGame>
{
    private static IRiotGamesApi? _api;
    private static IConfiguration? _configuration;
    protected static IConfiguration Configuration => _configuration ??= new ConfigurationManager()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.local.json", true)
        .AddEnvironmentVariables()
        .Build();

    protected static IRiotGamesApi Api => _api ??= new ServiceCollection()
        .AddSingleton(Configuration)
        .AddRiotGamesApi(c => c.ApiKey = GetConfiguration("ApiKey").Get<string>()!)
        .BuildServiceProvider()
        .GetRequiredService<IRiotGamesApi>();

    protected static IConfigurationSection GetConfiguration(string key) => Configuration.GetSection(typeof(TGame).Name).GetSection(key);

    protected static string ToBigRegion(string region)
    {
        if (AMERICAS.Contains(region)) return Regions.AMERICAS;
        if (ASIA.Contains(region)) return Regions.ASIA;
        if (EUROPE.Contains(region)) return Regions.EUROPE;
        if (SEA.Contains(region)) return Regions.SEA;
        throw new NotImplementedException($"Unknown region to convert. Region: {region}");
    }

    private static readonly HashSet<string> AMERICAS = new(StringComparer.OrdinalIgnoreCase)
    {
        Regions.NA1,
        Regions.BR1,
        Regions.LA1,
        Regions.LA2,
    };

    private static readonly HashSet<string> ASIA = new(StringComparer.OrdinalIgnoreCase)
    {
        Regions.KR,
        Regions.JP1,
    };

    private static readonly HashSet<string> EUROPE = new(StringComparer.OrdinalIgnoreCase)
    {
        Regions.EUN1,
        Regions.EUW1,
        Regions.TR1,
        Regions.RU,
    };

    private static readonly HashSet<string> SEA = new(StringComparer.OrdinalIgnoreCase)
    {
        Regions.OC1,
        Regions.PH2,
        Regions.SG2,
        Regions.TW2,
        Regions.VN2,
    };
}

public abstract class TGame
{
    public class LOL : TGame { }

    public class TFT : TGame { }

    public class LOR : TGame { }
}
