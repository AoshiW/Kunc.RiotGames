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
    /// Gets or sets the type of the event.
    /// </summary>
    /// <remarks>
    /// The possible values are: Create, Update, and Delete.
    /// </remarks>
    [JsonPropertyName("eventType")]
    public string EventType { get; set; } = default!;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = default!;
}
