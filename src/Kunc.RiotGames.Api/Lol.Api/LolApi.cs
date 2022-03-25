using Kunc.RiotGames.Lol.Api.Champion;
using Kunc.RiotGames.Lol.Api.ChampionMastery;
using Kunc.RiotGames.Lol.Api.Clash;
using Kunc.RiotGames.Lol.Api.League;
using Kunc.RiotGames.Lol.Api.Match;
using Kunc.RiotGames.Lol.Api.Spectator;
using Kunc.RiotGames.Lol.Api.Summoner;

namespace Kunc.RiotGames.Lol.Api;

/// <inheritdoc cref="ILolApi"/>
public class LolApi : ILolApi
{
    /// <inheritdoc/>
    public ILolClashV1 ClashV1 { get; }

    /// <inheritdoc/>
    public ILolChampionV3 ChampionV3 { get; }

    /// <inheritdoc/>
    public ILolChampionMasteryV4 ChampionMasteryV4 { get; }

    /// <inheritdoc/>
    public ILolLeagueV4 LeagueV4 { get; }

    /// <inheritdoc/>
    public ILolMatchV5 MatchV5 { get; }

    /// <inheritdoc/>
    public ILolSpectatorV4 SpectatorV4 { get; }

    /// <inheritdoc/>
    public ILolSummonerV4 SummonerV4 { get; }

    public LolApi(string apikey)
    {
        var client = new RiotGamesApiClient(apikey);
        ClashV1 = new LolClashEndpoint(client);
        ChampionV3 = new LolChampionEndpoint(client);
        ChampionMasteryV4 = new LolChampionMasteryEndpoint(client);
        LeagueV4 = new LolLeagueEndpoint(client);
        MatchV5 = new LolMatchEndpoint(client);
        SpectatorV4 = new LolSpectatorEndpoint(client);
        SummonerV4 = new LolSummonerEndpoint(client);
    }
}
