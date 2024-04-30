using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class SpellDto : PassiveDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("tooltip")]
    public string Tooltip { get; set; } = string.Empty;

    [JsonPropertyName("leveltip")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public LeveltipDto Leveltip { get; set; } = new();

    [JsonPropertyName("maxrank")]
    public int MaxRank { get; set; }

    // todo => timespan
    [JsonPropertyName("cooldown")]
    public double[] Cooldown { get; set; } = [];

    [JsonPropertyName("cooldownBurn")]
    public string CooldownBurn { get; set; } = string.Empty;

    [JsonPropertyName("cost")]
    public int[] Cost { get; set; } = [];

    [JsonPropertyName("costBurn")]
    public string CostBurn { get; set; } = string.Empty;

    [JsonPropertyName("datavalues")]
    public JsonElement Datavalues { get; set; }

    [JsonPropertyName("effect")]
    public double[]?[] Effect { get; set; } = [];

    [JsonPropertyName("effectBurn")]
    public string?[] EffectBurn { get; set; } = [];

    [JsonPropertyName("vars")]
    public JsonElement[] Vars { get; set; } = [];

    [JsonPropertyName("costType")]
    public string CostType { get; set; } = string.Empty;

    [JsonPropertyName("maxammo")]
    public string Maxammo { get; set; } = string.Empty;

    [JsonPropertyName("range")]
    public double[] Range { get; set; } = [];

    [JsonPropertyName("rangeBurn")]
    public string RangeBurn { get; set; } = string.Empty;

    [JsonPropertyName("resource")]
    public string Resource { get; set; } = string.Empty;
}
