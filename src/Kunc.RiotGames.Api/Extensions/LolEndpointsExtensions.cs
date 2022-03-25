using Kunc.RiotGames.Lol.Api.ChampionMastery;
using Kunc.RiotGames.Lol.Api.Clash;
using Kunc.RiotGames.Lol.Api.League;
using Kunc.RiotGames.Lol.Api.Match;
using Kunc.RiotGames.Lol.Api.Spectator;
using Kunc.RiotGames.Lol.Api.Summoner;

namespace Kunc.RiotGames.Extensions;

public static class LolEndpointsExtensions
{
    public static async Task<Player[]> GetPlayerAsync(this ILolClashV1 lolClashV1, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await lolClashV1.GetPlayerAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<ChampionMastery[]> GetAllChampionMasteriesAsync(this ILolChampionMasteryV4 lolChampionMasteryV4, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await lolChampionMasteryV4.GetAllChampionMasteriesAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<ChampionMastery?> GetChampionMasteriesAsync(this ILolChampionMasteryV4 lolChampionMasteryV4, SummonerDto summoner, long championId, CancellationToken cancellationToken = default)
    {
        return await lolChampionMasteryV4.GetChampionMasteriesAsync(summoner.Platform, summoner.Id, championId, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<int> GetTotalMasteryPointAsync(this ILolChampionMasteryV4 lolChampionMasteryV4, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await lolChampionMasteryV4.GetTotalMasteryPointAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(this ILolLeagueV4 lolLeagueV4, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await lolLeagueV4.GetSummonerLeagueEntriesAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MatchId<Region>[]> GetListMatchIdsAsync(this ILolMatchV5 lolMatchV5, SummonerDto summoner, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, int? queue = null, string? type = null, int? start = null, int? count = null, CancellationToken cancellationToken = default)
    {
        var region = summoner.Platform.ToRegion();
        var ids = await lolMatchV5.GetListMatchIdsAsync(region, summoner.Puuid, startTime?.ToUnixTimeSeconds(), endTime?.ToUnixTimeSeconds(), queue, type, start, count, cancellationToken).ConfigureAwait(false);
        return MatchId<Region>.Create(region, ids);
    }
    public static async Task<MatchId<Region>[]> GetListMatchIdsAsync(this ILolMatchV5 lolMatchV5, SummonerDto summoner, LolMatchListOptions options, CancellationToken cancellationToken = default)
    {
        var region = summoner.Platform.ToRegion();
        var ids = await lolMatchV5.GetListMatchIdsAsync(region, summoner.Puuid, options.StartTime?.ToUnixTimeSeconds(), options.EndTime?.ToUnixTimeSeconds(), options.Queue, options.Type, options.Start, options.Count, cancellationToken).ConfigureAwait(false);
        return MatchId<Region>.Create(region, ids);
    }

    public static async Task<Match?> GetMatchAsync(this ILolMatchV5 lolMatchV5, MatchId<Region> matchId, CancellationToken cancellationToken = default)
    {
        return await lolMatchV5.GetMatchAsync(matchId.Routing, matchId.Code, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<MatchTimeline?> GetMatchTimelineAsync(this ILolMatchV5 lolMatchV5, MatchId<Region> matchId, CancellationToken cancellationToken = default)
    {
        return await lolMatchV5.GetMatchTimelineAsync(matchId.Routing, matchId.Code, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CurrentGameInfo?> GetCurrentGameInformationForSummonerAsync(this ILolSpectatorV4 lolSpectatorV4, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await lolSpectatorV4.GetCurrentGameInformationForSummonerAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }
}
