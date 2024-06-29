using Kunc.RiotGames.Api.Http;

namespace Kunc.RiotGames.Api.SharedStatus;

public class LorStatusV1Endpoint : ApiEndpoint, ILorStatusV1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LorStatusV1Endpoint"/> class.
    /// </summary>
    public LorStatusV1Endpoint(IServiceProvider services) : base(services)
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
            MethodId = "/lor/status/v1/platform-data",
            Path = $"/lor/status/v1/platform-data",
        };
        var data = await _client.SendAndDeserializeAsync<PlatformDataDto>(request, RiotRequestOptions.Default, cancellationToken).ConfigureAwait(false);
        return data!;
    }
}
