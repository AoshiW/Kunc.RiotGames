using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor.Api.Match;

internal class FactionArrayConverter : JsonConverter<Faction[]>
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(Faction[]);
    private static readonly Dictionary<string, Faction> KeyValuePairs = new()
    {
        ["faction_Demacia_Name"] = Faction.Demacia,
        ["faction_Freljord_Name"] = Faction.Freljord,
        ["faction_Ionia_Name"] = Faction.Ionia,
        ["faction_Noxus_Name"] = Faction.Noxus,
        ["faction_Piltover_Name"] = Faction.PiltoverZaun,
        ["faction_ShadowIsles_Name"] = Faction.ShadowIsles,
        ["faction_Bilgewater_Name"] = Faction.Bilgewater,
        ["faction_Shurima_Name"] = Faction.Shurima,
        ["faction_MtTargon_Name"] = Faction.MountTargon,
        ["faction_BandleCity_Name"] = Faction.BandleCity,
    };

    public override Faction[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        reader.Read();
        var list = new List<Faction>(4);
        while (reader.TokenType != JsonTokenType.EndArray)
        {
            var value = KeyValuePairs.GetValueOrDefault(reader.GetString()!, Faction.UnknownEnumValue);
            list.Add(value);
            reader.Read();
        }
        return list.ToArray();
    }

    public override void Write(Utf8JsonWriter writer, Faction[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var item in value)
        {
            writer.WriteStringValue(KeyValuePairs.First(x => x.Value == item).Key);
        }
        writer.WriteEndArray();
    }
}
