using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum PublishLocation
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Riotclient,
    Riotstatus,
    Game
}
