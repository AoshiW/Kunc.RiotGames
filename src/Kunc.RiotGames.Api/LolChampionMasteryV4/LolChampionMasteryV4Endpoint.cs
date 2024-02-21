using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class LolChampionMasteryV4Endpoint : ILolChampionMasteryV4
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionMasteryV4Endpoint"/> class.
    /// </summary>
    public LolChampionMasteryV4Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto[]> GetAllChampionMasteryEntriesAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto?> GetChampionMasteryByPuuidAsync(string region, string puuid, long championId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}/by-champion/{championId}",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/by-champion/{championId}",
        };
        return await _client.SendAndDeserializeAsync<ChampionMasteryDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto[]> GetTopChampionMasteryEntriesAsync(string region, string puuid, TopChampionMasteryEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}/top",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/top",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<int> GetPlayersTotalChampionMasteryScoreAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/scores/by-puuid/{encryptedPUUID}",
            Path = $"/lol/champion-mastery/v4/scores/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<int>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
