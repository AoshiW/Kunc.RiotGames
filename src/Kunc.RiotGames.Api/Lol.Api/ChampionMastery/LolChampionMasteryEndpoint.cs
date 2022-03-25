using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.ChampionMastery;

/// <inheritdoc cref="ILolChampionMasteryV4"/>
public class LolChampionMasteryEndpoint : ILolChampionMasteryV4
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionMasteryEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolChampionMasteryEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChampionMastery[]> GetAllChampionMasteriesAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}");
        var result = await _client.SendAndDeserializeAsync<ChampionMastery[]>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return result!;
    }

    /// <inheritdoc/>
    public async Task<ChampionMastery?> GetChampionMasteriesAsync(Platform routing, string encryptedSummonerId, long championID, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/by-champion/{championID}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/by-champion/{championID}");
        return await _client.SendAndDeserializeAsync<ChampionMastery>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<int> GetTotalMasteryPointAsync(Platform routing, string encryptedSummonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}");
        return await _client.SendAndDeserializeAsync<int>(routing.ToLowerString(), requestFunc, methodId, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}