namespace Kunc.RiotGames.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Game"/> enum.
/// </summary>
public static class GameExtensions
{
    /// <summary>
    /// Converts the value of this instance to its equivalent lowercase string representation.
    /// </summary>
    /// <param name="value">Valie to convert</param>
    /// <returns>The lowercase string representation of the value of this instance.</returns>
    public static string ToLowerString(this Game value)
    {
        return value switch
        {
            Game.Lol => "lol",
            Game.Lor => "lor",
            Game.Val => "val",
            _ => value.ToString().ToLowerInvariant()
        };
    }
}
