using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class SeasonMilestoneDto : BaseDto
{
    [JsonPropertyName("milestoneGrades")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, int> MilestoneGrades { get; set; } = new();

    [JsonPropertyName("rewardMarks")]
    public int RewardMarks { get; set; }

    [JsonPropertyName("bonus")]
    public bool IsBonus { get; set; }

    [JsonPropertyName("rewardConfig")]
    public RewardConfigDto? RewardConfig { get; set; }
}
