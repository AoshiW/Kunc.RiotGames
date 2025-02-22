using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class CompanionDto : BaseDto
{
    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    [JsonPropertyName("content_ID")]
    public string ContentId { get; set; } = string.Empty;

    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    [JsonPropertyName("item_ID")]
    public int ItemId { get; set; }

    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    [JsonPropertyName("skin_ID")]
    public int SkinId { get; set; }

    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    [JsonPropertyName("species")]
    public string Species { get; set; } = string.Empty;
}
