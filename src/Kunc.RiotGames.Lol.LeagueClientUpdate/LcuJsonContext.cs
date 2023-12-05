using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lol.LeagueClientUpdate;

[JsonSerializable(typeof(LcuEventArgs<JsonElement>))]
[JsonSerializable(typeof(JsonElement[]))]
internal partial class LcuJsonContext : JsonSerializerContext
{
}
