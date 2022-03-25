using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api;

[Flags, JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum Positions
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue = -1,

    Unselected = 0,
    Top = 1,//IndividualPosition TeamPosition
    Jungle = 2,//IndividualPosition TeamPosition
    Middle = 4,//IndividualPosition TeamPosition
    Bottom = 8,//IndividualPosition TeamPosition
    Utility = 16,//IndividualPosition TeamPosition
    Fill = Top | Jungle | Middle | Bottom | Utility,
    Invalid = 32,
}
