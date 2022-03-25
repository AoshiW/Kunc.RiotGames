using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum EventType
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    PAUSE_END,
    LEVEL_UP,
    SKILL_LEVEL_UP,
    ITEM_PURCHASED,
    WARD_PLACED,
    ITEM_DESTROYED,
    CHAMPION_KILL,
    CHAMPION_SPECIAL_KILL,
    ITEM_UNDO,
    BUILDING_KILL,
    ITEM_SOLD,
    GAME_END,
    WARD_KILL,
    TURRET_PLATE_DESTROYED,
    ELITE_MONSTER_KILL,
    OBJECTIVE_BOUNTY_PRESTART,
    OBJECTIVE_BOUNTY_FINISH,
    DRAGON_SOUL_GIVEN,
    CHAMPION_TRANSFORM,
}
