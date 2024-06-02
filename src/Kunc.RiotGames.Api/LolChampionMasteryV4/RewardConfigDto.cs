using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class RewardConfigDto : BaseDto
{
    [JsonPropertyName("rewardValue")]
    public string RewardValue { get; set; } = string.Empty; // GUID

    [JsonPropertyName("rewardType")]
    public string RewardType { get; set; } = string.Empty; //todo to enum? HEXTECH_CHEST

    [JsonPropertyName("maximumReward")]
    public int MaximumReward { get; set; }
}
