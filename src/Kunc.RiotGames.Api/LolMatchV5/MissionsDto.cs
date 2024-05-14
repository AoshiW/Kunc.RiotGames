using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

/// <summary>
/// Missions DTO
/// </summary>
public class MissionsDto : BaseDto
{
    [JsonPropertyName("playerScore0")]
    public int PlayerScore0 { get; set; }

    [JsonPropertyName("playerScore1")]
    public int PlayerScore1 { get; set; }

    [JsonPropertyName("playerScore2")]
    public int PlayerScore2 { get; set; }

    [JsonPropertyName("playerScore3")]
    public int PlayerScore3 { get; set; }

    [JsonPropertyName("playerScore4")]
    public int PlayerScore4 { get; set; }

    [JsonPropertyName("playerScore5")]
    public int PlayerScore5 { get; set; }

    [JsonPropertyName("playerScore6")]
    public int PlayerScore6 { get; set; }

    [JsonPropertyName("playerScore7")]
    public int PlayerScore7 { get; set; }

    [JsonPropertyName("playerScore8")]
    public int PlayerScore8 { get; set; }

    [JsonPropertyName("playerScore9")]
    public int PlayerScore9 { get; set; }

    [JsonPropertyName("playerScore10")]
    public int PlayerScore10 { get; set; }

    [JsonPropertyName("playerScore11")]
    public int PlayerScore11 { get; set; }
}
