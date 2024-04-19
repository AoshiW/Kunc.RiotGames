using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class PerkStyleDto : BaseDto
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("selections")]
    public PerkStyleSelectionDto[] Selections { get; set; } = [];

    [JsonPropertyName("style")]
    public int Style { get; set; }
}
