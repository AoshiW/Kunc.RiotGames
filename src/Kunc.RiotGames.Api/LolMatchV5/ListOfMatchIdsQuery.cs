namespace Kunc.RiotGames.Api.LolMatchV5;

public class ListOfMatchIdsQuery : QueryString
{
    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    /// <summary>
    /// Filter the list of match ids by a specific queue id.
    /// </summary>
    /// <remarks>
    /// This filter is mutually inclusive of the <see cref="Type"/> filter meaning any match ids returned must match both the <see cref="Queue"/> and type <see cref="Type"/>.
    /// </remarks>
    public int? Queue{ get; set; }

    /// <summary>
    /// Filter the list of match ids by the type of match.
    /// </summary>
    /// <remarks>
    /// This filter is mutually inclusive of the <see cref="Queue"/> filter meaning any match ids returned must match both the <see cref="Queue"/> and type <see cref="Type"/>.
    /// </remarks>
    public string? Type { get; set; }

    /// <summary>
    /// Defaults to 0. Start index.
    /// </summary>
    public int? Start { get; set; }

    /// <summary>
    /// Defaults to 20. Valid values: 0 to 100. Number of match ids to return.
    /// </summary>
    public int? Count { get; set; }

    public ListOfMatchIdsQuery NextPage()
    {
        Start ??= 0;
        Count ??= 20;

        Start += Count;
        return this;
    }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (StartTime.HasValue)
            builder.Append("startTime", StartTime.Value.ToUnixTimeSeconds());
        if (EndTime.HasValue)
            builder.Append("endTime", EndTime.Value.ToUnixTimeSeconds());
        if (Queue.HasValue)
            builder.Append("queue", Queue.Value);
        if (Type is not null)
            builder.Append("type", Type);
        if (Start.HasValue)
            builder.Append("start", Start.Value);
        if (Count.HasValue)
            builder.Append("count", Count.Value);
    }
}
