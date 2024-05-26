using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class StatRuneDto : BaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rawDescription")]
    public string RawDescription { get; set; } = string.Empty;
}
