using System.Xml.Linq;
using TiledLoader.Utils;

namespace TiledLoader.Objects;

public class Property
{
    public readonly string Name;
    public readonly PropertyType Type;
    public readonly string CustomPropertyType; // SINCE 1.8
    public readonly string Value;

    public readonly Properties? Properties;

    public Property(XElement property)
    {
        Name = property.Attribute("name")?.Value ?? string.Empty;
        Type = PropertyType.FromString(property.Attribute("type")?.Value ?? "string");
        CustomPropertyType = property.Attribute("propertytype")?.Value ?? string.Empty;
        Value = property.Attribute("value")?.Value ?? string.Empty;

        Properties = property.Element("properties") == null ? null : new Properties(property.Element("properties")!);
    }
}