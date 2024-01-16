namespace DataGraph.Core.Services.DataScheme;

public interface IDataSchemaService
{
    Task<Models.DataScheme.DTOs.DataScheme> GetDataSchemeAsync(string connectionString);
}
