namespace DataGraph.Core.Models.DataScheme;

public class DataSchemeNode
{
    public string Name { get; set; }
    public string? PrimaryKeyName { get; set; }
    public List<string> ForeignKeyFields { get; set; } = new List<string>();
}
