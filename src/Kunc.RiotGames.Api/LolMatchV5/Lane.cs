using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<Lane>))]
public enum Lane
{
    None,
    Top,
    Jungle,
    Middle,
    Bottom,
}
