using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class PerksDto : BaseDto
{
    /// <summary>
    /// IDs of the perks/runes assigned.
    /// </summary>
    [JsonPropertyName("perkIds")]
    public long[] PerkIds { get; set; } = [];

    /// <summary>
    /// Primary runes path
    /// </summary>
    [JsonPropertyName("perkStyle")]
    public long PerkStyle { get; set; }

    /// <summary>
    /// Secondary runes path
    /// </summary>
    [JsonPropertyName("perkSubStyle")]
    public long PerkSubStyle { get; set; }
}

