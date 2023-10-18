using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// The game state.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<GameState>))]
public enum GameState
{
    /// <summary>
    /// Player is in the collection view, deck builder or Expedition drafts.
    /// </summary>
    Menus,

    /// <summary>
    /// Player is in an active game.
    /// </summary>
    InProgress,
}
