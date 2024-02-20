using Kunc.RiotGames.Api.LolChallengesV1;
using Kunc.RiotGames.Api.LolChampionMasteryV4;
using Kunc.RiotGames.Api.LolChampionV3;
using Kunc.RiotGames.Api.LolClashV1;
using Kunc.RiotGames.Api.LolLeagueV4;
using Kunc.RiotGames.Api.LolMatchV5;
using Kunc.RiotGames.Api.LolSpectatorV4;
using Kunc.RiotGames.Api.LolSummonerV4;
using Kunc.RiotGames.Api.LorMatchV1;
using Kunc.RiotGames.Api.LorRankedV1;
using Kunc.RiotGames.Api.RiotAccountV1;
using Kunc.RiotGames.Api.TftLeagueV1;
using Kunc.RiotGames.Api.TftMatchV1;
using Kunc.RiotGames.Api.TftSummonerV1;

namespace Kunc.RiotGames.Api;

public class RiotGamesApi
{
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
    public ILolSpectatorV4 LolSpectatorV4 { get; }

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
