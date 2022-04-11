using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Participant : BaseDto, IKda
{
    /// <inheritdoc/>
    [JsonPropertyName("assists")]
    public int Assists { get; init; }

    [JsonPropertyName("baronKills")]
    public int BaronKills { get; init; }

    [JsonPropertyName("bountyLevel")]
    public int BountyLevel { get; init; }

    [JsonPropertyName("challenges")]
    public Challenges? Challenges { get; init; }

    [JsonPropertyName("champExperience")]
    public int ChampExperience { get; init; }

    [JsonPropertyName("champLevel")]
    public int ChampLevel { get; init; }

    /// <remarks>
    /// Prior to patch 11.4, on Feb 18th, 2021, this field returned invalid championIds.
    /// Riot recommend determining the champion based on the championName field for matches played prior to patch 11.4.
    /// </remarks>
    [JsonPropertyName("championId")]
    public int ChampionId { get; init; }

    [JsonPropertyName("championName")]
    public string ChampionName { get; init; } = default!;

    /// <summary>
    /// This field is currently only utilized for Kayn's transformations. (Legal values: 0 - None, 1 - Slayer, 2 - Assassin)
    /// </summary>
    [JsonPropertyName("championTransform")]
    public int? ChampionTransform { get; init; }

    [JsonPropertyName("consumablesPurchased")]
    public int ConsumablesPurchased { get; init; }

    [JsonPropertyName("damageDealtToBuildings")]
    public int DamageDealtToBuildings { get; init; }

    [JsonPropertyName("damageDealtToObjectives")]
    public int DamageDealtToObjectives { get; init; }

    [JsonPropertyName("damageDealtToTurrets")]
    public int DamageDealtToTurrets { get; init; }

    [JsonPropertyName("damageSelfMitigated")]
    public int DamageSelfMitigated { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("deaths")]
    public int Deaths { get; init; }

    [JsonPropertyName("detectorWardsPlaced")]
    public int DetectorWardsPlaced { get; init; }

    [JsonPropertyName("doubleKills")]
    public int DoubleKills { get; init; }

    [JsonPropertyName("dragonKills")]
    public int DragonKills { get; init; }

    [JsonPropertyName("firstBloodAssist")]
    public bool FirstBloodAssist { get; init; }

    [JsonPropertyName("firstBloodKill")]
    public bool FirstBloodKill { get; init; }

    [JsonPropertyName("firstTowerAssist")]
    public bool FirstTowerAssist { get; init; }

    [JsonPropertyName("firstTowerKill")]
    public bool FirstTowerKill { get; init; }

    [JsonPropertyName("gameEndedInEarlySurrender")]
    public bool GameEndedInEarlySurrender { get; init; }

    [JsonPropertyName("gameEndedInSurrender")]
    public bool GameEndedInSurrender { get; init; }

    [JsonPropertyName("goldEarned")]
    public int GoldEarned { get; init; }

    [JsonPropertyName("goldSpent")]
    public int GoldSpent { get; init; }

    /// <summary>
    /// The individualPosition is the best guess for which position the player actually played in isolation of anything else. 
    /// </summary>
    [JsonPropertyName("individualPosition")]
    public Positions IndividualPosition { get; init; } = default!;

    [JsonPropertyName("inhibitorKills")]
    public int InhibitorKills { get; init; }

    [JsonPropertyName("inhibitorTakedowns")]
    public int InhibitorTakedowns { get; init; }

    [JsonPropertyName("inhibitorsLost")]
    public int InhibitorsLost { get; init; }

    [JsonPropertyName("item0")]
    public int Item0 { get; init; }

    [JsonPropertyName("item1")]
    public int Item1 { get; init; }

    [JsonPropertyName("item2")]
    public int Item2 { get; init; }

    [JsonPropertyName("item3")]
    public int Item3 { get; init; }

    [JsonPropertyName("item4")]
    public int Item4 { get; init; }

    [JsonPropertyName("item5")]
    public int Item5 { get; init; }

    [JsonPropertyName("item6")]
    public int Item6 { get; init; }

    [JsonPropertyName("itemsPurchased")]
    public int ItemsPurchased { get; init; }

    [JsonPropertyName("killingSprees")]
    public int KillingSprees { get; init; }

    /// <inheritdoc/>
    [JsonPropertyName("kills")]
    public int Kills { get; init; }

    [JsonPropertyName("lane")]
    public string Lane { get; init; } = default!;

    [JsonPropertyName("largestCriticalStrike")]
    public int LargestCriticalStrike { get; init; }

    [JsonPropertyName("largestKillingSpree")]
    public int LargestKillingSpree { get; init; }

    [JsonPropertyName("largestMultiKill")]
    public int LargestMultiKill { get; init; }

    [JsonPropertyName("longestTimeSpentLiving"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan LongestTimeSpentLiving { get; init; }

    [JsonPropertyName("magicDamageDealt")]
    public int MagicDamageDealt { get; init; }

    [JsonPropertyName("magicDamageDealtToChampions")]
    public int MagicDamageDealtToChampions { get; init; }

    [JsonPropertyName("magicDamageTaken")]
    public int MagicDamageTaken { get; init; }

    [JsonPropertyName("neutralMinionsKilled")]
    public int NeutralMinionsKilled { get; init; }

    [JsonPropertyName("nexusKills")]
    public int NexusKills { get; init; }

    [JsonPropertyName("nexusTakedowns")]
    public int NexusTakedowns { get; init; }

    [JsonPropertyName("nexusLost")]
    public int NexusLost { get; init; }

    [JsonPropertyName("objectivesStolen")]
    public int ObjectivesStolen { get; init; }

    [JsonPropertyName("objectivesStolenAssists")]
    public int ObjectivesStolenAssists { get; init; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; init; }

    [JsonPropertyName("pentaKills")]
    public int PentaKills { get; init; }

    [JsonPropertyName("perks")]
    public Perks Perks { get; init; } = default!;

    [JsonPropertyName("physicalDamageDealt")]
    public int PhysicalDamageDealt { get; init; }

    [JsonPropertyName("physicalDamageDealtToChampions")]
    public int PhysicalDamageDealtToChampions { get; init; }

    [JsonPropertyName("physicalDamageTaken")]
    public int PhysicalDamageTaken { get; init; }

    [JsonPropertyName("profileIcon")]
    public int ProfileIcon { get; init; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; init; } = default!;

    [JsonPropertyName("quadraKills")]
    public int QuadraKills { get; init; }

    [JsonPropertyName("riotIdName")]
    public string RiotIdName { get; init; } = default!;

    [JsonPropertyName("riotIdTagline")]
    public string RiotIdTagline { get; init; } = default!;

    [JsonPropertyName("role")]
    public string Role { get; init; } = default!;

    [JsonPropertyName("sightWardsBoughtInGame")]
    public int SightWardsBoughtInGame { get; init; }

    [JsonPropertyName("spell1Casts")]
    public int Spell1Casts { get; init; }

    [JsonPropertyName("spell2Casts")]
    public int Spell2Casts { get; init; }

    [JsonPropertyName("spell3Casts")]
    public int Spell3Casts { get; init; }

    [JsonPropertyName("spell4Casts")]
    public int Spell4Casts { get; init; }

    [JsonPropertyName("summoner1Casts")]
    public int Summoner1Casts { get; init; }

    [JsonPropertyName("summoner1Id")]
    public int Summoner1Id { get; init; }

    [JsonPropertyName("summoner2Casts")]
    public int Summoner2Casts { get; init; }

    [JsonPropertyName("summoner2Id")]
    public int Summoner2Id { get; init; }

    [JsonPropertyName("summonerId")]
    public string SummonerId { get; init; } = default!;

    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; init; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; init; } = default!;

    [JsonPropertyName("teamEarlySurrendered")]
    public bool TeamEarlySurrendered { get; init; }

    [JsonPropertyName("teamId")]
    public int TeamId { get; init; }

    /// <summary>
    /// The teamPosition is the best guess for which position the player actually played if we add the constraint that each team must have one top player, one jungle, one middle, etc. 
    /// </summary>
    [JsonPropertyName("teamPosition")]
    public string TeamPosition { get; init; } = default!;

    [JsonPropertyName("timeCCingOthers"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan TimeCCingOthers { get; init; }

    [JsonPropertyName("timePlayed"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan TimePlayed { get; init; }

    [JsonPropertyName("totalDamageDealt")]
    public int TotalDamageDealt { get; init; }

    [JsonPropertyName("totalDamageDealtToChampions")]
    public int TotalDamageDealtToChampions { get; init; }

    [JsonPropertyName("totalDamageShieldedOnTeammates")]
    public int TotalDamageShieldedOnTeammates { get; init; }

    [JsonPropertyName("totalDamageTaken")]
    public int TotalDamageTaken { get; init; }

    [JsonPropertyName("totalHeal")]
    public int TotalHeal { get; init; }

    [JsonPropertyName("totalHealsOnTeammates")]
    public int TotalHealsOnTeammates { get; init; }

    [JsonPropertyName("totalMinionsKilled")]
    public int TotalMinionsKilled { get; init; }

    [JsonPropertyName("totalTimeCCDealt"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan TotalTimeCCDealt { get; init; }

    [JsonPropertyName("totalTimeSpentDead"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan TotalTimeSpentDead { get; init; }

    [JsonPropertyName("totalUnitsHealed")]
    public int TotalUnitsHealed { get; init; }

    [JsonPropertyName("tripleKills")]
    public int TripleKills { get; init; }

    [JsonPropertyName("trueDamageDealt")]
    public int TrueDamageDealt { get; init; }

    [JsonPropertyName("trueDamageDealtToChampions")]
    public int TrueDamageDealtToChampions { get; init; }

    [JsonPropertyName("trueDamageTaken")]
    public int TrueDamageTaken { get; init; }

    [JsonPropertyName("turretKills")]
    public int TurretKills { get; init; }

    [JsonPropertyName("turretTakedowns")]
    public int TurretTakedowns { get; init; }

    [JsonPropertyName("turretsLost")]
    public int TurretsLost { get; init; }

    [JsonPropertyName("unrealKills")]
    public int UnrealKills { get; init; }

    [JsonPropertyName("visionScore")]
    public int VisionScore { get; init; }

    [JsonPropertyName("visionWardsBoughtInGame")]
    public int VisionWardsBoughtInGame { get; init; }

    [JsonPropertyName("wardsKilled")]
    public int WardsKilled { get; init; }

    [JsonPropertyName("wardsPlaced")]
    public int WardsPlaced { get; init; }

    [JsonPropertyName("win")]
    public bool Win { get; init; }
}
