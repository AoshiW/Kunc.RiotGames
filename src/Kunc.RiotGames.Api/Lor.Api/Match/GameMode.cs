using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum GameMode
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// Tutorial.
    /// </summary>
    Tutorial,

    /// <summary>
    /// AI, Normal, Ranked
    /// </summary>
    Constructed,

    /// <summary>
    /// Expedision.
    /// </summary>
    Expeditions,


    /// <summary>
    /// Singleton Gauntlet.
    /// </summary>
    Singleton,

    /// <summary>
    /// Standard gauntlet.
    /// </summary>
    StandardGauntletLobby,

    // Labs------------------------------------------

    /// <summary>
    /// A.R.A.M
    /// </summary>
    [EnumMember(Value = "Mods_ARAM")]
    ModsAram,

    /// <summary>
    /// Welcome to the Jungle.
    /// </summary>
    [EnumMember(Value = "Mods_Jungle")]
    ModsJungle,

    /// <summary>
    /// Journey to the Peak.
    /// </summary>
    [EnumMember(Value = "Mods_SP_ClimbTheMountain")]
    ModsSPClimbTheMountain,

    /// <summary>
    /// A Landmark Occasion.
    /// </summary>
    [EnumMember(Value = "Mods_SetCelebration_3B")]
    ModsSetCelebration3B,

    /// <summary>
    /// Star power.
    /// </summary>
    [EnumMember(Value = "Mods_StarPowerPreconstructed")]
    ModsStarPowerPreconstructed,

    /// <summary>
    /// Star power.
    /// </summary>
    /// <remarks>
    /// Custom decks.
    /// </remarks>
    [EnumMember(Value = "Mods_StarPowerConstructed")]
    ModsStarPowerConstructed,

    /// <summary>
    /// Hexperimentation 101
    /// </summary>
    [EnumMember(Value = "Mods_Brewery")]
    ModsBrewery,

    /// <summary>
    /// Recursive Heroes 101
    /// </summary>
    [EnumMember(Value = "Mods_Highlander")]
    ModsHighlander,

    /// <summary>
    /// Quick draw.
    /// </summary>
    [EnumMember(Value = "Mods_Inspired")]
    ModsInspired,

    /// <summary>
    /// United front
    /// </summary>
    [EnumMember(Value = "Mods_Coop")]
    ModsCoop,

    /// <summary>
    /// Lab of legends
    /// </summary>
    [EnumMember(Value = "Mods_Power_1")]
    ModsPower1,

    /// <summary>
    /// Heimer's madness
    /// </summary>
    [EnumMember(Value = "Mods_DeckManipulation")]
    ModsDeckManipulation,

    /// <summary>
    /// United front PvP
    /// </summary>
    TeamLabLobby,

    /// <summary>
    /// 
    /// </summary>
    IndependentLanesLabLobby,

    /// <summary>
    /// The path of Champions
    /// </summary>
    [EnumMember(Value = "Power_XP1")]
    PowerXP1,
}
