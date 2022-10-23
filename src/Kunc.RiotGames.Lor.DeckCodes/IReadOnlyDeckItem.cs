namespace Kunc.RiotGames.Lor.DeckCodes;

/// <summary>
/// Represent ReadOnly item in deck.
/// </summary>
public interface IReadOnlyDeckItem
{
    /// <summary>
    /// Card's card code.
    /// </summary>
    public string CardCode { get; }

    /// <summary>
    /// Card's count.
    /// </summary>
    public int Count { get; }
}
