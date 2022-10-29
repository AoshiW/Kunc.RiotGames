namespace Kunc.RiotGames.Lor.GameClient;

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

    public GameState? GameState { get; set; }

    /// <summary>
    /// Screen resolution in game.
    /// </summary>
    public Screen Screen { get; set; } = default!;

    public Rectangles[] Rectangles { get; set; } = default!;
}
