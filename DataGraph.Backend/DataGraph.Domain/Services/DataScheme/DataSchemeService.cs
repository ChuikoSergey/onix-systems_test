using DataGraph.Core;
using DataGraph.Core.Services.DataScheme;

namespace DataGraph.Domain.Services.DataScheme;

public class DataSchemeService : IDataSchemaService
{
    private readonly IDataSchemeProvider _dataSchemeProvider;

    public DataSchemeService(IDataSchemeProvider dataSchemeProvider)
    {
        _dataSchemeProvider = dataSchemeProvider;
    }

    public Task<Core.Models.DataScheme.DTOs.DataScheme> GetDataSchemeAsync(string connectionString)
    {
        return _dataSchemeProvider.GetEntitiesSchemeAsync(connectionString);
    }
}
