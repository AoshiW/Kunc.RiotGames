using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Api.LolSpectatorV5;

namespace Kunc.RiotGames.Api.LolSpectatorTftV5;

public class LolSpectatorTftV5Endpoint : ILolSpectatorTftV5
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorTftV5Endpoint"/> class.
    /// </summary>
    public LolSpectatorTftV5Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
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
            MethodId = "/lol/spectator/tft/v5/active-games/by-puuid/{encryptedPUUID}",
            Path = $"/lol/spectator/tft/v5/active-games/by-puuid/{puuid}",
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
            MethodId = "/lol/spectator/tft/v5/featured-games",
            Path = $"/lol/spectator/tft/v5/featured-games",
        };
        var data = await _client.SendAndDeserializeAsync<FeaturedGamesDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
