using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

/// <summary>
/// Converts <see cref="TimeSpan"/> to/from <see cref="double"/>.
/// </summary>
public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
{
    private readonly BaseTimeUnit _baseTimeUnit;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonTimeSpanConverter"/> class. 
    /// </summary>
    public JsonTimeSpanConverter(BaseTimeUnit baseTimeUnit)
    {
        _baseTimeUnit = baseTimeUnit;
    }

    /// <inheritdoc/>
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetDouble();
        return _baseTimeUnit switch
        {
            BaseTimeUnit.Milliseconds => TimeSpan.FromMilliseconds(value),
            BaseTimeUnit.Seconds => TimeSpan.FromSeconds(value),
            _ => throw new NotImplementedException()
        };
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(_baseTimeUnit switch
        {
            BaseTimeUnit.Milliseconds => value.TotalMilliseconds,
            BaseTimeUnit.Seconds => value.TotalSeconds,
            _ => throw new NotImplementedException()
        });
    }
}