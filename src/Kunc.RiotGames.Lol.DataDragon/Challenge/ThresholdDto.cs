using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Challenge;

public class ThresholdDto : BaseDto
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("rewards")]
    public RewardDto[] Rewards { get; set; } = [];
}
