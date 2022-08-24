using System.Xml.Linq;

namespace TiledLoader.Objects;

public class EditorSettings
{
    public readonly ChunkSize? ChunkSize;
    public readonly Export? Export;

    public EditorSettings(XElement editorSettings)
    {
        ChunkSize = editorSettings.Element("chunksize") == null ? null : new ChunkSize(editorSettings.Element("chunksize")!);
        Export = editorSettings.Element("export") == null ? null : new Export(editorSettings.Element("export")!);
    }
}