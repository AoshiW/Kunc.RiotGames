using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class MetadataDto : BaseDto
{
    /// <summary>
    /// Match data version.
    /// </summary>
    [JsonPropertyName("data_version")]
    public string DataVersion { get; set; } = string.Empty;

    /// <summary>
    /// Match id.
    /// </summary>
    [JsonPropertyName("match_id")]
    public string MatchId { get; set; } = string.Empty;

    /// <summary>
    /// A list of participant PUUIDs.
    /// </summary>
    [JsonPropertyName("participants")]
    public string[] Participants { get; set; } = [];
}
