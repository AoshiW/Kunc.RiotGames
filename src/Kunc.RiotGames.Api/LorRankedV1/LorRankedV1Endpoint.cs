using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LorRankedV1;

public class LorRankedV1Endpoint : ApiEndpoint, ILorRankedV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LorRankedV1Endpoint"/> class.
    /// </summary>
    public LorRankedV1Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/> 
    public async Task<LeaderboardDto> GetLeaderboardAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lor/ranked/v1/leaderboards",
            Path = "/lor/ranked/v1/leaderboards",
        };
        var data = await Client.SendAndDeserializeAsync<LeaderboardDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
