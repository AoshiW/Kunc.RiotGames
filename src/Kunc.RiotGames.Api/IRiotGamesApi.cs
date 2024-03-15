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
public interface IRiotGamesApi
{
    ILolClashV1 LolClashV1 { get; }
    ILolChallengesV1 LolChallengesV1 { get; }
    ILolChampionMasteryV4 LolChampionMasteryV4 { get; }
    ILolChampionV3 LolChampionV3 { get; }
    ILolLeagueV4 LolLeagueV4 { get; }
    ILolMatchV5 LolMatchV5 { get; }
    ILolSpectatorV5 LolSpectatorV5 { get; }
    ILolSummonerV4 LolSummonerV4 { get; }

    ILorMatchV1 LorMatchV1 { get; }
    ILorRankedV1 LorRankedV1 { get; }

    IRiotAccountV1 RiotAccountV1 { get; }

    ITftLeagueV1 TftLeagueV1 { get; }
    ITftMatchV1 TftMatchV1 { get; }
    ILolSpectatorTftV5 LolSpectatorTftV5 { get; }
    ITftSummonerV1 TftSummonerV1 { get; }
}
