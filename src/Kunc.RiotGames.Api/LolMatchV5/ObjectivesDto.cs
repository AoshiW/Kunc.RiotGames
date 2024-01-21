using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ObjectivesDto : BaseDto
{
    [JsonPropertyName("baron")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto Baron { get; set; } = new();

    [JsonPropertyName("champion")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto Champion { get; set; } = new();

    [JsonPropertyName("dragon")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto Dragon { get; set; } = new();

    [JsonPropertyName("inhibitor")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto Inhibitor { get; set; } = new();

    [JsonPropertyName("riftHerald")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto RiftHerald { get; set; } = new();

    [JsonPropertyName("tower")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObjectiveDto Tower { get; set; } = new();
}
