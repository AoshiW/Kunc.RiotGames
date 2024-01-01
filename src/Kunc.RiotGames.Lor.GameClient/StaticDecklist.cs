namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Represent the player's deck in the game.
/// </summary>
public class StaticDecklist : BaseDto
{
    /// <summary>
    /// DeckCode of current deck.
    /// </summary>
    public string? DeckCode { get; set; }

    /// <summary>
    /// Cards in current deck.
    /// </summary>
    public Dictionary<string, int>? CardsInDeck { get; set; }
}
