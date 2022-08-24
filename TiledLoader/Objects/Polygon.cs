using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Polygon
{
    public readonly string Points;

    public Polygon(XElement polygon)
    {
        Points = polygon.Attribute("points")?.Value ?? string.Empty;
    }
}