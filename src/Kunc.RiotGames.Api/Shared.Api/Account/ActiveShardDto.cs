using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Account;

public record ActiveShardDto<T>
{
     [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;

    [JsonPropertyName("game")]
    public Game Game { get; init; }

    [JsonPropertyName("activeShard")]
    public T ActiveShard { get; init; } = default!;
}
