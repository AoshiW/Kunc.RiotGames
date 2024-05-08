using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// Game modes in League of Legends.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverterWithAltNames<GameMode>))]
public enum GameMode
{
    [JsonEnumName("")]
    EmptyString,

    /// <summary>
    /// Classic Summoner's Rift and Twisted Treeline games.
    /// </summary>
    Classic,

    /// <summary>
    /// Dominion/Crystal Scar games,
    /// </summary>
    Odin,

    /// <summary>
    /// ARAM games.
    /// </summary>
    Aram,

    /// <summary>
    /// Tutorial games.
    /// </summary>
    Tutorial,

    /// <summary>
    /// URF games.
    /// </summary>
    Urf,

    /// <summary>
    /// Doom Bot games
    /// </summary>
    DoomBotsTeemo,

    /// <summary>
    /// One for All games.
    /// </summary>
    OneForAll,

    /// <summary>
    /// Ascension games.
    /// </summary>
    Ascension,

    /// <summary>
    /// Snowdown Showdown games
    /// </summary>
    FiestBlood,

    /// <summary>
    /// Legend of the Poro King games.
    /// </summary>
    KingPoro,

    /// <summary>
    /// Nexus Siege games.
    /// </summary>
    Siege,

    /// <summary>
    /// Blood Hunt Assassin games.
    /// </summary>
    Assassinate,

    /// <summary>
    /// All Random Summoner's Rift games.
    /// </summary>
    Arsr,

    /// <summary>
    /// Dark Star: Singularity games.
    /// </summary>
    DarkStar,

    /// <summary>
    /// Star Guardian Invasion games.
    /// </summary>
    StarGuardian,

    /// <summary>
    /// PROJECT: Hunters games.
    /// </summary>
    Project,

    /// <summary>
    /// Nexus Blitz games.
    /// </summary>
    GameModeX,

    /// <summary>
    /// Odyssey: Extraction games.
    /// </summary>
    Odyssey,

    /// <summary>
    /// Nexus Blitz games.
    /// </summary>
    NexusBlitz,

    /// <summary>
    /// Ultimate Spellbook games.
    /// </summary>
    UltBook,

    /// <summary>
    /// Arena (2v2v2v2)
    /// </summary>
    Cherry,

    /// <summary>
    /// Practice Tool.
    /// </summary>
    PracticeTool,

    /// <summary>
    /// Tutorial part 1: Welcome to League
    /// </summary>
    [JsonEnumName("TUTORIAL_MODULE_1")]
    TutorialModule1,

    /// <summary>
    /// Tutorial part 2: Power Up
    /// </summary>
    [JsonEnumName("TUTORIAL_MODULE_2")]
    TutorialModule2,

    /// <summary>
    /// Tutorial part 3: Shop for Gear
    /// </summary>
    [JsonEnumName("TUTORIAL_MODULE_3")]
    TutorialModule3,

    /// <summary>
    /// Teamfight Tactics
    /// </summary>
    Tft,
}
