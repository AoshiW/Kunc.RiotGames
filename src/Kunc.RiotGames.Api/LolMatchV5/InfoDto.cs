using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class InfoDto : BaseDto
{
    /// <summary>
    /// Date when the game is created on the game server.
    /// </summary>
    [JsonPropertyName("gameCreation")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameCreation { get; set; }

    [JsonPropertyName("gameDuration")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan GameDuration { get; set; }

    /// <summary>
    /// Unix timestamp for when match ends on the game server.
    /// </summary>
    [JsonPropertyName("gameEndTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameEndTimestamp { get; set; }

    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; set; }

    [JsonPropertyName("gameName")]
    public string GameName { get; set; }

    /// <summary>
    /// Date when the match starts on the game server.
    /// </summary>
    [JsonPropertyName("gameStartTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameStartTimestamp { get; set; }

    [JsonPropertyName("gameType")]
    public GameType GameType { get; set; }

    /// <summary>
    ///The first two parts can be used to determine the patch a game was played on.
    /// </summary>
    [JsonPropertyName("gameVersion")]
    public string GameVersion { get; set; }

    [JsonPropertyName("mapId")]
    public int MapId { get; set; }

    [JsonPropertyName("participants")]
    public ParticipantDto[] Participants { get; set; } = [];

    /// <summary>
    /// The platform where the match was played.
    /// </summary>
    [JsonPropertyName("platformId")]
    public string PlatformId { get; set; }

    [JsonPropertyName("queueId")]
    public int QueueId { get; set; }

    [JsonPropertyName("teams")]
    public TeamDto[] Teams { get; set; } = [];

    /// <summary>
    /// The tournament code used to generate the match.
    /// </summary>
    [JsonPropertyName("tournamentCode")]
    public string TournamentCode { get; set; } = string.Empty;
}
