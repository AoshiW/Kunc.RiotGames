using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Options;
using Polly;

namespace Kunc.RiotGames.Lol.DataDragon;

/// <summary>
/// Extension methods for setting up LoL DataDragon an <see cref="IServiceCollection" />.
/// </summary>
public static class LolDataDragonServiceCollectionExtensions
{
    /// <summary>
    /// Adds LoL DataDragon to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="Action{LolDataDragonOptions}"/> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLolDataDragon(this IServiceCollection services, Action<LolDataDragonOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddOptions();
        services.AddHybridCache();
        services.TryAdd(ServiceDescriptor.Singleton<ILolDataDragon, LolDataDragon>());

        var client = services.AddHttpClient(LolDDConstants.Project, (s, c) =>
        {
            var options = s.GetRequiredService<IOptions<LolDataDragonOptions>>().Value;
            c.BaseAddress = new(options.BaseAdress);
        }).AddAsKeyed();
        client.AddResilienceHandler(LolDDConstants.Project, pipline =>
        {
            pipline.AddRetry(new HttpRetryStrategyOptions());
        });

        if (configure is not null)
        {
            services.Configure(configure);
        }
        return services;
    }
}
