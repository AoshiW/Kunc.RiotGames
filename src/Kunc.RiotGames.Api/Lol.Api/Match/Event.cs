using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;
public record Event : BaseDto
{
    [JsonPropertyName("timestamp"), JsonTimeSpanConverter(BaseTimeUnit.Milliseconds)]
    public TimeSpan Timestamp { get; init; }

    [JsonPropertyName("type")]
    public EventType Type { get; init; }

    [JsonPropertyName("skillSlot")]
    public int? SkillSlot { get; init; }

    [JsonPropertyName("participantId")]
    public int? ParticipantId { get; init; }

    [JsonPropertyName("itemId")]
    public int? ItemId { get; init; }

    [JsonPropertyName("levelUpType")]
    public LevelUpType? LevelUpType { get; init; }

    [JsonPropertyName("wardType")]
    public WardType? WardType { get; init; }

    [JsonPropertyName("creatorId")]
    public int? CreatorId { get; init; }

    [JsonPropertyName("level")]
    public int? Level { get; init; }

    [JsonPropertyName("bounty")]
    public int? Bounty { get; init; }

    [JsonPropertyName("killStreakLength")]
    public int? KillStreakLength { get; init; }

    [JsonPropertyName("killerId")]
    public int? KillerId { get; init; }

    [JsonPropertyName("position")]
    public MapPoint? Position { get; init; }

    [JsonPropertyName("shutdownBounty")]
    public int? ShutdownBounty { get; init; }

    [JsonPropertyName("victimId")]
    public int? VictimId { get; init; }

    [JsonPropertyName("multiKillLength")]
    public int? MultiKillLength { get; init; }

    [JsonPropertyName("killType")]
    public KillType? KillType { get; init; }

    [JsonPropertyName("teamId")]
    public int? TeamId { get; init; }

    [JsonPropertyName("laneType")]
    public LaneType? LaneType { get; init; }

    [JsonPropertyName("gameId")]
    public long? GameId { get; init; }

    [JsonPropertyName("realTimestamp"), JsonConverter(typeof(UnixTimestampDateTimeOffsetMsConverter))]
    public DateTimeOffset? RealTimestamp { get; init; }

    [JsonPropertyName("winningTeam")]
    public int? WinningTeam { get; init; }

    [JsonPropertyName("assistingParticipantIds")]
    public int[]? AssistingParticipantIds { get; init; }

    [JsonPropertyName("buildingType")]
    public BuildingType? BuildingType { get; init; }

    [JsonPropertyName("towerType")]
    public TowerType? TowerType { get; init; }

    [JsonPropertyName("killerTeamId")]
    public int? KillerTeamId { get; init; }

    [JsonPropertyName("monsterType")]
    public MonsterType? MonsterType { get; init; }

    [JsonPropertyName("monsterSubType")]
    public string? MonsterSubType { get; init; }

    [JsonPropertyName("afterId")]
    public int? AfterId { get; init; }

    [JsonPropertyName("beforeId")]
    public int? BeforeId { get; init; }

    [JsonPropertyName("goldGain")]
    public int? GoldGain { get; init; }

    [JsonPropertyName("victimDamageDealt")]
    public DamageInfo[]? VictimDamageDealt { get; init; }

    [JsonPropertyName("victimDamageReceived")]
    public DamageInfo[]? VictimDamageReceived { get; init; }
}
