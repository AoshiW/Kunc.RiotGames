using System.Diagnostics.CodeAnalysis;

namespace Kunc.RiotGames.Api;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

[Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
public static class MethodId
{
    public const string Riot_AccountV1_ByPuuid = "/riot/account/v1/accounts/by-puuid/{puuid}";
    public const string Riot_AccountV1_ByRiotId = "/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}";
    public const string Riot_AccountV1_ActiveShard = "/riot/account/v1/active-shards/by-game/{game}/by-puuid/{puuid}";
    public const string Riot_AccountV1_Region = "/riot/account/v1/region/by-game/{game}/by-puuid/{puuid}";

    public const string Lol_ChampionV3_FreeRotations = "/lol/platform/v3/champion-rotations";
    public const string Lol_ChampionMasteryV4_ByPuuid = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}";
    public const string Lol_ChampionMasteryV4_ByPuuid_ByChampion = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/by-champion/{championId}";
    public const string Lol_ChampionMasteryV4_ByPuuid_Top = "/lol/champion-mastery/v4/champion-masteries/by-puuid/{puuid}/top";
    public const string Lol_ChampionMasteryV4_Score_ByPuuid = "/lol/champion-mastery/v4/scores/by-puuid/{puuid}";
    public const string Lol_ChallengesV1_Config = "/lol/challenges/v1/challenges/config";
    public const string Lol_ChallengesV1_Percentiles = "/lol/challenges/v1/challenges/percentiles";
    public const string Lol_ChallengesV1_Config_ById = "/lol/challenges/v1/challenges/{challengeId}/config";
    public const string Lol_ChallengesV1_Leaderboards = "/lol/challenges/v1/challenges/{challengeId}/leaderboards/by-level/{level}";
    public const string Lol_ChallengesV1_Percentiles_ById = "/lol/challenges/v1/challenges/{challengeId}/percentiles";
    public const string Lol_ChallengesV1_PlayerData = "/lol/challenges/v1/player-data/{puuid}";
    public const string Lol_ClashV1_Player = "/lol/clash/v1/players/by-puuid/{puuid}";
    public const string Lol_ClashV1_Team = "/lol/clash/v1/teams/{teamId}";
    public const string Lol_ClashV1_Tournaments = "/lol/clash/v1/tournaments";
    public const string Lol_ClashV1_Tournaments_ByTeam = "/lol/clash/v1/tournaments/by-team/{teamId}";
    public const string Lol_ClashV1_Tournaments_ById = "/lol/clash/v1/tournaments/{tournamentId}";
    public const string Lol_LeagueV4_Challenger = "/lol/league/v4/challengerleagues/by-queue/{queue}";
    public const string Lol_LeagueV4_Entries_ByPuuid = "/lol/league/v4/entries/by-puuid/{encryptedPUUID}";
    public const string Lol_LeagueV4_Entries = "/lol/league/v4/entries/{queue}/{tier}/{division}";
    public const string Lol_LeagueV4_Grandmaster = "/lol/league/v4/grandmasterleagues/by-queue/{queue}";
    public const string Lol_LeagueV4_League = "/lol/league/v4/leagues/{leagueId}";
    public const string Lol_LeagueV4_Master = "/lol/league/v4/masterleagues/by-queue/{queue}";
    public const string Lol_MatchV5_MatchIds = "/lol/match/v5/matches/by-puuid/{puuid}/ids";
    public const string Lol_MatchV5_Match = "/lol/match/v5/matches/{matchId}";
    public const string Lol_MatchV5_Timeline = "/lol/match/v5/matches/{matchId}/timeline";
    public const string Lol_SpectatorV5_ActiveGame = "/lol/spectator/v5/active-games/by-summoner/{encryptedPUUID}";
    public const string Lol_SpectatorV5_FeaturedGames = "/lol/spectator/v5/featured-games";
    public const string Lol_StatusV4_PlatformData = "/lol/status/v4/platform-data";
    public const string Lol_SummonerV4_ByPuuid = "/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";

    public const string Lor_MatchV1_MatchIds = "/lor/match/v1/matches/by-puuid/{puuid}/ids";
    public const string Lor_MatchV1_Match = "/lor/match/v1/matches/{matchId}";
    public const string Lor_RankedV1_Leaderboard = "/lor/ranked/v1/leaderboards";
    public const string Lor_StatusV1_PlatformData = "/lor/status/v1/platform-data";

    public const string Lol_SpectatorTftV5_ActiveGame = "/lol/spectator/tft/v5/active-games/by-puuid/{encryptedPUUID}";
    public const string Lol_SpectatorTftV5_FeaturedGames = "/lol/spectator/tft/v5/featured-games";
    public const string Tft_LeagueV1_Challenger = "/tft/league/v1/challenger";
    public const string Tft_LeagueV1_Entries_BySummonerId = "/tft/league/v1/entries/by-summoner/{summonerId}";
    public const string Tft_LeagueV1_Entries = "/tft/league/v1/entries/{tier}/{division}";
    public const string Tft_LeagueV1_Grandmaster = "/tft/league/v1/grandmaster";
    public const string Tft_LeagueV1_League = "/tft/league/v1/leagues/{leagueId}";
    public const string Tft_LeagueV1_Master = "/tft/league/v1/master";
    public const string Tft_LeagueV1_RatedLadders = "/tft/league/v1/rated-ladders/{queue}/top";
    public const string Tft_MatchV1_MatchIds = "/tft/match/v1/matches/by-puuid/{puuid}/ids";
    public const string Tft_MatchV1_Match = "/tft/match/v1/matches/{matchId}";
    public const string Tft_StatusV1_PlatformData = "/tft/status/v1/platform-data";
    public const string Tft_SummonerV1_ByPuuid = "/tft/summoner/v1/summoners/by-puuid/{encryptedPUUID}";
    public const string Tft_SummonerV1_BySummonerId = "/tft/summoner/v1/summoners/{encryptedSummonerId}";
}
