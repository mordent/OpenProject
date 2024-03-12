using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Base.DB;

public class DbManagerOracle : DbManager
{
    internal DbManagerOracle(string connectionString) : base(DbmsType.Oracle, connectionString) { }

    protected override DbConnection GetDbConnection()
    {
        return new OracleConnection(connectionString);
    }

    protected override DbParameter GetDbParameter(string columnName, DbType dbType)
    {
        return new OracleParameter(columnName, dbType);
    }
    protected override ulong DmlBulk(string sql, DataTable dataTable)
    {
        ulong affect = 0;
        try
        {
            using (OracleCommand oracleCommand = new OracleCommand(sql, (OracleConnection)dbConnection))
            {
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.BindByName = true;
                oracleCommand.ArrayBindCount = dataTable.Rows.Count;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    OracleParameter oracleParameter = new OracleParameter(dataColumn.ColumnName, dataColumn.DataType);
                    oracleParameter.Value = DataUtility.ToArray(dataTable, dataColumn.ColumnName);
                    oracleCommand.Parameters.Add(oracleParameter);
                }
                affect = (ulong)oracleCommand.ExecuteNonQuery();
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
        try
        {
            Dictionary<string, DataTypeInfo> typeDictionary =  DataUtility.GetDataType(list);
            using (OracleCommand oracleCommand = new OracleCommand(sql, (OracleConnection)dbConnection))
            {
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.BindByName = true;
                oracleCommand.ArrayBindCount = list.Count;
                foreach (KeyValuePair<string, DataTypeInfo> keyValuePair in typeDictionary)
                {
                    OracleParameter oracleParameter = new OracleParameter(keyValuePair.Key, keyValuePair.Value.DbType);
                    oracleParameter.Value = DataUtility.ToArray(list, keyValuePair.Key);
                    oracleCommand.Parameters.Add(oracleParameter);
                }
                affect = (ulong)oracleCommand.ExecuteNonQuery();
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