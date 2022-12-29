using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class LcuEventArgs<T> : EventArgs
{
    /// <summary>
    /// Event data.
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;

    /// <summary>
    /// Type of event.
    /// </summary>
    /// <remarks>
    /// Values: Create, Update, Delete
    /// </remarks>
    [JsonPropertyName("eventType")]
    public string EventType { get; set; } = default!;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = default!;
}
