using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol;

/// <summary>
/// Game modes in League of Legends.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<GameMode>))]
public enum GameMode
{
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

#pragma warning disable CA1707 // Identifiers should not contain underscores
    /// <summary>
    /// Tutorial part 1: Welcome to League
    /// </summary>
    TUTORIAL_MODULE_1,

    /// <summary>
    /// Tutorial part 2: Power Up
    /// </summary>
    TUTORIAL_MODULE_2,

    /// <summary>
    /// Tutorial part 3: Shop for Gear
    /// </summary>
    TUTORIAL_MODULE_3,
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
