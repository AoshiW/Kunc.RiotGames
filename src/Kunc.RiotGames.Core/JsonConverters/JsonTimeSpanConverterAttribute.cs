using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class JsonTimeSpanConverterAttribute : JsonConverterAttribute
{
    private readonly BaseTimeUnit _baseTimeUnit;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonTimeSpanConverterAttribute"/> class. 
    /// </summary>
    /// <param name="baseTimeUnit"></param>
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
