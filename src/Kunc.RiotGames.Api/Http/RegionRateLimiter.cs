using System.Collections.Concurrent;
using System.Globalization;
using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Api.Http;

sealed class RegionRateLimiter : IRegionRateLimiter, IDisposable
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

    private readonly SemaphoreSlim _appSS = new(1);
    private readonly SemaphoreSlim _methodSS = new(1);

    private RateLimiter? _app;
    private readonly ConcurrentDictionary<string, RateLimiter> _methods = new();

    public async ValueTask<RateLimitLease> AcquireAppAsync(CancellationToken cancellationToken)
    {
        if (_app is not null)
            return await _app.AcquireAsync(1, cancellationToken);
        await _appSS.WaitAsync(cancellationToken);
        if (_app is not null)
        {
            _appSS.Release();
            return await _app.AcquireAsync(1, cancellationToken);
        }
        return new SemaphoreSlimLease(_appSS);
    }

    public async ValueTask<RateLimitLease> AcquireMethodAsync(string methodId, CancellationToken cancellationToken)
    {
        if (_methods.TryGetValue(methodId, out var limiter))
            return await limiter.AcquireAsync(1, cancellationToken);
        await _methodSS.WaitAsync(cancellationToken);
        if (_methods.TryGetValue(methodId, out limiter))
        {
            _methodSS.Release();
            return await limiter.AcquireAsync(1, cancellationToken);
        }
        return new SemaphoreSlimLease(_methodSS);
    }

    public void Updade(RiotRequestMessage request, HttpResponseMessage response)
    {
        var headers = response.Headers;
        var methodId = request.MethodId;
        if (_app is null && headers.TryGetValues("X-App-Rate-Limit", out var values1))
        {
            _app = Parse(values1.FirstOrDefault());
        }
        if (!_methods.ContainsKey(methodId) && headers.TryGetValues("X-Method-Rate-Limit", out var values2))
        {
            var limiter = Parse(values2.FirstOrDefault());
            if (limiter is not null)
                _methods[methodId] = limiter; ;
        }

        static RateLimiter? Parse(string? rateLimit)
        {
            if (rateLimit is null)
                return null;

            var limiters = new List<RateLimiter>();
            foreach (var item in rateLimit.Split(','))
            {
                var splitIndex = item.IndexOf(':');
                if (splitIndex == -1)
                    continue;
                var limit = int.Parse(item.AsSpan(0, splitIndex), NumberFormatInfo.InvariantInfo);
                var periodS = int.Parse(item.AsSpan(splitIndex + 1), NumberFormatInfo.InvariantInfo);

                var limiter = new TokenBucketRateLimiter(new()
                {
                    TokenLimit = limit,
                    TokensPerPeriod = limit,
                    ReplenishmentPeriod = TimeSpan.FromSeconds(periodS + 1),
                    QueueLimit = int.MaxValue,
                });

                limiter.AttemptAcquire();
                limiters.Add(limiter);
            }
            return limiters.Count == 0
                ? null
                : new ChainedRateLimiter(limiters.ToArray());
        }
    }

    public void Dispose()
    {
        _appSS.Dispose();
        _methodSS.Dispose();
        _app?.Dispose();
        foreach (var method in _methods)
        {
            method.Value.Dispose();
        }
        _methods.Clear();
    }
}
