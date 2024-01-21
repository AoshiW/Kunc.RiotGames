using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MetadataDto : BaseDto
{
    /// <summary>
    /// Match data version.
    /// </summary>
    [JsonPropertyName("dataVersion")]
    public string DataVersion { get; set; } = string.Empty;

    /// <summary>
    /// Match id.
    /// </summary>
    [JsonPropertyName("matchId")]
    public string MatchId { get; set; } = string.Empty;

    /// <summary>
    /// A list of participant PUUIDs.
    /// </summary>
    [JsonPropertyName("participants")]
    public string[] Participants { get; set; } = [];
}
