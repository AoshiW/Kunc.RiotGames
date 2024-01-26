using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class ApexPlayerInfoDto : BaseDto
{
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }
}
