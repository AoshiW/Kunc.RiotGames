using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LorMatchV1;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<GameType>))]
public enum GameType
{
    [JsonStringEnumMemberName("")]
    EmptyString,
    Normal,
    Ranked,
    AI,
    Tutorial,
}
