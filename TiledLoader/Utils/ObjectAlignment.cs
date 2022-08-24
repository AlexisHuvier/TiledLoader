namespace TiledLoader.Utils;

public class ObjectAlignment
{
    private ObjectAlignment(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly ObjectAlignment Unspecified = new("unspecified");
    public static readonly ObjectAlignment TopLeft = new("topleft");
    public static readonly ObjectAlignment Top = new("top");
    public static readonly ObjectAlignment TopRight = new("topright");
    public static readonly ObjectAlignment Left = new("left");
    public static readonly ObjectAlignment Center = new("center");
    public static readonly ObjectAlignment Right = new("right");
    public static readonly ObjectAlignment BottomLeft = new("bottomleft");
    public static readonly ObjectAlignment Bottom = new("bottom");
    public static readonly ObjectAlignment BottomRight = new("bottomright");
    
    public static ObjectAlignment FromString(string type)
    {
        return type switch
        {
            "unspecified" => Unspecified,
            "topleft" => TopLeft,
            "top" => Top,
            "topright" => TopRight,
            "left" => Left,
            "center" => Center,
            "right" => Right,
            "bottomleft" => BottomLeft,
            "bottom" => Bottom,
            "bottomright" => BottomRight,
            _ => throw new Exception($"Unknown type of object alignment : {type}")
        };
    }

    public override string ToString() => Value;
}