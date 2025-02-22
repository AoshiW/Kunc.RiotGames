using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftMatchV1;

public class InfoDto : BaseDto
{
    /// <summary>
    /// Refer to indicate if the game ended in termination.
    /// </summary>
    [JsonPropertyName("endOfGameResult")]
    public EndOfGameResult EndOfGameResult { get; set; }

    [JsonPropertyName("game_datetime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameDateTime { get; set; }

    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

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

    [JsonPropertyName("mapId")]
    public MapId MapId { get; set; }

    [JsonPropertyName("participants")]
    public ParticipantDto[] Participants { get; set; } = [];

    [JsonPropertyName("queue_id")]
    public int QueueId { get; set; }

    [JsonPropertyName("tft_game_type")]
    public string GameType { get; set; } = default!;

    [JsonPropertyName("tft_set_core_name")]
    public string SetCoreName { get; set; } = default!;

    /// <summary>
    /// Teamfight Tactics set number.
    /// </summary>
    [JsonPropertyName("tft_set_number")]
    public int SetNumber { get; set; }
}
