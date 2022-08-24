namespace TiledLoader.Utils;

public class HorizontalAlignment
{
    private HorizontalAlignment(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly HorizontalAlignment Left = new("left");
    public static readonly HorizontalAlignment Center = new("center");
    public static readonly HorizontalAlignment Right = new("right");
    public static readonly HorizontalAlignment Justify = new("justify");

    public static HorizontalAlignment FromString(string type)
    {
        return type switch
        {
            "left" => Left,
            "center" => Center,
            "right" => Right,
            "justify" => Justify,
            _ => throw new Exception($"Unknown type of horizontal alignment : {type}")
        };
    }

    public override string ToString() => Value;
}