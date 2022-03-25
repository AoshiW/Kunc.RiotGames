using Kunc.RiotGames.Lor.Api.Match;
using Kunc.RiotGames.Lor.Api.Ranked;
using Kunc.RiotGames.Shared.Api.Account;
using Kunc.RiotGames.Shared.Api.Status;

namespace Kunc.RiotGames.Lor.Api;

public interface ILorApi
{
    IRiotAccountV1 AccountV1 { get; }
    ILorMatchV1 MatchV1 { get; }
    ILorRankedV1 RankedV1 { get; }
    ISharedStatus StatusV1 { get; }
}
