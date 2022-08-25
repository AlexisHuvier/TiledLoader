using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Chunk
{
    public readonly int X;
    public readonly int Y;
    public readonly uint Width;
    public readonly uint Height;

    public readonly List<uint> Tiles;

    public Chunk(XElement chunk)
    {
        X = Convert.ToInt32(chunk.Attribute("x")?.Value ?? "0");
        Y = Convert.ToInt32(chunk.Attribute("y")?.Value ?? "0");
        Width = Convert.ToUInt32(chunk.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(chunk.Attribute("height")?.Value ?? "0");

        Tiles = chunk.Value.Split(",").Select(tile => Convert.ToUInt32(tile)).ToList();
    }
}