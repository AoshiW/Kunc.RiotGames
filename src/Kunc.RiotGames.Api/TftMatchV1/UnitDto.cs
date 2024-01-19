using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class UnitDto : BaseDto
{
    /// <summary>
    /// A list of the unit's items. Please refer to the Teamfight Tactics documentation for item ids.
    /// </summary>
    [JsonPropertyName("itemNames")]
    public string[] ItemNames { get; set; } = [];

    [JsonPropertyName("character_id")]
    public string CharacterId { get; set; } = string.Empty;

    /// <summary>
    /// Unit rarity.This doesn't equate to the unit cost.
    /// </summary>
    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    /// <summary>
    /// Unit tier.
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier { get; set; }
}
