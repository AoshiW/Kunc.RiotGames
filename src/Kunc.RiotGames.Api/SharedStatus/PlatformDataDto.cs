using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.SharedStatus;

public class PlatformDataDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("locales")]
    public string[] Locales { get; set; } = [];

    [JsonPropertyName("maintenances")]
    public StatusDto[] Maintenances { get; set; } = [];

    [JsonPropertyName("incidents")]
    public StatusDto[] Incidents { get; set; } = [];
}
