namespace Kunc.RiotGames.Lor.DeckCodes;

/// <summary>
/// Encode/Decode decks to/from simple strings.
/// </summary>
/// <remarks>
/// <see href="https://developer.riotgames.com/docs/lor#deck-codes"/>
/// </remarks>
public interface ILorDeckEncoder
{
    /// <summary>
    ///  Create deck code from given <paramref name="deck"/>.
    /// </summary>
    /// <typeparam name="T">Type that implements <see cref="IReadOnlyDeckItem"/>.</typeparam>
    /// <param name="deck">Deck</param>
    /// <returns>DeckCode created from <paramref name="deck"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deck"/> is null.</exception>
    /// <exception cref="ArgumentException"></exception>
    string GetCodeFromDeck<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem;

    /// <summary>
    /// Create deck from given <paramref name="deckCode"/>.
    /// </summary>
    /// <typeparam name="T">Type that implements <see cref="IDeckItem"/>.</typeparam>
    /// <param name="deckCode">Deck code.</param>
    /// <returns>Deck created from <paramref name="deckCode"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    List<T> GetDeckFromCode<T>(ReadOnlySpan<char> deckCode) where T : IDeckItem, new();

    /// <inheritdoc cref="GetDeckFromCode{T}(ReadOnlySpan{char})"/>
    List<T> GetDeckFromCode<T>(string deckCode) where T : IDeckItem, new()
        => GetDeckFromCode<T>(deckCode.AsSpan());
}
