using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Properties
{
    public readonly List<Property> PropertiesList;

    public Properties(XElement properties)
    {
        PropertiesList = new List<Property>();
        foreach (var property in properties.Elements("property"))
            PropertiesList.Add(new Property(property));
    }
}