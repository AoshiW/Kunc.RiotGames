using System.Collections.Concurrent;
using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Api.Http;

sealed class RegionRateLimiter : IDisposable
{
    sealed class SemaphoreSlimLease : RateLimitLease
    {
        SemaphoreSlim? _semaphoreSlim;
        readonly object _lock = new();

        public SemaphoreSlimLease(SemaphoreSlim semaphoreSlim)
        {
            _semaphoreSlim = semaphoreSlim;
        }

        public override bool IsAcquired => true;

        public override IEnumerable<string> MetadataNames => [];

        public override bool TryGetMetadata(string metadataName, out object? metadata)
        {
            metadata = default;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (_semaphoreSlim is null)
                return;

            lock (_lock)
            {
                if (_semaphoreSlim is null)
                    return;

                _semaphoreSlim.Release();
                _semaphoreSlim = null;
                base.Dispose(disposing);
            }
        }
    }

    private readonly SemaphoreSlim _app = new(1);
    private readonly ConcurrentDictionary<string, SemaphoreSlim> _methods = new();

    public async ValueTask<RateLimitLease> AcquireAppAsync(CancellationToken cancellationToken)
    {
        await _app.WaitAsync(cancellationToken);
        return new SemaphoreSlimLease(_app);
    }

    public async ValueTask<RateLimitLease> AcquireMethodAsync(string methodId, CancellationToken cancellationToken)
    {
        var method = _methods.GetOrAdd(methodId, k => new(1));
        await method.WaitAsync(cancellationToken);
        return new SemaphoreSlimLease(method);
    }

    public void Dispose()
    {
        _app.Dispose();
        foreach (var method in _methods)
        {
            method.Value.Dispose();
        }
        _methods.Clear();
    }
}
