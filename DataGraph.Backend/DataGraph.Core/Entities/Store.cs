namespace DataGraph.Core.Entities;

public class Store
{
    public Guid StoreId { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<Sale> Sales { get; set; }
}
