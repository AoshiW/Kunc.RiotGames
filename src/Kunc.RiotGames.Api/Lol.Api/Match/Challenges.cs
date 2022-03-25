using System.Text.Json.Serialization;

using Kunc.RiotGames.JsonConverters;

namespace Kunc.RiotGames.Lol.Api.Match;

public record Challenges : BaseDto
{
    [JsonPropertyName("12AssistStreakCount")]
    public int TwelveAssistStreakCount { get; init; }

    [JsonPropertyName("abilityUses")]
    public int AbilityUses { get; init; }

    [JsonPropertyName("acesBefore15Minutes")]
    public int AcesBefore15Minutes { get; init; }

    [JsonPropertyName("alliedJungleMonsterKills")]
    public double AlliedJungleMonsterKills { get; init; }

    [JsonPropertyName("baronBuffGoldAdvantageOverThreshold")]
    public int? BaronBuffGoldAdvantageOverThreshold { get; init; }

    [JsonPropertyName("baronTakedowns")]
    public int BaronTakedowns { get; init; }

    [JsonPropertyName("blastConeOppositeOpponentCount")]
    public int BlastConeOppositeOpponentCount { get; init; }

    [JsonPropertyName("bountyGold")]
    public int BountyGold { get; init; }

    [JsonPropertyName("buffsStolen")]
    public int BuffsStolen { get; init; }

    [JsonPropertyName("completeSupportQuestInTime")]
    public int CompleteSupportQuestInTime { get; init; }

    [JsonPropertyName("controlWardsPlaced")]
    public int ControlWardsPlaced { get; init; }

    [JsonPropertyName("controlWardTimeCoverageInRiverOrEnemyHalf")]
    public double? ControlWardTimeCoverageInRiverOrEnemyHalf { get; init; }

    [JsonPropertyName("damagePerMinute")]
    public double DamagePerMinute { get; init; }

    [JsonPropertyName("damageTakenOnTeamPercentage")]
    public double DamageTakenOnTeamPercentage { get; init; }

    [JsonPropertyName("dancedWithRiftHerald")]
    public int DancedWithRiftHerald { get; init; }

    [JsonPropertyName("deathsByEnemyChamps")]
    public int DeathsByEnemyChamps { get; init; }

    [JsonPropertyName("dodgeSkillShotsSmallWindow")]
    public int DodgeSkillShotsSmallWindow { get; init; }

    [JsonPropertyName("doubleAces")]
    public int DoubleAces { get; init; }

    [JsonPropertyName("dragonTakedowns")]
    public int DragonTakedowns { get; init; }

    [JsonPropertyName("earliestBaron"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan? EarliestBaron { get; init; }

    [JsonPropertyName("earliestDragonTakedown"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan? EarliestDragonTakedown { get; init; }

    [JsonPropertyName("earliestElderDragon"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan? EarliestElderDragon { get; init; }

    [JsonPropertyName("earlyLaningPhaseGoldExpAdvantage")]
    public double EarlyLaningPhaseGoldExpAdvantage { get; init; }

    [JsonPropertyName("effectiveHealAndShielding")]
    public double EffectiveHealAndShielding { get; init; }

    [JsonPropertyName("elderDragonKillsWithOpposingSoul")]
    public int ElderDragonKillsWithOpposingSoul { get; init; }

    [JsonPropertyName("elderDragonMultikills")]
    public int ElderDragonMultikills { get; init; }

    [JsonPropertyName("enemyChampionImmobilizations")]
    public int EnemyChampionImmobilizations { get; init; }

    [JsonPropertyName("enemyJungleMonsterKills")]
    public double EnemyJungleMonsterKills { get; init; }

    [JsonPropertyName("epicMonsterKillsNearEnemyJungler")]
    public int EpicMonsterKillsNearEnemyJungler { get; init; }

    [JsonPropertyName("epicMonsterKillsWithin30SecondsOfSpawn")]
    public int EpicMonsterKillsWithin30SecondsOfSpawn { get; init; }

    [JsonPropertyName("epicMonsterSteals")]
    public int EpicMonsterSteals { get; init; }

    [JsonPropertyName("epicMonsterStolenWithoutSmite")]
    public int EpicMonsterStolenWithoutSmite { get; init; }

    [JsonPropertyName("fasterSupportQuestCompletion")]
    public double? FasterSupportQuestCompletion { get; init; }

    [JsonPropertyName("fastestLegendary")]
    public double? FastestLegendary { get; init; }

    [JsonPropertyName("firstTurretKilledTime"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan? FirstTurretKilledTime { get; init; }

    [JsonPropertyName("flawlessAces")]
    public int FlawlessAces { get; init; }

    [JsonPropertyName("fullTeamTakedown")]
    public int FullTeamTakedown { get; init; }

    [JsonPropertyName("gameLength"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan GameLength { get; init; }

    [JsonPropertyName("getTakedownsInAllLanesEarlyJungleAsLaner")]
    public int GetTakedownsInAllLanesEarlyJungleAsLaner { get; init; }

    [JsonPropertyName("goldPerMinute")]
    public double GoldPerMinute { get; init; }

    [JsonPropertyName("hadAfkTeammate")]
    public int HadAfkTeammate { get; init; }

    [JsonPropertyName("hadOpenNexus")]
    public int HadOpenNexus { get; init; }

    [JsonPropertyName("highestChampionDamage")]
    public int? HighestChampionDamage { get; init; }

    [JsonPropertyName("highestCrowdControlScore")]
    public int? HighestCrowdControlScore { get; init; }

    [JsonPropertyName("highestWardKills")]
    public int? HighestWardKills { get; init; }

    [JsonPropertyName("initialBuffCount")]
    public int InitialBuffCount { get; init; }

    [JsonPropertyName("initialCrabCount")]
    public int InitialCrabCount { get; init; }

    [JsonPropertyName("jungleCsBefore10Minutes")]
    public double JungleCsBefore10Minutes { get; init; }

    [JsonPropertyName("junglerKillsEarlyJungle")]
    public int JunglerKillsEarlyJungle { get; init; }

    [JsonPropertyName("junglerTakedownsNearDamagedEpicMonster")]
    public int JunglerTakedownsNearDamagedEpicMonster { get; init; }

    [JsonPropertyName("kTurretsDestroyedBeforePlatesFall")]
    public int KTurretsDestroyedBeforePlatesFall { get; init; }

    [JsonPropertyName("kda")]
    public double Kda { get; init; }

    [JsonPropertyName("killParticipation")]
    public double KillParticipation { get; init; }

    [JsonPropertyName("killsNearEnemyTurret")]
    public int KillsNearEnemyTurret { get; init; }

    [JsonPropertyName("killsOnLanersEarlyJungleAsJungler")]
    public int KillsOnLanersEarlyJungleAsJungler { get; init; }

    [JsonPropertyName("killsOnOtherLanesEarlyJungleAsLaner")]
    public int KillsOnOtherLanesEarlyJungleAsLaner { get; init; }

    [JsonPropertyName("killsOnRecentlyHealedByAramPack")]
    public int KillsOnRecentlyHealedByAramPack { get; init; }

    [JsonPropertyName("killsUnderOwnTurret")]
    public int KillsUnderOwnTurret { get; init; }

    [JsonPropertyName("killsWithHelpFromEpicMonster")]
    public int KillsWithHelpFromEpicMonster { get; init; }

    [JsonPropertyName("landSkillShotsEarlyGame")]
    public int LandSkillShotsEarlyGame { get; init; }

    [JsonPropertyName("laneMinionsFirst10Minutes")]
    public int LaneMinionsFirst10Minutes { get; init; }

    [JsonPropertyName("laningPhaseGoldExpAdvantage")]
    public double LaningPhaseGoldExpAdvantage { get; init; }

    [JsonPropertyName("legendaryCount")]
    public int LegendaryCount { get; init; }

    [JsonPropertyName("lostAnInhibitor")]
    public int LostAnInhibitor { get; init; }

    [JsonPropertyName("maxCsAdvantageOnLaneOpponent")]
    public double MaxCsAdvantageOnLaneOpponent { get; init; }

    [JsonPropertyName("maxKillDeficit")]
    public int MaxKillDeficit { get; init; }

    [JsonPropertyName("maxLevelLeadLaneOpponent")]
    public int MaxLevelLeadLaneOpponent { get; init; }

    [JsonPropertyName("mejaisFullStackInTime"), JsonTimeSpanConverter(BaseTimeUnit.Seconds)]
    public TimeSpan? MejaisFullStackInTime { get; init; }

    [JsonPropertyName("moreEnemyJungleThanOpponent")]
    public double MoreEnemyJungleThanOpponent { get; init; }

    [JsonPropertyName("mostWardsDestroyedOneSweeper")]
    public int MostWardsDestroyedOneSweeper { get; init; }

    [JsonPropertyName("multiKillOneSpell")]
    public int MultiKillOneSpell { get; init; }

    [JsonPropertyName("multiTurretRiftHeraldCount")]
    public int MultiTurretRiftHeraldCount { get; init; }

    [JsonPropertyName("multikills")]
    public int Multikills { get; init; }

    [JsonPropertyName("multikillsAfterAggressiveFlash")]
    public int MultikillsAfterAggressiveFlash { get; init; }

    [JsonPropertyName("mythicItemUsed")]
    public int? MythicItemUsed { get; init; }

    [JsonPropertyName("outerTurretExecutesBefore10Minutes")]
    public int OuterTurretExecutesBefore10Minutes { get; init; }

    [JsonPropertyName("outnumberedKills")]
    public int OutnumberedKills { get; init; }

    [JsonPropertyName("outnumberedNexusKill")]
    public int OutnumberedNexusKill { get; init; }

    [JsonPropertyName("perfectDragonSoulsTaken")]
    public int PerfectDragonSoulsTaken { get; init; }

    [JsonPropertyName("perfectGame")]
    public int PerfectGame { get; init; }

    [JsonPropertyName("poroExplosions")]
    public int PoroExplosions { get; init; }

    [JsonPropertyName("quickCleanse")]
    public int QuickCleanse { get; init; }

    [JsonPropertyName("quickFirstTurret")]
    public int QuickFirstTurret { get; init; }

    [JsonPropertyName("quickSoloKills")]
    public int QuickSoloKills { get; init; }

    [JsonPropertyName("riftHeraldTakedowns")]
    public int RiftHeraldTakedowns { get; init; }

    [JsonPropertyName("scuttleCrabKills")]
    public int ScuttleCrabKills { get; init; }

    [JsonPropertyName("shortestTimeToAceFromFirstTakedown")]
    public double? ShortestTimeToAceFromFirstTakedown { get; init; }

    [JsonPropertyName("skillshotsDodged")]
    public int SkillshotsDodged { get; init; }

    [JsonPropertyName("skillshotsHit")]
    public int SkillshotsHit { get; init; }

    [JsonPropertyName("snowballsHit")]
    public int SnowballsHit { get; init; }

    [JsonPropertyName("soloBaronKills")]
    public int SoloBaronKills { get; init; }

    [JsonPropertyName("soloKills")]
    public int SoloKills { get; init; }

    [JsonPropertyName("soloTurretsLategame")]
    public int SoloTurretsLategame { get; init; }

    [JsonPropertyName("stealthWardsPlaced")]
    public int StealthWardsPlaced { get; init; }

    [JsonPropertyName("survivedSingleDigitHpCount")]
    public int SurvivedSingleDigitHpCount { get; init; }

    [JsonPropertyName("takedownOnFirstTurret")]
    public int TakedownOnFirstTurret { get; init; }

    [JsonPropertyName("takedowns")]
    public int Takedowns { get; init; }

    [JsonPropertyName("takedownsAfterGainingLevelAdvantage")]
    public int TakedownsAfterGainingLevelAdvantage { get; init; }

    [JsonPropertyName("takedownsBeforeJungleMinionSpawn")]
    public int TakedownsBeforeJungleMinionSpawn { get; init; }

    [JsonPropertyName("takedownsFirst25Minutes")]
    public int TakedownsFirst25Minutes { get; init; }

    [JsonPropertyName("takedownsInAlcove")]
    public int TakedownsInAlcove { get; init; }

    [JsonPropertyName("takedownsInEnemyFountain")]
    public int TakedownsInEnemyFountain { get; init; }

    [JsonPropertyName("teamBaronKills")]
    public int TeamBaronKills { get; init; }

    [JsonPropertyName("teamDamagePercentage")]
    public double TeamDamagePercentage { get; init; }

    [JsonPropertyName("teamElderDragonKills")]
    public int TeamElderDragonKills { get; init; }

    [JsonPropertyName("teamRiftHeraldKills")]
    public int TeamRiftHeraldKills { get; init; }

    [JsonPropertyName("teleportTakedowns")]
    public int? TeleportTakedowns { get; init; }

    [JsonPropertyName("thirdInhibitorDestroyedTime")]
    public double? ThirdInhibitorDestroyedTime { get; init; }

    [JsonPropertyName("threeWardsOneSweeperCount")]
    public int ThreeWardsOneSweeperCount { get; init; }

    [JsonPropertyName("tookLargeDamageSurvived")]
    public int TookLargeDamageSurvived { get; init; }

    [JsonPropertyName("turretPlatesTaken")]
    public int TurretPlatesTaken { get; init; }

    [JsonPropertyName("turretTakedowns")]
    public int TurretTakedowns { get; init; }

    [JsonPropertyName("turretsTakenWithRiftHerald")]
    public int TurretsTakenWithRiftHerald { get; init; }

    [JsonPropertyName("twentyMinionsIn3SecondsCount")]
    public int TwentyMinionsIn3SecondsCount { get; init; }

    [JsonPropertyName("unseenRecalls")]
    public int UnseenRecalls { get; init; }

    [JsonPropertyName("visionScoreAdvantageLaneOpponent")]
    public double VisionScoreAdvantageLaneOpponent { get; init; }

    [JsonPropertyName("visionScorePerMinute")]
    public double VisionScorePerMinute { get; init; }

    [JsonPropertyName("wardTakedowns")]
    public int WardTakedowns { get; init; }

    [JsonPropertyName("wardTakedownsBefore20M")]
    public int WardTakedownsBefore20M { get; init; }

    [JsonPropertyName("wardsGuarded")]
    public int WardsGuarded { get; init; }

    [JsonPropertyName("immobilizeAndKillWithAlly")]
    public int ImmobilizeAndKillWithAlly { get; init; }

    [JsonPropertyName("killAfterHiddenWithAlly")]
    public int KillAfterHiddenWithAlly { get; init; }

    [JsonPropertyName("killedChampTookFullTeamDamageSurvived")]
    public int KilledChampTookFullTeamDamageSurvived { get; init; }

    [JsonPropertyName("knockEnemyIntoTeamAndKill")]
    public int KnockEnemyIntoTeamAndKill { get; init; }

    [JsonPropertyName("pickKillWithAlly")]
    public int PickKillWithAlly { get; init; }

    [JsonPropertyName("saveAllyFromDeath")]
    public int SaveAllyFromDeath { get; init; }

    [JsonPropertyName("survivedThreeImmobilizesInFight")]
    public int SurvivedThreeImmobilizesInFight { get; init; }
}
