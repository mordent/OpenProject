using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Base.DB;

public class DbManagerMysql : DbManager
{
    internal DbManagerMysql(string connectionString) : base(DbmsType.MySQL, connectionString) { }

    protected override DbConnection GetDbConnection()
    {
        return new MySqlConnection(connectionString);
    }

    protected override DbParameter GetDbParameter(string columnName, DbType dbType)
    {
        return new MySqlParameter(columnName, dbType);
    }

    protected override ulong DmlBulk(string sql, DataTable dataTable)
    {
        ulong affect = 0;
        try
        {
            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, (MySqlConnection)dbConnection))
            {
                using(MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter))
                {
                    mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                    affect = (ulong)mySqlDataAdapter.Update(dataTable);
                }
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
            DataTable dataTable = DataUtility.ToDataTable(list);
            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, (MySqlConnection)dbConnection))
            {
                using (MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter))
                {
                    mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
                    affect = (ulong)mySqlDataAdapter.Update(dataTable);
                }
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