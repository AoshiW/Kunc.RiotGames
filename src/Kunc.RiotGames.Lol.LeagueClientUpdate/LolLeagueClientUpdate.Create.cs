using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

public partial class LolLeagueClientUpdate
{
    /// <summary>
    /// Creates new instance of <see cref="ILolLeagueClientUpdate"/>.
    /// </summary>
    /// <param name="configure">A delegate to configure the <see cref="LolLeagueClientUpdateOptions"/>.</param>
    /// <returns>The <see cref="ILolLeagueClientUpdate"/> that was created.</returns>
    public static ILolLeagueClientUpdate Create(Action<LolLeagueClientUpdateOptions>? configure = null)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLolLeagueClientUpdate(configure);
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var leagueClientUpdate = serviceProvider.GetRequiredService<ILolLeagueClientUpdate>();
        return new DisposingLolLeagueClientUpdate(leagueClientUpdate, serviceProvider);
    }

    sealed class DisposingLolLeagueClientUpdate : ILolLeagueClientUpdate
    {
        private readonly ILolLeagueClientUpdate _leagueClientUpdate;
        private readonly ServiceProvider _serviceProvider;

        public DisposingLolLeagueClientUpdate(ILolLeagueClientUpdate leagueClientUpdate, ServiceProvider serviceProvider)
        {
            _leagueClientUpdate = leagueClientUpdate;
            _serviceProvider = serviceProvider;
        }

        public event EventHandler<LcuEventArgs<JsonElement>>? OnLcuEvent
        {
            add => _leagueClientUpdate.OnLcuEvent += value;
            remove => _leagueClientUpdate.OnLcuEvent -= value;
        }

        public Task<T?> GetFromJsonAsync<T>([StringSyntax("Uri")] string requestUri, CancellationToken cancellationToken = default)
        {
            return _leagueClientUpdate.GetFromJsonAsync<T>(requestUri, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsJsonAsync<T>([StringSyntax("Uri")] string requestUri, T value, CancellationToken cancellationToken = default)
        {
            return _leagueClientUpdate.PostAsJsonAsync<T>(requestUri, value, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsJsonAsync<T>([StringSyntax("Uri")] string requestUri, T value, CancellationToken cancellationToken = default)
        {
            return _leagueClientUpdate.PutAsJsonAsync<T>(requestUri, value, cancellationToken);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
        {
            return _leagueClientUpdate.SendAsync(httpRequestMessage, cancellationToken);
        }

        public Task ConnectWampAsync(CancellationToken token = default)
        {
            return _leagueClientUpdate.ConnectWampAsync(token);
        }

        public Task CloseWampAsync(CancellationToken token = default)
        {
            return _leagueClientUpdate.CloseWampAsync(token);
        }

        public IDisposable Subscribe(LcuEventAttribute attribute, Delegate eventHandler)
        {
            return _leagueClientUpdate.Subscribe(attribute, eventHandler);
        }

        public IDisposable Subscribe(string uri, Delegate eventHandler)
        {
            return _leagueClientUpdate.Subscribe(uri, eventHandler);
        }

        public IDisposable Subscribe(Delegate eventHandler)
        {
            return _leagueClientUpdate.Subscribe(eventHandler);
        }

        public IDisposable[] SubscribeAll<T>(T? target = null, MethodOptions options = MethodOptions.Instance | MethodOptions.Public) where T : class
        {
            return _leagueClientUpdate.SubscribeAll(target, options);
        }

        public int UnsubscribeAll()
        {
            return _leagueClientUpdate.UnsubscribeAll();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
