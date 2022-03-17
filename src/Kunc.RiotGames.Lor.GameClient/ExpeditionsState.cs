namespace Kunc.RiotGames.Lor.GameClient;

public record ExpeditionsState : BaseDto
{
    /// <summary>
    /// Flag indicating whether expedition is active.
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Indicate the current state of the Expedition
    /// </summary>
    public StateExpe State { get; init; }

    /// <summary>
    /// win,loss
    /// </summary>
    public string[]? Record { get; init; }

    /// <summary>
    /// Picked card in draft,
    /// </summary>
    public DraftPick[]? DraftPicks { get; init; }

    /// <summary>
    /// Card (CardCode) in deck
    /// </summary>
    public string[]? Deck { get; init; }

    /// <summary>
    /// Count of games.
    /// </summary>
    public int Games { get; init; }

    /// <summary>
    /// Count of wins.
    /// </summary>
    public int Wins { get; init; }

    /// <summary>
    /// Count of losses. 
    /// </summary>
    public int Losses { get; init; }
}
