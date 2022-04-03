using Kunc.RiotGames.JsonConverters;

using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Event : BaseDto
{
    public int EventID { get; init; }
    public EventName EventName { get; init; }

    [JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan EventTime { get; init; }
    public string? KillerName { get; init; }
    public string? VictimName { get; init; }
    public string? Acer { get; init; }
    public string? InhibRespawned { get; init; }
    public string? InhibKilled { get; init; }
    public string? InhibRespawningSoon { get; init; }
    public string? TurretKilled { get; init; }
    public string[]? Assisters { get; init; }
    public int? KillStreak { get; init; }
    public string? Result { get; init; } // todo

    [JsonPropertyName("Stolen"), JsonConverter(typeof(BooleanConverter))]
    public bool? IsStolen { get; init; }
    public DragonType? DragonType { get; init; }

    // todo maybe TryGetTurret(out (team, lane, ???)) TryGetInhib(out (team, lane))
}
