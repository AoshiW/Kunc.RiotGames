using System.Text.Json;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class LolLeagueClientUpdateOptions
{
    public bool AutoReconnectToWamp { get; set; } = true;

    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }
}
