namespace Kunc.RiotGames.Lol;

// TODO summary
/// <remarks>
/// Map ids are used in match history to indicate which map a match was played.
/// </remarks>
public enum MapId
{
    /// <summary>
    /// Original Summer variant
    /// </summary>
    /// Original Summer variant
    SummonersRiftOriginal = 1,

    /// <summary>
    /// Original Autumn variant
    /// </summary>
    SummonersRiftOriginalAutumn = 2,

    /// <summary>
    /// The Proving Grounds
    /// </summary>
    TutorialMap = 3,

    /// <summary>
    /// Original Version (v1)
    /// </summary>
    [Obsolete("This map is no longer available.")]
    TwistedTreelineOriginal = 4,

    /// <summary>
    /// Dominion map
    /// </summary>
    TheCrystalScar = 8,

    /// <summary>
    /// Last TT map (v2)
    /// </summary>
    [Obsolete("November 19, 2019 (patch 9.23) Removed")]
    TwistedTreeline = 10,

    /// <summary>
    /// Current Version
    /// </summary>
    SummonersRift = 11,

    /// <summary>
    /// ARAM map
    /// </summary>
    HowlingAbyss = 12,

    /// <summary>
    /// Alternate ARAM map
    /// </summary>
    ButchersBridge = 14,

    /// <summary>
    /// Dark Star: Singularity map
    /// </summary>
    CosmicRuins = 16,

    /// <summary>
    /// Star Guardian Invasion map
    /// </summary>
    ValoranCityPark = 18,

    /// <summary>
    /// PROJECT: Hunters map
    /// </summary>
    Substructure43 = 19,

    /// <summary>
    /// Odyssey: Extraction map
    /// </summary>
    CrashSite = 20,

    /// <summary>
    /// Nexus Blitz map
    /// </summary>
    NexusBlitz = 21,

    /// <summary>
    /// Teamfight Tactics map
    /// </summary>
    Convergence = 22,
}
