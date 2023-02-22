namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class LcuEventAttribute : Attribute
{
    public string Uri { get; }

    /// <remarks>
    /// Values: Create, Update, Delete
    /// </remarks>
    public string? EventType { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LcuEventAttribute"/> class
    /// </summary>
    /// <param name="uri"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public LcuEventAttribute(string uri)
    {
        ArgumentNullException.ThrowIfNull(uri);
        Uri = uri;
    }
}
