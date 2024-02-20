using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class LolMatchV5Endpoint : ILolMatchV5
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolMatchV5Endpoint"/> class.
    /// </summary>
    public LolMatchV5Endpoint(IRiotGamesApiClient client)
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
            MethodId = "/lol/match/v5/matches/by-puuid/{puuid}/ids",
            Path = $"/lol/match/v5/matches/by-puuid/{puuid}/ids",
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
            MethodId = "/lol/match/v5/matches/{matchId}",
            Path = $"/lol/match/v5/matches/{matchId}",
        };
        return await _client.SendAndDeserializeAsync<MatchDto>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MatchTimelineDto?> GetMatchTimelineAsync(string region, string matchId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(matchId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/match/v5/matches/{matchId}/timeline",
            Path = $"/lol/match/v5/matches/{matchId}/timeline",
        };
        return await _client.SendAndDeserializeAsync<MatchTimelineDto>(request, cancellationToken).ConfigureAwait(false);
    }
}
