using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Api.LolMatchV5;

[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<MatchEventType>))]
public enum MatchEventType
{
    [JsonStringEnumMemberName("BUILDING_KILL")]
    BuildingKill,

    [JsonStringEnumMemberName("CHAMPION_KILL")]
    ChampionKill,

    [JsonStringEnumMemberName("CHAMPION_SPECIAL_KILL")]
    ChampionSpecialKill,

    [JsonStringEnumMemberName("CHAMPION_TRANSFORM")]
    ChampionTransform,

    [JsonStringEnumMemberName("DRAGON_SOUL_GIVEN")]
    DragonSoulGiven,

    [JsonStringEnumMemberName("ELITE_MONSTER_KILL")]
    EliteMonsterKill,

    [JsonStringEnumMemberName("GAME_END")]
    GameEnd,

    [JsonStringEnumMemberName("ITEM_DESTROYED")]
    ItemDestroyed,

    [JsonStringEnumMemberName("ITEM_SOLD")]
    ItemSold,

    [JsonStringEnumMemberName("ITEM_PURCHASED")]
    ItemPurchased,

    [JsonStringEnumMemberName("ITEM_UNDO")]
    ItemUndo,

    [JsonStringEnumMemberName("LEVEL_UP")]
    LevelUp,

    [JsonStringEnumMemberName("OBJECTIVE_BOUNTY_FINISH")]
    ObjectiveBountyFinish,

    [JsonStringEnumMemberName("OBJECTIVE_BOUNTY_PRESTART")]
    ObjectiveBountyPrestart,

    [JsonStringEnumMemberName("PAUSE_END")]
    PauseEnd,

    [JsonStringEnumMemberName("PAUSE_START")]
    PauseStart,

    [JsonStringEnumMemberName("SKILL_LEVEL_UP")]
    SkillLevelUp,

    [JsonStringEnumMemberName("TURRET_PLATE_DESTROYED")]
    TurretPlateDestroyed,

    [JsonStringEnumMemberName("WARD_KILL")]
    WardKill,

    [JsonStringEnumMemberName("WARD_PLACED")]
    WardPlaced,
}
