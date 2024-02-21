using Kunc.RiotGames.Api.Http;
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
        services.TryAdd(ServiceDescriptor.Singleton<IRiotGamesApi, RiotGamesApi>());
        services.TryAdd(ServiceDescriptor.Singleton<IRiotGamesApiClient, RiotGamesApiClient>());
        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
