using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Clash;

public record TournamentPhase : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("registrationTime"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset RegistrationTime { get; init; }

    [JsonPropertyName("startTime"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset StartTime { get; init; }

    [JsonPropertyName("cancelled")]
    public bool IsCancelled { get; init; }
}