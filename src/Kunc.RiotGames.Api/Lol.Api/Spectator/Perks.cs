using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record Perks : BaseDto
{
    /// <summary>
    /// IDs of the perks/runes assigned..
    /// </summary>
    [JsonPropertyName("perkIds")]
    public long[] PerkIds { get; set; } = default!;

    /// <summary>
    /// Primary runes path.
    /// </summary>
    [JsonPropertyName("perkStyle")]
    public long PerkStyle { get; init; }

    /// <summary>
    /// Secondary runes path.
    /// </summary>
    [JsonPropertyName("perkSubStyle")]
    public long PerkSubStyle { get; init; }
}