using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

public record SummonerSpell : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("tooltip")]
    public string ToolTip { get; init; } = default!;

    [JsonPropertyName("maxrank")]
    public int MaxRank { get; init; }

    [JsonPropertyName("cooldown")]
    public int[] Cooldown { get; init; } = default!;

    [JsonPropertyName("cooldownBurn")]
    public string CooldownBurn { get; init; } = default!;

    [JsonPropertyName("cost")]
    public int[] Cost { get; init; } = default!;

    [JsonPropertyName("costBurn")]
    public string CostBurn { get; init; } = default!;

    [JsonPropertyName("datavalues")]
    public DataValues DataValues { get; init; } = default!;

    [JsonPropertyName("effect")]
    public double[]?[] Effect { get; set; } = default!;

    [JsonPropertyName("effectBurn")]
    public string?[] EffectBurn { get; set; } = default!;

    [JsonPropertyName("vars")]
    public object[] Vars { get; set; } = default!;

    [JsonPropertyName("key")]
    public string Key { get; set; } = default!;

    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }

    [JsonPropertyName("modes")]
    public string[] Modes { get; set; } = default!;

    [JsonPropertyName("costType")]
    public string CostType { get; set; } = default!;

    [JsonPropertyName("maxammo")]
    public string Maxammo { get; set; } = default!;

    [JsonPropertyName("range")]
    public int[] Range { get; set; } = default!;

    [JsonPropertyName("rangeBurn")]
    public string RangeBurn { get; set; } = default!;

    [JsonPropertyName("image")]
    public Image Image { get; set; } = default!;

    [JsonPropertyName("resource")]
    public string Resource { get; set; } = default!;
}
