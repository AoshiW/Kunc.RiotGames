using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum Platform
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Windows,
    macOS,
    Android,
    iOS,
    PS4,
    Xbone,
    Switch
}
