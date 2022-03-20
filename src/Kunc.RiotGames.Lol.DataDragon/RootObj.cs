using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

internal record RootObj<T> : BaseDto
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = default!;

    [JsonPropertyName("version")]
    public string Version { get; init; } = default!;

    [JsonPropertyName("basic")]
    public JsonElement? Basic { get; init; }

    [JsonPropertyName("format")]
    public string? Format { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, T> Data { get; init; } = default!;

    [JsonPropertyName("groups")]
    public JsonElement? Groups { get; init; }

    [JsonPropertyName("tree")]
    public JsonElement? Tree { get; init; }

    [JsonPropertyName("keys")]
    public JsonElement? Keys { get; init; }
}
