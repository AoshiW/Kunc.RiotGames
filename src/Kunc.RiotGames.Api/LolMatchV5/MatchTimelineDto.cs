using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MatchTimelineDto : BaseDto
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public MetadataDto Metadata { get; set; } = new();

    /// <summary>
    /// Match info.
    /// </summary>
    [JsonPropertyName("info")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public InfoTimelineDto Info { get; set; } = new();
}

public class InfoTimelineDto : BaseDto
{
    [JsonPropertyName("frameInterval")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan FrameInterval { get; set; }

    [JsonPropertyName("frames")]
    public FrameTimelineDto[] Frames { get; set; } = [];

    [JsonPropertyName("gameId")]
    public long GameId { get; set; }

    [JsonPropertyName("participants")]
    public ParticipantTimelineDto[] Participants { get; set; } = [];
}

public class FrameTimelineDto : BaseDto
{

    [JsonPropertyName("events")]
    public EventTimelineDto[] Events { get; set; } = [];

    [JsonPropertyName("participantFrames")]
    public Dictionary<string,ParticipantFrameDto> ParticipantFrames { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan Timestamp { get; set; }
}
public class ParticipantTimelineDto : BaseDto
{
    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;
}
public class ParticipantFrameDto : BaseDto
{
    [JsonPropertyName("championStats")]
    public object ChampionStats { get; set; }

    [JsonPropertyName("currentGold")]
    public int CurrentGold { get; set; }

    [JsonPropertyName("damageStats")]
    public object DamageStats { get; set; }

    [JsonPropertyName("goldPerSecond")]
    public int GoldPerSecond { get; set; }

    [JsonPropertyName("jungleMinionsKilled")]
    public int JungleMinionsKilled { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("minionsKilled")]
    public int MinionsKilled { get; set; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("position")]
    public object Position { get; set; }

    [JsonPropertyName("timeEnemySpentControlled")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan TimeEnemySpentControlled { get; set; }

    [JsonPropertyName("totalGold")]
    public int TotalGold { get; set; }

    [JsonPropertyName("xp")]
    public int XP { get; set; }
}
public class EventTimelineDto : BaseDto
{
    [JsonPropertyName("realTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset? RealTimestamp { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan Timestamp { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
