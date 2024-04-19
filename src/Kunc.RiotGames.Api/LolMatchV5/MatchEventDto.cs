using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class MatchEventDto : BaseDto
{
    [JsonPropertyName("actualStartTime")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan ActualStartTime { get; set; }

    [JsonPropertyName("afterId")]
    public int? AfterId { get; set; }

    [JsonPropertyName("assistingParticipantIds")]
    public int[]? AssistingParticipantIds { get; set; }

    [JsonPropertyName("beforeId")]
    public int? BeforeId { get; set; }

    [JsonPropertyName("bounty")]
    public int? Bounty { get; set; }

    [JsonPropertyName("buildingType")]
    public BuildingType? BuildingType { get; set; }

    [JsonPropertyName("creatorId")]
    public int? CreatorId { get; set; }

    [JsonPropertyName("gameId")]
    public long? GameId { get; set; }

    [JsonPropertyName("goldGain")]
    public int? GoldGain { get; set; }

    [JsonPropertyName("itemId")]
    public int? ItemId { get; set; }

    [JsonPropertyName("killType")]
    public KillType? KillType { get; set; }

    [JsonPropertyName("killerId")]
    public int? KillerId { get; set; }

    [JsonPropertyName("killerTeamId")]
    public TeamId? KillerTeamId { get; set; }

    [JsonPropertyName("killStreakLength")]
    public int? KillStreakLength { get; set; }

    [JsonPropertyName("laneType")]
    public string? LaneType { get; set; }
    // MID_LANE TOP_LANE BOT_LANE

    [JsonPropertyName("level")]
    public int? Level { get; set; }

    [JsonPropertyName("levelUpType")]
    public string? LevelUpType { get; set; }
    // 

    [JsonPropertyName("monsterSubType")]
    public MonsterSubType? MonsterSubType { get; set; }

    [JsonPropertyName("monsterType")]
    public MonsterType? MonsterType { get; set; }

    [JsonPropertyName("multiKillLength")]
    public int? MultiKillLength { get; set; }

    [JsonPropertyName("participantId")]
    public int? ParticipantId { get; set; }

    [JsonPropertyName("position")]
    public MatchPosition? Position { get; set; }

    [JsonPropertyName("realTimestamp")]
    [JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset? RealTimestamp { get; set; }

    [JsonPropertyName("shutdownBounty")]
    public int? ShutdownBounty { get; set; }

    [JsonPropertyName("skillSlot")]
    public int? SkillSlot { get; set; }

    [JsonPropertyName("teamId")]
    public TeamId? TeamId { get; set; }

    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan Timestamp { get; set; }

    [JsonPropertyName("type")]
    public MatchEventType Type { get; set; }

    [JsonPropertyName("towerType")]
    public TowerType? TowerType { get; set; }

    [JsonPropertyName("victimDamageDealt")]
    public DamageDto[]? VictimDamageDealt { get; set; }

    [JsonPropertyName("victimDamageReceived")]
    public DamageDto[]? VictimDamageReceived { get; set; }

    [JsonPropertyName("victimId")]
    public int? VictimId { get; set; }

    [JsonPropertyName("wardType")]
    public WardType? WardType { get; set; }

    [JsonPropertyName("winningTeam")]
    public TeamId? WinningTeam { get; set; }
}
