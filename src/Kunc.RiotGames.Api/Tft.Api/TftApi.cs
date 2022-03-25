using Kunc.RiotGames.Tft.Api.League;
using Kunc.RiotGames.Tft.Api.Match;
using Kunc.RiotGames.Tft.Api.Summoner;

namespace Kunc.RiotGames.Tft.Api;

/// <inheritdoc cref="ITftApi"/>
public class TftApi : ITftApi
{
    /// <inheritdoc/>
    public ITftMatchV1 MatchV1 { get; }

    /// <inheritdoc/>
    public ITftSummonerV1 SummonerV1 { get; }

    /// <inheritdoc/>
    public ITftLeagueV1 LeagueV1 { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="TftApi"/>.
    /// </summary>
    public TftApi(string apikey)
    {
        var client = new RiotGamesApiClient(apikey);
        MatchV1 = new TftMatchEndpoint(client);
        LeagueV1 = new TftLeagueEndpoint(client);
        SummonerV1 = new TftSummonerEndpoint(client);
    }
}