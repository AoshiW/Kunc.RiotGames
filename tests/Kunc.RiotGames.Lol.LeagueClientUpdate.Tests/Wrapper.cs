namespace Kunc.RiotGames.Lol.LeagueClientUpdate.Tests;

internal sealed class Wrapper<T>
{
    private readonly Action<Wrapper<T>> _onEvent;

    public Wrapper(Action<Wrapper<T>> onEvent)
    {
        _onEvent = onEvent;
    }

    public Wrapper()
    {
        if (typeof(T) == typeof(bool))
        {
            _onEvent = x => x.Value = (T)(object)true;
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    public T Value { get; set; } = default!;

    public void EventHandler(object? sender, EventArgs e)
    {
        _onEvent(this);
    }
}
