using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;
public class TftStatusV1Endpoint : ITftStatusV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftStatusV1Endpoint"/> class.
    /// </summary>
    public TftStatusV1Endpoint(IRiotGamesApiClient client)
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
            MethodId = "/tft/status/v1/platform-data",
            Path = $"/tft/status/v1/platform-dataa",
        };
        var data = await _client.SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
