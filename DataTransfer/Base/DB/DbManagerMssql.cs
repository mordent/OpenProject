using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Base.DB;

public class DbManagerMssql : DbManager
{
    internal DbManagerMssql(string connectionString) : base(DbmsType.MSSQL, connectionString){}

    protected override DbConnection GetDbConnection()
    {
        return new SqlConnection(connectionString);
    }

    protected override DbParameter GetDbParameter(string columnName, DbType dbType)
    {
        return new SqlParameter(columnName, dbType);
    }

    protected override ulong DmlBulk(string sql, DataTable dataTable)
    {
        ulong affect = 0;
        try
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy((SqlConnection)dbConnection))
            {
                sqlBulkCopy.DestinationTableName = sql;
                sqlBulkCopy.BatchSize = dataTable.Rows.Count;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
                }
                sqlBulkCopy.WriteToServer(dataTable);
                affect = (ulong)dataTable.Rows.Count;
            }
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
        DataTable dataTable = DataUtility.ToDataTable(list);
        try
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy((SqlConnection)dbConnection))
            {
                sqlBulkCopy.DestinationTableName = sql;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
                }
                sqlBulkCopy.WriteToServer(dataTable);
                affect = (ulong)dataTable.Rows.Count;
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return affect;
    }
}