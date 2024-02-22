using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class FrameTimelineDto : BaseDto
{

    [JsonPropertyName("events")]
    public EventTimelineDto[] Events { get; set; } = [];

    [JsonPropertyName("participantFrames")]
    public Dictionary<int, ParticipantFrameDto> ParticipantFrames { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan Timestamp { get; set; }
}
