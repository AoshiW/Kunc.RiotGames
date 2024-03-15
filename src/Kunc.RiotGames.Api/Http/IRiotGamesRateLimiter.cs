namespace Kunc.RiotGames.Api.Http;

public interface IRiotGamesRateLimiter
{
    IRegionRateLimiter GetPartialRateLimiter(RiotRequestMessage riotRequestMessage);
}
