using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSummonerV4;

public class LolSummonerV4Endpoint : ILolSummonerV4
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolSummonerV4Endpoint"/> class.
    /// </summary>
    public LolSummonerV4Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}",
            Path = $"/lol/summoner/v4/summoners/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/summoner/v4/summoners/{encryptedSummonerId}",
            Path = $"/lol/summoner/v4/summoners/{summonerId}",
        };
        return await _client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
