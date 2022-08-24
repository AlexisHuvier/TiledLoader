using System.Xml.Linq;

namespace TiledLoader.Objects;

public class TileOffset
{
    public readonly int X;
    public readonly int Y;

    public TileOffset(XElement tileOffset)
    {
        X = Convert.ToInt32(tileOffset.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(tileOffset.Attribute("y")?.Value ?? "0");
    }
}