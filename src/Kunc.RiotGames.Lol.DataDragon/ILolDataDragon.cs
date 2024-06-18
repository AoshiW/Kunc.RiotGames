using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;

namespace Kunc.RiotGames.Lol.DataDragon;

public interface ILolDataDragon : IDisposable
{
    Task<Dictionary<string, ChampionDto>> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Dictionary<string, ChampionBaseDto>> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<ChampionDto> GetChampionsAsync(string version, string language, string id, CancellationToken cancellationToken = default);
    Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken = default);
    Task<string[]> GetLanguagesAsync(CancellationToken cancellationToken = default);
    Task<string[]> GetVersionsAsync(CancellationToken cancellationToken = default);
}
