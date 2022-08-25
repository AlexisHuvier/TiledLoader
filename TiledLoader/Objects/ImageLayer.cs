using System.Xml.Linq;

namespace TiledLoader.Objects;

public class ImageLayer
{
    public readonly uint Id; // SINCE 1.2
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly uint OffsetX; // SINCE 0.15
    public readonly uint OffsetY; // SINCE 0.15
    public readonly uint ParallaxX; // SINCE 1.5
    public readonly uint ParallaxY; // SINCE 1.5
    [Obsolete("Deprecated since 0.15")] public readonly int X;
    [Obsolete("Deprecated since 0.15")] public readonly int Y;
    public readonly float Opacity;
    public readonly bool Visible;
    public readonly string? TintColor;
    public readonly bool RepeatX; // SINCE 1.8
    public readonly bool RepeatY; // SINCE 1.8

    public readonly Properties? Properties;
    public readonly Image? Image;

    public ImageLayer(XElement imageLayer)
    {
        Id = Convert.ToUInt32(imageLayer.Element("id")?.Value ?? "0");
        Name = imageLayer.Element("name")?.Value ?? string.Empty;
        Class = imageLayer.Element("class")?.Value ?? string.Empty;
        OffsetX = Convert.ToUInt32(imageLayer.Attribute("offsetx")?.Value ?? "0");
        OffsetY = Convert.ToUInt32(imageLayer.Attribute("offsety")?.Value ?? "0");
        ParallaxX = Convert.ToUInt32(imageLayer.Attribute("parallaxx")?.Value ?? "1");
        ParallaxY = Convert.ToUInt32(imageLayer.Attribute("parallaxy")?.Value ?? "1");
        X = Convert.ToInt32(imageLayer.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(imageLayer.Attribute("y")?.Value ?? "0");
        Opacity = Convert.ToSingle(imageLayer.Attribute("opacity")?.Value ?? "1");
        Visible = imageLayer.Attribute("visible")?.Value == "1";
        TintColor = imageLayer.Attribute("tintcolor") == null ? null : imageLayer.Attribute("tintcolor")!.Value;
        RepeatX = imageLayer.Attribute("repeatx")?.Value == "1";
        RepeatY = imageLayer.Attribute("repeaty")?.Value == "1";
        
        Properties = imageLayer.Element("properties") == null ? null : new Properties(imageLayer.Element("properties")!);
        Image = imageLayer.Element("image") == null ? null : new Image(imageLayer.Element("image")!);
    }
}