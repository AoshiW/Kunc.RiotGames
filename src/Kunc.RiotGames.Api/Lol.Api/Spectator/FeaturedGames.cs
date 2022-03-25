using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Spectator;

public record FeaturedGames
{
    /// <summary>
    /// The list of featured games.
    /// </summary>
    [JsonPropertyName("gameList")]
    public FeaturedGameInfo[] GameList { get; init; } = default!;

    /// <summary>
    /// The suggested interval to wait before requesting FeaturedGames again.
    /// </summary>
    [JsonPropertyName("clientRefreshInterval")]
    public long ClientRefreshInterval { get; init; }
}
