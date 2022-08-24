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
    public readonly uint Width;
    public readonly uint Height;

    public readonly Properties? Properties;
    public readonly Image? Image;
    public readonly ObjectGroup? ObjectGroup;
    public readonly Animation? Animation;

    public Tile(XElement tile)
    {
        Id = Convert.ToUInt32(tile.Attribute("id")?.Value ?? "0");
        Class = tile.Attribute("class")?.Value ?? (tile.Attribute("type")?.Value ?? string.Empty);
        Terrain = tile.Attribute("terrain")?.Value ?? string.Empty;
        Probability = tile.Attribute("propability")?.Value ?? "0";
        X = Convert.ToInt32(tile.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(tile.Attribute("y")?.Value ?? "0");
        Width = Convert.ToUInt32(tile.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(tile.Attribute("height")?.Value ?? "0");

        Properties = tile.Element("properties") == null ? null : new Properties(tile.Element("properties")!);
        Image = tile.Element("image") == null ? null : new Image(tile.Element("image")!);
        ObjectGroup = tile.Element("objectgroup") == null ? null : new ObjectGroup(tile.Element("objectgroup")!);
        Animation = tile.Element("animation") == null ? null : new Animation(tile.Element("animation")!);
    }
}