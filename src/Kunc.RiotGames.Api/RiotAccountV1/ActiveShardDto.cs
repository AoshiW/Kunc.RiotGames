using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.RiotAccountV1;

public class ActiveShardDto : BaseDto
{
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; }

    [JsonPropertyName("game")]
    public Game Game { get; set; }

    [JsonPropertyName("activeShard")]
    public string ActiveShard { get; set; }
}
