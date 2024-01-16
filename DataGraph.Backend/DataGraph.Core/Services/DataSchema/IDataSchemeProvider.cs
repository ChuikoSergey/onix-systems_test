using DataGraph.Core.Models.DataScheme.DTOs;

namespace DataGraph.Core;

public interface IDataSchemeProvider
{
    Task<DataScheme> GetEntitiesSchemeAsync(string connectionString);
}
