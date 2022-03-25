using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.Spectator;

/// <inheritdoc cref="ILolSpectatorV4"/>
public class LolSpectatorEndpoint : ILolSpectatorV4
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolSpectatorEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<CurrentGameInfo?> GetCurrentGameInformationForSummonerAsync(Platform rouing, string encryptedSummonerId, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}");
        var result = await _client.SendAndDeserializeAsync<CurrentGameInfo>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return result;
    }

    /// <inheritdoc/>
    public async Task<FeaturedGames> GetFeaturedGamesAsync(Platform rouing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/spectator/v4/featured-games";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, $"/lol/spectator/v4/featured-games");
        var result = await _client.SendAndDeserializeAsync<FeaturedGames>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return result!;
    }
}

