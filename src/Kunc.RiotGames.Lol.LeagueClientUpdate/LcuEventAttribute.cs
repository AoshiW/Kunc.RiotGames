namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class LcuEventAttribute : Attribute
{
    public string Uri { get; }
    //public string EventType { get; }

    public LcuEventAttribute(string uri)
    {
        Uri = uri;
    }
}
