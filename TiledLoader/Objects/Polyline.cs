using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Polyline
{
    public readonly string Points;

    public Polyline(XElement polyline)
    {
        Points = polyline.Attribute("points")?.Value ?? string.Empty;
    }
}