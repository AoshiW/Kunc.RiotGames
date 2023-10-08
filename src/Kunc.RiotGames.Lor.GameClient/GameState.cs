using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// The game state.
/// </summary>
#if NET8_0_OR_GREATER
[JsonConverter(typeof(JsonStringEnumConverter<GameState>))]
#else
[JsonConverter(typeof(JsonStringEnumConverter))]
#endif
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
