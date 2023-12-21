using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Map;

public class MapDto : BaseDto
{
    public string MapName { get; set; } = string.Empty;
    
    //todo => int
    public string MapId { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();
}
