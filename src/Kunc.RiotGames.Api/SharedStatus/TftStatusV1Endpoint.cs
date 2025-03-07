using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;

public class TftStatusV1Endpoint : EndpointBase, ITftStatusV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftStatusV1Endpoint"/> class.
    /// </summary>
    public TftStatusV1Endpoint(IServiceProvider service) : base(service)
    { }

    /// <inheritdoc/>
    public async Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = MethodId.Tft_StatusV1_PlatformData,
            Path = $"/tft/status/v1/platform-dataa",
        };
        var data = await SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
