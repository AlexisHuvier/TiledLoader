namespace TiledLoader.Utils;

public class StaggerAxis
{
    private StaggerAxis(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly StaggerAxis X = new("x");
    public static readonly StaggerAxis Y = new("y");
    
    public static StaggerAxis FromString(string type)
    {
        return type switch
        {
            "x" => X,
            "y" => Y,
            _ => throw new Exception($"Unknown type of stagger axis : {type}")
        };
    }

    public override string ToString() => Value;
}