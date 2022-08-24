using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Transformations
{
    public readonly bool HFlip;
    public readonly bool VFlip;
    public readonly bool Rotate;
    public readonly bool PreferUntransformed;

    public Transformations(XElement transformations)
    {
        HFlip = transformations.Attribute("hflip")?.Value == "1";
        VFlip = transformations.Attribute("vflip")?.Value == "1";
        Rotate = transformations.Attribute("rotate")?.Value == "1";
        PreferUntransformed = transformations.Attribute("preferuntransformed")?.Value == "1";
    }
}