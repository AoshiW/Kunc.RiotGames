namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Information about position of the cards in the collection, deck builder, and active games.
/// </summary>
public class PositionalRectangles : BaseDto
{
    /// <summary>
    /// Local player name
    /// </summary>
    public string? PlayerName { get; set; }

    /// <summary>
    /// Opponent name.
    /// </summary>
    public string? OpponentName { get; set; }

    /// <summary>
    /// Current state of game.
    /// </summary>
    /// <remarks>
    /// <see langword="null"/> means that the game is loading (state between <see cref="GameState.Menus"/> and <see cref="GameState.InProgress"/>).
    /// </remarks>
    public GameState? GameState { get; set; }

    /// <summary>
    /// Screen resolution in game.
    /// </summary>
    public Screen Screen { get; set; } = default!;

    /// <summary>
    /// Information about card positions.
    /// </summary>
    public Rectangles[] Rectangles { get; set; } = default!;
}
