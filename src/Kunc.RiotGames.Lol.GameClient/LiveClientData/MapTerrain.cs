using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumConverter<MapTerrain>))]
public enum MapTerrain
{
    Default,
    Infernal,
    Mountain,
    Ocean,
    Cloud,
    Hextech,
    Chemtech,
}
