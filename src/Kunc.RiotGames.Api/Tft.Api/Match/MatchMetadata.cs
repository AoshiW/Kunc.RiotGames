using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.Match;

public record MatchMetadata : BaseDto 
{
    /// <summary>
    /// Match data version.
    /// </summary>
    [JsonPropertyName("data_version")]
    public string DataVersion { get; init; } = default!;

    /// <summary>
    /// Match id.
    /// </summary>
    [JsonPropertyName("match_id")]
    public string MatchId { get; init; } = default!;

    /// <summary>
    /// A list of participant PUUIDs.
    /// </summary>
    public string[] Participants { get; init; } = default!;
}
