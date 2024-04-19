using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolClashV1;

public class TournamentPhaseDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("registrationTime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset RegistrationTime { get; set; }

    [JsonPropertyName("startTime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset StartTime { get; set; }

    [JsonPropertyName("cancelled")]
    public bool IsCancelled { get; set; }
}
