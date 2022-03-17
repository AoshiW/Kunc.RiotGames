using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

public class UnixTimestampDateTimeOffsetMsConverter : JsonConverter<DateTimeOffset>
{
    /// <inheritdoc/>
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.ToUnixTimeMilliseconds());
    }
}
