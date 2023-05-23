using System.Reflection;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[Flags]
public enum MethodOptions
{
    /// <inheritdoc cref="BindingFlags.Instance"/>
    Instance = BindingFlags.Instance,

    /// <inheritdoc cref="BindingFlags.Static"/>
    Static = BindingFlags.Static,

    /// <inheritdoc cref="BindingFlags.Public"/>
    Public = BindingFlags.Public,

    /// <inheritdoc cref="BindingFlags.NonPublic"/>
    NonPublic = BindingFlags.NonPublic,

    /// <summary>
    /// Specifies that instance/static/public/non-public members are to be included in the search.
    /// </summary>
    All = Instance | Static | Public | NonPublic,
}
