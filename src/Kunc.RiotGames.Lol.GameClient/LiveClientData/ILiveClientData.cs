namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public interface ILiveClientData
{
    /// <summary>
    /// Get all data about the active player.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<ActivePlayer> GeActivePlayerAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the basic runes of any player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="summonerName"/> is null.</exception>
    Task<Runes> GetPayerMainRunesAsync(string summonerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Abilities for the active player.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<Abilities> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the full list of runes for the active player.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<FullRunes> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all available data.
    /// </summary>
    /// <param name="eventID">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<AllGameData> GetAllGameDataAsync(int? eventID = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of heroes in the game and their stats.
    /// </summary>
    /// <param name="teamID">Heroes team ID. Optional, returns all players on all teams if null.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<Player[]> GetAllPlayersAsync(string? teamID = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of events that have occurred in the game.
    /// </summary>
    /// <param name="eventID">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<EventData> GetEventDataAsync(int? eventID = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Basic data about the game.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<GameData> GetGameStatsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of items for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="summonerName"/> is null.</exception>
    Task<Item[]> GetPlayerItemsAsync(string summonerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of the current scores for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="summonerName"/> is null.</exception>
    Task<Scores> GetPlayerScoreAsync(string summonerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of the summoner spells for the player.
    /// </summary>
    /// <param name="summonerName">Summoner name of player.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentNullException">The <paramref name="summonerName"/> is null.</exception>
    Task<SummonerSpells> GetPlayerSummonerSpellsAsync(string summonerName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the player name.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="HttpRequestException"></exception>
    Task<string> GetSummonerNameAsync(CancellationToken cancellationToken = default);
}
