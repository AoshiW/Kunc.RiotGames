using Kunc.RiotGames.Extensions;
using Kunc.RiotGames.Lol.Api.Summoner;

namespace Kunc.RiotGames.Tft.Api.Summoner;

/// <inheritdoc cref="ITftSummonerV1"/>
public class TftSummonerEndpoint : ITftSummonerV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TftSummonerEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public TftSummonerEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerByAccountIDAsync(Platform routing, string encryptedAccountID, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/summoner/v1/summoners/by-account/{encryptedAccountId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/summoner/v1/summoners/by-account/{encryptedAccountID}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerBySummonerNameAsync(Platform routing, string summonerName, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/summoner/v1/summoners/by-name/{summonerName}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/summoner/v1/summoners/by-name/{summonerName}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerByPuuidAsync(Platform routing, string encryptedPUUID, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/summoner/v1/summoners/by-puuid/{encryptedPUUID}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/summoner/v1/summoners/by-puuid/{encryptedPUUID}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerBySummonerIDAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/tft/summoner/v1/summoners/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/tft/summoner/v1/summoners/{encryptedSummonerId}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    private async Task<SummonerDto?> GetSummonerAsync(Platform routing, Func<HttpRequestMessage> request, string methodId, CancellationToken cancellationToken)
    {
        var summoner = await _client.SendAndDeserializeAsync<SummonerDto>(routing.ToLowerString(), request, methodId, cancellationToken).ConfigureAwait(false);
        if (summoner is not null)
        {
            summoner.SetPlatform(routing); 
        }
        return summoner;
    }
}
