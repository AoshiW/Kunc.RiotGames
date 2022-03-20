using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

[JsonConverter(typeof(JsonStringEnumMemberConverter)), JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: UnknownEnumValue)]
public enum GameMode
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue,

    /// <summary>
    /// ARAM games
    /// </summary>
    [Description("ARAM games")]
    Aram,

    /// <summary>
    /// All Random Summoner's Rift games
    /// </summary>
    [Description("All Random Summoner's Rift games")]
    Arsr,

    /// <summary>
    /// Ascension games
    /// </summary>
    [Description("Ascension games")]
    Ascension,

    /// <summary>
    /// Blood Hunt Assassin games
    /// </summary>
    [Description("Blood Hunt Assassin games")]
    Assassinate,

    /// <summary>
    /// Classic Summoner's Rift and Twisted Treeline games
    /// </summary>
    [Description("Classic Summoner's Rift and Twisted Treeline games")]
    Classic,

    /// <summary>
    /// Dark Star: Singularity games
    /// </summary>
    [Description("Dark Star: Singularity games")]
    DarkStar,

    /// <summary>
    /// Doom Bot games
    /// </summary>
    [Description("Doom Bot games")]
    DoomBotsTeemo,

    /// <summary>
    /// Snowdown Showdown games
    /// </summary>
    [Description("Snowdown Showdown games")]
    FirstBlood,

    /// <summary>
    /// Nexus Blitz games
    /// </summary>
    [Description("Nexus Blitz games")]
    GameModeX,

    /// <summary>
    /// Legend of the Poro King games
    /// </summary>
    [Description("Legend of the Poro King games")]
    KingPoro,

    /// <summary>
    /// Nexus Blitz games
    /// </summary>
    [Description("Nexus Blitz games")]
    NexisBlitz,

    /// <summary>
    /// Dominion/Crystal Scar games
    /// </summary>
    [Description("Dominion/Crystal Scar games")]
    ODIN,

    /// <summary>
    /// Odyssey: Extraction games
    /// </summary>
    [Description("Odyssey: Extraction games")]
    Odyssey,

    /// <summary>
    /// One for All games
    /// </summary>
    [Description("One for All games")]
    OneForAll,

    /// <summary>
    /// PROJECT: Hunters games
    /// </summary>
    [Description("PROJECT: Hunters games")]
    Project,

    /// <summary>
    /// Nexus Siege games
    /// </summary>
    [Description("Nexus Siege games")]
    Siege,

    /// <summary>
    /// Star Guardian Invasion games
    /// </summary>
    [Description("Star Guardian Invasion games")]
    StarGuardian,

    /// <summary>
    /// Tutorial games
    /// </summary>
    [Obsolete($"Use {nameof(TutorialModule1)}/{nameof(TutorialModule2)}/{nameof(TutorialModule3)} instead"), Description("Tutorial games")]
    Tutorial,

    /// <summary>
    /// Tutorial: Welcome to League
    /// </summary>
    [EnumMember(Value ="TUTORIAL_MODULE_1"), Description("Tutorial: Welcome to League")]
    TutorialModule1,

    /// <summary>
    /// Tutorial: Power Up
    /// </summary>
    [EnumMember(Value = "TUTORIAL_MODULE_2"), Description("Tutorial: Power Up")]
    TutorialModule2,

    /// <summary>
    /// Tutorial: Shop for Gear
    /// </summary>
    [EnumMember(Value = "TUTORIAL_MODULE_3"), Description("Tutorial: Shop for Gear")]
    TutorialModule3,

    /// <summary>
    /// Ultimate Spellbook games
    /// </summary>
    [Description("Ultimate Spellbook games")]
    UltBook,

    /// <summary>
    /// URF games
    /// </summary>
    [Description("URF games")]
    Urf,
}
