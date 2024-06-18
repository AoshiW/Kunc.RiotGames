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

public partial class RiotGamesApi : IRiotGamesApi
{
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="RiotGamesApi"/> class.
    /// </summary>
    public RiotGamesApi(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        RiotAccountV1 = services.GetRequiredService<IRiotAccountV1>();

        LolClashV1 = services.GetRequiredService<ILolClashV1>();
        LolChallengesV1 = services.GetRequiredService<ILolChallengesV1>();
        LolChampionMasteryV4 = services.GetRequiredService<ILolChampionMasteryV4>();
        LolChampionV3 = services.GetRequiredService<ILolChampionV3>();
        LolLeagueV4 = services.GetRequiredService<ILolLeagueV4>();
        LolMatchV5 = services.GetRequiredService<ILolMatchV5>();
        LolSpectatorV5 = services.GetRequiredService<ILolSpectatorV5>();
        LolStatusV4 = services.GetRequiredService<ILolStatusV4>();
        LolSummonerV4 = services.GetRequiredService<ILolSummonerV4>();

        LorMatchV1 = services.GetRequiredService<ILorMatchV1>();
        LorRankedV1 = services.GetRequiredService<ILorRankedV1>();
        LorStatusV1 = services.GetRequiredService<ILorStatusV1>();

        TftLeagueV1 = services.GetRequiredService<ITftLeagueV1>();
        TftMatchV1 = services.GetRequiredService<ITftMatchV1>();
        LolSpectatorTftV5 = services.GetRequiredService<ILolSpectatorTftV5>();
        TftStatusV1 = services.GetRequiredService<ITftStatusV1>();
        TftSummonerV1 = services.GetRequiredService<ITftSummonerV1>();
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
    /// Releases the unmanaged resources and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {

            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
