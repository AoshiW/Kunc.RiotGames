using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public class AllGameDataDto : BaseDto
{
    [JsonPropertyName("activePlayer")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ActivePlayerDto ActivePlayer { get; set; } = new();

    [JsonPropertyName("allPlayers")]
    public PlayerDto[] AllPlayers { get; set; } = [];

    [JsonPropertyName("events")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public EventDataDto Events { get; set; } = new();

    [JsonPropertyName("gameData")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public GameStatsDto GameData { get; set; } = new();
}
