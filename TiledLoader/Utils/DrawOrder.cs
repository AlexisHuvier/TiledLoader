namespace TiledLoader.Utils;

public class DrawOrder
{
    private DrawOrder(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly DrawOrder Index = new("index");
    public static readonly DrawOrder TopDown = new("topdown");

    public static DrawOrder FromString(string type)
    {
        return type switch
        {
            "index" => Index,
            "topdown" => TopDown,
            _ => throw new Exception($"Unknown type of horizontal alignment : {type}")
        };
    }

    public override string ToString() => Value;
}