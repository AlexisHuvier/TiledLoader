using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Image // NOT SUPPORT EMBEDDED IMAGE
{
    public readonly string Source;
    public readonly string TransparentColor;
    public readonly uint Width;
    public readonly uint Height;

    public Image(XElement image)
    {
        Source = image.Attribute("source")?.Value ?? string.Empty;
        TransparentColor = image.Attribute("trans")?.Value ?? string.Empty;
        Width = Convert.ToUInt32(image.Attribute("width")?.Value ?? "0");
        Height = Convert.ToUInt32(image.Attribute("height")?.Value ?? "0");
    }
}