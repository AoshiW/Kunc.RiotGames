using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.RuneReforged;

public class RuneDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("shortDesc")]
    public string ShortDesc { get; set; } = string.Empty;

    [JsonPropertyName("longDesc")]
    public string LongDesc { get; set; } = string.Empty;
}
