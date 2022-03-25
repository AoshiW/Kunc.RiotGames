using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lor.Api.Match;

/// <inheritdoc cref="ILorMatchV1"/>
public class LorMatchEndpoint : ILorMatchV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LorMatchEndpoint"/>.
    /// </summary>
    public LorMatchEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetListOfMatchIdsAsync(Region routing, string puuid, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lor/match/v1/matches/by-puuid/{puuid}/ids";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lor/match/v1/matches/by-puuid/{puuid}/ids");
        var matchIds = await _client.SendAndDeserializeAsync<string[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return matchIds!;
    }

    /// <inheritdoc/>   
    public async Task<Match?> GetMatchAsync(Region routing, string matchId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lor/match/v1/matches/{matchId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lor/match/v1/matches/{matchId}");
        return await _client.SendAndDeserializeAsync<Match>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }
}
