using Kunc.RiotGames;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Utils;

public static class AssertExtensions
{
    static readonly NullabilityInfoContext s_nullabilityInfoContext = new();

    public static void CheckNullabilityInfo<T>(this Assert assert, T obj)
    {
        if (obj is null)
            return;
        Type type = obj.GetType();
        if (type.Namespace!.StartsWith("System"))
        {
            if (obj is IEnumerable enumerable)
            {
                foreach (object item in enumerable)
                {
                    CheckNullabilityInfo(assert, item);
                }
            }
        }
        else
        {
            if (obj is not BaseDto)
                return;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                NullabilityInfo nullInfo = s_nullabilityInfoContext.Create(prop);
                object? value = prop.GetValue(obj);
                if (nullInfo.ReadState == NullabilityState.NotNull && value is null)
                    Assert.Inconclusive($"Not nullable properties with null value: {prop.ReflectedType}.{prop.Name}");
                if (value is string || prop.GetCustomAttribute<JsonExtensionDataAttribute>() is not null)
                    return;
                CheckNullabilityInfo(assert, value);
            }
        }
    }

#pragma warning disable IDE0060 // Remove unused parameter
    public static void CheckJsonExtensionData<T>(this Assert assert, T obj)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        var dic = new Dictionary<string, string>();
        ED(obj, dic);
        if(dic.Count > 0)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> item in dic)
            {
                sb.Append(item.Key).Append(" = ").AppendLine(item.Value);
            }
            Assert.Inconclusive(sb.ToString());
        }
    }

    static void ED(object? obj, Dictionary<string, string> dic, string path = "base")
    {
        if (obj is null)
            return;
        if (obj is IList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ED(list[i], dic, path + $"[{i}]");
            }
        }
        else if (obj is IDictionary dict)
        {
            foreach (DictionaryEntry item in dict)
            {
                ED(item.Value, dic, path + $"[{item.Key}]");
            }
        }
        else
        {
            if (obj is BaseDto baseDto)
            {
                if (baseDto.ExtensionData is not null)
                {
                    foreach (KeyValuePair<string, System.Text.Json.JsonElement> item in baseDto.ExtensionData)
                    {
                        dic.Add(path + "." + item.Key, item.Value.GetRawText());
                    }
                }
                foreach (PropertyInfo? prop in obj.GetType().GetProperties())
                {
                    if (prop.GetCustomAttribute<JsonExtensionDataAttribute>(true) is null)
                    {
                        object? value = prop.GetValue(obj);
                        ED(value, dic, path + "." + prop.Name);
                    }
                }
            }
        }
    }
}
