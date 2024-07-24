using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Map;

public class MapDto : BaseDto
{
    public string MapName { get; set; } = string.Empty;

    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int MapId { get; set; }

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();
}
