using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.RiotGames.JsonConverters;

// https://github.com/dotnet/runtime/issues/74385
public sealed class JsonStringEnumConverterWithAltNames<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum>
    : JsonStringEnumConverter<TEnum> where TEnum : struct, Enum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonStringEnumConverterWithAltNames{TEnum}"/> class.
    /// </summary>
    public JsonStringEnumConverterWithAltNames() : base(ResolveNamingPolicy())
    {
    }

    private static JsonEnumNamingPolicy? ResolveNamingPolicy()
    {
        var map = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (f.Name, AttributeName: f.GetCustomAttribute<JsonEnumNameAttribute>()?.Value))
            .Where(pair => pair.AttributeName != null)
            .ToDictionary();

        return map.Count > 0 ? new JsonEnumNamingPolicy(map!) : null;
    }

}
sealed class JsonEnumNamingPolicy : JsonNamingPolicy
{
    private readonly FrozenDictionary<string, string> _map;

    public JsonEnumNamingPolicy(Dictionary<string, string> map)
    {
        _map = map.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    public override string ConvertName(string name)
        => _map.TryGetValue(name, out string? newName) ? newName : name;
}

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class JsonEnumNameAttribute : JsonAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonEnumNameAttribute"/> class.
    /// </summary>
    public JsonEnumNameAttribute(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Value = value;
    }

    public string Value { get; }
}
