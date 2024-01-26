using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class ChallengeConfigInfoDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("localizedNames")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, Dictionary<string, string>> LocalizedNames { get; set; } = new();

    [JsonPropertyName("state")]
    public State State { get; set; }

    [JsonPropertyName("tracking")]
    public Tracking Tracking { get; set; }

    [JsonPropertyName("startTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset? Start { get; set; }

    [JsonPropertyName("endTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset? End { get; set; }

    [JsonPropertyName("leaderboard")]
    public bool Leaderboard { get; set; }

    [JsonPropertyName("thresholds")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, double> Thresholds { get; set; } = new();
}
