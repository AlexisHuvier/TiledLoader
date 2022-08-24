namespace TiledLoader.Utils;

public class VerticalAlignment
{
    private VerticalAlignment(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly VerticalAlignment Top = new("top");
    public static readonly VerticalAlignment Center = new("center");
    public static readonly VerticalAlignment Bottom = new("bottom");

    public static VerticalAlignment FromString(string type)
    {
        return type switch
        {
            "top" => Top,
            "center" => Center,
            "bottom" => Bottom,
            _ => throw new Exception($"Unknown type of vertical alignment : {type}")
        };
    }

    public override string ToString() => Value;
}