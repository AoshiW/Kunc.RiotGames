using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class SummonerSpellDto : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; set; } = string.Empty;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; set; } = string.Empty;
}
