namespace Kunc.RiotGames.Lor.GameClient;

public partial class LorGameClient
{
    /// <summary>
    /// Creates new instance of <see cref="ILorGameClient"/> configured using provided <paramref name="configure"/> delegate.
    /// </summary>
    /// <param name="configure">A delegate to configure the <see cref="LorGameClientOptions"/>.</param>
    /// <returns>The <see cref="ILorGameClient"/> that was created.</returns>
    public static ILorGameClient Create(Action<LorGameClientOptions>? configure = null)
    {
        var options = new LorGameClientOptions();
        configure?.Invoke(options);
        return new LorGameClient(options);
    }
}
