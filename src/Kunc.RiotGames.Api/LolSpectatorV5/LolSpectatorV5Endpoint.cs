using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSpectatorV5;

public class LolSpectatorV5Endpoint : ApiEndpoint, ILolSpectatorV5
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorV5Endpoint"/> class.
    /// </summary>
    public LolSpectatorV5Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<CurrentGameInfoDto?> GetCurrentGameInformationForPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/spectator/v5/active-games/by-summoner/{encryptedPUUID}",
            Path = $"/lol/spectator/v5/active-games/by-summoner/{puuid}",
        };
        return await _client.SendAndDeserializeAsync<CurrentGameInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FeaturedGamesDto> GetFeaturedGamesAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/spectator/v5/featured-games",
            Path = $"/lol/spectator/v5/featured-games",
        };
        var data = await _client.SendAndDeserializeAsync<FeaturedGamesDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
