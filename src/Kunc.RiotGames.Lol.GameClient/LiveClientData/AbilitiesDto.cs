using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class AbilitiesDto : BaseDto
{
    [JsonPropertyName("Passive")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilityDto Passive { get; set; } = new();

    [JsonPropertyName("Q")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilityDto Q { get; set; } = new();

    [JsonPropertyName("W")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilityDto W { get; set; } = new();

    [JsonPropertyName("E")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilityDto E { get; set; } = new();

    [JsonPropertyName("R")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public AbilityDto R { get; set; } = new();
}
