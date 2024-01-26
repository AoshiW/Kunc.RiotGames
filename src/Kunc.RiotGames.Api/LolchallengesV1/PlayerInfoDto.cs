using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class PlayerInfoDto : BaseDto
{
    [JsonPropertyName("challenges")]
    public ChallengeInfoDto[] Challenges { get; set; } = [];

    [JsonPropertyName("preferences")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public PlayerClientPreferencesDto Preferences { get; set; } = new();

    [JsonPropertyName("totalPoints")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ChallengePointsDto TotalPoints { get; set; } = new();

    [JsonPropertyName("categoryPoints")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, ChallengePointsDto> CategoryPoints { get; set; } = new();
}
