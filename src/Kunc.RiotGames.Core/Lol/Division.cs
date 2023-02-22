using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Division
{
    None,
    I,
    II,
    III,
    IV
}
