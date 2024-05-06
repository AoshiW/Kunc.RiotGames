namespace Kunc.RiotGames.Api.Http;

public class RiotRequestMessage
{
    public required HttpMethod HttpMethod { get; set; }
    public required string MethodId { get; set; }
    public required string Host { get; set; }
    public required string Path { get; set; }
    public QueryString? Query { get; set; }

    internal HttpRequestMessage ToHttpRequestMessage()
    {
        return new()
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
}
