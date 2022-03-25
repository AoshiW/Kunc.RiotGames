using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

///<inheritdoc cref="ILolGameClient"/>
public class LolGameClient : ILolGameClient
{
    /// <inheritdoc/>
    public ILiveClientData LiveClientData { get; } = new LiveClientDataEndpoint();
}
