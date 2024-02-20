namespace Kunc.RiotGames.Api.LolChampionMasteryV4;

public class TopChampionMasteryEntriesQuery : QueryString
{
    /// <summary>
    /// Number of entries to retrieve, defaults to 3.
    /// </summary>
    public int? Count { get; set; }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (Count.HasValue)
            builder.Append("count", Count.Value);
    }
}
