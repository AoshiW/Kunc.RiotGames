using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.GameClient;

[JsonSerializable(typeof(GameResult))]
[JsonSerializable(typeof(PositionalRectangles))]
[JsonSerializable(typeof(StaticDecklist))]
internal partial class JsonContext : JsonSerializerContext
{
}
