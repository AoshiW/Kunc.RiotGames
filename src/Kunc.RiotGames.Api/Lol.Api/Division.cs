using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Division 
{
    I,
    II,
    III,
    IV,
    //V,
}
