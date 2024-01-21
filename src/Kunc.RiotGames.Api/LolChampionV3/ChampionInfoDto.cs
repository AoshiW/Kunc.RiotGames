using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChampionV3;

public class ChampionInfoDto : BaseDto
{
    [JsonPropertyName("maxNewPlayerLevel")]
    public int MaxNewPlayerLevel { get; set; }

    [JsonPropertyName("freeChampionIdsForNewPlayers")]
    public int[] FreeChampionIdsForNewPlayers { get; set; } = [];

    [JsonPropertyName("freeChampionIds")]
    public int[] FreeChampionIds { get; set; } = [];
}
