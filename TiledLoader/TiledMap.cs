using System.Xml.Linq;
using TiledLoader.Objects;
using TiledLoader.Utils;

namespace TiledLoader;

public class TiledMap
{
    public readonly string File;
    
    public readonly string Version;
    public readonly string TiledVersion; // SINCE 1.0.1
    public readonly string Class; // SINCE 1.9
    public readonly MapOrientation Orientation; // SINCE 0.11
    public readonly RenderOrder RenderOrder;
    public readonly int CompressionLevel;
    public readonly uint Width;
    public readonly uint Height;
    public readonly uint TileWidth;
    public readonly uint TileHeight;
    public readonly uint? HexSideLength; // FOR HEXAGONAL MAP
    public readonly StaggerAxis? StaggerAxis; // FOR STAGGERED AND HEXAGONAL MAP / SINCE 0.11
    public readonly StaggerIndex? StaggerIndex; // FOR STAGGERED AND HEXAGONAL MAP / SINCE 0.11
    public readonly int ParallaxOriginX; // SINCE 1.8
    public readonly int ParallaxOriginY; // SINCE 1.8
    public readonly string BackgroundColor; // MAY INCLUDE ALPHA SINCE 0.15
    public readonly uint NextLayerId; // SINCE 1.2
    public readonly uint NextObjectId; // SINCE 0.11
    public readonly bool Infinite;

    public readonly Properties? Properties;
    public readonly EditorSettings? EditorSettings; // SINCE 1.3

    public readonly List<Tileset> Tilesets;
    public readonly List<ObjectGroup> ObjectGroups;

    public TiledMap(string tmxfile)
    {
        File = tmxfile;
        
        var file = XElement.Load(tmxfile);
        Version = file.Attribute("version")?.Value ?? string.Empty;
        TiledVersion = file.Attribute("tiledversion")?.Value ?? string.Empty;
        Class = file.Attribute("class")?.Value ?? string.Empty;
        Orientation = MapOrientation.FromString(file.Attribute("orientation")?.Value ?? "orthogonal");
        RenderOrder = RenderOrder.FromString(file.Attribute("renderorder")?.Value ?? "right-down");
        CompressionLevel = Convert.ToInt32(file.Attribute("compressionlevel")?.Value ?? "-1");
        Width = Convert.ToUInt32(file.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(file.Attribute("height")?.Value ?? "0");
        TileWidth = Convert.ToUInt32(file.Attribute("tilewidth")?.Value ?? "0");
        TileHeight = Convert.ToUInt32(file.Attribute("tileheight")?.Value ?? "0");
        HexSideLength = file.Attribute("hexsidelength") == null ? null : Convert.ToUInt32(file.Attribute("hexsidelength")?.Value ?? "0");
        StaggerAxis = file.Attribute("staggeraxis") == null ? null : StaggerAxis.FromString(file.Attribute("staggeraxis")?.Value ?? "x");
        StaggerIndex = file.Attribute("staggerindex") == null ? null : StaggerIndex.FromString(file.Attribute("staggerindex")?.Value ?? "x");
        ParallaxOriginX = Convert.ToInt32(file.Attribute("parallaxoriginx")?.Value ?? "0");
        ParallaxOriginY = Convert.ToInt32(file.Attribute("parallaxoriginy")?.Value ?? "0");
        BackgroundColor = file.Attribute("backgroundcolor")?.Value ?? string.Empty;
        NextLayerId = Convert.ToUInt32(file.Attribute("nextlayerid")?.Value ?? "0");
        NextObjectId = Convert.ToUInt32(file.Attribute("nextobjectid")?.Value ?? "0");
        Infinite = file.Attribute("infinite")?.Value == "1";

        Properties = file.Element("properties") == null ? null : new Properties(file.Element("properties")!);
        EditorSettings = file.Element("editorsettings") == null ? null : new EditorSettings(file.Element("editorsettings")!);

        Tilesets = new List<Tileset>();
        foreach(var tileset in file.Elements("tileset"))
            Tilesets.Add(new Tileset(tileset));
        ObjectGroups = new List<ObjectGroup>();
        foreach(var objectgroup in file.Elements("objectgroup"))
            ObjectGroups.Add(new ObjectGroup(objectgroup));
    }
}