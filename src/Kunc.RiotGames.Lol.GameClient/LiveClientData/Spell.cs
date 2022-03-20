using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record Spell : Passive
{
    [JsonPropertyName("abilityLevel")]
    public int AbilityLevel { get; init; }
}
