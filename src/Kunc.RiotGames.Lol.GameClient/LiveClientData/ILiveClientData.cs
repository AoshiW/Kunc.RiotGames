namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public interface ILiveClientData
{

    /// <summary>
    /// Get Abilities for the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AbilitiesDto> GetActivePlayerAbilitiesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all data about the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ActivePlayerDto> GetActivePlayerAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the player RiotId.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<RiotId> GetActivePlayerNameAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the full list of runes for the active player.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<FullRunesDto> GetActivePlayerRunesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all available data.
    /// </summary>
    /// <param name="eventId">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AllGameDataDto> GetAllGameDataAsync(int? eventId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of events that have occurred in the game.
    /// </summary>
    /// <param name="eventId">ID of the next event you expect to see.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<EventDataDto> GetEventDataAsync(int? eventId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get basic data about the game.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GameStatsDto> GetGameStatsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of items for the player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PlayerItemDto[]> GetPlayerItemsAsync(RiotId riotId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of heroes in the game and their stats.
    /// </summary>
    /// <param name="teamId">Heroes team ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PlayerDto[]> GetPlayerListAsync(TeamId? teamId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the basic runes of any player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MainRunesDto> GetPlayerMainRunesAsync(RiotId riotId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of the current scores for the player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PlayerScoresDto> GetPlayerScoresAsync(RiotId riotId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve the list of the summoner spells for the player.
    /// </summary>
    /// <param name="riotId">RiotID GameName (with tag) of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SummonerSpellsDto> GetPlayerSummonerSpellsAsync(RiotId riotId, CancellationToken cancellationToken = default);
}
