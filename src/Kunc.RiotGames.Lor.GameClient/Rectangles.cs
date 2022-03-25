namespace Kunc.RiotGames.Lor.GameClient;

public record Rectangles : BaseDto
{
    public int CardID { get; init; }

    /// <summary>
    /// CardCode of card.
    /// </summary>
    public string CardCode { get; init; } = default!;

    /// <summary>
    /// The TopLeftX fields indicate the position of the top left corner of the card relative to the bottom left corner of the game client.
    /// </summary>
    public int TopLeftX { get; init; }

    /// <summary>
    /// The TopLeftY fields indicate the position of the top left corner of the card relative to the bottom left corner of the game client.
    /// </summary>
    public int TopLeftY { get; init; }

    /// <summary>
    /// Card's width.
    /// </summary>
    public int Width { get; init; }

    /// <summary>
    /// Card's height.
    /// </summary>
    public int Height { get; init; }

    /// <summary>
    /// <see langword="true"/> if the particular card belongs to the local player and <see langword="false"/> if the card belongs to an opponent.
    /// </summary>
    public bool LocalPlayer { get; init; }
}
