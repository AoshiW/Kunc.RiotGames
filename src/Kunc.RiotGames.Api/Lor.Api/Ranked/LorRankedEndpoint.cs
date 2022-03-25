using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lor.Api.Ranked;

/// <inheritdoc cref="ILorRankedV1"/>
public class LorRankedEndpoint : ILorRankedV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LorRankedEndpoint"/>.
    /// </summary>
    public LorRankedEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Leaderboard> GetLeaderboardAsync(Region routing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lor/ranked/v1/leaderboards";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/lor/ranked/v1/leaderboards");
        var leaderboard =  await _client.SendAndDeserializeAsync<Leaderboard>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return leaderboard!;
    }
}
