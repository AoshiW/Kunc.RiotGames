using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.RiotAccountV1;

public class RiotAccountV1Endpoint : IRiotAccountV1
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotAccountV1Endpoint"/> class.
    /// </summary>
    public RiotAccountV1Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AccountDto> GetAccountByPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/riot/account/v1/accounts/by-puuid/{puuid}",
            Path = $"/riot/account/v1/accounts/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<AccountDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountDto?> GetAccountByRiotIdAsync(string region, string gameName, string tagLine, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(gameName);
        ArgumentNullException.ThrowIfNull(tagLine);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}",
            Path = $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}",
        };
        return await _client.SendAndDeserializeAsync<AccountDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ActiveShardDto> GetActiveShardForPlayerAsync(string region, Game game, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/riot/account/v1/active-shards/by-game/{game}/by-puuid/{puuid}",
            Path = $"/riot/account/v1/active-shards/by-game/{game.ToLowerString()}/by-puuid/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<ActiveShardDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
