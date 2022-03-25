using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Extensions;

public static class Extensions
{
    /// <summary>
    /// Retrieve the list of heroes in the game and their stats.
    /// </summary>
    /// <param name="liveClientData"></param>
    /// <param name="teamID">Heroes team ID. Optional, returns all players on all teams if null.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public static async Task<Player[]> GetAllPlayersAsync(this ILiveClientData liveClientData, Team? teamID = null, CancellationToken cancellationToken = default)
    {
        return await liveClientData.GetAllPlayersAsync(teamID?.ToUpperString(), cancellationToken);
    }

    /// <summary>
    /// Converts the value of this instance to its equivalent uppercase string representation.
    /// </summary>
    /// <param name="value">Valie to convert</param>
    /// <returns>The uppercase string representation of the value of this instance.</returns>
    public static string ToUpperString(this Team value)
    {
        return value switch
        {
            Team.All => "ALL",
            Team.Unknown => "UNKNOWN",
            Team.Neutral => "NEUTRAL",
            Team.Order => "ORDER",
            Team.Chaos => "CHAOS",
            _ => value.ToString().ToUpper()
        };
    }
}
