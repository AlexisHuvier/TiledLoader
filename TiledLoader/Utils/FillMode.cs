namespace TiledLoader.Utils;

public class FillMode
{
    private FillMode(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly FillMode Stretch = new("stretch");
    public static readonly FillMode PreserveAspect = new("preserve-aspect-fit");
    
    public static FillMode FromString(string type)
    {
        return type switch
        {
            "stretch" => Stretch,
            "preserve-aspect-fit" => PreserveAspect,
            _ => throw new Exception($"Unknown type of fill mode : {type}")
        };
    }

    public override string ToString() => Value;
}