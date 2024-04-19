using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class PerkStatsDto : BaseDto
{
    [JsonPropertyName("defense")]
    public int Defense { get; set; }

    [JsonPropertyName("flex")]
    public int Flex { get; set; }

    [JsonPropertyName("offense")]
    public int Offense { get; set; }
}
