using System.Text.Json.Serialization;
using Kunc.RiotGames;

public class RuneDto : BaseDto
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; set; } = string.Empty;

    [JsonPropertyName("rawDisplayName")]
    public string RawDisplayName { get; set; } = string.Empty;
}
