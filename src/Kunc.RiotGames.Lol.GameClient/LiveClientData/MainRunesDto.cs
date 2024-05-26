using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class MainRunesDto : BaseDto
{
    [JsonPropertyName("keystone")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public RuneDto Keystone { get; set; } = new();

    [JsonPropertyName("primaryRuneTree")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public RuneDto PrimaryRuneTree { get; set; } = new();

    [JsonPropertyName("secondaryRuneTree")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public RuneDto SecondaryRuneTree { get; set; } = new();
}
