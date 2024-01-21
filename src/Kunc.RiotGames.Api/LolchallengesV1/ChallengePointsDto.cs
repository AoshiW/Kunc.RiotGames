using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolchallengesV1;

public class ChallengePointsDto : BaseDto
{
    [JsonPropertyName("percentile")]
    public double Percentile { get; set; }

    [JsonPropertyName("level")]
    public string Level { get; set; }

    [JsonPropertyName("max")]
    public int Max { get; set; }

    [JsonPropertyName("current")]
    public int Current { get; set; }
}
