using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Tft.Api.Match;

public record Info : BaseDto
{
    [JsonPropertyName("game_datetime"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameDatetime { get; init; }

    /// <summary>
    /// Game length
    /// </summary>
    [JsonPropertyName("game_length"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan GameLength { get; init; }

    [JsonPropertyName("game_variation")]
    public string GameVariation { get; init; } = default!;

    /// <summary>
    /// Game client version.
    /// </summary>
    [JsonPropertyName("game_version")]
    public string GameVersion { get; init; } = default!;

    [JsonPropertyName("participants")]
    public Participant[] Participants { get; init; } = default!;

    [JsonPropertyName("queue_id")]
    public int QueueId { get; init; }

    /// <summary>
    /// Teamfight Tactics set number.
    /// </summary>
    [JsonPropertyName("tft_set_number")]
    public int SetNumber { get; init; }
}
