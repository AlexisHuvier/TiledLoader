using System.Xml.Linq;

namespace TiledLoader.Objects;

public class WangSets
{
    public readonly List<WangSet> WangSetsList;

    public WangSets(XElement wangsets)
    {
        WangSetsList = new List<WangSet>();
        foreach(var wangset in wangsets.Elements("wangset"))
            WangSetsList.Add(new WangSet(wangset));
    }
}