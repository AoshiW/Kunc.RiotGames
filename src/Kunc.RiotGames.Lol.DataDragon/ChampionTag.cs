using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.DataDragon;

// todo fix converter ChampionTag?
[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum ChampionTag
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    Assassin,
    Fighter,
    Mage, 
    Support,
    Marksman,
    Tank,

    /// <remarks>
    /// For "Shen", DataDragon versions: 6.16.1 - 7.2.1
    /// </remarks>
    Melee,
}
