using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Data
{
    public readonly string Encoding;
    public readonly string Compression;

    public readonly List<uint> Tiles;
    public readonly List<Chunk> Chunks;

    public Data(XElement data)
    {
        Encoding = data.Attribute("encoding")?.Value ?? string.Empty;
        Compression = data.Attribute("compression")?.Value ?? string.Empty;

        if (Encoding != "csv" || Compression != string.Empty)
        {
            #warning "Data doesn't manage compression and other encoding than csv"
            
            Tiles = new List<uint>();
            Chunks = new List<Chunk>();
        }
        else
        {
            Tiles = !data.Elements("chunk").Any() ? data.Value.Split(",").Select(tile => Convert.ToUInt32(tile)).ToList() : new List<uint>();
            Chunks = new List<Chunk>();
            foreach(var chunk in data.Elements("chunk"))
                Chunks.Add(new Chunk(chunk));
        }
    }
}