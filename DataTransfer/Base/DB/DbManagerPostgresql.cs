using Npgsql;
using System.Data;
using System.Data.Common;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Base.DB;

public class DbManagerPostgresql : DbManager
{
    internal DbManagerPostgresql(string connectionString) : base(DbmsType.PostgreSQL, connectionString) { }

    protected override DbConnection GetDbConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

    protected override DbParameter GetDbParameter(string columnName, DbType dbType)
    {
        return new NpgsqlParameter(columnName, dbType);
    }

    protected override ulong DmlBulk(string sql, DataTable dataTable)
    {
        ulong affect = 0;
        try
        {
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(dataTable);
            NpgsqlBinaryImporter importer = ((NpgsqlConnection)dbConnection).BeginBinaryImport(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                importer.StartRow();
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    if (dataRow[dataColumn] == DBNull.Value)
                    {
                        importer.WriteNull();
                    }
                    else
                    {
                        if (typeDictionary.ContainsKey(dataColumn.ColumnName))
                        {
                            importer.Write(dataRow[dataColumn], typeDictionary[dataColumn.ColumnName].NpgsqlDbType);
                        }
                        else
                        {
                            importer.Write(dataRow[dataColumn]);
                        }
                    }
                }
            }
            affect = importer.Complete();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return affect;
    }

    protected override ulong DmlBulk(string sql, List<Dictionary<string, object>> list)
    {
        ulong affect = 0;
        try
        {
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(list);
            NpgsqlBinaryImporter importer = ((NpgsqlConnection)dbConnection).BeginBinaryImport(sql);
            foreach (Dictionary<string, object> dictionary in list)
            {
                importer.StartRow();
                foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                {
                    if (keyValuePair.Value == DBNull.Value)
                    {
                        importer.WriteNull();
                    }
                    else
                    {
                        if (typeDictionary.ContainsKey(keyValuePair.Key))
                        {
                            importer.Write(keyValuePair.Value, typeDictionary[keyValuePair.Key].NpgsqlDbType);
                        }
                        else
                        {
                            importer.Write(keyValuePair.Value);
                        }
                    }
                }
            }
            affect = importer.Complete();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return affect;
    }
}