using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class TftMatchV1Endpoint : EndpointBase, ITftMatchV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftMatchV1Endpoint"/> class.
    /// </summary>
    public TftMatchV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<string[]> GetMatchIdsAsync(string region, string puuid, MatchIdsQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_MatchV1_MatchIds,
            Path = $"/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Query = query,
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
            MethodId = MethodId.Tft_MatchV1_Match,
            Path = $"/tft/match/v1/matches/{matchId}",
        };
        return await SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
