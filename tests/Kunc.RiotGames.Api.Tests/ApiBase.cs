using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api.Tests;

public abstract class ApiBase<TGame> where TGame : Tests.TGame
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
        Regions.SG2,
        Regions.TW2,
        Regions.VN2,
    };
    static IEnumerable<(Type, string)> GetReturnTypes(Type type)
    {
        var endpoints = type.Name;
        int index;

        if ((index = endpoints.IndexOf('_')) is not -1)
            endpoints = endpoints[..index];
        endpoints = endpoints[0..^4]; // Remove "Test"

        type = typeof(IRiotGamesApi).Assembly.GetTypes().First(x => x.FullName == $"Kunc.RiotGames.Api.{endpoints}.I{endpoints}")!;

        foreach (var method in type.GetMethods())
        {
            bool isEndpointFound = false;
            type = method.ReturnType.GetGenericArguments()[0]; ;
            var path = Path.Join("TestData", endpoints, type.Name);
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.json"))
                {
                    isEndpointFound = true;
                    yield return (type, file);
                }
            }
            if (!isEndpointFound)
                yield return (type, default!);
        }
    }

    public TestContext TestContext { get; set; } = default!;

    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void ClassInit(TestContext context)
    {
        ReturnTypes = GetReturnTypes(Type.GetType(context.FullyQualifiedTestClassName)!).ToArray();
    }

    public static IEnumerable<(Type, string)> ReturnTypes { get; set; } = default!;

    public static string ReturnTypesName(MethodInfo methodInfo, object[] data)
    {
        var typeName = ((Type)data[0])?.Name ?? "null";
        var path = data[1]?.ToString() ?? "null";
        return $"{methodInfo.Name} ({typeName}, {path})";
    }

    [TestMethod]
    [DynamicData(nameof(ReturnTypes), DynamicDataDisplayName = nameof(ReturnTypesName))]
    public void DeserializeTest(Type type, string? path)
    {
        if (path is null)
            Assert.Inconclusive("No test data found for this endpoint.");

        var json = File.ReadAllText(path);
        var obj = JsonSerializer.Deserialize(json, type);
        Assert.IsNotNull(obj);
    }
}

public abstract class TGame
{
    public class LOL : TGame { }

    public class TFT : TGame { }

    public class LOR : TGame { }
}
