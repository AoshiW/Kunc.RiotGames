using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class InfoTimelineDto : BaseDto
{
    [JsonPropertyName("frameInterval")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan FrameInterval { get; set; }

    [JsonPropertyName("frames")]
    public FrameTimelineDto[] Frames { get; set; } = [];

    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

    [JsonPropertyName("participants")]
    public ParticipantTimelineDto[] Participants { get; set; } = [];
}
