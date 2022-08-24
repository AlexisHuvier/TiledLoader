using System.Xml.Linq;

namespace TiledLoader.Objects;

[Obsolete("Deprecated since Tiled 1.5 in favour of <wangsets>")]
public class TerrainTypes
{
    public readonly List<Terrain> Terrains;

    public TerrainTypes(XElement terrainTypes)
    {
        Terrains = new List<Terrain>();
        foreach (var property in terrainTypes.Elements("property"))
            Terrains.Add(new Terrain(property));
    }
}