using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;

public class LolStatusV4Endpoint : EndpointBase, ILolStatusV4
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LolStatusV4Endpoint"/> class.
    /// </summary>
    public LolStatusV4Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Lol_StatusV4_PlatformData,
            Path = $"/lol/status/v4/platform-data",
        };
        var data = await SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
