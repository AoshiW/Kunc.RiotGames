using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.RiotAccountV1;

public class AccountRegionDto :BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("game")]
    public Game Game { get; set; }
    
    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;
}
