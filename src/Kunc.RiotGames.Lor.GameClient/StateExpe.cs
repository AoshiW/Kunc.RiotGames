using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Indicate the current state of the Expedition
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum StateExpe
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Indicates the player doesn't have an active Expedition.
    /// </summary>
    Inactive,

    /// <summary>
    /// Indicates the player has an active Expedition, but they're elsewhere in the client including when the player is playing their drafted deck.
    /// </summary>
    Offscreen,

    /// <summary>
    /// Indicates the player is being presented with potential cards to draft. 
    /// </summary>
    Picking,

    /// <summary>
    ///  Indicates the player is being presented with potential card swaps.
    /// </summary>
    Swapping,

    /// <summary>
    /// Indicates the player is viewing one of the interstitial screens within Expeditions.
    /// </summary>
    Other
}
