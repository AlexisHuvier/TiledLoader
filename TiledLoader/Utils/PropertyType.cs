namespace TiledLoader.Utils;

public class PropertyType
{
    private PropertyType(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public static readonly PropertyType String = new("string");
    public static readonly PropertyType Int = new("int");
    public static readonly PropertyType Float = new("float");
    public static readonly PropertyType Bool = new("bool");
    public static readonly PropertyType Color = new("color"); // SINCE 0.17
    public static readonly PropertyType File = new("file"); // SINCE 0.17
    public static readonly PropertyType Object = new("object"); // SINCE 1.4
    public static readonly PropertyType Class = new("class"); // SINCE 1.8
    
    public static PropertyType FromString(string type)
    {
        return type switch
        {
            "string" => String,
            "int" => Int,
            "float" => Float,
            "bool" => Bool,
            "color" => Color,
            "file" => File,
            "object" => Object,
            "class" => Class,
            _ => throw new Exception($"Unknown type of property : {type}")
        };
    }

    public override string ToString() => Value;
}