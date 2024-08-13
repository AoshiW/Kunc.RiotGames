namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public interface ILockfileProvider : IDisposable
{
    event EventHandler<LockFileCreatedEventArgs>? Created;
    event EventHandler? Deleted;

    ValueTask<Lockfile?> GetLockfileAsync(CancellationToken cancellationToken = default);
}
