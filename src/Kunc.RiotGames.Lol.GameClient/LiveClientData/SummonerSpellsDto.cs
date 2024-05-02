using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class SummonerSpellsDto : BaseDto
{
    [JsonPropertyName("summonerSpellOne")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SummonerSpellDto SummonerSpellOne { get; set; } = new();

    [JsonPropertyName("summonerSpellTwo")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SummonerSpellDto SummonerSpellTwo { get; set; } = new();
}
