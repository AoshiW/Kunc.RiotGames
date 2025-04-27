using System.Diagnostics.CodeAnalysis;

namespace Kunc.RiotGames.Api.Http;

[Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.KNCRG0000)]
public class RequestInfo
{
    public static readonly HttpRequestOptionsKey<RequestInfo> HttpRequestOptionsKey = new("RequestInfo");

    public required string Host { get; set; }
    public required string MethodId { get; set; }
    public bool IncludeApiKey { get; set; } = true;
}
