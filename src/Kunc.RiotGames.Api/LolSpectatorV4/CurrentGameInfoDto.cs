using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class CurrentGameInfoDto : BaseDto
{
    /// <summary>
    /// The ID of the game.
    /// </summary>
    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

    /// <summary>
    /// The game type.
    /// </summary>
    [JsonPropertyName("gameType")]
    public GameType GameType { get; set; }

    /// <summary>
    /// The game start time.
    /// </summary>
    [JsonPropertyName("gameStartTime")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameStartTime { get; set; }

    /// <summary>
    /// The ID of the map.
    /// </summary>
    [JsonPropertyName("mapId")]
    public MapId MapId { get; set; }

    /// <summary>
    /// The amount of time that has passed since the game started.
    /// </summary>
    [JsonPropertyName("gameLength")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan GameLength { get; set; }

    /// <summary>
    /// The ID of the platform on which the game is being played.
    /// </summary>
    [JsonPropertyName("platformId")]
    public string PlatformId { get; set; } = string.Empty;

    /// <summary>
    /// The game mode.
    /// </summary>
    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; set; }

    /// <summary>
    /// Banned champion information.
    /// </summary>
    [JsonPropertyName("bannedChampions")]
    public BannedChampionDto[] BannedChampions { get; set; } = [];

    /// <summary>
    /// The queue type.
    /// </summary>
    [JsonPropertyName("gameQueueConfigId")]
    public long GameQueueConfigId { get; set; }

    /// <summary>
    /// The observer information.
    /// </summary>
    [JsonPropertyName("observers")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ObserverDto Observers { get; set; } = new();

    /// <summary>
    /// The participant information.
    /// </summary>
    [JsonPropertyName("participants")]
    public CurrentGameParticipantDto[] Participants { get; set; } = [];
}
