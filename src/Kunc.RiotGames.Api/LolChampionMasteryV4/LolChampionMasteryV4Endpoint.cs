using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class LolChampionMasteryV4Endpoint : ApiEndpoint, ILolChampionMasteryV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionMasteryV4Endpoint"/> class.
    /// </summary>
    public LolChampionMasteryV4Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto[]> GetAllChampionMasteryEntriesAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}",
        };
        var data = await Client.SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto?> GetChampionMasteryByPuuidAsync(string region, string puuid, int championId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}/by-champion/{championId}",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/by-champion/{championId}",
        };
        return await Client.SendAndDeserializeAsync<ChampionMasteryDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto[]> GetTopChampionMasteryEntriesAsync(string region, string puuid, TopChampionMasteryEntriesQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{encryptedPUUID}/top",
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/top",
            Query = query,
        };
        var data = await Client.SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<int> GetPlayersTotalChampionMasteryScoreAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/champion-mastery/v4/scores/by-puuid/{encryptedPUUID}",
            Path = $"/lol/champion-mastery/v4/scores/by-puuid/{puuid}",
        };
        return await Client.SendAndDeserializeAsync<int>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
