using System.Collections.Concurrent;

namespace Kunc.RiotGames.Api.Http;

sealed public class RiotGamesRateLimiter : IRiotGamesRateLimiter, IDisposable
{
    private readonly ConcurrentDictionary<string, RegionRateLimiter> _rl = new();

    /// <inheritdoc/>
    public IRegionRateLimiter GetPartialRateLimiter(RiotRequestMessage riotRequestMessage)
    {
        return _rl.GetOrAdd(riotRequestMessage.Host, static k => new());
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        foreach(var item in _rl)
        {
            item.Value.Dispose();
        }
        _rl.Clear();
    }
}
