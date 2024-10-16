﻿using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolChallengesV1;

public class ChallengeInfoDto : BaseDto
{
    [JsonPropertyName("level")]
    public string Level { get; set; } = string.Empty; // todo enum

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("challengeId")]
    public int ChallengeId { get; set; }

    [JsonPropertyName("percentile")]
    public double Percentile { get; set; }

    [JsonPropertyName("achievedTime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset AchievedTime { get; set; }
}
