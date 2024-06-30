using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class TftMatchV1Endpoint : ApiEndpoint, ITftMatchV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftMatchV1Endpoint"/> class.
    /// </summary>
    public TftMatchV1Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<string[]> GetMatchIdsAsync(string region, string puuid, MatchIdsQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Path = $"/tft/match/v1/matches/by-puuid/{puuid}/ids",
            Query = query,
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
            MethodId = "/tft/match/v1/matches/{matchId}",
            Path = $"/tft/match/v1/matches/{matchId}",
        };
        return await Client.SendAndDeserializeAsync<MatchDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
