using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Layer
{
    public readonly uint Id; // SINCE 1.2
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly int X;
    public readonly int Y;
    public readonly uint Width;
    public readonly uint Height;
    public readonly float Opacity;
    public readonly bool Visible;
    public readonly string? TintColor;
    public readonly uint OffsetX; // SINCE 0.14
    public readonly uint OffsetY; // SINCE 0.14
    public readonly uint ParallaxX; // SINCE 1.5
    public readonly uint ParallaxY; // SINCE 1.5

    public readonly Properties? Properties;
    public readonly Data? Data;

    public Layer(XElement layer)
    {
        Id = Convert.ToUInt32(layer.Element("id")?.Value ?? "0");
        Name = layer.Element("name")?.Value ?? string.Empty;
        Class = layer.Element("class")?.Value ?? string.Empty;
        X = Convert.ToInt32(layer.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(layer.Attribute("y")?.Value ?? "0");
        Width = Convert.ToUInt32(layer.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(layer.Attribute("height")?.Value ?? "0");
        Opacity = Convert.ToSingle(layer.Attribute("opacity")?.Value ?? "1");
        Visible = layer.Attribute("visible")?.Value == "1";
        TintColor = layer.Attribute("tintcolor") == null ? null : layer.Attribute("tintcolor")!.Value;
        OffsetX = Convert.ToUInt32(layer.Attribute("offsetx")?.Value ?? "0");
        OffsetY = Convert.ToUInt32(layer.Attribute("offsety")?.Value ?? "0");
        ParallaxX = Convert.ToUInt32(layer.Attribute("parallaxx")?.Value ?? "1");
        ParallaxY = Convert.ToUInt32(layer.Attribute("parallaxy")?.Value ?? "1");
        
        Properties = layer.Element("properties") == null ? null : new Properties(layer.Element("properties")!);
        Data = layer.Element("data") == null ? null : new Data(layer.Element("data")!);
    }
}