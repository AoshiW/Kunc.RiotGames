using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Lol.DataDragon;

public partial class LolDataDragon
{
    /// <summary>
    /// Creates new instance of <see cref="ILolDataDragon"/> configured using provided <paramref name="configure"/> delegate.
    /// </summary>
    /// <param name="configure">A delegate to configure the <see cref="LolDataDragonOptions"/>.</param>
    /// <returns>The <see cref="ILolDataDragon"/> that was created.</returns>
    public static ILolDataDragon Create(Action<LolDataDragonOptions>? configure = null)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLolDataDragon(configure);
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var lolDataDragon = serviceProvider.GetRequiredService<ILolDataDragon>();
        return new DisposingLolDataDragon(lolDataDragon, serviceProvider);
    }

    private sealed class DisposingLolDataDragon : ILolDataDragon
    {
        private readonly ILolDataDragon _lolDataDragon;
        private readonly ServiceProvider _serviceProvider;

        public DisposingLolDataDragon(ILolDataDragon lolDataDragon, ServiceProvider serviceProvider)
        {
            _lolDataDragon = lolDataDragon;
            _serviceProvider = serviceProvider;
        }

        public Task<Dictionary<string, ChampionDto>> GetChampionsAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetChampionsAsync(version, language, cancellationToken);
        }

        public Task<Dictionary<string, ChampionBaseDto>> GetChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetChampionsBaseAsync(version, language, cancellationToken);
        }

        public Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetChallengesAsync(version, language, cancellationToken);
        }

        public Task<ChampionDto> GetChampionAsync(string version, string language, string id, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetChampionAsync(version, language, id, cancellationToken);
        }

        public Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetItemsAsync(version, language, cancellationToken);
        }

        public Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetLanguagesAsync(cancellationToken);
        }

        public Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetMapsAsync(version, language, cancellationToken);
        }

        public Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetProfileIconsAsync(version, language, cancellationToken);
        }

        public Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetRunesReforgedAsync(version, language, cancellationToken);
        }

        public Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetSummonerSpellsAsync(version, language, cancellationToken);
        }

        public Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default)
        {
            return _lolDataDragon.GetVersionsAsync(cancellationToken);
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
