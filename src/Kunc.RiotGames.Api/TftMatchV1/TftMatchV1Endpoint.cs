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
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Path = $"/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<string[]>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MatchDto?> GetMatchAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(matchId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/match/v1/matches/{matchId}",
            Path = $"/tft/match/v1/matches/{matchId}",
        };
        return await _client.SendAndDeserializeAsync<MatchDto>(request, cancellationToken).ConfigureAwait(false);
    }
}
