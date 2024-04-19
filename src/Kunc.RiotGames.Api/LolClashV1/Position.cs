using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Api.LolClashV1;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter<Position>))]
public enum Position
{
    Unselected,
    Top = 1,
    Jungle = 2,
    Middle = 4,
    Bottom = 8,
    Utility = 16,
    Fill = Top | Jungle | Middle | Bottom | Utility,
}
