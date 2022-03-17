using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

public class JsonTimeSpanConverterAttribute : JsonConverterAttribute
{
    private readonly BaseTimeUnit _baseTimeUnit;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonTimeSpanConverterAttribute"/> class. 
    /// </summary>
    public JsonTimeSpanConverterAttribute(BaseTimeUnit baseTimeUnit)
    {
        _baseTimeUnit = baseTimeUnit;
    }

    /// <inheritdoc/>
    public override JsonConverter? CreateConverter(Type typeToConvert)
    {
        return new JsonTimeSpanConverter(_baseTimeUnit);
    }
}
