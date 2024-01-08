using DataGraph.Core;
using DataGraph.Core.Models.DataScheme;
using DataGraph.Core.Services.DataScheme;

namespace DataGraph.Domain.Services.DataScheme;

public class DataSchemeService : IDataSchemaService
{
    private readonly IDataSchemeProvider _dataSchemeProvider;

    public DataSchemeService(IDataSchemeProvider dataSchemeProvider)
    {
        _dataSchemeProvider = dataSchemeProvider;
    }

    public Core.Models.DataScheme.DataScheme GetDataScheme()
    {
        var result = new Core.Models.DataScheme.DataScheme();
        var entities = _dataSchemeProvider.GetEntities();
        foreach (var entity in entities)
        {
            var foreignKeys = entity.GetForeignKeys();
            var node = new DataSchemeNode
            {
                Name = entity.Name.Split('.').LastOrDefault(),
                PrimaryKeyName = entity.FindPrimaryKey()?.Properties.FirstOrDefault()?.Name,
                ForeignKeyFields = foreignKeys.SelectMany(fk => fk.Properties.Select(p => p.Name)).ToList()
            };

            var branches = foreignKeys
                .Select(fk => new DataSchemeBranch
                {
                    FromNode = fk.DeclaringEntityType.Name.Split('.').LastOrDefault(),
                    ToNode = fk.PrincipalEntityType.Name.Split('.').LastOrDefault()
                });

            result.Nodes.Add(node);

            if (branches.Any())
            {
                result.Branches.AddRange(branches);
            }
        }

        return result;
    }
}
