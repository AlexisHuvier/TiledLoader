using TiledLoader;

namespace TiledLoaderExample;

internal class Program
{
    private static void Main(string[] args)
    {
        var maps = new TiledMap[] {new("Resources/map.tmx"), new("Resources/map_tileset.tmx")};

        foreach (var map in maps)
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
            Console.WriteLine("===============================\n");
        }
    }
}
