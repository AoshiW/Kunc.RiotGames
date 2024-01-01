namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Simple client for game client API.
/// </summary>
/// <remarks>
/// <see href="https://developer.riotgames.com/docs/lor#game-client-api" />
/// </remarks>
public interface ILorGameClient
{
    /// <summary>
    /// Get <see cref="GameResult"/> after last game.
    /// </summary>
    /// <remarks>
    /// A request to the game-result endpoint can be made to determine the result of the player's most recently completed game.
    /// The <see cref="GameResult.GameID"/> resets every time the client restarts and is incremented after a game is completed.
    /// The <see cref="GameResult.GameID"/> isn't associated with any other source of data.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    Task<GameResult> GetGameResultAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint can be used to determine the position of the cards in the collection, deck builder, Expedition drafts, and active games.
    /// </summary>
    /// <remarks>
    /// The response time of this endpoint will vary by computer, however Riot suggest polling this endpoint no more than once per second.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    Task<PositionalRectangles> GetPositionalRectanglesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get player's current deck in an active game.
    /// </summary>
    /// <remarks>
    /// The static-decklist endpoint can be used to describe the player's current deck in an active game.
    /// As the name of the endpoint suggests, this response remains static even after cards in the deck have been played.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns></returns>
    Task<StaticDecklist> GetStaticDecklistAsync(CancellationToken cancellationToken = default);
}
