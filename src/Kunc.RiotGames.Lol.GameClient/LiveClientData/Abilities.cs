namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

/// <summary>
/// Champion's abilities.
/// </summary>
public record Abilities : BaseDto
{
    /// <summary>
    /// Passive ability.
    /// </summary>
    public Passive Passive { get; init; } = default!;

    /// <summary>
    /// Q ability. 
    /// </summary>
    public Spell Q { get; init; } = default!;

    /// <summary>
    /// W ability. 
    /// </summary>
    public Spell W { get; init; } = default!;

    /// <summary>
    /// E ability. 
    /// </summary>
    public Spell E { get; init; } = default!;

    /// <summary>
    /// Ultimate (R) ability.
    /// </summary>
    public Spell R { get; init; } = default!;
}
