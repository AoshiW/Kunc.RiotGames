namespace Kunc.RiotGames.Api.LolChallengesV1;

//
public class TopPlayersQuery : QueryString
{
    public int? Limit { get; set; }

    /// <inheritdoc/>
    protected override void ToStringCore(ref QueryStringBuilder builder)
    {
        if (Limit.HasValue)
            builder.Append("limit", Limit.Value);
    }
}
