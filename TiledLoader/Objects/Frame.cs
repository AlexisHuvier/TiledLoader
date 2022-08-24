using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Frame
{
    public readonly uint Id;
    public readonly uint Duration;

    public Frame(XElement frame)
    {
        Id = Convert.ToUInt32(frame.Attribute("id")?.Value ?? "0");
        Duration = Convert.ToUInt32(frame.Attribute("duration")?.Value ?? "0");
    }
}