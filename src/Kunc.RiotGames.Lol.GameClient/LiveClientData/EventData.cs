namespace Kunc.RiotGames.Lol.GameClient.LiveClientData;

public record EventData : BaseDto
{
    public Event[] Events { get; init; } = default!;
}
