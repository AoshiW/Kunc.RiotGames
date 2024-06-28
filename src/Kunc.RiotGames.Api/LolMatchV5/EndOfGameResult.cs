using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<EndOfGameResult>))]
public enum EndOfGameResult
{
    GameComplete,

    [JsonEnumName("Abort_AntiCheatExit")]
    AbortAntiCheatExit,

    [JsonEnumName("Abort_TooFewPlayers")]
    AbortTooFewPlayers,

    [JsonEnumName("Abort_Unexpected")]
    AbortUnexpected,
}
