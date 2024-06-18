using System.Text.Json;

namespace Kunc.RiotGames.Api;

/// <summary>
/// Options for the <see cref="RiotGamesApi"/>.
/// </summary>
public class RiotGamesApiOptions
{
    /// <summary>
    /// The Riot Games API Key.
    /// </summary>
    public string ApiKey { get; set; } = default!;

    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1);

    public TimeSpan BonusRLDelay { get; set; } = TimeSpan.FromMilliseconds(800);

    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }
}
