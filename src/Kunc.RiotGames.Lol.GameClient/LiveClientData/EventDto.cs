using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class EventDto : BaseDto
{
    [JsonPropertyName("EventID")]
    public int EventId { get; set; }

    public string EventName { get; set; } = string.Empty;

    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan EventTime { get; set; }

    public string? Acer { get; set; }
    
    public TeamId? AcingTeam { get; set; }
    
    public string[]? Assisters { get; set; }
    
    public DragonType? DragonType { get; set; }
    
    public string? InhibKilled { get; set; }
    
    public string? InhibRespawned { get; set; }
    
    [JsonPropertyName("Stolen")]
    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsStolen { get; set; }
    
    public string? KillerName { get; set; }
    
    public string? KillStreak { get; set; }
    
    public string? Recipient { get; set; }
    
    public string? Result { get; set; }
    
    public string? TurretKilled { get; set; }

    public string? VictimName { get; set; }
}
