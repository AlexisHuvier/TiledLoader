using System.Xml.Linq;

namespace TiledLoader.Objects;

public class Animation
{
    public readonly List<Frame> Frames;

    public Animation(XElement animation)
    {
        Frames = new List<Frame>();
        foreach(var frame in animation.Elements("frame"))
            Frames.Add(new Frame(frame));
    }
}