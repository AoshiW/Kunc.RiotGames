using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

/// <summary>
/// This object contains required reward config information.
/// </summary>
public class RewardConfigDto : BaseDto
{
    /// <summary>
    /// Reward value.
    /// </summary>
    [JsonPropertyName("rewardValue")]
    public string RewardValue { get; set; } = string.Empty; // GUID

    /// <summary>
    /// Reward type.
    /// </summary>
    [JsonPropertyName("rewardType")]
    public string RewardType { get; set; } = string.Empty; //todo to enum? HEXTECH_CHEST

    /// <summary>
    /// Maximun reward.
    /// </summary>
    [JsonPropertyName("maximumReward")]
    public int MaximumReward { get; set; }
}
