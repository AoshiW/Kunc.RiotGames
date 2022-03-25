using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

/// <summary>
/// Simple client for Game Client API.
/// </summary>
public interface ILolGameClient
{
    /// <inheritdoc/>
    ILiveClientData LiveClientData { get; }
}
