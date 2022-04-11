using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Info : BaseDto
{
#pragma warning disable IDE0032 // Use auto property
    private TimeSpan _gameDuration;
    private DateTimeOffset _gameEnd;
#pragma warning restore IDE0032 // Use auto property

    /// <summary>
    /// Timew hen the game is created on the game server (i.e., the loading screen).
    /// </summary>
    [JsonPropertyName("gameCreation"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameCreation { get; init; }

    [JsonPropertyName("gameDuration"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan GameDuration { get => _gameDuration; init => _gameDuration = value; }

    [JsonPropertyName("gameEndTimestamp"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameEnd { get => _gameEnd; init => _gameEnd = value; }

    [JsonPropertyName("gameId")]
    public long GameId { get; init; }

    [JsonPropertyName("gameMode")]
    public GameMode GameMode { get; init; }

    [JsonPropertyName("gameName")]
    public string GameName { get; init; } = default!;

    /// <summary>
    /// Time when match starts on the game server.
    /// </summary>
    [JsonPropertyName("gameStartTimestamp"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset GameStart { get; init; }

    [JsonPropertyName("gameType")]
    public GameType GameType { get; init; }

    /// <summary>
    /// The first two parts can be used to determine the patch a game was played on.
    /// </summary>
    [JsonPropertyName("gameVersion")]
    public Version GameVersion { get; init; } = default!;

    [JsonPropertyName("mapId")]
    public MapId MapId { get; init; }

    [JsonPropertyName("participants")]
    public Participant[] Participants { get; init; } = default!;

    /// <summary>
    /// Platform where the match was played.
    /// </summary>
    [JsonPropertyName("platformId")]
    public string PlatformId { get; init; } = default!;

    [JsonPropertyName("queueId")]
    public int QueueId { get; init; }

    [JsonPropertyName("teams")]
    public Team[] Teams { get; init; } = default!;

    [JsonPropertyName("tournamentCode")]
    public string TournamentCode { get; init; } = default!;

    internal void FixGameDurationAndEnd(TimeSpan newDuration, DateTimeOffset newGameEnd)
    {
        _gameDuration = newDuration;
        _gameEnd = newGameEnd;
    }
}
