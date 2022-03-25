using Kunc.RiotGames.Lol.Api.Champion;
using Kunc.RiotGames.Lol.Api.ChampionMastery;
using Kunc.RiotGames.Lol.Api.Clash;
using Kunc.RiotGames.Lol.Api.League;
using Kunc.RiotGames.Lol.Api.Match;
using Kunc.RiotGames.Lol.Api.Spectator;
using Kunc.RiotGames.Lol.Api.Summoner;

namespace Kunc.RiotGames.Lol.Api;

public interface ILolApi
{
    ILolClashV1 ClashV1 { get; }
    ILolChampionMasteryV4 ChampionMasteryV4 { get; }
    ILolChampionV3 ChampionV3 { get; }
    ILolLeagueV4 LeagueV4 { get; }
    ILolMatchV5 MatchV5 { get; }
    ILolSpectatorV4 SpectatorV4 { get; }
    ILolSummonerV4 SummonerV4 { get; }
}
