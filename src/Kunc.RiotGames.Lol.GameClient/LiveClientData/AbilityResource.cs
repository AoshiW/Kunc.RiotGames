using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

/// <summary>
/// Ability Resource
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum AbilityResource
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue = -1,

    Mana, // Ahri
    Energy, // Akali
    None, // Dr. Mundo
    Shield, // Mordekaiser
    BattleFury, // Tryndamere
    DragonFury, // Shyvana
    Rage, // Renekton
    Heat, // Rumble
    GnarFury, // Gnar
    Ferocity, // Rengar
    BloodWell, // Aatrox
    Wind, // Yasuo

    //??
    Ammo, 
    MoonLight,
    Other,
    Max,
}
