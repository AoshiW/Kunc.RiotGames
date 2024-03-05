using Kunc.RiotGames.Api.Http;
using Kunc.RiotGames.Api.LolChallengesV1;
using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Kunc.RiotGames.Api.LolChampionV3;
using Kunc.RiotGames.Api.LolClashV1;
using Kunc.RiotGames.Api.LolLeagueV4;
using Kunc.RiotGames.Api.LolMatchV5;
using Kunc.RiotGames.Api.LolSpectatorV5;
using Kunc.RiotGames.Api.LolSummonerV4;
using Kunc.RiotGames.Api.LorMatchV1;
using Kunc.RiotGames.Api.LorRankedV1;
using Kunc.RiotGames.Api.RiotAccountV1;
using Kunc.RiotGames.Api.TftLeagueV1;
using Kunc.RiotGames.Api.TftMatchV1;
using Kunc.RiotGames.Api.TftSummonerV1;

namespace Kunc.RiotGames.Api;

public class RiotGamesApi : IRiotGamesApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApi"/> class.
    /// </summary>
    public RiotGamesApi(IRiotGamesApiClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        RiotAccountV1 = new RiotAccountV1Endpoint(client);

        LolChallengesV1 = new LolChallengesV1Endpoint(client);
        LolChampionMasteryV4 = new LolChampionMasteryV4Endpoint(client);
        LolChampionV3 = new LolChampionV3Endpoint(client);
        LolClashV1 = new LolClashV1Endpoint(client);
        LolLeagueV4 = new LolLeagueV4Endpoint(client);
        LolMatchV5 = new LolMatchV5Endpoint(client);
        LolSpectatorV5 = new LolSpectatorV5Endpoint(client);
        LolSummonerV4 = new LolSummonerV4Endpoint(client);

        LorMatchV1 = new LorMatchV1Endpoint(client);
        LorRankedV1 = new LorRankedV1Endpoint(client);

        TftLeagueV1 = new TftLeagueV1Endpoint(client);
        TftMatchV1 = new TftMatchV1Endpoint(client);
        TftSummonerV1 = new TftSummonerV1Endpoint(client);
    }

    /// <inheritdoc />
    public IRiotAccountV1 RiotAccountV1 { get; }

    /// <inheritdoc />
    public ILolChallengesV1 LolChallengesV1 { get; }

    /// <inheritdoc />
    public ILolChampionMasteryV4 LolChampionMasteryV4 { get; }

    /// <inheritdoc />
    public ILolChampionV3 LolChampionV3 { get; }

    /// <inheritdoc />
    public ILolClashV1 LolClashV1 { get; }

    /// <inheritdoc />
    public ILolLeagueV4 LolLeagueV4 { get; }

    /// <inheritdoc />
    public ILolMatchV5 LolMatchV5 { get; }

    /// <inheritdoc />
    public ILolSpectatorV5 LolSpectatorV5 { get; }

    ///// <inheritdoc />
    //public int LolStatusV4 { get; }

    /// <inheritdoc />
    public ILolSummonerV4 LolSummonerV4 { get; }

    /// <inheritdoc />
    public ILorMatchV1 LorMatchV1 { get; }

    /// <inheritdoc />
    public ILorRankedV1 LorRankedV1 { get; }

    ///// <inheritdoc />
    //public int LorStatusV1 { get; }

    /// <inheritdoc />
    public ITftLeagueV1 TftLeagueV1 { get; }

    /// <inheritdoc />
    public ITftMatchV1 TftMatchV1 { get; }

    ///// <inheritdoc />
    //public int TftStatusV1 { get; }

    /// <inheritdoc />
    public ITftSummonerV1 TftSummonerV1 { get; }
}
