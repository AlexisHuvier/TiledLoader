namespace TiledLoader.Utils;

public class MapOrientation
{
    private MapOrientation(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly MapOrientation Orthogonal = new("orthogonal");
    public static readonly MapOrientation Isometric = new("isometric");
    public static readonly MapOrientation Staggered = new("staggered");
    public static readonly MapOrientation Hexagonal = new("hexagonal");

    public static MapOrientation FromString(string type)
    {
        return type switch
        {
            "orthogonal" => Orthogonal,
            "isometric" => Isometric,
            "staggered" => Staggered,
            "hexagonal" => Hexagonal,
            _ => throw new Exception($"Unknown type of map orientation : {type}")
        };
    }

    public override string ToString() => Value;
}