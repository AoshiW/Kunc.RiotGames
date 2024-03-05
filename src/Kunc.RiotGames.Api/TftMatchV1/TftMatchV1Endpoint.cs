using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class TftMatchV1Endpoint : ITftMatchV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftMatchV1Endpoint"/> class.
    /// </summary>
    public TftMatchV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetListOfMatchIdsAsync(string region, string puuid, ListOfMatchIdsQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Path = $"/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<string[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(matchId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/match/v1/matches/{matchId}",
            Path = $"/tft/match/v1/matches/{matchId}",
        };
        return await _client.SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
