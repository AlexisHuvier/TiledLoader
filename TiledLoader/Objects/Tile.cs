using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Tile
{
    public readonly uint Id;
    public readonly string Class; // SINCE 1.0 / RENAME FROM TYPE SINCE 1.9
    
    [Obsolete("Deprecated since Tiled 1.5 in favour of <wangtile>")]
    public readonly string Terrain;

    public readonly string Probability;
    public readonly int X;
    public readonly int Y;
    public readonly int Width;
    public readonly int Height;

    public Tile(XElement tile)
    {
        
    }
}