using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.ProfileIcon;

public class ProfileIconDto : BaseDto
{
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id { get; set; }

    [JsonPropertyName("image")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ImageDto Image { get; set; } = new();
}
