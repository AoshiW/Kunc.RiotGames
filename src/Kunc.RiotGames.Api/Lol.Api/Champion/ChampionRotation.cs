using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Champion;

public record ChampionRotation : BaseDto
{
    [JsonPropertyName("maxNewPlayerLevel")]
    public int MaxNewPlayerLevel { get; init; }

    /// <summary>
    /// Low-level free-to-play rotations.
    /// </summary>
    [JsonPropertyName("freeChampionIdsForNewPlayers")]
    public int[] FreeChampionIdsForNewPlayers { get; init; } = default!;

    /// <summary>
    /// Free-to-play rotations.
    /// </summary>
    [JsonPropertyName("freeChampionIds")]
    public int[] FreeChampionIds { get; init; } = default!;
}
