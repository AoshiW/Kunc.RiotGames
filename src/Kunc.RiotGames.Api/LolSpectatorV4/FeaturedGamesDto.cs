using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolSpectatorV4;

public class FeaturedGamesDto : BaseDto
{
    /// <summary>
    /// The list of featured games.
    /// </summary>
    [JsonPropertyName("gameList")]
    public FeaturedGameInfoDto[] GameList { get; set; } = [];

    /// <summary>
    /// The suggested interval to wait before requesting FeaturedGames again.
    /// </summary>
    [JsonPropertyName("clientRefreshInterval")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan ClientRefreshInterval { get; set; }
}
