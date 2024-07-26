using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Item;

public class ItemDto : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("colloq")]
    public string Colloq { get; set; } = string.Empty;

    [JsonPropertyName("plaintext")]
    public string PlainText { get; set; } = string.Empty;

    [JsonPropertyName("from")]
    public string[] From { get; set; } = [];

    [JsonPropertyName("into")]
    public string[] Into { get; set; } = [];

    [JsonPropertyName("inStore")]
    public bool IsInStore { get; set; } = true;

    [JsonPropertyName("hideFromAll")]
    public bool IsHideFromAll { get; set; }

    [JsonPropertyName("requiredChampion")]
    public string? RequiredChampion { get; set; }

    [JsonPropertyName("requiredAlly")]
    public string? RequiredAlly { get; set; }

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();

    [JsonPropertyName("gold")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public GoldDto Gold { get; set; } = new();

    [JsonPropertyName("tags")]
    public string[] Tags { get; set; } = [];

    [JsonPropertyName("maps")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, bool> Maps { get; set; } = new();

    [JsonPropertyName("stats")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public StatsDto Stats { get; set; } = new();

    [JsonPropertyName("stacks")]
    public int Stacks { get; set; } = 1;

    [JsonPropertyName("effect")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public EffectDto Effect { get; set; } = new();

    [JsonPropertyName("depth")]
    public int Depth { get; set; } = 1;
}
