namespace DataGraph.Data.Queries;

public class DataSchemeQueries
{
    public static string GetForeignKeysSqlQuery { get; } =
    @"
    SELECT fk_tab.name as foreign_table,
        pk_tab.name as primary_table,
        fk_col.name as fk_column_name,
        pk_col.name as pk_column_name
    FROM sys.foreign_keys fk
        JOIN sys.tables fk_tab
            on fk_tab.object_id = fk.parent_object_id
        JOIN sys.tables pk_tab
            on pk_tab.object_id = fk.referenced_object_id
        JOIN sys.foreign_key_columns fk_cols
            ON fk_cols.constraint_object_id = fk.object_id
        JOIN sys.columns fk_col
            ON fk_col.column_id = fk_cols.parent_column_id
            AND fk_col.object_id = fk_tab.object_id
        JOIN sys.columns pk_col
            ON pk_col.column_id = fk_cols.referenced_column_id
            AND pk_col.object_id = pk_tab.object_id
    ORDER BY fk_tab.name,
        pk_tab.name, 
        fk_cols.constraint_column_id";

    public static string GetPrimaryKeysSqlQuery { get; } =
    @"
    SELECT 
        tables.name as table_name,
        columns.name as column_name
    FROM sys.key_constraints key_cons
        JOIN sys.tables tables
            ON key_cons.parent_object_id = tables.object_id
        JOIN sys.index_columns id_col
            ON key_cons.parent_object_id = id_col.object_id
            AND key_cons.unique_index_id = id_col.index_id
        JOIN sys.columns columns
            ON id_col.object_id = columns.object_id
            AND id_col.index_column_id = columns.column_id";

    public static string GetTablesNamesSqlQuery { get; } = 
    @"SELECT name FROM sys.tables";
}
