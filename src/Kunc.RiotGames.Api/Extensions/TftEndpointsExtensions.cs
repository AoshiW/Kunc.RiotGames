using Kunc.RiotGames.Lol.Api.Summoner;
using Kunc.RiotGames.Tft.Api.League;
using Kunc.RiotGames.Tft.Api.Match;

namespace Kunc.RiotGames.Extensions;

public static class TftEndpointsExtensions
{
    public static async Task<MatchId<Region>[]> GetListOfMatcIdsAsync(this ITftMatchV1 tftMatchV1, SummonerDto summoner, int? count = 0, CancellationToken cancellationToken = default)
    {
        var region = summoner.Platform.ToRegion();
        var ids = await tftMatchV1.GetListOfMatcIdsAsync(region, summoner.Puuid, count, cancellationToken).ConfigureAwait(false);
        return MatchId<Region>.Create(region, ids);
    }

    public static async Task<Match?> GetMatchAsync(this ITftMatchV1 tftMatchV1, MatchId<Region> matchId, CancellationToken cancellationToken = default)
    {
        return await tftMatchV1.GetMatchAsync(matchId.Routing, matchId.Code, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<LeagueEntry[]> GetSummonerLeagueEntriesAsync(this ITftLeagueV1 tftLeagueV1, SummonerDto summoner, CancellationToken cancellationToken = default)
    {
        return await tftLeagueV1.GetSummonerLeagueEntriesAsync(summoner.Platform, summoner.Id, cancellationToken).ConfigureAwait(false);
    }
}
