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

    public string GetImageUrl(SkinDto skin, ChampionImageType imageType)
    {
        ArgumentNullException.ThrowIfNull(skin);
        var type = imageType switch
        {
            ChampionImageType.Centered => "centered",
            ChampionImageType.Loading => "loading",
            ChampionImageType.Splash => "splash",
            ChampionImageType.Tiles => "tiles",
            _ => throw new ArgumentOutOfRangeException(nameof(imageType))
        };
        return $"cdn/img/champion/{type}/{Id}_{skin.Num}.jpg";
    }
}
