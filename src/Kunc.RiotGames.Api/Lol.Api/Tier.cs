using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Tier 
{
    Unranked,
    Iron,
    Bronze,
    Silver,
    Gold,
    Platinum,
    Diamond,
    Master,
    Grandmater,
    Challenger,
}
