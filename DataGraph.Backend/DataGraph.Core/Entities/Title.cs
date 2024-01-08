namespace DataGraph.Core.Entities;

public class Title
{
    public Guid TitleId { get; set; }
    public ICollection<Sale> Sales { get; set; }
}
