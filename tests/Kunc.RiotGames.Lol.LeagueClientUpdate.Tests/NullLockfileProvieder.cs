namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Tests;

internal sealed class NullLockfileProvieder : ILockfileProvider
{
    public static NullLockfileProvieder Instance { get; } = new();

#pragma warning disable CS0067
    public event EventHandler<LockFileCreatedEventArgs>? Created;
    public event EventHandler? Deleted;
#pragma warning restore CS0067

    private NullLockfileProvieder()
    {

    }

    public ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult<Lockfile?>(Lockfile.Empty);
    }

    public void Dispose()
    {
    }
}
