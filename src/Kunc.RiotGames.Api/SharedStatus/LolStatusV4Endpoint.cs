using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;

public class LolStatusV4Endpoint : ILolStatusV4
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolStatusV4Endpoint"/> class.
    /// </summary>
    public LolStatusV4Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/status/v4/platform-data",
            Path = $"/lol/status/v4/platform-data",
        };
        return await _client.SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
