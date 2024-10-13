using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

/// <summary>
/// Extension methods for setting up Lol LeagueClientUpdate in an <see cref="IServiceCollection" />.
/// </summary>
public static class LolLeagueClientUpdateServiceCollectionExtensions
{
    /// <summary>
    /// Adds Lol LeagueClientUpdate to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="Action{LolLeagueClientUpdateOptions}"/> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLolLeagueClientUpdate(this IServiceCollection services, Action<LolLeagueClientUpdateOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddOptions();
        services.TryAdd(ServiceDescriptor.Singleton<IWamp, Wamp>());
        services.TryAdd(ServiceDescriptor.Singleton<ILockfileProvider, FileLockfileProvider>());
        services.TryAdd(ServiceDescriptor.Singleton<ILolLeagueClientUpdate, LolLeagueClientUpdate>());
        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
