using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

class RootDto<T>
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("format")]
    public string Format { get; set; } = default!;

    [JsonPropertyName("version")]
    public string Version { get; set; } = default!;

    [JsonPropertyName("data")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Dictionary<string, T> Data { get; set; } = new();
}
