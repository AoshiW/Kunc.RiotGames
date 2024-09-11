using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;
public class ApexPlayerInfoDto : BaseDto
{
    /// <summary>
    /// Player Universal Unique Identifier.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }
}
