using Kunc.RiotGames.Lor.DeckCodes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kunc.RiotGames.DependencyInjection;

/// <summary>
/// Extension methods for setting up <see cref="ILorDeckEncoder"/> service in an <see cref="IServiceCollection" />.
/// </summary>
public static class LorDeckCodesServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="ILorDeckEncoder"/> services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLorDeckCodes(this IServiceCollection services)
    {
        services.TryAddSingleton<ILorDeckEncoder>(new LorDeckEncoder(new()));
        return services;
    }
}
