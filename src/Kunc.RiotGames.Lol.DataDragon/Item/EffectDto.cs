using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Kunc.RiotGames.Lol.DataDragon.Item;

[Experimental(DiagnosticIds.KNCRG0000, UrlFormat = DiagnosticIds.UrlFormat)]
public class EffectDto : BaseDto
{
    public JsonElement Effect1Amount { get; set; }
    public JsonElement Effect2Amount { get; set; }
    public JsonElement Effect3Amount { get; set; }
    public JsonElement Effect4Amount { get; set; }
    public JsonElement Effect5Amount { get; set; }
    public JsonElement Effect6Amount { get; set; }
    public JsonElement Effect7Amount { get; set; }
    public JsonElement Effect8Amount { get; set; }
    public JsonElement Effect9Amount { get; set; }
    public JsonElement Effect10Amount { get; set; }
    public JsonElement Effect11Amount { get; set; }
    public JsonElement Effect12Amount { get; set; }
    public JsonElement Effect13Amount { get; set; }
    public JsonElement Effect14Amount { get; set; }
    public JsonElement Effect15Amount { get; set; }
}
