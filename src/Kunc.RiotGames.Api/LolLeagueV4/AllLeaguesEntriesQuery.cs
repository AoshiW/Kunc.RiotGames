namespace Kunc.RiotGames.Api.LolLeagueV4;

public class AllLeaguesEntriesQuery : QueryString
{
    /// <summary>
    /// Defaults to 1. Starts with page 1.
    /// </summary>
    public int? Page { get; set; }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (Page.HasValue)
            builder.Append("page", Page.Value);
    }
}
