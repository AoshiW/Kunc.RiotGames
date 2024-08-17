using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

public class MatchDto : BaseDto
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
    public InfoDto Info { get; set; } = new();
}
