using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Champion : ChampionBase
{
    [JsonPropertyName("skins")]
    public Skin[] Skins { get; init; } = default!;

    [JsonPropertyName("lore")]
    public string Lore { get; init; } = default!;

    [JsonPropertyName("allytips")]
    public string[] AllyTips { get; init; } = default!;

    [JsonPropertyName("enemytips")]
    public string[] EnemyTips { get; init; } = default!;

    [JsonPropertyName("spells")]
    public Spell[] Spells { get; init; } = default!;

    [JsonPropertyName("passive")]
    public Passive Passive { get; init; } = default!;

    [JsonPropertyName("recommended")]
    public Recommended[]? Recommended { get; init; }
}
