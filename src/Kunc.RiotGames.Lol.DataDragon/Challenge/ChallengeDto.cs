using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Challenge;

public class ChallengeDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("hasLeaderboard")]
    public bool HasLeaderboard { get; set; }

    [JsonPropertyName("levelToIconPath")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, string> LevelToIconPath { get; set; } = new();

    [JsonPropertyName("thresholds")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, ThresholdDto> Thresholds { get; set; } = new();
}
