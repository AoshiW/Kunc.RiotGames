using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Champion;

public record ChampionRotation : BaseDto
{
    [JsonPropertyName("maxNewPlayerLevel")]
    public int MaxNewPlayerLevel { get; init; }

    [JsonPropertyName("freeChampionIdsForNewPlayers")]
    public int[] FreeChampionIdsForNewPlayers { get; init; } = default!;

    [JsonPropertyName("freeChampionIds")]
    public int[] FreeChampionIds { get; init; } = default!;
}
