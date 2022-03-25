using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record CurrentGameInfo
{
    /// <summary>
    /// The game mode.
    /// </summary>
    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; init; }

    /// <summary>
    /// The amount of time that has passed since the game started.
    /// </summary>
    [JsonPropertyName("gameLength"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan GameLength { get; init; }

    /// <summary>
    /// The ID of the map.
    /// </summary>
    [JsonPropertyName("mapId")]
    public MapId MapId { get; init; }

    /// <summary>
    /// The game type.
    /// </summary>
    [JsonPropertyName("gameType")]
    public GameType GameType { get; init; }

    /// <summary>
    /// Banned champion information.
    /// </summary>
    [JsonPropertyName("bannedChampions")]
    public BannedChampion[] BannedChampions { get; init; } = default!;

    /// <summary>
    /// The ID of the game.
    /// </summary>
    [JsonPropertyName("gameId")]
    public long GameId { get; init; }

    /// <summary>
    /// The observer information
    /// </summary>
    [JsonPropertyName("observers")]
    public Observer Observers { get; init; } = default!;

    /// <summary>
    /// The queue type.
    /// </summary>
    [JsonPropertyName("gameQueueConfigId")]
    public long GameQueueConfigId { get; init; } = default!;

    /// <summary>
    /// The game start time represented.
    /// </summary>
    [JsonPropertyName("gameStartTime"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameStartTime { get; init; } = default!;

    /// <summary>
    /// The participant information.
    /// </summary>
    [JsonPropertyName("participants")]
    public CurrentGameParticipant[] Participants { get; init; } = default!;

    /// <summary>
    /// The ID of the platform on which the game is being played.
    /// </summary>
    [JsonPropertyName("platformId")]
    public string PlatformId { get; init; } = default!;
}
