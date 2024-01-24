using System.Data;
using DataGraph.Core;
using DataGraph.Core.Extensions;
using DataGraph.Core.Models.DataScheme.DTOs;
using DataGraph.Data.Queries;
using Microsoft.Data.SqlClient;

namespace DataGraph.Data;

public class DataSchemeProvider : IDataSchemeProvider
{

    public async Task<DataScheme> GetEntitiesSchemeAsync(string connectionString)
    {
        var result = new DataScheme();
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var schema = await connection.GetSchemaAsync("IndexColumns");
            using var getTablesSqlCommand = new SqlCommand(DataSchemeQueries.GetTablesNamesSqlQuery, connection);
            using var getPrimaryKeysSqlCommand = new SqlCommand(DataSchemeQueries.GetPrimaryKeysSqlQuery, connection);
            using var getForeignKeysSqlCommand = new SqlCommand(DataSchemeQueries.GetForeignKeysSqlQuery, connection);


            using var tablesReader = await getTablesSqlCommand.ExecuteReaderAsync();

            var tables = GetDataFromReaderAndCloseIt(tablesReader, r => new
            {
                Name = r["name"].ToString()!
            });

            using var primaryKeysReader = await getPrimaryKeysSqlCommand.ExecuteReaderAsync();

            var groupedPrimaryKeys = GetDataFromReaderAndCloseIt(primaryKeysReader, r => new
            {
                TableName = r["table_name"].ToString()!,
                PrimaryColumnName = r["column_name"].ToString()!
            }).GroupBy(x => x.TableName);

            using var foreignKeysReader = await getForeignKeysSqlCommand.ExecuteReaderAsync();

            var groupedForeignKeys = GetDataFromReaderAndCloseIt(foreignKeysReader, r => new
            {
                ForeignTable = r["foreign_table"].ToString()!,
                PrimaryTable = r["primary_table"].ToString()!,
                ColumnName = r["fk_column_name"].ToString()!
            }).GroupBy(x => x.ForeignTable);

            if (tables.Any())
            {
                result.Nodes = tables.Select(t =>
                {
                    var node = new DataSchemeNode
                    {
                        Name = t.Name
                    };
                    node.PrimaryKeyFields = groupedPrimaryKeys.FirstOrDefault(g => g.Key == node.Name)?.Select(g => g.PrimaryColumnName).ToList() ?? new List<string>();
                    node.ForeignKeyFields = groupedForeignKeys.FirstOrDefault(g => g.Key == node.Name)?.Select(g => g.ColumnName).ToList() ?? new List<string>();

                    return node;
                }).ToList();

                result.Branches = groupedForeignKeys.SelectMany(g => g.Select(x => new DataSchemeBranch
                {
                    FromNode = x.ForeignTable,
                    ToNode = x.PrimaryTable
                })).ToList();
            }
        }
        return result;
    }


    private List<T> GetDataFromReaderAndCloseIt<T>(IDataReader reader, Func<IDataReader, T> projection)
    {
        try
        {
            return reader.Select(projection).ToList();
        }
        finally
        {
            reader.Close();
        }
    }
}
