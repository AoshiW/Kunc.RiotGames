using System.Diagnostics;

namespace Kunc.RiotGames.Api.Tests;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal sealed class AccountInfo
{
    public string RiotId { get; set; } = default!;

    public string Region { get; set; } = default!;

    public string Puuid { get; set; } = default!;

    private string GetDebuggerDisplay()
    {
        return $"{RiotId} - {Region}";
    }
}
