using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class LolChampionMasteryV4Endpoint : EndpointBase, ILolChampionMasteryV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionMasteryV4Endpoint"/> class.
    /// </summary>
    public LolChampionMasteryV4Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<ChampionMasteryDto[]> GetAllChampionMasteryEntriesAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChampionMasteryV4_ByPuuid,
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}",
        };
        var data = await SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ChampionMasteryV4_ByPuuid_ByChampion,
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/by-champion/{championId}",
        };
        return await SendAndDeserializeAsync<ChampionMasteryDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ChampionMasteryV4_ByPuuid_Top,
            Path = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/top",
            Query = query,
        };
        var data = await SendAndDeserializeAsync<ChampionMasteryDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
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
            MethodId = MethodId.Lol_ChampionMasteryV4_Score_ByPuuid,
            Path = $"/lol/champion-mastery/v4/scores/by-puuid/{puuid}",
        };
        return await SendAndDeserializeAsync<int>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
