using System.Threading.RateLimiting;

namespace Kunc.RiotGames.Api.Http;

class ChainedRateLimiter : RateLimiter
{
    private readonly RateLimiter[] _limiters;
    private readonly int _length;

    public ChainedRateLimiter(params RateLimiter[] limiters)
    {
        _limiters = limiters;
        _length = limiters.Length;
    }

    public override TimeSpan? IdleDuration => throw new NotImplementedException();

    public override RateLimiterStatistics? GetStatistics()
    {
        throw new NotImplementedException();
    }

    protected override async ValueTask<RateLimitLease> AcquireAsyncCore(int permitCount, CancellationToken cancellationToken)
    {
        var leases = new RateLimitLease[_length];
        for (int i = 0; i < _length; i++)
        {
            leases[i] = await _limiters[i].AcquireAsync(permitCount, cancellationToken);
        }
        return new ChainedRateLimitLease(leases);
    }

    protected override RateLimitLease AttemptAcquireCore(int permitCount)
    {
        var leases = new RateLimitLease[_length];
        for (int i = 0; i < _length; i++)
        {
            leases[i] = _limiters[i].AttemptAcquire(permitCount);
        }
        return new ChainedRateLimitLease(leases);
    }

    class ChainedRateLimitLease : RateLimitLease
    {
        private readonly RateLimitLease[] _leases;

        public ChainedRateLimitLease(RateLimitLease[] leases)
        {
            _leases = leases;
        }

        public override bool IsAcquired => Array.TrueForAll(_leases, static lease => lease.IsAcquired);

        public override IEnumerable<string> MetadataNames => throw new NotImplementedException();

        public override bool TryGetMetadata(string metadataName, out object? metadata)
        {
            throw new NotImplementedException();
        }
    }
}
