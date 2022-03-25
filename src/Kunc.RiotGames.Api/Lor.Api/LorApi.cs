using Kunc.RiotGames.Extensions;
using Kunc.RiotGames.Lor.Api.Match;
using Kunc.RiotGames.Lor.Api.Ranked;
using Kunc.RiotGames.Shared.Api.Account;
using Kunc.RiotGames.Shared.Api.Status;

namespace Kunc.RiotGames.Lor.Api;

/// <inheritdoc cref="ILorApi"/>
public class LorApi : ILorApi
{
    /// <inheritdoc/>
    public IRiotAccountV1 AccountV1 { get; }

    /// <inheritdoc/>
    public ILorRankedV1 RankedV1 { get; }

    /// <inheritdoc/>
    public ILorMatchV1 MatchV1 { get; }

    /// <inheritdoc/>
    public ISharedStatus StatusV1 { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LorApi"/>.
    /// </summary>
    public LorApi(string apikey)
    {
        var client = new RiotGamesApiClient(apikey);
        AccountV1 = new RiotAccountEndpoint(client);
        RankedV1 = new LorRankedEndpoint(client);
        MatchV1 = new LorMatchEndpoint(client);
        StatusV1 = new SharedStatusEndpoint(client, Game.Lor.ToLowerString());
    }
}
