using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class LorMatchV1Endpoint : EndpointBase, ILorMatchV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LorMatchV1Endpoint"/> class.
    /// </summary>
    public LorMatchV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<string[]> GetMatchIdsAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lor_MatchV1_MatchIds,
            Path = $"/lor/match/v1/matches/by-puuid/{puuid}/ids",
        };
        var data = await SendAndDeserializeAsync<string[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lor_MatchV1_Match,
            Path = $"/lor/match/v1/matches/{matchId}",
        };
        return await SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
