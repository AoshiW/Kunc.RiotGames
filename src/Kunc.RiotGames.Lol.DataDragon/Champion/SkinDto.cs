using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon.Champion;

public class SkinDto : BaseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("chromas")]
    public bool HasChromas { get; set; }

    public string GetImageUrl(string championId, ChampionImageType imageType)
    {
        ArgumentNullException.ThrowIfNull(championId);
        var type = imageType switch
        {
            ChampionImageType.Centered => "centered",
            ChampionImageType.Loading => "loading",
            ChampionImageType.Splash => "splash",
            ChampionImageType.Tiles => "tiles",
            _ => throw new ArgumentOutOfRangeException(nameof(imageType))
        };
        return $"cdn/img/champion/{type}/{championId}_{Num}.jpg";
    }
}
