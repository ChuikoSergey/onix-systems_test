namespace DataGraph.Core.Models.DataScheme;

public class DataScheme
{
    public List<DataSchemeNode> Nodes { get; set; } = new List<DataSchemeNode>();
    public List<DataSchemeBranch> Branches { get; set; } = new List<DataSchemeBranch>();
}
