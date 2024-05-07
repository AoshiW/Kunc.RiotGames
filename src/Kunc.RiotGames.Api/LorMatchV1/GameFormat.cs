using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LorMatchV1;

[JsonConverter(typeof(JsonStringEnumConverter<GameFormat>))]
public enum GameFormat
{
    Standard,
    Eternal,
}
