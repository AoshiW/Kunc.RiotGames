#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0052 // Remove unread private members
using Kunc.RiotGames.Lol.DataDragon;
using Kunc.RiotGames.Lol.GameClient;
using Kunc.RiotGames.Lor.DeckCodes;
using Kunc.RiotGames.Lor.GameClient;
using System.Text;
using System.Text.Json;

partial class Program
{
    static readonly ILolDataDragon LolDataDragon = new LolDataDragon();
    static readonly ILolGameClient LolGameClient = new LolGameClient();

    static readonly ILorDeckEncoder LorDeckEncoder = new LorDeckEncoder();
    static readonly ILorGameClient LorGameClient = new LorGameClient();

    static void ExtensionDataPropertyGenerator(Dictionary<string, JsonElement>? extensionData)
    {
        if (extensionData is null)
            return;
        var sb = new StringBuilder();
        foreach (var item in extensionData)
        {
            (string type, bool isRefType) = item.Value.ValueKind switch
            {
                JsonValueKind.Array => ("object[]", true),
                JsonValueKind.Object => ("object", true),
                JsonValueKind.String => ("string", true),
                JsonValueKind.Number => ("int", false),
                _ => ("error", false)
            };
            var propName = item.Key;
            sb.Length = 0;
            if (char.IsLower(propName[0]))
            {
                sb.Append("[JsonPropertyName(\"").Append(propName).AppendLine("\")]");
                propName = string.Create(propName.Length, propName, (span, a) =>
                {
                    a.CopyTo(span);
                    span[0] = char.ToUpper(span[0]);
                });
            }
            sb.Append("public ").Append(type).Append(' ').Append(propName).Append(" { get; init; }");
            if (isRefType)
                sb.Append(" = default!;");
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
