using Kunc.RiotGames.Api.LolChallengesV1;
using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Kunc.RiotGames.Api.LolChampionV3;
using Kunc.RiotGames.Api.LolClashV1;
using Kunc.RiotGames.Api.LolLeagueV4;
using Kunc.RiotGames.Api.LolMatchV5;
using Kunc.RiotGames.Api.LolSpectatorTftV5;
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
    public RiotGamesApi(
        IRiotAccountV1 riotAccountV1,
        ILolClashV1 lolClashV1, ILolChallengesV1 lolChallengesV1, ILolChampionMasteryV4 lolChampionMasteryV4, ILolChampionV3 lolChampionV3, ILolLeagueV4 lolLeagueV4, ILolMatchV5 lolMatchV5, ILolSpectatorV5 lolSpectatorV5, ILolSummonerV4 lolSummonerV4,
        ILorMatchV1 lorMatchV1, ILorRankedV1 lorRankedV1,
        ITftLeagueV1 tftLeagueV1, ITftMatchV1 tftMatchV1, ILolSpectatorTftV5 lolSpectatorTftV5, ITftSummonerV1 tftSummonerV1
    )
    {
        RiotAccountV1 = riotAccountV1;

        LolClashV1 = lolClashV1;
        LolChallengesV1 = lolChallengesV1;
        LolChampionMasteryV4 = lolChampionMasteryV4;
        LolChampionV3 = lolChampionV3;
        LolLeagueV4 = lolLeagueV4;
        LolMatchV5 = lolMatchV5;
        LolSpectatorV5 = lolSpectatorV5;
        LolSummonerV4 = lolSummonerV4;

        LorMatchV1 = lorMatchV1;
        LorRankedV1 = lorRankedV1;

        TftLeagueV1 = tftLeagueV1;
        TftMatchV1 = tftMatchV1;
        LolSpectatorTftV5 = lolSpectatorTftV5;
        TftSummonerV1 = tftSummonerV1;
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

    ///// <inheritdoc />
    public ILolSpectatorTftV5 LolSpectatorTftV5 { get; }

    /// <inheritdoc />
    public ITftSummonerV1 TftSummonerV1 { get; }
}
