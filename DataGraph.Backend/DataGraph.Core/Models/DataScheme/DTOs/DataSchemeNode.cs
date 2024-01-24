namespace DataGraph.Core.Models.DataScheme.DTOs;

public class DataSchemeNode
{
    public string Name { get; set; }
    public List<string> PrimaryKeyFields { get; set; } = new List<string>();
    public List<string> ForeignKeyFields { get; set; } = new List<string>();
}
