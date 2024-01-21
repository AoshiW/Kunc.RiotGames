using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolchallengesV1;

public class PlayerClientPreferencesDto : BaseDto
{
    [JsonPropertyName("bannerAccent")]
    public string BannerAccent { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("challengeIds")]
    public int[] ChallengeIds { get; set; } = [];

    [JsonPropertyName("crestBorder")]
    public string CrestBorder { get; set; } = string.Empty;

    [JsonPropertyName("prestigeCrestBorderLevel")]
    public int PrestigeCrestBorderLevel { get; set; }
}
