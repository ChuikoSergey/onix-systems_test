using DataGraph.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataGraph.Data.Configuration;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.HasKey(t => t.TitleId);

        builder.Property(t => t.TitleId).ValueGeneratedOnAdd();
    }
}
