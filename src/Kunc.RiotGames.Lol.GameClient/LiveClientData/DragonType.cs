using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumConverter<DragonType>))]
public enum DragonType
{
    Fire,
    Earth,
    Water,
    Air,
    Hextech,
    Chemtech,
    Elder,
}
