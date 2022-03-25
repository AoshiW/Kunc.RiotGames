using Kunc.RiotGames.Shared.Api.Account;

namespace Kunc.RiotGames.Extensions;

public static class SharedEndpointsExtensions
{
    public static async Task<Account> GetAccountAsync(this IRiotAccountV1 riotAccountV1, Region routing, IRiotID riotID, CancellationToken cancellationToken = default)
    {
        if (!riotID.HasRiotID)
        {
            throw new ArgumentException(null, nameof(riotID));
        }
        var account = await riotAccountV1.GetAccountAsync(routing, riotID.GameName, riotID.GameName, cancellationToken).ConfigureAwait(false);
        return account!;
    }

    public static async Task<ActiveShardDto<Region>> GetLorActiveShardAsync(this IRiotAccountV1 riotAccountV1, Region routing, string puuid, CancellationToken cancellationToken = default)
    {
        return await riotAccountV1.GetActiveShardAsync<Region>(routing, Game.Lor, puuid, cancellationToken).ConfigureAwait(false);
    }
}
