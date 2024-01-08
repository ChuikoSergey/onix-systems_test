using DataGraph.Core.Entities;
using DataGraph.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DataGraph.Data;

public class DataContext : DbContext, IDataContext
{
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Title> Titles { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
