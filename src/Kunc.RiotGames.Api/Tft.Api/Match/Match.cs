using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Match : BaseDto
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MatchMetadata Metadata { get; init; }

    /// <summary>
    /// Match info.
    /// </summary>
    [JsonPropertyName("info")]
    public Info Info { get; init; }
}
