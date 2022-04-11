using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

public record Match : BaseDto
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MatchMetadata Metadata { get; init; } = default!;

    /// <summary>
    /// Match info.
    /// </summary>
    [JsonPropertyName("info")]
    public Info Info { get; init; } = default!;
}
