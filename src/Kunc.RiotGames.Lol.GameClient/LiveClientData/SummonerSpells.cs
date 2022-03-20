using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record SummonerSpells : BaseDto
{
    [JsonPropertyName("summonerSpellOne")]
    public SummonerSpell SummonerSpellOne { get; init; } = default!;

    [JsonPropertyName("summonerSpellTwo")]
    public SummonerSpell SummonerSpellTwo { get; init; } = default!;
}
