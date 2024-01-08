using DataGraph.Core;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataGraph.Data;

public class DataSchemeProvider : IDataSchemeProvider
{
    private readonly DataContext _context;

    public DataSchemeProvider(DataContext context)
    {
        _context = context;
    }

    public List<IEntityType> GetEntities() => _context.Model.GetEntityTypes().ToList();
}
