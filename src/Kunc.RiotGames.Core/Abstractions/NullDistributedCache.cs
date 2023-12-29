using Microsoft.Extensions.Caching.Distributed;

namespace Kunc.RiotGames.Abstractions;

/// <summary>
/// Minimalistic distributed cache that does nothing.
/// </summary>
internal class NullDistributedCache : IDistributedCache
{
    static NullDistributedCache? _instance;

    /// <summary>
    /// Returns an instance of <see cref="NullDistributedCache"/>.
    /// </summary>
    /// <returns>An instance of <see cref="NullDistributedCache"/>.</returns>
    public static NullDistributedCache Instance => _instance ??= new();

    /// <inheritdoc/>
    public byte[]? Get(string key) => null;

    /// <inheritdoc/>
    public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
        => Task.FromResult<byte[]?>(null);

    /// <inheritdoc/>
    public void Refresh(string key)
    { }

    /// <inheritdoc/>
    public Task RefreshAsync(string key, CancellationToken token = default)
        => Task.CompletedTask;

    /// <inheritdoc/>
    public void Remove(string key)
    { }

    /// <inheritdoc/>
    public Task RemoveAsync(string key, CancellationToken token = default)
        => Task.CompletedTask;

    /// <inheritdoc/>
    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    { }

    /// <inheritdoc/>
    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        => Task.CompletedTask;
}
