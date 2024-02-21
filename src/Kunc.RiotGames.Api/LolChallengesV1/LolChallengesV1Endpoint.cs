using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class LolChallengesV1Endpoint : ILolChallengesV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolChallengesV1Endpoint"/> class.
    /// </summary>
    public LolChallengesV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChallengeConfigInfoDto[]> GetListOfAllBasicChallengeConfigurationInformationAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/challenges/config",
            Path = $"/lol/challenges/v1/challenges/config",
        };
        return await _client.SendAndDeserializeAsync<ChallengeConfigInfoDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<long, Dictionary<string, double>>> GetMapOfLevelToPercentileOfPlayersAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/challenges/percentiles",
            Path = $"/lol/challenges/v1/challenges/percentiles",
        };
        return await _client.SendAndDeserializeAsync<Dictionary<long, Dictionary<string, double>>>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChallengeConfigInfoDto?> GetChallengeConfigurationAsync(string region, long challengeId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/challenges/{challengeId}/config",
            Path = $"/lol/challenges/v1/challenges/{challengeId}/config",
        };
        return await _client.SendAndDeserializeAsync<ChallengeConfigInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApexPlayerInfoDto[]?> GetTopPlayersAsync(string region, long challengeId, string level, TopPlayersQuery? query = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(level);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/challenges/{challengeId}/leaderboards/by-level/{level}",
            Path = $"/lol/challenges/v1/challenges/{challengeId}/leaderboards/by-level/{level}",
            Query = query,
        };
        return await _client.SendAndDeserializeAsync<ApexPlayerInfoDto[]>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, double>?> GetMapOfLevelToPercentileAsync(string region, long challengeId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/challenges/{challengeId}/percentiles",
            Path = $"/lol/challenges/v1/challenges/{challengeId}/percentiles",
        };
        return await _client.SendAndDeserializeAsync<Dictionary<string, double>>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlayerInfoDto> GetPlayerInformationAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/challenges/v1/player-data/{puuid}",
            Path = $"/lol/challenges/v1/player-data/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<PlayerInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
