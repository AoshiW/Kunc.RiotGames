using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.TftLeagueV1;

public class AllLeaguesEntriesQuery : QueryString
{
    /// <summary>
    /// Defaults to <see cref="QueueType.RankedTft"/>
    /// </summary>
    public QueueType? Queue { get; set; }

    /// <summary>
    /// Defaults to 1. Starts with page 1.
    /// </summary>
    public int? Page { get; set; }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (Queue.HasValue)
            builder.Append("queue", Queue.Value.ToApiString());
        if (Page.HasValue)
            builder.Append("page", Page.Value);
    }
}
