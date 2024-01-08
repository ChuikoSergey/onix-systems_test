using DataGraph.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataGraph.Data.Configuration;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.DiscountId);

        builder.Property(d => d.DiscountId).ValueGeneratedOnAdd();

        builder.HasOne(d => d.Store)
            .WithMany(s => s.Discounts)
            .HasForeignKey(d => d.StoreId);
    }
}
