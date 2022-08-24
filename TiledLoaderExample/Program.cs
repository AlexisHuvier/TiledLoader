using TiledLoader;
using TiledLoader.Objects;

namespace TiledLoaderExample;

internal class Program
{
    private static void DisplayTileset(Tileset tileset)
    {
        Console.WriteLine($" - First Global ID : {tileset.FirstGId}");
        Console.WriteLine($" - Source : {tileset.Source}");
        Console.WriteLine($" - Name : {tileset.Name}");
        Console.WriteLine($" - Class : {tileset.Class}");
        Console.WriteLine($" - Tile Size : {tileset.TileWidth}x{tileset.TileHeight}");
        Console.WriteLine($" - Spacing : {tileset.Spacing}");
        Console.WriteLine($" - Margin : {tileset.Margin}");
        Console.WriteLine($" - Tile Count : {tileset.TileCount}");
        Console.WriteLine($" - Columns : {tileset.Columns}");
        Console.WriteLine($" - Object Alignment : {tileset.ObjectAlignment}");
        Console.WriteLine($" - Tile Render Size : {tileset.TileRenderSize}");
        Console.WriteLine($" - Fill Mode : {tileset.FillMode}");
    }
    
    private static void DisplayMap(TiledMap map)
    {
        Console.WriteLine("============= MAP =============");
        Console.WriteLine($"File : {map.File}");
        Console.WriteLine($"Version : {map.Version}");
        Console.WriteLine($"Tiled Version : {map.TiledVersion}");
        Console.WriteLine($"Class : {map.Class}");
        Console.WriteLine($"Orientation : {map.Orientation}");
        Console.WriteLine($"Render Order : {map.RenderOrder}");
        Console.WriteLine($"Compression Level : {map.CompressionLevel}");
        Console.WriteLine($"Size : {map.Width}x{map.Height}");
        Console.WriteLine($"Tile Size : {map.TileWidth}x{map.TileHeight}");
        Console.WriteLine($"Length of Hexagonal Tile : {map.HexSideLength}");
        Console.WriteLine($"Stagger Axis : {map.StaggerAxis}");
        Console.WriteLine($"Stagger Index : {map.StaggerIndex}");
        Console.WriteLine($"Parallax Origin : X = {map.ParallaxOriginX} / Y = {map.ParallaxOriginY}");
        Console.WriteLine($"Background Color : {map.BackgroundColor}");
        Console.WriteLine($"Next Layer ID : {map.NextLayerId}");
        Console.WriteLine($"Next Object ID : {map.NextObjectId}");
        Console.WriteLine($"Infinite : {map.Infinite}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Tilesets ({map.Tilesets.Count}) : ");
        foreach (var tileset in map.Tilesets)
        {
            Console.WriteLine("-------------------------------");
            DisplayTileset(tileset);
        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Object Groups ({map.ObjectGroups.Count}) : ");
        Console.WriteLine("===============================\n");
    }
    
    private static void Main(string[] args)
    {
        var maps = new TiledMap[]
        {
            new("Resources/map.tmx"), new("Resources/map_tileset.tmx"), 
            new("Resources/map_infinite.tmx")
        };

        foreach (var map in maps)
            DisplayMap(map);
    }
}
