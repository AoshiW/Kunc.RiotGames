using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSummonerV4;

public class LolSummonerV4Endpoint : EndpointBase, ILolSummonerV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolSummonerV4Endpoint"/> class.
    /// </summary>
    public LolSummonerV4Endpoint(IServiceProvider service) : base(service)
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
            MethodId = MethodId.Lol_SummonerV4_ByPuuid,
            Path = $"/lol/summoner/v4/summoners/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data;
    }
}
