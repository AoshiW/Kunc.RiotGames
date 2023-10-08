using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// League of Legends TeamId.
/// </summary>
#if NET8_0_OR_GREATER
[JsonConverter(typeof(JsonStringEnumConverter<TeamId>))]
#else
[JsonConverter(typeof(JsonStringEnumConverter))]
#endif
public enum TeamId
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    All = -100,

    Unknown = 0,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>   
    /// Blue team
    /// </summary>
    Order = 100,

    /// <summary>
    /// Red team
    /// </summary>
    Chaos = 200,

    /// <remarks>
    /// When Baron kill herald.
    /// </remarks>
    Neutral = 300,
}
