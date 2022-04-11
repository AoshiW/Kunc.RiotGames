using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum GameType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Tutorial.
    /// </summary>
    Tutorial,

    /// <summary>
    /// AI.
    /// </summary>
    AI,

    /// <summary>
    /// Normal.
    /// </summary>
    Normal,

    /// <summary>
    /// Ranked.
    /// </summary>
    Ranked,

    /// <summary>
    /// Standard gauntlet.
    /// </summary>
    StandardGauntlet,

    /// <summary>
    /// Singleton.
    /// </summary>
    Singleton,

    VanillaTrial,

    [EnumMember(Value = "")]
    Lab,
}
