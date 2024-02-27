using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverter<MatchEventType>))]
public enum MatchEventType
{
    BUILDING_KILL,
    CHAMPION_KILL,
    CHAMPION_SPECIAL_KILL,
    CHAMPION_TRANSFORM,
    DRAGON_SOUL_GIVEN,
    ELITE_MONSTER_KILL,
    GAME_END,
    ITEM_DESTROYED,
    ITEM_SOLD,
    ITEM_PURCHASED,
    ITEM_UNDO,
    LEVEL_UP,
    OBJECTIVE_BOUNTY_FINISH,
    OBJECTIVE_BOUNTY_PRESTART,
    PAUSE_END,
    SKILL_LEVEL_UP,
    TURRET_PLATE_DESTROYED,
    WARD_KILL,
    WARD_PLACED,
}
