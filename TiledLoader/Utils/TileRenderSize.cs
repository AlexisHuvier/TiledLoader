namespace TiledLoader.Utils;

public class TileRenderSize
{
    private TileRenderSize(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly TileRenderSize Tile = new("tile");
    public static readonly TileRenderSize Grid = new("grid");
    
    public static TileRenderSize FromString(string type)
    {
        return type switch
        {
            "tile" => Tile,
            "grid" => Grid,
            _ => throw new Exception($"Unknown type of tile render size : {type}")
        };
    }

    public override string ToString() => Value;
}