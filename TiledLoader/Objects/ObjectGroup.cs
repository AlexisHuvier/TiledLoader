using System.Xml.Linq;
using TiledLoader.Utils;

namespace TiledLoader.Objects;

public class ObjectGroup
{
    public readonly uint Id;
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly string? Color;
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
    public readonly DrawOrder DrawOrder;

    public readonly Properties? Properties;

    public readonly List<Object> Objects;

    public ObjectGroup(XElement objGroup)
    {
        Id = Convert.ToUInt32(objGroup.Attribute("id")?.Value ?? "0");
        Name = objGroup.Attribute("name")?.Value ?? string.Empty;
        Class = objGroup.Attribute("class")?.Value ?? string.Empty;
        Color = objGroup.Attribute("color") == null ? null : objGroup.Attribute("color")!.Value;
        X = Convert.ToInt32(objGroup.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(objGroup.Attribute("y")?.Value ?? "0");
        Width = Convert.ToUInt32(objGroup.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(objGroup.Attribute("height")?.Value ?? "0");
        Opacity = Convert.ToSingle(objGroup.Attribute("opacity")?.Value ?? "1");
        Visible = objGroup.Attribute("visible")?.Value == "1";
        TintColor = objGroup.Attribute("tintcolor") == null ? null : objGroup.Attribute("tintcolor")?.Value;
        OffsetX = Convert.ToUInt32(objGroup.Attribute("offsetx")?.Value ?? "0");
        OffsetY = Convert.ToUInt32(objGroup.Attribute("offsety")?.Value ?? "0");
        ParallaxX = Convert.ToUInt32(objGroup.Attribute("parallaxx")?.Value ?? "1");
        ParallaxY = Convert.ToUInt32(objGroup.Attribute("parallaxy")?.Value ?? "1");
        DrawOrder = DrawOrder.FromString(objGroup.Attribute("draworder")?.Value ?? "topdown");

        Properties = objGroup.Element("properties") == null ? null : new Properties(objGroup.Element("properties")!);

        Objects = new List<Object>();
        foreach(var @object in objGroup.Elements("object"))
            Objects.Add(new Object(@object));
    }
}