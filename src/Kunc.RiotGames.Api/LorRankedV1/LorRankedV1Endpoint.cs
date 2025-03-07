using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class LorRankedV1Endpoint : EndpointBase, ILorRankedV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LorRankedV1Endpoint"/> class.
    /// </summary>
    public LorRankedV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/> 
    public async Task<LeaderboardDto> GetLeaderboardAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lor_RankedV1_Leaderboard,
            Path = "/lor/ranked/v1/leaderboards",
        };
        var data = await SendAndDeserializeAsync<LeaderboardDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
