using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

public class LolGameClient
{
    public LiveClientDataEndpoint LiveClientData { get; } = new();
}
