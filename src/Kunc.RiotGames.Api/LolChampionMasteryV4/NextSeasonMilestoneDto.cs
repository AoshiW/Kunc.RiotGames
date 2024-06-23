using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

/// <summary>
/// This object contains required next season milestone information.
/// </summary>
public class NextSeasonMilestoneDto : BaseDto
{
    [JsonPropertyName("milestoneGrades")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, int> MilestoneGrades { get; set; } = new();

    /// <summary>
    /// Reward marks.
    /// </summary>
    [JsonPropertyName("rewardMarks")]
    public int RewardMarks { get; set; }

    /// <summary>
    /// Bonus.
    /// </summary>
    [JsonPropertyName("bonus")]
    public bool IsBonus { get; set; }

    /// <summary>
    /// Reward configuration.
    /// </summary>
    [JsonPropertyName("rewardConfig")]
    public RewardConfigDto? RewardConfig { get; set; }
}
