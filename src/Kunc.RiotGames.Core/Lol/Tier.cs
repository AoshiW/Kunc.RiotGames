using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Tier
{
    Unranked,
    Iron,
    Bronze,
    Silver,
    Gold,
    Platinum,
    Dismond,
    Master,
    Grandmaster,
    Challenger
}
