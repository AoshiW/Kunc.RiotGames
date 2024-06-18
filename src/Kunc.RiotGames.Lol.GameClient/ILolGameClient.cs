using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

public interface ILolGameClient : IDisposable
{
    ILiveClientData LiveClientData { get; }
}
