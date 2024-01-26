using System.Text.Json.Serialization;
using Kunc.RiotGames.JsonConverters;
using Kunc.RiotGames.Lol;

namespace Kunc.RiotGames.Api.LolMatchV5;

public class ParticipantDto : BaseDto, IKda
{
    /// <inheritdoc/>
    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("baronKills")]
    public int BaronKills { get; set; }

    [JsonPropertyName("bountyLevel")]
    public int BountyLevel { get; set; }

    [JsonPropertyName("challenges")]
    public Dictionary<string, double>? Challenges { get; set; }

    [JsonPropertyName("champExperience")]
    public int ChampExperience { get; set; }

    [JsonPropertyName("champLevel")]
    public int ChampLevel { get; set; }

    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    [JsonPropertyName("championName")]
    public string ChampionName { get; set; }

    /// <remarks>
    /// This field is currently only utilized for Kayn's transformations. (Legal values: 0 - None, 1 - Slayer, 2 - Assassin)
    /// </remarks>
    [JsonPropertyName("championTransform")]
    public int ChampionTransform { get; set; }

    [JsonPropertyName("consumablesPurchased")]
    public int ConsumablesPurchased { get; set; }

    [JsonPropertyName("damageDealtToBuildings")]
    public int DamageDealtToBuildings { get; set; }

    [JsonPropertyName("damageDealtToObjectives")]
    public int DamageDealtToObjectives { get; set; }

    [JsonPropertyName("damageDealtToTurrets")]
    public int DamageDealtToTurrets { get; set; }

    [JsonPropertyName("damageSelfMitigated")]
    public int DamageSelfMitigated { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("detectorWardsPlaced")]
    public int DetectorWardsPlaced { get; set; }

    [JsonPropertyName("doubleKills")]
    public int DoubleKills { get; set; }

    [JsonPropertyName("dragonKills")]
    public int DragonKills { get; set; }

    [JsonPropertyName("firstBloodAssist")]
    public bool HasFirstBloodAssist { get; set; }

    [JsonPropertyName("firstBloodKill")]
    public bool HasFirstBloodKill { get; set; }

    [JsonPropertyName("firstTowerAssist")]
    public bool HasFirstTowerAssist { get; set; }

    [JsonPropertyName("firstTowerKill")]
    public bool HasFirstTowerKill { get; set; }

    [JsonPropertyName("gameEndedInEarlySurrender")]
    public bool GameEndedInEarlySurrender { get; set; }

    [JsonPropertyName("gameEndedInSurrender")]
    public bool GameEndedInSurrender { get; set; }

    [JsonPropertyName("goldEarned")]
    public int GoldEarned { get; set; }

    [JsonPropertyName("goldSpent")]
    public int GoldSpent { get; set; }

    [JsonPropertyName("individualPosition")]
    public string IndividualPosition { get; set; }

    [JsonPropertyName("inhibitorKills")]
    public int InhibitorKills { get; set; }

    [JsonPropertyName("inhibitorTakedowns")]
    public int InhibitorTakedowns { get; set; }

    [JsonPropertyName("inhibitorsLost")]
    public int InhibitorsLost { get; set; }

    [JsonPropertyName("item0")]
    public int Item0 { get; set; }

    [JsonPropertyName("item1")]
    public int Item1 { get; set; }

    [JsonPropertyName("item2")]
    public int Item2 { get; set; }

    [JsonPropertyName("item3")]
    public int Item3 { get; set; }

    [JsonPropertyName("item4")]
    public int Item4 { get; set; }

    [JsonPropertyName("item5")]
    public int Item5 { get; set; }

    [JsonPropertyName("item6")]
    public int Item6 { get; set; }

    [JsonPropertyName("itemsPurchased")]
    public int ItemsPurchased { get; set; }

    [JsonPropertyName("killingSprees")]
    public int KillingSprees { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("lane")]
    public string Lane { get; set; }

    [JsonPropertyName("largestCriticalStrike")]
    public int LargestCriticalStrike { get; set; }

    [JsonPropertyName("largestKillingSpree")]
    public int LargestKillingSpree { get; set; }

    [JsonPropertyName("largestMultiKill")]
    public int LargestMultiKill { get; set; }

    [JsonPropertyName("longestTimeSpentLiving")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan LongestTimeSpentLiving { get; set; }

    [JsonPropertyName("magicDamageDealt")]
    public int MagicDamageDealt { get; set; }

    [JsonPropertyName("magicDamageDealtToChampions")]
    public int MagicDamageDealtToChampions { get; set; }

    [JsonPropertyName("magicDamageTaken")]
    public int MagicDamageTaken { get; set; }

    [JsonPropertyName("neutralMinionsKilled")]
    public int NeutralMinionsKilled { get; set; }

    [JsonPropertyName("nexusKills")]
    public int NexusKills { get; set; }

    [JsonPropertyName("nexusTakedowns")]
    public int NexusTakedowns { get; set; }

    [JsonPropertyName("nexusLost")]
    public int NexusLost { get; set; }

    [JsonPropertyName("objectivesStolen")]
    public int ObjectivesStolen { get; set; }

    [JsonPropertyName("objectivesStolenAssists")]
    public int ObjectivesStolenAssists { get; set; }

    [JsonPropertyName("participantId")]
    public int ParticipantId { get; set; }

    [JsonPropertyName("pentaKills")]
    public int PentaKills { get; set; }

    [JsonPropertyName("perks")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public PerksDto Perks { get; set; } = new();

    [JsonPropertyName("physicalDamageDealt")]
    public int PhysicalDamageDealt { get; set; }

    [JsonPropertyName("physicalDamageDealtToChampions")]
    public int PhysicalDamageDealtToChampions { get; set; }

    [JsonPropertyName("physicalDamageTaken")]
    public int PhysicalDamageTaken { get; set; }

    [JsonPropertyName("profileIcon")]
    public int ProfileIcon { get; set; }

    [JsonPropertyName("puuid")]
    public string Puuid { get; set; } = string.Empty;

    [JsonPropertyName("quadraKills")]
    public int QuadraKills { get; set; }

    [JsonPropertyName("riotIdName")]
    public string RiotIdName { get; set; } = string.Empty;

    [JsonPropertyName("riotIdTagline")]
    public string RiotIdTagline { get; set; } = string.Empty;

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("sightWardsBoughtInGame")]
    public int SightWardsBoughtInGame { get; set; }

    [JsonPropertyName("spell1Casts")]
    public int Spell1Casts { get; set; }

    [JsonPropertyName("spell2Casts")]
    public int Spell2Casts { get; set; }

    [JsonPropertyName("spell3Casts")]
    public int Spell3Casts { get; set; }

    [JsonPropertyName("spell4Casts")]
    public int Spell4Casts { get; set; }

    [JsonPropertyName("summoner1Casts")]
    public int Summoner1Casts { get; set; }

    [JsonPropertyName("summoner1Id")]
    public int Summoner1Id { get; set; }

    [JsonPropertyName("summoner2Casts")]
    public int Summoner2Casts { get; set; }

    [JsonPropertyName("summoner2Id")]
    public int Summoner2Id { get; set; }

    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }

    [JsonPropertyName("summonerName")]
    public string SummonerName { get; set; } = string.Empty;

    [JsonPropertyName("teamEarlySurrendered")]
    public bool TeamEarlySurrendered { get; set; }

    [JsonPropertyName("teamId")]
    public TeamId TeamId { get; set; }

    [JsonPropertyName("teamPosition")]
    public string TeamPosition { get; set; } = string.Empty;

    [JsonPropertyName("timeCCingOthers")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan TimeCCingOthers { get; set; }

    [JsonPropertyName("timePlayed")]
    [JsonConverter(typeof(JsonTimeSpanMillisecondsConverter))]
    public TimeSpan TimePlayed { get; set; }

    [JsonPropertyName("totalAllyJungleMinionsKilled")]
    public int TotalAllyJungleMinionsKilled { get; set; }

    [JsonPropertyName("totalDamageDealt")]
    public int TotalDamageDealt { get; set; }

    [JsonPropertyName("totalDamageDealtToChampions")]
    public int TotalDamageDealtToChampions { get; set; }

    [JsonPropertyName("totalDamageShieldedOnTeammates")]
    public int TotalDamageShieldedOnTeammates { get; set; }

    [JsonPropertyName("totalDamageTaken")]
    public int TotalDamageTaken { get; set; }

    [JsonPropertyName("totalEnemyJungleMinionsKilled")]
    public int TotalEnemyJungleMinionsKilled { get; set; }

    [JsonPropertyName("totalHeal")]
    public int TotalHeal { get; set; }

    [JsonPropertyName("totalHealsOnTeammates")]
    public int TotalHealsOnTeammates { get; set; }

    [JsonPropertyName("totalMinionsKilled")]
    public int TotalMinionsKilled { get; set; }

    [JsonPropertyName("totalTimeCCDealt")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan TotalTimeCCDealt { get; set; }

    [JsonPropertyName("totalTimeSpentDead")]
    [JsonConverter(typeof(JsonTimeSpanSecondsConverter))]
    public TimeSpan TotalTimeSpentDead { get; set; }

    [JsonPropertyName("totalUnitsHealed")]
    public int TotalUnitsHealed { get; set; }

    [JsonPropertyName("tripleKills")]
    public int TripleKills { get; set; }

    [JsonPropertyName("trueDamageDealt")]
    public int TrueDamageDealt { get; set; }

    [JsonPropertyName("trueDamageDealtToChampions")]
    public int TrueDamageDealtToChampions { get; set; }

    [JsonPropertyName("trueDamageTaken")]
    public int TrueDamageTaken { get; set; }

    [JsonPropertyName("turretKills")]
    public int TurretKills { get; set; }

    [JsonPropertyName("turretTakedowns")]
    public int TurretTakedowns { get; set; }

    [JsonPropertyName("turretsLost")]
    public int TurretsLost { get; set; }

    [JsonPropertyName("unrealKills")]
    public int UnrealKills { get; set; }

    [JsonPropertyName("visionScore")]
    public int VisionScore { get; set; }

    [JsonPropertyName("visionWardsBoughtInGame")]
    public int VisionWardsBoughtInGame { get; set; }

    [JsonPropertyName("wardsKilled")]
    public int WardsKilled { get; set; }

    [JsonPropertyName("wardsPlaced")]
    public int WardsPlaced { get; set; }

    [JsonPropertyName("win")]
    public bool IsWinner { get; set; }

    [JsonPropertyName("allInPings")]
    public int AllInPings { get; set; }

    [JsonPropertyName("assistMePings")]
    public int AssistMePings { get; set; }
    
    [JsonPropertyName("baitPings")]
    public int BaitPings { get; set; }
    
    [JsonPropertyName("basicPings")]
    public int BasicPings { get; set; }
    
    [JsonPropertyName("commandPings")]
    public int CommandPings { get; set; }
    
    [JsonPropertyName("dangerPings")]
    public int DangerPings { get; set; }
    
    [JsonPropertyName("enemyMissingPings")]
    public int EnemyMissingPings { get; set; }
    
    [JsonPropertyName("getBackPings")]
    public int GetBackPings { get; set; }
    
    [JsonPropertyName("holdPings")]
    public int HoldPings { get; set; }
    
    [JsonPropertyName("onMyWayPings")]
    public int OnMyWayPings { get; set; }
    
    [JsonPropertyName("pPushPings")]
    public int PushPings { get; set; }

    [JsonPropertyName("needVisionPings")]
    public int NeedVisionPings { get; set; }

    [JsonPropertyName("enemyVisionPings")]
    public int EnemyVisionPings { get; set; }

    [JsonPropertyName("visionClearedPings")]
    public int VisionClearedPings { get; set; }

    [JsonIgnore]
    public int CreepScore => TotalMinionsKilled + NeutralMinionsKilled;
}

//teamPosition/individualposotopn came as LolClashV1.Position without Fill, Unselected
