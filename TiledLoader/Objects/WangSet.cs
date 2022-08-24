using System.Xml.Linq;

namespace TiledLoader.Objects;

public class WangSet
{
    public readonly string Name;
    public readonly string Class; // SINCE 1.9
    public readonly uint Tile;

    public readonly Properties? Properties;

    public readonly List<WangColor> WangColors; // SINCE 1.5
    public readonly List<WangTile> WangTiles;

    public WangSet(XElement wangset)
    {
        Name = wangset.Attribute("name")?.Value ?? string.Empty;
        Class = wangset.Attribute("class")?.Value ?? string.Empty;
        Tile = Convert.ToUInt32(wangset.Attribute("tile")?.Value ?? "0");

        Properties = wangset.Element("properties") == null ? null : new Properties(wangset.Element("properties")!);

        WangColors = new List<WangColor>();
        foreach (var wangColor in wangset.Elements("wangcolor"))
            WangColors.Add(new WangColor(wangColor));
        WangTiles = new List<WangTile>();
        foreach(var wangTile in wangset.Elements("wangtile"))
            WangTiles.Add(new WangTile(wangTile));
    }
}