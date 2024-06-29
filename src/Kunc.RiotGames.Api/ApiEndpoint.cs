using Kunc.RiotGames.Api.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api;

public abstract class ApiEndpoint
{
    protected readonly IServiceProvider _services;
    protected readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiEndpoint"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    protected ApiEndpoint(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        _services = services;
        _client = services.GetRequiredService<IRiotGamesApiClient>();
    }
}
