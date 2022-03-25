using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.Summoner;

/// <inheritdoc cref="ILolSummonerV4"/>
public class LolSummonerEndpoint : ILolSummonerV4
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolSummonerEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolSummonerEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerByAccountIDAsync(Platform routing, string encryptedAccountID, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/summoner/v4/summoners/by-account/{encryptedAccountID}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/summoner/v4/summoners/by-account/{encryptedAccountID}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerBySummonerNameAsync(Platform routing, string summonerName, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/summoner/v4/summoners/by-name/{summonerName}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/summoner/v4/summoners/by-name/{summonerName}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerByPuuidAsync(Platform routing, string encryptedPUUID, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}");
        return await GetSummonerAsync(routing, requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SummonerDto?> GetSummonerBySummonerIDAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/summoner/v4/summoners/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/summoner/v4/summoners/{encryptedSummonerId}");
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
