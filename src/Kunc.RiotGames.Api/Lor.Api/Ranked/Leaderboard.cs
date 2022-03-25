namespace Kunc.RiotGames.Lor.Api.Ranked;

public record Leaderboard : BaseDto
{
    /// <summary>
    /// A list of players in Master tier.
    /// </summary>
    public Player[] Players { get; init; } = default!;
}
