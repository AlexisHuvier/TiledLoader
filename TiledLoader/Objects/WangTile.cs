using System.Xml.Linq;

namespace TiledLoader.Objects;

public class WangTile
{
    public readonly uint TileId;
    public readonly string WangId;
    public readonly bool HFlip; // REMOVED IN 1.5
    public readonly bool VFlip; // REMOVED IN 1.5
    public readonly bool DFlip; // REMOVED IN 1.5

    public WangTile(XElement wangTile)
    {
        TileId = Convert.ToUInt32(wangTile.Attribute("tileid")?.Value ?? "0");
        WangId = wangTile.Attribute("wangid")?.Value ?? string.Empty;
        HFlip = wangTile.Attribute("hflip")?.Value == "1";
        VFlip = wangTile.Attribute("vflip")?.Value == "1";
        DFlip = wangTile.Attribute("dflip")?.Value == "1";
    }
}