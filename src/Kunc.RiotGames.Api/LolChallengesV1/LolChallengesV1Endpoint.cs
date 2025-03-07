using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class LolChallengesV1Endpoint : EndpointBase, ILolChallengesV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolChallengesV1Endpoint"/> class.
    /// </summary>
    public LolChallengesV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<ChallengeConfigInfoDto[]> GetListOfAllBasicChallengeConfigurationInformationAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_Config,
            Path = $"/lol/challenges/v1/challenges/config",
        };
        var data = await SendAndDeserializeAsync<ChallengeConfigInfoDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<long, Dictionary<string, double>>> GetMapOfLevelToPercentileOfPlayersAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_Percentiles,
            Path = $"/lol/challenges/v1/challenges/percentiles",
        };
        var data = await SendAndDeserializeAsync<Dictionary<long, Dictionary<string, double>>>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }

    /// <inheritdoc/>
    public async Task<ChallengeConfigInfoDto?> GetChallengeConfigurationAsync(string region, long challengeId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_Config_ById,
            Path = $"/lol/challenges/v1/challenges/{challengeId}/config",
        };
        return await SendAndDeserializeAsync<ChallengeConfigInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApexPlayerInfoDto[]?> GetTopPlayersAsync(string region, long challengeId, string level, TopPlayersQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(level);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_Leaderboards,
            Path = $"/lol/challenges/v1/challenges/{challengeId}/leaderboards/by-level/{level}",
            Query = query,
        };
        return await SendAndDeserializeAsync<ApexPlayerInfoDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, double>?> GetMapOfLevelToPercentileAsync(string region, long challengeId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_Percentiles_ById,
            Path = $"/lol/challenges/v1/challenges/{challengeId}/percentiles",
        };
        return await SendAndDeserializeAsync<Dictionary<string, double>>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlayerInfoDto> GetPlayerInformationAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_ChallengesV1_PlayerData,
            Path = $"/lol/challenges/v1/player-data/{puuid}",
        };
        var data = await SendAndDeserializeAsync<PlayerInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
