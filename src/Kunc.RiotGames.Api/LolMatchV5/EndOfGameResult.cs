using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<EndOfGameResult>))]
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
