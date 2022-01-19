namespace Kunc.RiotGames.Lor.DeckCodes;

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
