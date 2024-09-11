using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class ChallengePointsDto : BaseDto
{
    [JsonPropertyName("percentile")]
    public double Percentile { get; set; }

    [JsonPropertyName("level")]
    public string Level { get; set; } = string.Empty; // todo enum

    [JsonPropertyName("max")]
    public int Max { get; set; }

    [JsonPropertyName("current")]
    public int Current { get; set; }
}
