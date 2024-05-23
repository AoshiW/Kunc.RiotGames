using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

public interface ILolGameClient
{
    ILiveClientData LiveClientData { get; }
}
