using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class LorRankedV1Endpoint : ILorRankedV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LorRankedV1Endpoint"/> class.
    /// </summary>
    public LorRankedV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/> 
    public async Task<LeaderboardDto> GetLeaderboardAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lor/ranked/v1/leaderboards",
            Path = "/lor/ranked/v1/leaderboards",
        };
        return await _client.SendAndDeserializeAsync<LeaderboardDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
