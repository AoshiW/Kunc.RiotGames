using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<EndOfGameResult>))]
public enum EndOfGameResult
{
    GameComplete,

    [JsonStringEnumMemberName("Abort_AntiCheatExit")]
    AbortAntiCheatExit,

    [JsonStringEnumMemberName("Abort_TooFewPlayers")]
    AbortTooFewPlayers,

    [JsonStringEnumMemberName("Abort_Unexpected")]
    AbortUnexpected,
}
