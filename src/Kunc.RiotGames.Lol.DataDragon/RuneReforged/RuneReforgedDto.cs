using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.RuneReforged;

public class RuneReforgedDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("slots")]
    public SlotDto[] Slots { get; set; } = [];
}
