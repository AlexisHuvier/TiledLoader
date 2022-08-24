using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Export
{
    public readonly string Target;
    public readonly string Format;

    public Export(XElement export)
    {
        Target = export.Attribute("target")?.Value ?? string.Empty;
        Format = export.Attribute("format")?.Value ?? string.Empty;
    }
}