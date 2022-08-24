namespace TiledLoader.Utils;

public class GridOrientation
{
    private GridOrientation(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly GridOrientation Orthogonal = new("orthogonal");
    public static readonly GridOrientation Isometric = new("isometric");
    
    public static GridOrientation FromString(string type)
    {
        return type switch
        {
            "orthogonal" => Orthogonal,
            "isometric" => Isometric,
            _ => throw new Exception($"Unknown type of grid orientation : {type}")
        };
    }

    public override string ToString() => Value;
}