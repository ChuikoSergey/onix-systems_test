using Microsoft.EntityFrameworkCore.Metadata;

namespace DataGraph.Core;

public interface IDataSchemeProvider
{
    List<IEntityType> GetEntities();
}
