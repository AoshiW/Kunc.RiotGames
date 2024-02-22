using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MatchTimelineDto : BaseDto
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public MetadataDto Metadata { get; set; } = new();

    /// <summary>
    /// Match info.
    /// </summary>
    [JsonPropertyName("info")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public InfoTimelineDto Info { get; set; } = new();
}
