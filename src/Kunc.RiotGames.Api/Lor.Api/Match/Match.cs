namespace Kunc.RiotGames.Lor.Api.Match;

public record Match
{
    /// <summary>
    /// Match metadata.
    /// </summary>
    public MatchMetadata Metadata { get; init; } = default!;

    /// <summary>
    /// Match info.
    /// </summary>
    public Info Info { get; init; } = default!;
}
