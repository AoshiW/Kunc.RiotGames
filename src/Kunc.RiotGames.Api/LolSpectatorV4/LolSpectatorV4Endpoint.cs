using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class LolSpectatorV4Endpoint : ILolSpectatorV4
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorV4Endpoint"/> class.
    /// </summary>
    public LolSpectatorV4Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    public async Task<CurrentGameInfoDto?> GetCurrentGameInformationForSummonerAsync(string region, string summonerId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);
        ArgumentNullException.ThrowIfNull(summonerId);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}",
            Path = $"/lol/spectator/v4/active-games/by-summoner/{summonerId}",
        };
        return await _client.SendAndDeserializeAsync<CurrentGameInfoDto>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<FeaturedGameInfoDto> GetListOfFeaturedGamesAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/spectator/v4/featured-games",
            Path = $"/lol/spectator/v4/featured-games",
        };
        return await _client.SendAndDeserializeAsync<FeaturedGameInfoDto>(request, cancellationToken).ConfigureAwait(false);
    }
}
