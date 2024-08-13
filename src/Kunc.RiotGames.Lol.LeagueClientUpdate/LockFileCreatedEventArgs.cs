namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public class LockFileCreatedEventArgs : EventArgs
{
    public required Lockfile Lockfile { get; init; }
}
