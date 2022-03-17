using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum GameState
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Player is in the collection view, deck builder or Expedition drafts.
    /// </summary>
    Menus,

    /// <summary>
    /// Player is in an active game.
    /// </summary>
    InProgress,
}
