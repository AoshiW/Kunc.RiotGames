using Kunc.RiotGames.Api.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api;

public abstract class ApiEndpoint
{
    protected readonly IRiotGamesApiClient Client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiEndpoint"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    protected ApiEndpoint(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Client = services.GetRequiredService<IRiotGamesApiClient>();
    }
}
