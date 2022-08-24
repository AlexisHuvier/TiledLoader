using System.Xml.Linq;

namespace TiledLoader.Objects;

[Obsolete("Deprecated since Tiled 1.5 in favour of <wangcolor>")]
public class Terrain
{
    public readonly string Name;
    public readonly uint Tile;

    public readonly Properties? Properties;

    public Terrain(XElement terrain)
    {
        Name = terrain.Attribute("name")?.Value ?? string.Empty;
        Tile = Convert.ToUInt32(terrain.Attribute("tile")?.Value ?? "0");
        
        Properties = terrain.Element("properties") == null ? null : new Properties(terrain.Element("properties")!);
    }
}