using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class PerksDto : BaseDto
{
    [JsonPropertyName("statPerks")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public PerkStatsDto StatPerks { get; set; } = new();

    [JsonPropertyName("styles")]
    public PerkStyleDto[] Styles { get; set; } = [];
}
