namespace Kunc.RiotGames.Lor.GameClient;

/// <summary>
/// Card position information.
/// </summary>
public class Rectangles : BaseDto
{
    /// <summary>
    /// Card ID.
    /// </summary>
    public int CardID { get; set; }

    /// <summary>
    /// CardCode of card.
    /// </summary>
    public string CardCode { get; set; } = default!;

    /// <summary>
    /// The TopLeftX fields indicate the position of the top left corner of the card relative to the bottom left corner of the game client.
    /// </summary>
    public int TopLeftX { get; set; }

    /// <summary>
    /// The TopLeftY fields indicate the position of the top left corner of the card relative to the bottom left corner of the game client.
    /// </summary>
    public int TopLeftY { get; set; }

    /// <summary>
    /// Card's width.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Card's height.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// <see langword="true"/> if the particular card belongs to the local player and <see langword="false"/> if the card belongs to an opponent.
    /// </summary>
    public bool LocalPlayer { get; set; }
}
