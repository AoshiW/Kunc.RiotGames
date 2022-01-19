namespace Kunc.RiotGames.Lor.DeckCodes;

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
