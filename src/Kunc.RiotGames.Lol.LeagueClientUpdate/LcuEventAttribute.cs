using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[DebuggerDisplay("Uri = {Uri}, EventType = {EventType} ")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class LcuEventAttribute : Attribute
{
    /// <summary>
    /// Gets the URI of the event.
    /// </summary>
    public string Uri { get; }

    /// <summary>
    /// Gets or sets the type of the event.
    /// </summary>
    /// <remarks>
    /// The possible values are: Create, Update, and Delete.
    /// </remarks>
    public string? EventType { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LcuEventAttribute"/> class
    /// </summary>
    /// <param name="uri">The Uri of the event.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="uri"/> is <see  langword="null"/> or consists only of white-space characters.</exception>
    public LcuEventAttribute([StringSyntax(StringSyntaxAttribute.Uri)] string uri)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(uri);
        if (uri[0] != '/')
            uri = '/' + uri;
        Uri = uri;
    }
}
