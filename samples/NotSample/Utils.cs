using System.Collections;
using Kunc.RiotGames;

static class Utils
{
    public static void PrintExtensionData(this BaseDto? dto) => PrintExtensionDataObj(dto);
    public static void PrintExtensionData(this IEnumerable<BaseDto>? dtos) => PrintExtensionDataObj(dtos);

    public static void PrintExtensionDataObj(object? obj)
    {
        var dic = new Dictionary<string, object>();
        PrintExtensionData(obj, dic, "");
        foreach (var item in dic)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void PrintExtensionData(object? obj, Dictionary<string, object> extensionData, string path)
    {
        if (obj is null)
            return;
        if (obj is BaseDto baseDto)
        {
            if (baseDto.ExtensionData is not null)
            {
                foreach (var item in baseDto.ExtensionData)
                {
                    extensionData.TryAdd($"{path}.{item.Key}", item.Value);
                }
            }
            foreach (var item in obj.GetType().GetProperties())
            {
                if (item.Name != nameof(BaseDto.ExtensionData))
                    PrintExtensionData(item.GetValue(obj), extensionData, $"{item}.{item.Name}");
            }
        }
        else if (obj is IEnumerable<BaseDto> values)
        {
            int index = 0;
            foreach (var item in values)
            {
                index++;
                PrintExtensionData(item, extensionData, $"{path}[{""}]");
            }
        }
        else if (obj is IDictionary dictionary)
        {
            foreach (DictionaryEntry item in dictionary)
            {
                PrintExtensionData(item.Value, extensionData, $"{path}[{""}]");
            }
        }
    }
}
