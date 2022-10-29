using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

/// <summary>
/// Represent base DTO.
/// </summary>
public abstract class BaseDto
{
    /// <summary>
    /// Contains extra JSON properties that did not map to fields.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
