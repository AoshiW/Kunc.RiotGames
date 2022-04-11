using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Clash;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum ClashRole
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Captein,
    Member
}
