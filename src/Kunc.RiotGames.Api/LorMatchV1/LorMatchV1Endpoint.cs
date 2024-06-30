using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class LorMatchV1Endpoint : ApiEndpoint, ILorMatchV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LorMatchV1Endpoint"/> class.
    /// </summary>
    public LorMatchV1Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<string[]> GetMatchIdsAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lor/match/v1/matches/by-puuid/{puuid}/ids",
            Path = $"/lor/match/v1/matches/by-puuid/{puuid}/ids",
        };
        var data = await Client.SendAndDeserializeAsync<string[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
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
            MethodId = "/lor/match/v1/matches/{matchId}",
            Path = $"/lor/match/v1/matches/{matchId}",
        };
        return await Client.SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
