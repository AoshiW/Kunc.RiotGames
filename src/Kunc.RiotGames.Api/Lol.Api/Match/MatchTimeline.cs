using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record MatchTimeline : BaseDto
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public MatchMetadata Metadata { get; init; } = default!;

    /// <summary>
    /// Match timeline info.
    /// </summary>
    [JsonPropertyName("info")]
    public InfoTimeline Info { get; init; } = default!;
}
