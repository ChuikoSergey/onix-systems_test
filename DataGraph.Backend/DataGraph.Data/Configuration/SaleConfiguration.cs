using DataGraph.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataGraph.Data.Configuration;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.SaleId);

        builder.Property(s => s.SaleId).ValueGeneratedOnAdd();

        builder.HasOne(s => s.Store)
            .WithMany(s => s.Sales)
            .HasForeignKey(s => s.StoreId);

        builder.HasOne(s => s.Title)
            .WithMany(t => t.Sales)
            .HasForeignKey(s => s.TitleId);
    }
}
