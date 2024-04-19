using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class InfoDto : BaseDto
{
    [JsonPropertyName("game_datetime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameDatetime { get; set; }

    [JsonPropertyName("game_length")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan GameLength { get; set; }

    [JsonPropertyName("game_variation")]
    public string GameVariation { get; set; } = string.Empty;

    /// <summary>
    /// Game client version.
    /// </summary>
    [JsonPropertyName("game_version")]
    public string GameVersion { get; set; } = string.Empty;

    [JsonPropertyName("participants")]
    public ParticipantDto[] Participants { get; set; } = [];

    [JsonPropertyName("queue_id")]
    public int QueueId { get; set; }

    /// <summary>
    /// Teamfight Tactics set number.
    /// </summary>
    [JsonPropertyName("tft_set_number")]
    public int SetNumber { get; set; }

    //todo 2 missing props
}
