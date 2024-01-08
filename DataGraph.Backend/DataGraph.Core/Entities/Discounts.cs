namespace DataGraph.Core.Entities;

public class Discount
{
    public Guid DiscountId { get; set; }
    public Guid StoreId { get; set; }

    public Store Store { get; set; }
}
