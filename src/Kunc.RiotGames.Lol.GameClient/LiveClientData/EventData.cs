using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class EventDataDto : BaseDto
{
    [JsonPropertyName("Events")]
    public EventDto[] Events { get; set; } = [];
}
