using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record Spell : Passive
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("tooltip")]
    public string Tooltip { get; init; } = default!;

    [JsonPropertyName("leveltip")]
    public LevelTip? LevelTip { get; init; }

    [JsonPropertyName("maxrank")]
    public int MaxRank { get; init; }

    [JsonPropertyName("cooldown")]
    public double[] Cooldown { get; init; } = default!;

    [JsonPropertyName("cooldownBurn")]
    public string CooldownBurn { get; init; } = default!;

    [JsonPropertyName("cost")]
    public int[] Cost { get; init; } = default!;

    [JsonPropertyName("costBurn")]
    public string CostBurn { get; init; } = default!;

    [JsonPropertyName("datavalues")]
    public DataValues DataValues { get; init; } = default!;

    [JsonPropertyName("effect")]
    public double[]?[] Effect { get; init; } = default!;

    [JsonPropertyName("effectBurn")]
    public string?[] EffectBurn { get; init; } = default!;

    [JsonPropertyName("vars")] 
    public Var[] Vars { get; init; } = default!;

    [JsonPropertyName("costType")]
    public string CostType { get; init; } = default!;

    [JsonPropertyName("maxammo")]
    public string Maxammo { get; init; } = default!;

    [JsonPropertyName("range")]
    public int[] Range { get; init; } = default!;

    [JsonPropertyName("rangeBurn")]
    public string RangeBurn { get; init; } = default!;

    [JsonPropertyName("resource")]
    public string? Resource { get; init; }
}
