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
using Kunc.RiotGames.Api.SharedStatus;
using Kunc.RiotGames.Api.TftLeagueV1;
using Kunc.RiotGames.Api.TftMatchV1;
using Kunc.RiotGames.Api.TftSummonerV1;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Api;

public class RiotGamesApi : IRiotGamesApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApi"/> class.
    /// </summary>
    public RiotGamesApi(
        IRiotAccountV1 riotAccountV1,
        ILolClashV1 lolClashV1, ILolChallengesV1 lolChallengesV1, ILolChampionMasteryV4 lolChampionMasteryV4, ILolChampionV3 lolChampionV3, ILolLeagueV4 lolLeagueV4, ILolMatchV5 lolMatchV5, ILolSpectatorV5 lolSpectatorV5, ILolStatusV4 lolStatusV4, ILolSummonerV4 lolSummonerV4,
        ILorMatchV1 lorMatchV1, ILorRankedV1 lorRankedV1, ILorStatusV1 lorStatusV1,
        ITftLeagueV1 tftLeagueV1, ITftMatchV1 tftMatchV1, ILolSpectatorTftV5 lolSpectatorTftV5, ITftStatusV1 tftStatusV1, ITftSummonerV1 tftSummonerV1
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
        LolStatusV4 = lolStatusV4;
        LolSummonerV4 = lolSummonerV4;

        LorMatchV1 = lorMatchV1;
        LorRankedV1 = lorRankedV1;
        LorStatusV1 = lorStatusV1;

        TftLeagueV1 = tftLeagueV1;
        TftMatchV1 = tftMatchV1;
        LolSpectatorTftV5 = lolSpectatorTftV5;
        TftStatusV1 = tftStatusV1;
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

    /// <inheritdoc />
    public ILolStatusV4 LolStatusV4 { get; }

    /// <inheritdoc />
    public ILolSummonerV4 LolSummonerV4 { get; }

    /// <inheritdoc />
    public ILorMatchV1 LorMatchV1 { get; }

    /// <inheritdoc />
    public ILorRankedV1 LorRankedV1 { get; }

    /// <inheritdoc />
    public ILorStatusV1 LorStatusV1 { get; }

    /// <inheritdoc />
    public ITftLeagueV1 TftLeagueV1 { get; }

    /// <inheritdoc />
    public ITftMatchV1 TftMatchV1 { get; }

    /// <inheritdoc />
    public ITftStatusV1 TftStatusV1 { get; }

    /// <inheritdoc />
    public ILolSpectatorTftV5 LolSpectatorTftV5 { get; }

    /// <inheritdoc />
    public ITftSummonerV1 TftSummonerV1 { get; }

    /// <summary>
    /// Creates new instance of <see cref="IRiotGamesApi"/> configured using provided <paramref name="configure"/> delegate.
    /// </summary>
    /// <param name="configure">A delegate to configure the <see cref="RiotGamesApiOptions"/>.</param>
    /// <returns>The <see cref="IRiotGamesApi"/> that was created.</returns>
    public static IRiotGamesApi Create(Action<RiotGamesApiOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddRiotGamesApi(configure);
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var riotGamesApi = serviceProvider.GetRequiredService<IRiotGamesApi>();
        return new DisposingRiotGamesApi(riotGamesApi, serviceProvider);
    }

    private sealed class DisposingRiotGamesApi : IRiotGamesApi, IDisposable
    {
        private readonly IRiotGamesApi _riotGamesApi;

        private readonly ServiceProvider _serviceProvider;

        public DisposingRiotGamesApi(IRiotGamesApi loggerFactory, ServiceProvider serviceProvider)
        {
            _riotGamesApi = loggerFactory;
            _serviceProvider = serviceProvider;
        }

        public ILolClashV1 LolClashV1 => _riotGamesApi.LolClashV1;

        public ILolChallengesV1 LolChallengesV1 => _riotGamesApi.LolChallengesV1;

        public ILolChampionMasteryV4 LolChampionMasteryV4 => _riotGamesApi.LolChampionMasteryV4;

        public ILolChampionV3 LolChampionV3 => _riotGamesApi.LolChampionV3;

        public ILolLeagueV4 LolLeagueV4 => _riotGamesApi.LolLeagueV4;

        public ILolMatchV5 LolMatchV5 => _riotGamesApi.LolMatchV5;

        public ILolStatusV4 LolStatusV4 => _riotGamesApi.LolStatusV4;

        public ILolSpectatorV5 LolSpectatorV5 => _riotGamesApi.LolSpectatorV5;

        public ILolSummonerV4 LolSummonerV4 => _riotGamesApi.LolSummonerV4;

        public ILorMatchV1 LorMatchV1 => _riotGamesApi.LorMatchV1;

        public ILorRankedV1 LorRankedV1 => _riotGamesApi.LorRankedV1;

        public ILorStatusV1 LorStatusV1 => _riotGamesApi.LorStatusV1;

        public IRiotAccountV1 RiotAccountV1 => _riotGamesApi.RiotAccountV1;

        public ITftLeagueV1 TftLeagueV1 => _riotGamesApi.TftLeagueV1;

        public ITftMatchV1 TftMatchV1 => _riotGamesApi.TftMatchV1;

        public ILolSpectatorTftV5 LolSpectatorTftV5 => _riotGamesApi.LolSpectatorTftV5;

        public ITftStatusV1 TftStatusV1 => _riotGamesApi.TftStatusV1;

        public ITftSummonerV1 TftSummonerV1 => _riotGamesApi.TftSummonerV1;

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
