using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Api.LolChallengesV1;
using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Kunc.RiotGames.Api.LolChampionV3;
using Kunc.RiotGames.Api.LolClashV1;
using Kunc.RiotGames.Api.LolLeagueV4;
using Kunc.RiotGames.Api.LolMatchV5;
using Kunc.RiotGames.Api.LolSpectatorTftV5;
using Kunc.RiotGames.Api.LolSpectatorV5;
using Kunc.RiotGames.Api.LolSummonerV4;
using Kunc.RiotGames.Api.LorMatchV1;
using Kunc.RiotGames.Api.LorRankedV1;
using Kunc.RiotGames.Api.RiotAccountV1;
using Kunc.RiotGames.Api.SharedStatus;
using Kunc.RiotGames.Api.TftLeagueV1;
using Kunc.RiotGames.Api.TftMatchV1;
using Kunc.RiotGames.Api.TftSummonerV1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kunc.RiotGames.Api;

/// <summary>
/// Extension methods for setting up Riot Games API an <see cref="IServiceCollection" />.
/// </summary>
public static class RiotGamesApiServiceCollectionExtensions
{
    /// <summary>
    /// Adds Riot Games API to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="Action{RiotGamesApiOptions}"/> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddRiotGamesApi(this IServiceCollection services, Action<RiotGamesApiOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddOptions();
        services.TryAdd(ServiceDescriptor.Singleton<IRiotGamesRateLimiter, RiotGamesRateLimiter>());
        services.TryAdd(ServiceDescriptor.Singleton<IRiotGamesApiClient, RiotGamesApiClient>());
        services.TryAdd(ServiceDescriptor.Singleton<IRiotGamesApi, RiotGamesApi>());

        services.TryAdd(ServiceDescriptor.Singleton<ILolClashV1, LolClashV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolChallengesV1, LolChallengesV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolChampionMasteryV4, LolChampionMasteryV4Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolChampionV3, LolChampionV3Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolLeagueV4, LolLeagueV4Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolMatchV5, LolMatchV5Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolSpectatorV5, LolSpectatorV5Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolStatusV4, LolStatusV4Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolSummonerV4, LolSummonerV4Endpoint>());

        services.TryAdd(ServiceDescriptor.Singleton<ILorMatchV1, LorMatchV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILorRankedV1, LorRankedV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILorStatusV1, LorStatusV1Endpoint>());

        services.TryAdd(ServiceDescriptor.Singleton<IRiotAccountV1, RiotAccountV1Endpoint>());

        services.TryAdd(ServiceDescriptor.Singleton<ITftLeagueV1, TftLeagueV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ITftMatchV1, TftMatchV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolSpectatorTftV5, LolSpectatorTftV5Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ITftStatusV1, TftStatusV1Endpoint>());
        services.TryAdd(ServiceDescriptor.Singleton<ITftSummonerV1, TftSummonerV1Endpoint>());

        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
