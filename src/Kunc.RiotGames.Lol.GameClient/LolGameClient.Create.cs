namespace Kunc.RiotGames.Lol.GameClient;

public partial class LolGameClient
{
    /// <summary>
    /// Creates new instance of <see cref="ILolGameClient"/>.
    /// </summary>
    /// <returns>The <see cref="ILolGameClient"/> that was created.</returns>
    public static ILolGameClient Create()
    {
        return new LolGameClient();
    }
}
