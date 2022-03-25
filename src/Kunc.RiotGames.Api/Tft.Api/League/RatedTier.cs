using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Tft.Api.League;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum RatedTier
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Orange,
    Purple,
    Blue,
    Green,
    Gray,
}
