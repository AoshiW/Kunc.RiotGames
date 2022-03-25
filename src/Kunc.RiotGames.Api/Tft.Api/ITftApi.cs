using Kunc.RiotGames.Tft.Api.League;
using Kunc.RiotGames.Tft.Api.Match;
using Kunc.RiotGames.Tft.Api.Summoner;

namespace Kunc.RiotGames.Tft.Api;

public interface ITftApi
{
    ITftLeagueV1 LeagueV1 { get; }
    ITftMatchV1 MatchV1 { get; }
    ITftSummonerV1 SummonerV1 { get; }
}
