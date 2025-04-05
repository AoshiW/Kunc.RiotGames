using System.Text.Json;
using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class LolLeagueClientUpdateOptions
{
    public bool AutoReconnectToWamp { get; set; } = true;

    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions? JsonSerializerOptions { get; set; }

    // TODO I don't like this first solution I came up with, maybe it'll look better if I rewrite it as: [FromKeyedServices(someKey)] RateLimiter rateLimiter ??
    public RateLimiter RateLimiter { get; set; } = new NoopLimiter();
}
