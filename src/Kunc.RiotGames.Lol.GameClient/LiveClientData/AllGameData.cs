using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record AllGameData : BaseDto
{
    [JsonPropertyName("activePlayer")]
    public ActivePlayer ActivePlayer { get; init; } = default!;

    [JsonPropertyName("allPlayers")]
    public Player[] AllPlayers { get; init; } = default!;

    [JsonPropertyName("events")]
    public EventData Events { get; init; } = default!;

    [JsonPropertyName("gameData")]
    public GameData GameData { get; init; } = default!;
}