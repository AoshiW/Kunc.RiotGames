using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class ChampionDto : ChampionBaseDto
{
    [JsonPropertyName("skins")]
    public SkinDto[] Skins { get; set; } = [];

    [JsonPropertyName("lore")]
    public string Lore { get; set; } = string.Empty;

    [JsonPropertyName("allytips")]
    public string[] AllyTips { get; set; } = [];

    [JsonPropertyName("enemytips")]
    public string[] EnemyTips { get; set; } = [];

    [JsonPropertyName("spells")]
    public SpellDto[] Spells { get; set; } = [];

    [JsonPropertyName("passive")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public PassiveDto Passive { get; set; } = new();

    [JsonPropertyName("recommended")]
    public JsonElement[] Recommended { get; set; } = [];
}
