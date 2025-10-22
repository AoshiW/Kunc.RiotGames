using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolSpectatorV5;

public class LolSpectatorV5Endpoint : EndpointBase, ILolSpectatorV5
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolSpectatorV5Endpoint"/> class.
    /// </summary>
    public LolSpectatorV5Endpoint(IServiceProvider service) : base(service)
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
            MethodId = MethodId.Lol_SpectatorV5_ActiveGame,
            Path = $"/lol/spectator/v5/active-games/by-summoner/{puuid}",
        };
        return await SendAndDeserializeAsync<CurrentGameInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
