using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Shared.Api.Account;

/// <inheritdoc cref="IRiotAccountV1"/>
public class RiotAccountEndpoint : IRiotAccountV1
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotAccountEndpoint"/>.
    /// </summary>
    public RiotAccountEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Account> GetAccountAsync(Region routing, string puuid, CancellationToken cancellationToken)
    {
        const string methodId = "/riot/account/v1/accounts/by-puuid/{puuid}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/riot/account/v1/accounts/by-puuid/{puuid}");
        var account = await _client.SendAndDeserializeAsync<Account>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return account!;
    }

    /// <inheritdoc/>
    public async Task<Account?> GetAccountAsync(Region routing, string gameName, string tagLine, CancellationToken cancellationToken)
    {
        const string methodId = "/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
        return await _client.SendAndDeserializeAsync<Account>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ActiveShardDto<T>> GetActiveShardAsync<T>(Region routing, Game game, string puuid, CancellationToken cancellationToken)
    {
        const string methodId = "/riot/account/v1/active-shards/by-game/{game}/by-puuid/{puuid}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/riot/account/v1/active-shards/by-game/{game.ToLowerString()}/by-puuid/{puuid}");
        var activeSard = await _client.SendAndDeserializeAsync<ActiveShardDto<T>>(routing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return activeSard!;
    } 
}
