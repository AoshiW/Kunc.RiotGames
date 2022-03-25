using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Frame : BaseDto
{
    [JsonPropertyName("events")]
    public Event[] Events { get; init; } = default!;

    [JsonPropertyName("participantFrames")]
    public Dictionary<string, ParticipantFrame> ParticipantFrames { get; init; } = default!;

    [JsonPropertyName("timestamp"), JsonTimeSpanConverter(BaseTimeUnit.Milliseconds)]
    public TimeSpan Timestamp { get; init; }
}
