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
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLolLeagueClientUpdate(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILockfileProvider), typeof(FileLockfileProvider)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(ILolLeagueClientUpdate), typeof(LolLeagueClientUpdate)));
        return services;
    }
}
