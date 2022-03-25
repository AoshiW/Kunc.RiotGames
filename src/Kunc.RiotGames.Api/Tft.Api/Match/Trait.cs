using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Trait : BaseDto
{
    /// <summary>
    /// Trait name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// Number of units with this trait.
    /// </summary>
    [JsonPropertyName("num_units")]
    public int NumUnits { get; init; }

    /// <summary>
    /// Current style for this trait
    /// </summary>
    [JsonPropertyName("style")]
    public TraitStyle Style { get; init; }

    /// <summary>
    /// Current active tier for the trait.
    /// </summary>
    [JsonPropertyName("tier_current	")]
    public int TierCurrent { get; init; }

    /// <summary>
    /// Total tiers for the trait.
    /// </summary>
    [JsonPropertyName("tier_total")]
    public int TierTotal { get; init; }
}
