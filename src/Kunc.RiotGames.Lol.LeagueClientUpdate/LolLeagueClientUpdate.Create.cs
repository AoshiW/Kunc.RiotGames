using Microsoft.Extensions.Logging.Abstractions;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    /// <summary>
    /// Creates new instance of <see cref="ILolLeagueClientUpdate"/>.
    /// </summary>
    /// <returns>The <see cref="ILolLeagueClientUpdate"/> that was created.</returns>
    public static ILolLeagueClientUpdate Create()
    {
        var lockfileProvider = new FileLockfileProvider();
        return new LolLeagueClientUpdate(lockfileProvider);
    }
}
