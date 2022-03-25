using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record MatchMetadata : BaseDto
{
    /// <summary>
    /// Match data version.
    /// </summary>
    [JsonPropertyName("dataVersion")]
    public string DataVersion { get; init; } = default!;

    /// <summary>
    /// Match id.
    /// </summary>
    [JsonPropertyName("matchId")]
    public string MatchId { get; init; } = default!;

    /// <summary>
    /// A list of participant PUUIDs.
    /// </summary>
    [JsonPropertyName("participants")]
    public string[] Participants { get; init; } = default!;
}
