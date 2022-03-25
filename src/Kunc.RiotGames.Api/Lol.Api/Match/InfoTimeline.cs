using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;

public record InfoTimeline : BaseDto
{
    [JsonPropertyName("frameInterval"), JsonTimeSpanConverter(BaseTimeUnit.Milliseconds)]
    public TimeSpan FrameInterval { get; init; }

    [JsonPropertyName("frames")]
    public Frame[] Frames { get; init; } = default!;

    [JsonPropertyName("gameId")]
    public long GameId { get; init; }

    [JsonPropertyName("participants")]
    public ParticipantInfo[] Participants { get; init; } = default!;
}
