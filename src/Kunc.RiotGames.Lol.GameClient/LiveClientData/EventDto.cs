using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class EventDto : BaseDto
{
    [JsonPropertyName("EventID")]
    public int EventID { get; set; }

    [JsonPropertyName("EventName")]
    public string EventName { get; set; } = string.Empty;

    [JsonPropertyName("EventTime")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan EventTime { get; set; }

    //todo missing events
}
