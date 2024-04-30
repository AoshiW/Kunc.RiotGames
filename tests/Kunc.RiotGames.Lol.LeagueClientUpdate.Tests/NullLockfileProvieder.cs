namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Tests;

internal sealed class NullLockfileProvieder : ILockfileProvider
{
#pragma warning disable CS0067
    public event EventHandler<Lockfile>? Created;
    public event EventHandler? Deleted;
#pragma warning restore CS0067

    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult<Lockfile?>(Lockfile.Empty);
    }

    public void Dispose()
    {
    }
}
