using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.SummonerSpell;

public class SummonerSpellDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("tooltip")]
    public string Tooltip { get; set; } = string.Empty;

    [JsonPropertyName("maxrank")]
    public int MaxRank { get; set; }

    //todo => TimeSpan[]
    [JsonPropertyName("cooldown")]
    public double[] Cooldown { get; set; } = [];

    [JsonPropertyName("cooldownBurn")]
    public string CooldownBurn { get; set; } = string.Empty;

    [JsonPropertyName("cost")]
    public int[] Cost { get; set; } = [];

    [JsonPropertyName("costBurn")]
    public string CostBurn { get; set; } = string.Empty;

    // todo
    [JsonPropertyName("datavalues")]
    public JsonElement Datavalues { get; set; }

    [JsonPropertyName("effect")]
    public double[]?[] Effect { get; set; } = [];

    [JsonPropertyName("effectBurn")]
    public string?[] EffectBurn { get; set; } = [];

    [JsonPropertyName("vars")]
    public JsonElement[] Vars { get; set; } = [];

    //todo? => int
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }

    //todo => GameMode
    [JsonPropertyName("modes")]
    public string[] Modes { get; set; } = [];

    [JsonPropertyName("costType")]
    public string CostType { get; set; } = string.Empty;

    //todo? => int
    [JsonPropertyName("maxammo")]
    public string Maxammo { get; set; } = string.Empty;

    [JsonPropertyName("range")]
    public int[] Range { get; set; } = [];

    //todo => int
    [JsonPropertyName("rangeBurn")]
    public string RangeBurn { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();

    [JsonPropertyName("resource")]
    public string Resource { get; set; } = string.Empty;
}
