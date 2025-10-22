using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Api.LolSpectatorV5;

namespace Kunc.RiotGames.Api.LolSpectatorTftV5;

public class LolSpectatorTftV5Endpoint : EndpointBase, ILolSpectatorTftV5
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorTftV5Endpoint"/> class.
    /// </summary>
    public LolSpectatorTftV5Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<CurrentGameInfoDto?> GetCurrentGameInformationForPuuidAsync(string region, string puuid, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);
        ArgumentException.ThrowIfNullOrEmpty(puuid);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_SpectatorTftV5_ActiveGame,
            Path = $"/lol/spectator/tft/v5/active-games/by-puuid/{puuid}",
        };
        return await SendAndDeserializeAsync<CurrentGameInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
