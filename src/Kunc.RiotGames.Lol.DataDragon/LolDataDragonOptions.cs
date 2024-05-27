using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.DataDragon;

public class LolDataDragonOptions : IOptions<LolDataDragonOptions>
{
    public DistributedCacheEntryOptions DistributedCacheEntryOptions { get; set; } = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7),
        SlidingExpiration = TimeSpan.FromDays(1),
    };

    /// <summary>
    /// Options to control the behavior during deserialization.
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new();

    LolDataDragonOptions IOptions<LolDataDragonOptions>.Value => this;
}
