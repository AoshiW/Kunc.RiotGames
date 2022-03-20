using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum ResourceType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    None, // Dr. Mundo
    BattleFury, // Tryndamere
    BloodWell, // Aatrox
    DragonFury, // Shyvana
    Energy, // Akali
    Ferocity, // Rengar
    GnarFury, // Gnar
    Heat, // Rumble
    Mana, // Ahri
    Rage, // Renekton
    Shield, // Mordekaiser
    Wind, // Yasuo

    //Max, Ammo, Other, MoonLight
}
