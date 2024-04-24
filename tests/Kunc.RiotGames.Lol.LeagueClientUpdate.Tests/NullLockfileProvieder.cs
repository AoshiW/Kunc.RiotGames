namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Tests;

internal class NullLockfileProvieder : ILockfileProvider
{
    public event EventHandler<Lockfile>? Created;
    public event EventHandler? Deleted;

    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult<Lockfile?>(Lockfile.Empty);
    }

    public void Dispose()
    {
    }
}
