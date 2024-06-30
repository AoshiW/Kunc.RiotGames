using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.LolChampionV3;

public class LolChampionV3Endpoint : ApiEndpoint, ILolChampionV3
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolChampionV3Endpoint"/> class.
    /// </summary>
    public LolChampionV3Endpoint(IServiceProvider services) : base(services)
    {
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
        var data = await Client.SendAndDeserializeAsync<ChampionInfoDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
