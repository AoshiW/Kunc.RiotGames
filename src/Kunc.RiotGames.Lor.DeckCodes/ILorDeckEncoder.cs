using System;
using System.Collections.Generic;

namespace Kunc.RiotGames.Lor.DeckCodes;

public interface ILorDeckEncoder
{
    /// <summary>
    ///  Create deck code from given <paramref name="deck"/>.
    /// </summary>
    /// <typeparam name="T">Type that implements <see cref="IReadOnlyDeckItem"/>.</typeparam>
    /// <param name="deck">Deck</param>
    /// <returns>DeckCode created from <paramref name="deck"/>.</returns>
    string GetCodeFromDeck<T>(IEnumerable<T> deck) where T : IReadOnlyDeckItem;

    /// <summary>
    /// Create deck from given <paramref name="deckCode"/>.
    /// </summary>
    /// <typeparam name="T">Type that implements <see cref="IDeckItem"/>.</typeparam>
    /// <param name="deckCode">Deck code.</param>
    /// <returns>Deck created from <paramref name="deckCode"/>.</returns>
    List<T> GetDeckFromCode<T>(ReadOnlySpan<char> deckCode) where T : IDeckItem, new();
}