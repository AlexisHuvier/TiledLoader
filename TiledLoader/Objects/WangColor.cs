using System.Xml.Linq;

namespace TiledLoader.Objects;

public class WangColor
{
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly string Color;
    public readonly uint Tile;
    public readonly string Probability;

    public readonly Properties? Properties;

    public WangColor(XElement wangColor)
    {
        Name = wangColor.Attribute("name")?.Value ?? string.Empty;
        Class = wangColor.Attribute("class")?.Value ?? string.Empty;
        Color = wangColor.Attribute("color")?.Value ?? string.Empty;
        Tile = Convert.ToUInt32(wangColor.Attribute("tile")?.Value ?? "0");
        Probability = wangColor.Attribute("propability")?.Value ?? string.Empty;
        
        Properties = wangColor.Element("properties") == null ? null : new Properties(wangColor.Element("properties")!);
    }
}