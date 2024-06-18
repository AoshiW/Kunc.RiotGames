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
        services.TryAdd(ServiceDescriptor.Singleton(typeof(IRiotGamesRateLimiter), typeof(RiotGamesRateLimiter)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(IRiotGamesApiClient), typeof(RiotGamesApiClient)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(IRiotGamesApi), typeof(RiotGamesApi)));

        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolClashV1), typeof(LolClashV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolChallengesV1), typeof(LolChallengesV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolChampionMasteryV4), typeof(LolChampionMasteryV4Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolChampionV3), typeof(LolChampionV3Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolLeagueV4), typeof(LolLeagueV4Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolMatchV5), typeof(LolMatchV5Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolSpectatorV5), typeof(LolSpectatorV5Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolStatusV4), typeof(LolStatusV4Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolSummonerV4), typeof(LolSummonerV4Endpoint)));

        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILorMatchV1), typeof(LorMatchV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILorRankedV1), typeof(LorRankedV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILorStatusV1), typeof(LorStatusV1Endpoint)));

        services.TryAdd(ServiceDescriptor.Singleton(typeof(IRiotAccountV1), typeof(RiotAccountV1Endpoint)));

        services.TryAdd(ServiceDescriptor.Singleton(typeof(ITftLeagueV1), typeof(TftLeagueV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ITftMatchV1), typeof(TftMatchV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolSpectatorTftV5), typeof(LolSpectatorTftV5Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ITftStatusV1), typeof(TftStatusV1Endpoint)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ITftSummonerV1), typeof(TftSummonerV1Endpoint)));

        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
