using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChampionV3;

public class LolChampionV3Endpoint : ILolChampionV3
{
    private readonly IRiotGamesApiClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ILolChampionV3Endpoint"/> class.
    /// </summary>
    public LolChampionV3Endpoint(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChampionInfoDto> GetChampionFreeRotationsAsync(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/lol/platform/v3/champion-rotations",
            Path = "/lol/platform/v3/champion-rotations",
        };
        return await _client.SendAndDeserializeAsync<ChampionInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
    }
}
