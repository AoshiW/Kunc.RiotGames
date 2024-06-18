using Kunc.RiotGames.Lol.GameClient.LiveClientData;

namespace Kunc.RiotGames.Lol.GameClient;

public partial class LolGameClient : ILolGameClient
{
    private readonly HttpClient _client = new(new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
    })
    {
        BaseAddress = new("https://127.0.0.1:2999"),
    };
    private bool _disposedValue;

    /// <inheritdoc/>
    public ILiveClientData LiveClientData { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LolGameClient"/> class.
    /// </summary>
    public LolGameClient()
    {
        LiveClientData = new LiveClientDataEndpoint(_client);
    }

    /// <summary>
    /// Releases the unmanaged resources and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _client.Dispose();
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
