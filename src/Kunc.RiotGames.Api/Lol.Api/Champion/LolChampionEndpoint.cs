using Kunc.RiotGames.Extensions;

namespace Kunc.RiotGames.Lol.Api.Champion;

/// <inheritdoc cref="ILolChampionV3"/>
public class LolChampionEndpoint : ILolChampionV3
{
    private readonly RiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionEndpoint"/> class with the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException">If <paramref name="client"/> is null.</exception>
    public LolChampionEndpoint(RiotGamesApiClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChampionRotation> GetSummonerByAccountIDAsync(Platform rouing, CancellationToken cancellationToken = default)
    {
        const string methodId = "/lol/platform/v3/champion-rotations";
        var requestFunc = () => new HttpRequestMessage(HttpMethod.Get, "/lol/platform/v3/champion-rotations");
        var rotation = await _client.SendAndDeserializeAsync<ChampionRotation>(rouing.ToLowerString(), requestFunc, methodId, cancellationToken).ConfigureAwait(false);
        return rotation!;
    }
}