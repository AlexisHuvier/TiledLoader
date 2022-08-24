using System.Xml.Linq;

namespace TiledLoader.Objects;

public class ChunkSize
{
    public readonly uint Width;
    public readonly uint Height;

    public ChunkSize(XElement chunkSize)
    {
        Width = Convert.ToUInt32(chunkSize.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(chunkSize.Attribute("height")?.Value ?? "0");
    }
}