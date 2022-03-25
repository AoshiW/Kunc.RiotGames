namespace Kunc.RiotGames;

public readonly record struct MatchId<T>(T Routing, string Code)
{
    public static MatchId<T>[] Create(T routing, string[] ids)
    {
        if(ids.Length == 0)
        {
            return Array.Empty<MatchId<T>>();
        }
        var matchIds = new MatchId<T>[ids.Length];
        for(int i = 0; i < ids.Length; i++)
        {
            matchIds[i] = new MatchId<T>(routing, ids[i]);
        }
        return matchIds;
    }
}
