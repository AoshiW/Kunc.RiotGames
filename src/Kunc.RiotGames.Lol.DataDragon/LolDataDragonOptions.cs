using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Lol.DataDragon;

public class LolDataDragonOptions : IOptions<LolDataDragonOptions>
{
    public DistributedCacheEntryOptions DistributedCacheEntryOptions { get; set; } = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(14),
        SlidingExpiration = TimeSpan.FromDays(7),
    };

    LolDataDragonOptions IOptions<LolDataDragonOptions>.Value => this;
}
