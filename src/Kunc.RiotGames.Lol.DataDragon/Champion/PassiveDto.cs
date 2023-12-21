using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class PassiveDto : BaseDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();
}
