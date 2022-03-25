namespace Kunc.RiotGames.Lor.DeckCodes;

/// <summary>
/// Represent item in deck.
/// </summary>
public interface IDeckItem
{
    /// <summary>
    /// Card's card code.
    /// </summary>
    public string CardCode { get; set; }

    /// <summary>
    /// Card's count.
    /// </summary>
    public int Count { get; set; }
}
