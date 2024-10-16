﻿using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class FrameTimelineDto : BaseDto
{
    [JsonPropertyName("events")]
    public EventsTimelineDto[] Events { get; set; } = [];

    [JsonPropertyName("participantFrames")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<int, ParticipantFrameDto> ParticipantFrames { get; set; } = new();

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan Timestamp { get; set; }
}
