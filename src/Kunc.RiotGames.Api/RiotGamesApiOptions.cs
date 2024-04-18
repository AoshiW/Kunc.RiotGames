using System.Text.Json;

namespace Kunc.RiotGames.Api;

public class RiotGamesApiOptions
{
    /// <summary>
    /// The Riot Games API Key.
    /// </summary>
    public string ApiKey { get; set; } = default!;

    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1);

    public TimeSpan BonusRLDelay { get; set; } = TimeSpan.FromMilliseconds(800);

    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new()
    {

    };
}
