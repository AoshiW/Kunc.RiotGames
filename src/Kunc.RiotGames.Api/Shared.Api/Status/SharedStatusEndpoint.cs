namespace Kunc.RiotGames.Shared.Api.Status;

/// <inheritdoc cref="ISharedStatus"/>
public class SharedStatusEndpoint : ISharedStatus
{
    private readonly string _statusUrl;
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="SharedStatusEndpoint"/>.
    /// </summary>
    public SharedStatusEndpoint(RiotGamesApiClient client, string game)
    {
        _client = client;
        _statusUrl = game;
    }

    /// <inheritdoc/>
    public async Task<PlatformData> GetStatusAsync(string region, CancellationToken cancellationToken)
    {
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, _statusUrl);
        var platformData = await _client.SendAndDeserializeAsync<PlatformData>(region, requestFunc, _statusUrl, cancellationToken).ConfigureAwait(false);
        return platformData!;
    }
}
