using Kunc.RiotGames.Lor.Api.Match;
using Kunc.RiotGames.Shared.Api.Account;

namespace Kunc.RiotGames.Extensions;

public static class LorEndpointsExtensions
{
    public static async Task<MatchId<Region>[]> GetListOfMatcIdsAsync(this ILorMatchV1 lorMatchV1, ActiveShardDto<Region> activeShard, CancellationToken cancellationToken = default)
    {
        var ids = await lorMatchV1.GetListOfMatchIdsAsync(activeShard.ActiveShard, activeShard.Puuid, cancellationToken).ConfigureAwait(false);
        return MatchId<Region>.Create(activeShard.ActiveShard, ids);
    }

    public static async Task<Match?> GetMatchAsync(this ILorMatchV1 lorMatchV1, MatchId<Region> matchId, CancellationToken cancellationToken = default)
    {
        return await lorMatchV1.GetMatchAsync(matchId.Routing, matchId.Code, cancellationToken).ConfigureAwait(false);
    }
}
