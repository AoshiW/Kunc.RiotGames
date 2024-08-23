using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Extension methods for setting up LoR GameClient in an <see cref="IServiceCollection" />.
/// </summary>
public static class LorGameClientServiceCollectionExtensions
{
    /// <summary>
    /// Adds LoR GameClient to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="Action{LorGameClientOptions}"/> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLorGameClient(this IServiceCollection services, Action<LorGameClientOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddOptions();
        services.TryAdd(ServiceDescriptor.Singleton<ILorGameClient, LorGameClient>());
        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
