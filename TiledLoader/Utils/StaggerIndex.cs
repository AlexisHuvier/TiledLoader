namespace TiledLoader.Utils;

public class StaggerIndex
{
    private StaggerIndex(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static StaggerIndex Odd => new("odd");
    public static StaggerIndex Even => new("even");
    
    public static StaggerIndex FromString(string type)
    {
        return type switch
        {
            "odd" => Odd,
            "even" => Even,
            _ => throw new Exception($"Unknown type of stagger index : {type}")
        };
    }

    public override string ToString() => Value;
}