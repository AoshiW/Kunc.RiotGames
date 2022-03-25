using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Unit : BaseDto
{
    /// <summary>
    /// A list of the unit's items.
    /// </summary>
    [JsonPropertyName("items")]
    public int[] Items { get; init; } = default!;

    /// <summary>
    /// This field was introduced in patch 9.22 with data_version 2.
    /// </summary>
    [JsonPropertyName("character_id")]
    public string character_id { get; init; } = default!;

    /// <summary>
    /// If a unit is chosen as part of the Fates set mechanic, the chosen trait will be indicated by this field.
    /// </summary>
    [JsonPropertyName("chosen")]
    public string? Chosen { get; init; }

    /// <summary>
    /// Unit name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Unit rarity. This doesn't equate to the unit cost.
    /// </summary>
    [JsonPropertyName("rarity")]
    public int Rarity { get; init; }

    /// <summary>
    /// Unit tier.
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier { get; init; }
}
