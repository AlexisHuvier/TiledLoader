namespace TiledLoader.Utils;

public class RenderOrder
{
    private RenderOrder(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static RenderOrder RightDown => new("right-down");
    public static RenderOrder RightUp => new("right-up");
    public static RenderOrder LeftDown => new("left-down");
    public static RenderOrder LeftUp => new("left-up");

    public static RenderOrder FromString(string type)
    {
        return type switch
        {
            "right-down" => RightDown,
            "right-up" => RightUp,
            "left-down" => LeftDown,
            "left-up" => LeftUp,
            _ => throw new Exception($"Unknown type of render order : {type}")
        };
    }

    public override string ToString() => Value;
}