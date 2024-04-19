using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class TraitDto : BaseDto
{
    /// <summary>
    /// Trait name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Number of units with this trait.
    /// </summary>
    [JsonPropertyName("num_units")]
    public int NumUnits { get; set; }

    /// <summary>
    /// Current style for this trait.
    /// </summary>
    [JsonPropertyName("style")]
    public TraitStyle Style { get; set; }

    /// <summary>
    /// Current active tier for the trait.
    /// </summary>
    [JsonPropertyName("tier_current")]
    public int TierCurrent { get; set; }

    /// <summary>
    /// Total tiers for the trait.
    /// </summary>
    [JsonPropertyName("tier_total")]
    public int TierTotal { get; set; }
}
