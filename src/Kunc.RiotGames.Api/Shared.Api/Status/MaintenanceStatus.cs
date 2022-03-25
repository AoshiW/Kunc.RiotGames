using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Shared.Api.Status;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum MaintenanceStatus
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Scheduled,
    [EnumMember(Value = "in_progress")]
    InProgress,
    Complete
}
