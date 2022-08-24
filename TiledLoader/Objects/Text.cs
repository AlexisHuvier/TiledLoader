using System.Xml.Linq;
using TiledLoader.Utils;

namespace TiledLoader.Objects;

public class Text
{
    public readonly string FontFamily;
    public readonly uint PixelSize;
    public readonly bool Wrap;
    public readonly string Color;
    public readonly bool Bold;
    public readonly bool Italic;
    public readonly bool Underline;
    public readonly bool Strikeout;
    public readonly bool Kerning;
    public readonly HorizontalAlignment HAlign;
    public readonly VerticalAlignment VAlign;

    public Text(XElement text)
    {
        FontFamily = text.Attribute("fontfamily")?.Value ?? "sans-serif";
        PixelSize = Convert.ToUInt32(text.Attribute("pixelsize")?.Value ?? "16");
        Wrap = text.Attribute("wrap")?.Value == "1";
        Color = text.Attribute("color")?.Value ?? "#000000";
        Bold = text.Attribute("bold")?.Value == "1";
        Italic = text.Attribute("italic")?.Value == "1";
        Underline = text.Attribute("underline")?.Value == "1";
        Strikeout = text.Attribute("strikeout")?.Value == "1";
        Kerning = text.Attribute("kerning")?.Value == "1";
        HAlign = HorizontalAlignment.FromString(text.Attribute("halign")?.Value ?? "left");
        VAlign = VerticalAlignment.FromString(text.Attribute("VAlign")?.Value ?? "top");
    }
}