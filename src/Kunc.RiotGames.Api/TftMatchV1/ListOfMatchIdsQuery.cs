namespace Kunc.RiotGames.Api.TftMatchV1;

public class ListOfMatchIdsQuery : QueryString
{
    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    /// <summary>
    /// Defaults to 0. Start index.
    /// </summary>
    public int? Start { get; set; }

    /// <summary>
    /// Defaults to 20. Valid values: 0 to 100. Number of match ids to return.
    /// </summary>
    public int? Count { get; set; }

    public void NextPage()
    {
        Start ??= 0;
        Count ??= 20;

        Start += Count;
    }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (StartTime.HasValue)
            builder.Append("startTime", StartTime.Value.ToUnixTimeSeconds());
        if (EndTime.HasValue)
            builder.Append("endTime", EndTime.Value.ToUnixTimeSeconds());
        if (Start.HasValue)
            builder.Append("start", Start.Value);
        if (Count.HasValue)
            builder.Append("count", Count.Value);
    }
}
