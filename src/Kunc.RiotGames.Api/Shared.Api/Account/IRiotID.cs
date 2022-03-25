using Kunc.RiotGames.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Account;

public interface IRiotID
{
    /// <summary>
    /// Account's TagLine.
    /// </summary>
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
