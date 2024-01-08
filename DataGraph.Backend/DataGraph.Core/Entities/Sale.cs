namespace DataGraph.Core.Entities;

public class Sale
{
    public Guid SaleId { get; set; }
    public Guid StoreId { get; set; }
    public Guid TitleId { get; set; }

    public Store Store { get; set; }
    public Title Title { get; set; }
}
