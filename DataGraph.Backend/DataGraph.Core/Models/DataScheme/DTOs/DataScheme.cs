namespace DataGraph.Core.Models.DataScheme.DTOs;

public class DataScheme
{
    public List<DataSchemeNode> Nodes { get; set; } = new List<DataSchemeNode>();
    public List<DataSchemeBranch> Branches { get; set; } = new List<DataSchemeBranch>();
}
