using System.Text.Json.Serialization;

namespace Kunc.RiotGames;

[JsonConverter(typeof(JsonStringEnumConverter<Game>))]
public enum Game
{
    /// <summary>
    /// League of Legends
    /// </summary>
    Lol,

    /// <summary>
    /// Legends of Runeterra
    /// </summary>
    Lor,

    /// <summary>
    /// Teamfight Tactics
    /// </summary>
    Tft,

    /// <summary>
    /// Valorant
    /// </summary>
    Val,
}

internal static class GameExtensions
{
    public static string ToLowerString(this Game game)
    {
        return game switch
        {
            Game.Lol => "lol",
            Game.Lor => "lor",
            Game.Val => "val",
            Game.Tft => "tft",
            _ => game.ToString().ToLowerInvariant()
        };
    }
}
