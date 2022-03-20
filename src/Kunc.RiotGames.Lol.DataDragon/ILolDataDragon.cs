namespace Kunc.RiotGames.Lol.DataDragon;

public interface ILolDataDragon
{
    Task<Champion[]> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<ChampionBase[]> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Champion> GetChampionsAsync(string version, string language, string championId, CancellationToken cancellationToken = default);
    Task<Item[]> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default);
    Task<Map[]> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<ProfileIcon[]> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<RunesReforged[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<SummonerSpell[]> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default);
}
