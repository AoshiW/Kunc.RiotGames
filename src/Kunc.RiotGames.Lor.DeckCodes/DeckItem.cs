namespace Kunc.RiotGames.Lor.DeckCodes;

public class DeckItem : IReadOnlyDeckItem, IDeckItem
{
    /// <inheritdoc/>
    public string CardCode { get; set; } = default!;

    /// <inheritdoc/>
    public int Count { get; set; }
}
