namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class LcuEventAttribute : Attribute
{
    public string Uri { get; }

    /// <remarks>
    /// Values: Create, Update, Delete
    /// </remarks>
    public string? EventType { get; set; }

    public LcuEventAttribute(string uri)
    {
        Uri = uri;
    }
}
