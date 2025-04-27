namespace Kunc.RiotGames.Api.Http;

public class RiotRequestMessage
{
    public required HttpMethod HttpMethod { get; set; }
    public required string MethodId { get; set; }
    public required string Host { get; set; }
    public required string Path { get; set; }
    public QueryString? Query { get; set; }

    internal HttpRequestMessage ToHttpRequestMessage(RiotRequestOptions options)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod,
            RequestUri = new UriBuilder()
            {
                Scheme = Uri.UriSchemeHttps,
                Host = $"{Host}.api.riotgames.com",
                Path = Path,
                Query = Query?.ToString(),
            }.Uri,
        };

        request.Options.Set(RequestInfo.HttpRequestOptionsKey, new()
        {
            Host = Host,
            MethodId = MethodId,
            IncludeApiKey = options.IncludeApiKey,
        });

        return request;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var url = new UriBuilder()
        {
            Scheme = Uri.UriSchemeHttps,
            Host = $"{Host}.api.riotgames.com",
            Path = Path,
            Query = Query?.ToString(),
        };
        return $"{HttpMethod} {url}";
    }

    internal string GetCacheKey()
    {
        return $"{Host}_{Path}{Query}";
    }
}
