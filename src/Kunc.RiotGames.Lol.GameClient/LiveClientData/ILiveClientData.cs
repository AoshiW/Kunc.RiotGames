namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public interface ILiveClientData
{
    Task<ActivePlayer> GeActivePlayerAsync(CancellationToken cancellationToken = default);
    Task<Runes> GepPayerMainRunesAsync(string summonerName, CancellationToken cancellationToken = default);
    Task<Abilities> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default);
    Task<FullRunes> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default);
    Task<AllGameData> GetAllGameDataAsync(CancellationToken cancellationToken = default);
    Task<Player[]> GetAllPlayersAsync(CancellationToken cancellationToken = default);
    Task<EventData> GetEventDataAsync(CancellationToken cancellationToken = default);
    Task<GameData> GetGameStatsAsync(CancellationToken cancellationToken = default);
    Task<Item[]> GetPlayerItemsAsync(string summonerName, CancellationToken cancellationToken = default);
    Task<Scores> GetPlayerScoreAsync(string summonerName, CancellationToken cancellationToken = default);
    Task<SummonerSpells> GetPlayerSummonerSpellsAsync(string summonerName, CancellationToken cancellationToken = default);
    Task<string> GetSummonerNameAsync(CancellationToken cancellationToken = default);
}
