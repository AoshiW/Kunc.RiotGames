using Kunc.RiotGames.Lol.DataDragon.Challenge;
using Kunc.RiotGames.Lol.DataDragon.Champion;
using Kunc.RiotGames.Lol.DataDragon.Item;
using Kunc.RiotGames.Lol.DataDragon.Map;
using Kunc.RiotGames.Lol.DataDragon.ProfileIcon;
using Kunc.RiotGames.Lol.DataDragon.RuneReforged;
using Kunc.RiotGames.Lol.DataDragon.SummonerSpell;

namespace Kunc.RiotGames.Lol.DataDragon;
public interface ILolDataDragon
{
    Task<Dictionary<string, ChampionDto>> GetAllChampionsAsync(string version, string language, CancellationToken cancellationToken);
    Task<Dictionary<string, ChampionBaseDto>> GetAllChampionsBaseAsync(string version, string language, CancellationToken cancellationToken);
    Task<ChallengeDto[]> GetChallengesAsync(string version, string language, CancellationToken cancellationToken);
    Task<Dictionary<string, ItemDto>> GetItemsAsync(string version, string language, CancellationToken cancellationToken);
    Task<Dictionary<string, MapDto>> GetMapsAsync(string version, string language, CancellationToken cancellationToken);
    Task<Dictionary<string, ProfileIconDto>> GetProfileIconsAsync(string version, string language, CancellationToken cancellationToken);
    Task<RuneReforgedDto[]> GetRunesReforgedAsync(string version, string language, CancellationToken cancellationToken);
    Task<Dictionary<string, SummonerSpellDto>> GetSummonerSpellsAsync(string version, string language, CancellationToken cancellationToken);
    Task<string[]> GetVersionsAsync(CancellationToken cancellationToken);
}