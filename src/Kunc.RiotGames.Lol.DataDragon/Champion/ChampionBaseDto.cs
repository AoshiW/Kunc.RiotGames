using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class ChampionBaseDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("blurb")]
    public string Blurb { get; set; } = string.Empty;

    [JsonPropertyName("info")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ChamionInfoDto Info { get; set; } = new();

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();

    [JsonPropertyName("tags")]
    public string[] Tags { get; set; } = [];

    [JsonPropertyName("partype")]
    public string Partype { get; set; } = string.Empty;

    [JsonPropertyName("stats")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ChampionStatsDto Stats { get; set; } = new();

}
