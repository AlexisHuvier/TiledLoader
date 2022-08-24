using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Object
{
    public readonly uint Id; // SINCE 0.11
    public readonly string Name;
    public readonly string Class; // RENAME FROM TYPE SINCE 1.9
    public readonly int X;
    public readonly int Y;
    public readonly uint Width;
    public readonly uint Height;
    public readonly int Rotation;
    public readonly uint? GId;
    public readonly bool Visible;
    public readonly string? Template;

    public readonly Properties? Properties;
    public readonly Ellipse? Ellipse; // SINCE 0.9
    public readonly Point? Point; // SINCE 1.1
    public readonly Polygon? Polygon;
    public readonly Polyline? Polyline;
    public readonly Text? Text; // SINCE 1.0

    public Object(XElement @object)
    {
        Id = Convert.ToUInt32(@object.Attribute("id")?.Value ?? "0");
        Name = @object.Attribute("name")?.Value ?? string.Empty;
        Class = @object.Attribute("class")?.Value ?? (@object.Attribute("type")?.Value ?? string.Empty);
        X = Convert.ToInt32(@object.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(@object.Attribute("y")?.Value ?? "0");
        Width = Convert.ToUInt32(@object.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(@object.Attribute("height")?.Value ?? "0");
        Rotation = Convert.ToInt32(@object.Attribute("rotation")?.Value ?? "0");
        GId = @object.Attribute("gid") == null ? null : Convert.ToUInt32(@object.Attribute("gid")!.Value);
        Visible = @object.Attribute("visible")?.Value == "1";
        Template = @object.Attribute("template") == null ? null : @object.Attribute("template")!.Value;

        Properties = @object.Element("properties") == null ? null : new Properties(@object.Element("properties")!);
        Ellipse = @object.Element("ellipse") == null ? null : new Ellipse();
        Point = @object.Element("point") == null ? null : new Point();
        Polygon = @object.Element("polygon") == null ? null : new Polygon(@object.Element("polygon")!);
        Polyline = @object.Element("polyline") == null ? null : new Polyline(@object.Element("polyline")!);
        Text = @object.Element("text") == null ? null : new Text(@object.Element("text")!);
    }
}