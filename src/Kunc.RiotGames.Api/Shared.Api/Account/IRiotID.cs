using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Account;

public interface IRiotID
{
    /// <summary>
    /// Account's TagLine.
    /// </summary>
    /// <remarks>
    /// Three-to-five numbers or letters. 
    /// </remarks>
    // Theoretical 62 192 448 combinations (36^3 + 36^4 + 36^5)
    string? TagLine { get; }

    /// <summary>
    /// Account's GameName.
    /// </summary>
    string? GameName { get; }

    /// <summary>
    /// Flag indicating whether <see cref="GameName"/> and <see cref="TagLine"/> are not null.
    /// </summary>
    [JsonIgnore, MemberNotNullWhen(true, nameof(GameName), nameof(TagLine))]
    bool HasRiotID { get; }
}
