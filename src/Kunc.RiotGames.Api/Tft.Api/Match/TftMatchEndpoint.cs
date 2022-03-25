using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Tft.Api.Match;

/// <inheritdoc cref="ITftMatchV1"/>
public class TftMatchEndpoint : ITftMatchV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftMatchEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public TftMatchEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<string[]> GetListOfMatcIdsAsync(Region routing, string puuid, int? count = null, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/match/v1/matches/by-puuid/{puuid}/ids";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/match/v1/matches/by-puuid/{puuid}/ids{(count is null ? string.Empty : $"?count={count}")}");
        var matchIds = await _client.SendAndDeserializeAsync<string[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return matchIds!;
    }

    /// <inheritdoc/>
    public async Task<Match?> GetMatchAsync(Region routing, string matchId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/match/v1/matches/{matchId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/match/v1/matches/{matchId}");
        return await _client.SendAndDeserializeAsync<Match>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }
}
