using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Group
{
    public readonly uint Id; // SINCE 1.2
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly uint OffsetX;
    public readonly uint OffsetY;
    public readonly uint ParallaxX; // SINCE 1.5
    public readonly uint ParallaxY; // SINCE 1.5
    public readonly float Opacity;
    public readonly bool Visible;
    public readonly string? TintColor;

    public readonly Properties? Properties;

    public readonly List<Layer> Layers;
    public readonly List<ObjectGroup> ObjectGroups;
    public readonly List<ImageLayer> ImageLayers;
    public readonly List<Group> Groups;

    public Group(XElement group)
    {
        Id = Convert.ToUInt32(group.Element("id")?.Value ?? "0");
        Name = group.Element("name")?.Value ?? string.Empty;
        Class = group.Element("class")?.Value ?? string.Empty;
        OffsetX = Convert.ToUInt32(group.Attribute("offsetx")?.Value ?? "0");
        OffsetY = Convert.ToUInt32(group.Attribute("offsety")?.Value ?? "0");
        ParallaxX = Convert.ToUInt32(group.Attribute("parallaxx")?.Value ?? "1");
        ParallaxY = Convert.ToUInt32(group.Attribute("parallaxy")?.Value ?? "1");
        Opacity = Convert.ToSingle(group.Attribute("opacity")?.Value ?? "1");
        Visible = group.Attribute("visible")?.Value == "1";
        TintColor = group.Attribute("tintcolor") == null ? null : group.Attribute("tintcolor")!.Value;
        
        Properties = group.Element("properties") == null ? null : new Properties(group.Element("properties")!);

        Layers = new List<Layer>();
        foreach(var layer in group.Elements("layer"))
            Layers.Add(new Layer(layer));
        ObjectGroups = new List<ObjectGroup>();
        foreach(var objectGroup in group.Elements("objectgroup"))
            ObjectGroups.Add(new ObjectGroup(objectGroup));
        ImageLayers = new List<ImageLayer>();
        foreach(var imageLayer in group.Elements("imagelayer"))
            ImageLayers.Add(new ImageLayer(imageLayer));
        Groups = new List<Group>();
        foreach(var groupE in group.Elements("group"))
            Groups.Add(new Group(groupE));
    }
}