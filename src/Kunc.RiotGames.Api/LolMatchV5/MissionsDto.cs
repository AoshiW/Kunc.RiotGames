using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

/// <summary>
/// Missions DTO
/// </summary>
public class MissionsDto : BaseDto
{
    [JsonPropertyName("playerScore0")]
    public double PlayerScore0 { get; set; }

    [JsonPropertyName("playerScore1")]
    public double PlayerScore1 { get; set; }

    [JsonPropertyName("playerScore2")]
    public double PlayerScore2 { get; set; }

    [JsonPropertyName("playerScore3")]
    public double PlayerScore3 { get; set; }

    [JsonPropertyName("playerScore4")]
    public double PlayerScore4 { get; set; }

    [JsonPropertyName("playerScore5")]
    public double PlayerScore5 { get; set; }

    [JsonPropertyName("playerScore6")]
    public double PlayerScore6 { get; set; }

    [JsonPropertyName("playerScore7")]
    public double PlayerScore7 { get; set; }

    [JsonPropertyName("playerScore8")]
    public double PlayerScore8 { get; set; }

    [JsonPropertyName("playerScore9")]
    public double PlayerScore9 { get; set; }

    [JsonPropertyName("playerScore10")]
    public double PlayerScore10 { get; set; }

    [JsonPropertyName("playerScore11")]
    public double PlayerScore11 { get; set; }
}
