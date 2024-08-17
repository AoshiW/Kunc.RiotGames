using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LorMatchV1;

[JsonConverter(typeof(CustomJsonStringEnumConverter<GameType>))]
public enum GameType
{
    [JsonStringEnumMemberName("")]
    EmptyString,
    Normal,
    Ranked,
    AI,
    Tutorial,
}
