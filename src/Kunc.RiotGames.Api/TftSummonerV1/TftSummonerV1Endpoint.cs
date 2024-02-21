using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.TftSummonerV1;

public class TftSummonerV1Endpoint : ITftSummonerV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftSummonerV1Endpoint"/> class.
    /// </summary>
    public TftSummonerV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/summoner/v1/summoners/by-puuid/{encryptedPUUID}",
            Path = $"/tft/summoner/v1/summoners/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto> GetSummonerBySummonerIdAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/summoner/v1/summoners/{encryptedSummonerId}",
            Path = $"/tft/summoner/v1/summoners/{summonerId}",
        };
        return await _client.SendAndDeserializeAsync<SummonerDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
