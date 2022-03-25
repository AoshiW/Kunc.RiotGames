using System.Diagnostics.CodeAnalysis;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Represent action in draft pick.
/// </summary>
public record DraftPick : BaseDto
{
    /// <summary>
    /// Flag indicate if is swap action or pick action.
    /// </summary>
    [MemberNotNullWhen(true, nameof(SwappedIn), nameof(SwappedOut))]
    [MemberNotNullWhen(false, nameof(Picks))]
    public bool IsSwap { get; init; }

    /// <summary>
    /// CardCode of picked cards.
    /// </summary>
    public string[]? Picks { get; init; }

    /// <summary>
    /// CardCode of the cards you received in exchange.
    /// </summary>
    public string[]? SwappedIn { get; init; }

    /// <summary>
    /// CardCode of the cards you lost in exchange.
    /// </summary>
    public string[]? SwappedOut { get; init; }
    
    // todo override PrintMembers?
}
