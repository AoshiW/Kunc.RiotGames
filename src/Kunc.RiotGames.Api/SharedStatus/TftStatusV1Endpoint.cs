using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;
public class TftStatusV1Endpoint : ApiEndpoint, ITftStatusV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TftStatusV1Endpoint"/> class.
    /// </summary>
    public TftStatusV1Endpoint(IServiceProvider services) : base(services)
    {
    }

    /// <inheritdoc/>
    public async Task<PlatformDataDto> GetStatus(string region, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(region);

        var request = new RiotRequestMessage()
        {
            HttpMethod = HttpMethod.Get,
            Host = region,
            MethodId = "/tft/status/v1/platform-data",
            Path = $"/tft/status/v1/platform-dataa",
        };
        var data = await Client.SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
