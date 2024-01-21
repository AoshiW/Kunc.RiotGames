using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class BanDto : BaseDto
{
    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    [JsonPropertyName("pickTurn")]
    public int PickTurn { get; set; }
}
