namespace Kunc.RiotGames.Extensions;

public record LolMatchListOptions
{
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
    public int? Queue { get; set; }
    public string? Type { get; set; }
    public int? Start { get; set; }
    public int? Count { get; set; }

    public LolMatchListOptions NextPage()
    {
        Start = (Start ?? 0) + (Count ??= 20);
        return this;
    }
}
