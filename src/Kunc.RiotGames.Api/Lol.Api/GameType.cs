using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum GameType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue = -1,

    /// <summary>
    /// Custom games
    /// </summary>
    [EnumMember(Value = "CUSTOM_GAME")]
    CustomGame,

    /// <summary>
    /// Tutorial games
    /// </summary>
    [EnumMember(Value = "TUTORIAL_GAME")]
    TutorialGame,

    /// <summary>
    /// All other games
    /// </summary>
    [EnumMember(Value = "MATCHED_GAME")]
    MatchedGame,
}
