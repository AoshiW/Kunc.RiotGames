using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class AbilityDto : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; set; } = string.Empty;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; set; } = string.Empty;
}
