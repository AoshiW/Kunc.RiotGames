using System.Text.Json.Serialization;

namespace Kunc.RiotGames.Lor;

public enum Faction
{
    /// <summary>
    /// Represent unknow enum value.
    /// </summary>
    UnknownEnumValue = -1,

    Demacia,
    Freljord,
    Ionia,
    Noxus,
    PiltoverZaun,
    ShadowIsles,
    Bilgewater,
    Shurima,
    MountTargon = 9,
    BandleCity,
}
