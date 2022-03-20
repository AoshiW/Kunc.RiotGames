using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Scores : BaseDto, IKda
{
    /// <inheritdoc/>
    [JsonPropertyName("assists")]
    public int Assists { get; init; }

    [JsonPropertyName("creepScore")]
    public int CreepScore { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("deaths")]
    public int Deaths { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("kills")]
    public int Kills { get; init; }

    [JsonPropertyName("WardScore")]
    public double WardScore { get; init; }
}
