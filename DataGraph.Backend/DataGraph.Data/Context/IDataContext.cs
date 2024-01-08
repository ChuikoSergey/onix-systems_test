using DataGraph.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataGraph.Data.Context;

public interface IDataContext
{
    DbSet<Discount> Discounts { get; set; }
    DbSet<Sale> Sales { get; set; }
    DbSet<Store> Stores { get; set; }
    DbSet<Title> Titles { get; set; }
}
