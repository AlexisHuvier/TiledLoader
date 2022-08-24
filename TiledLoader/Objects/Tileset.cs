using System.Xml.Linq;
using TiledLoader.Utils;

namespace TiledLoader.Objects;

public class Tileset
{
    public readonly uint FirstGId;
    public readonly string Source;
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly uint TileWidth;
    public readonly uint TileHeight;
    public readonly uint Spacing;
    public readonly uint Margin;
    public readonly uint TileCount; // SINCE 0.13
    public readonly uint Columns; // SINCE 0.15
    public readonly ObjectAlignment ObjectAlignment; // SINCE 1.4
    public readonly TileRenderSize TileRenderSize; // SINCE 1.9
    public readonly FillMode FillMode; // SINCE 1.9

    public readonly Image? Image;
    public readonly TileOffset? TileOffset;
    public readonly Grid? Grid; // SINCE 1.0
    public readonly Properties? Properties;
    public readonly TerrainTypes? TerrainTypes;
    public readonly WangSets? WangSets;
    public readonly Transformations? Transformations;

    public readonly List<Tile> Tiles;

    public Tileset(XElement tileset)
    {
        FirstGId = Convert.ToUInt32(tileset.Attribute("firstgid")?.Value ?? "0");
        Source = tileset.Attribute("source")?.Value ?? string.Empty;
        Name = tileset.Attribute("name")?.Value ?? string.Empty;
        Class = tileset.Attribute("class")?.Value ?? string.Empty;
        TileWidth = Convert.ToUInt32(tileset.Attribute("tilewidth")?.Value ?? "0");
        TileHeight = Convert.ToUInt32(tileset.Attribute("tileheight")?.Value ?? "0");
        Spacing = Convert.ToUInt32(tileset.Attribute("spacing")?.Value ?? "0");
        Margin = Convert.ToUInt32(tileset.Attribute("margin")?.Value ?? "0");
        TileCount = Convert.ToUInt32(tileset.Attribute("tilecount")?.Value ?? "0");
        Columns = Convert.ToUInt32(tileset.Attribute("columns")?.Value ?? "0");
        ObjectAlignment = ObjectAlignment.FromString(tileset.Attribute("objectalignment")?.Value ?? "unspecified");
        TileRenderSize = TileRenderSize.FromString(tileset.Attribute("tilerendersize")?.Value ?? "tile");
        FillMode = FillMode.FromString(tileset.Attribute("fillmode")?.Value ?? "stretch");

        Image = tileset.Element("image") == null ? null : new Image(tileset.Element("image")!);
        TileOffset = tileset.Element("tileoffset") == null ? null : new TileOffset(tileset.Element("tileoffset")!);
        Grid = tileset.Element("grid") == null ? null : new Grid(tileset.Element("grid")!);
        Properties = tileset.Element("properties") == null ? null : new Properties(tileset.Element("properties")!);
        TerrainTypes = tileset.Element("terraintypes") == null ? null : new TerrainTypes(tileset.Element("terraintypes")!);
        WangSets = tileset.Element("wangsets") == null ? null : new WangSets(tileset.Element("wangsets")!);
        Transformations = tileset.Element("transformations") == null ? null : new Transformations(tileset.Element("transformations")!);

        Tiles = new List<Tile>();
        foreach (var tile in tileset.Elements("tile"))
            Tiles.Add(new Tile(tile));
    }
}