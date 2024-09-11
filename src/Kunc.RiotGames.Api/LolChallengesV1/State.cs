using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolChallengesV1;

[JsonConverter(typeof(JsonStringEnumConverter<State>))]
public enum State
{
    /// <summary>
    /// not visible and not calculated
    /// </summary>
    Disabled,

    /// <summary>
    /// not visible, but calculated
    /// </summary>
    Hidden,

    /// <summary>
    /// visible, but not calculated
    /// </summary>
    Archived,

    /// <summary>
    /// visible and calculated
    /// </summary>
    Enabled,
}

[Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
public static class StateExtensions
{
    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    public static bool IsVisible(this State state)
    {
        return (state & State.Archived) == State.Archived;
    }

    [Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
    public static bool IsCalculated(this State state)
    {
        return (state & State.Hidden) == State.Hidden;
    }
}
