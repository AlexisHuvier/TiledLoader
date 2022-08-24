using System.Xml.Linq;
using TiledLoader.Utils;

namespace TiledLoader.Objects;

public class Grid
{
    public readonly GridOrientation Orientation;
    public readonly uint Width;
    public readonly uint Height;

    public Grid(XElement grid)
    {
        Orientation = GridOrientation.FromString(grid.Attribute("orientation")?.Value ?? "orthogonal");
        Width = Convert.ToUInt32(grid.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(grid.Attribute("height")?.Value ?? "0");
    }
}