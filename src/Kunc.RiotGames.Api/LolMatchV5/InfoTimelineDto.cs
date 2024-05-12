using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class InfoTimelineDto : BaseDto
{
    /// <summary>
    /// Refer to indicate if the game ended in termination.
    /// </summary>
    [JsonPropertyName("endOfGameResult")]
    public string EndOfGameResult { get; set; } = string.Empty;

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
