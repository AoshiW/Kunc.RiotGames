using System.Collections.Concurrent;
using System.Globalization;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kunc.RiotGames.Api.Http;

sealed public class RiotGamesRateLimiter : IRiotGamesRateLimiter, IDisposable
{
    private readonly ConcurrentDictionary<string, RegionRateLimiter> _regionsRateLimiters = new();
    private readonly ILogger<RiotGamesRateLimiter> _logger;
    private readonly IOptions<RiotGamesApiOptions> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesRateLimiter"/> class.
    /// </summary>
    public RiotGamesRateLimiter(IOptions<RiotGamesApiOptions> options, ILogger<RiotGamesRateLimiter>? logger = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
        _logger = logger ?? NullLogger<RiotGamesRateLimiter>.Instance;
    }

    private RegionRateLimiter GetRegionalLimiter(string region)
    {
        return _regionsRateLimiters.GetOrAdd(region, static (k, a) => new(a._logger, a._options), (_logger, _options));
    }

    /// <inheritdoc/>
    public ValueTask<RateLimitLease> AcquireAppAsync(string region, CancellationToken cancellationToken)
    {
        return GetRegionalLimiter(region).AcquireAppAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask<RateLimitLease> AcquireMethodAsync(string region, string methodId, CancellationToken cancellationToken)
    {
        return GetRegionalLimiter(region).AcquireMethodAsync(methodId, cancellationToken);
    }

    /// <inheritdoc/>
    public ValueTask UpdateAsync(string region, RiotRequestMessage request, HttpResponseMessage response, CancellationToken cancellationToken)
    {
        GetRegionalLimiter(region).Update(request, response);
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        foreach (var item in _regionsRateLimiters)
        {
            item.Value.Dispose();
        }
        _regionsRateLimiters.Clear();
    }

    internal sealed class RegionRateLimiter : IDisposable
    {
        private readonly SemaphoreSlim _appSS = new(1);
        private readonly SemaphoreSlim _methodSS = new(1);

        private RateLimiter? _app;
        private readonly ConcurrentDictionary<string, RateLimiter> _methods = new();
        private readonly ILogger _logger;
        private readonly IOptions<RiotGamesApiOptions> _options;

        public RegionRateLimiter(ILogger logger, IOptions<RiotGamesApiOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        public async ValueTask<RateLimitLease> AcquireAppAsync(CancellationToken cancellationToken)
        {
            if (_app is not null)
                return await _app.AcquireAsync(1, cancellationToken).ConfigureAwait(false);

            await _appSS.WaitAsync(cancellationToken).ConfigureAwait(false);
            if (_app is not null)
            {
                _appSS.Release();
                return await _app.AcquireAsync(1, cancellationToken).ConfigureAwait(false);
            }
            return new SemaphoreSlimLease(_appSS);
        }

        public async ValueTask<RateLimitLease> AcquireMethodAsync(string methodId, CancellationToken cancellationToken)
        {
            if (_methods.TryGetValue(methodId, out var limiter))
                return await limiter.AcquireAsync(1, cancellationToken).ConfigureAwait(false);

            await _methodSS.WaitAsync(cancellationToken).ConfigureAwait(false);
            if (_methods.TryGetValue(methodId, out limiter))
            {
                _methodSS.Release();
                return await limiter.AcquireAsync(1, cancellationToken).ConfigureAwait(false);
            }
            return new SemaphoreSlimLease(_methodSS);
        }

        public void Update(RiotRequestMessage request, HttpResponseMessage response)
        {
            var headers = response.Headers;
            var methodId = request.MethodId;
            if (_app is null && headers.TryGetValues(ApiConstants.AppRateLimit, out var values1))
            {
                var value = values1.FirstOrDefault();
                var limiter = Parse(value, _options.Value);
                if (limiter is not null)
                {
                    _logger.InitializedAppRateLimit(request.Host, value!);
                    _app = limiter;
                }
            }
            if (!_methods.ContainsKey(methodId) && headers.TryGetValues(ApiConstants.MethodRateLimit, out var values2))
            {
                var value = values2.FirstOrDefault();
                var limiter = Parse(value, _options.Value);
                if (limiter is not null)
                {
                    _logger.InitializedMethodRateLimit(request.Host, methodId, value!);
                    _methods[methodId] = limiter;
                }
            }
        }

        static ChainedRateLimiter? Parse(string? rateLimit, RiotGamesApiOptions options)
        {
            if (string.IsNullOrEmpty(rateLimit))
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
                    ReplenishmentPeriod = TimeSpan.FromSeconds(periodS) + options.BonusRLDelay,
                    QueueLimit = int.MaxValue,
                });

                limiter.AttemptAcquire();
                limiters.Add(limiter);
            }

            if (limiters.Count == 0)
                return null;

            limiters.Reverse();
            return new ChainedRateLimiter(limiters.ToArray());
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
    }
}
