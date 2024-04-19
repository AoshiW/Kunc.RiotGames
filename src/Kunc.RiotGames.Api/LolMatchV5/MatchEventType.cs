using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<MatchEventType>))]
public enum MatchEventType
{
    [JsonEnumName("BUILDING_KILL")]
    BuildingKill,

    [JsonEnumName("CHAMPION_KILL")]
    ChampionKill,

    [JsonEnumName("CHAMPION_SPECIAL_KILL")]
    ChampionSpecialKill,

    [JsonEnumName("CHAMPION_TRANSFORM")]
    ChampionTransform,

    [JsonEnumName("DRAGON_SOUL_GIVEN")]
    DragonSoulGiven,

    [JsonEnumName("ELITE_MONSTER_KILL")]
    EliteMonsterKill,

    [JsonEnumName("GAME_END")]
    GameEnd,

    [JsonEnumName("ITEM_DESTROYED")]
    ItemDestroyed,

    [JsonEnumName("ITEM_SOLD")]
    ItemSold,

    [JsonEnumName("ITEM_PURCHASED")]
    ItemPurchased,

    [JsonEnumName("ITEM_UNDO")]
    ItemUndo,

    [JsonEnumName("LEVEL_UP")]
    LevelUp,

    [JsonEnumName("OBJECTIVE_BOUNTY_FINISH")]
    ObjectiveBountyFinish,

    [JsonEnumName("OBJECTIVE_BOUNTY_PRESTART")]
    ObjectiveBountyPrestart,

    [JsonEnumName("PAUSE_END")]
    PauseEnd,

    [JsonEnumName("SKILL_LEVEL_UP")]
    SkillLevelUp,

    [JsonEnumName("TURRET_PLATE_DESTROYED")]
    TurretPlateDestroyed,

    [JsonEnumName("WARD_KILL")]
    WardKill,

    [JsonEnumName("WARD_PLACED")]
    WardPlaced,
}
