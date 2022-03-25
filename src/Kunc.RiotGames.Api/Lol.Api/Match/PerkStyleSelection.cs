using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

public record PerkStyleSelection : BaseDto
{
    [JsonPropertyName("perk")]
    public int Pert { get; init; }

    [JsonPropertyName("var1")]
    public int Var1 { get; init; }
    
    [JsonPropertyName("var2")]
    public int Var2 { get; init; }
    
    [JsonPropertyName("var3")]
    public int Var3 { get; init; }
}
