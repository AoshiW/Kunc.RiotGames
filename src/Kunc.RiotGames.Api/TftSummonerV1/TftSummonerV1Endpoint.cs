using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.TftSummonerV1;

public class TftSummonerV1Endpoint : EndpointBase, ITftSummonerV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftSummonerV1Endpoint"/> class.
    /// </summary>
    public TftSummonerV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_SummonerV1_ByPuuid,
            Path = $"/tft/summoner/v1/summoners/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_SummonerV1_BySummonerId,
            Path = $"/tft/summoner/v1/summoners/{summonerId}",
        };
        var data = await SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data;
    }
}
