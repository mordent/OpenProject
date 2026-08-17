using System.Data;
using System.Data.Common;
using ThiRA.Base.Infos;
using ThiRA.Base.Log;
using ThiRA.Base.Util;

namespace ThiRA.Base.DB;

public abstract class DbManager : BaseLog, IDisposable
{
    private static readonly Dictionary<string, object> EMPTY_PARAMETERS = new Dictionary<string, object>();

    private bool isConnect = false;
    private DmlType dmlType = DmlType.Batch;
    private DbmsType dbmsType = DbmsType.MSSQL;
    protected string connectionString;
    protected DbConnection dbConnection;
    protected DbTransaction? dbTransaction;
    public bool IsConnect
    {
        get { return isConnect; }
    }

    protected abstract DbConnection GetDbConnection();
    protected abstract DbParameter GetDbParameter(string columnName, DbType dbType);
    protected abstract ulong DmlBulk(string sql, DataTable dataTable);
    protected abstract ulong DmlBulk(string sql, List<Dictionary<string, object>> list);

    protected DbManager(DbmsType dbmsType, string connectionString)
    {
        this.dbmsType = dbmsType;
        this.connectionString = connectionString;
        this.dbConnection = GetDbConnection();
        dbConnection.Open();
    }

    public static DbManager GetManager(DbmsType dbmsType, string connectionString)
    {
        switch (dbmsType)
        {
            case DbmsType.MSSQL: default: return new DbManagerMssql(connectionString);
            case DbmsType.MySQL: return new DbManagerMysql(connectionString);
            case DbmsType.Oracle: return new DbManagerOracle(connectionString);
            case DbmsType.PostgreSQL: return new DbManagerPostgresql(connectionString);
        }
    }

    public static DmlType GetDmlType(string str)
    {
        if (str.Equals(DmlType.Loop.ToString(), StringComparison.OrdinalIgnoreCase)) { return DmlType.Loop; }
        if (str.Equals(DmlType.Reuse.ToString(), StringComparison.OrdinalIgnoreCase)) { return DmlType.Reuse; }
        if (str.Equals(DmlType.Batch.ToString(), StringComparison.OrdinalIgnoreCase)) { return DmlType.Batch; }
        //if (str.Equals(DmlType.Bulk.ToString(), StringComparison.OrdinalIgnoreCase)) { return DmlType.Bulk; }
        return DmlType.Loop;
    }
    public static DbmsType GetDbmsType(string str)
    {
        if (str.Equals(DbmsType.Oracle.ToString(), StringComparison.OrdinalIgnoreCase)) { return DbmsType.Oracle; }
        if (str.Equals(DbmsType.MySQL.ToString(), StringComparison.OrdinalIgnoreCase)) { return DbmsType.MySQL; }
        if (str.Equals(DbmsType.PostgreSQL.ToString(), StringComparison.OrdinalIgnoreCase)){ return DbmsType.PostgreSQL; }
        return DbmsType.MSSQL;
    }
    public string ParameterDelimiter
    {
        get
        {
            switch (dbmsType)
            {
                case DbmsType.Oracle:
                    return ":";
                case DbmsType.MSSQL:
                case DbmsType.MySQL:
                case DbmsType.PostgreSQL:
                default:
                    return "@";
            }
        }
    }

    public DbmsType DbmsType
    {
        get
        {
            return dbmsType;
        }
    }

    public DmlType DmlType
    {
        get
        {
            return dmlType;
        }
    }
    

    public DbConnection DbConnection
    {
        get
        {
            return dbConnection;
        }
    }

    private void BeginTransactin()
    {
        if(dbTransaction == null)
        {
            dbTransaction = dbConnection.BeginTransaction();
        }
    }

    public void Commit()
    {
        if(dbTransaction != null)
        {
            dbTransaction.Commit();
            dbTransaction.Dispose();
            dbTransaction = null;
        }
    }

    public void Rollback()
    {
        if (dbTransaction != null)
        {
            dbTransaction.Rollback();
            dbTransaction.Dispose();
            dbTransaction = null;
        }
    }

    public DataTable GetSchema()
    {
        return dbConnection.GetSchema("Tables");
    }

    public DataTable SelectDataTable(string sql, int startIndex = 0, int endIndex = 0)
    {
        return SelectDataTable(sql, EMPTY_PARAMETERS, startIndex, endIndex);
    }

    public DataTable SelectDataTable(string sql, Dictionary<string, object> parameters, int startIndex=0,int endIndex=0)
    {
        DataTable dataTable = new DataTable();
        using (DbCommand dbCommand = dbConnection.CreateCommand())
        {
            logSql(sql);
            dbCommand.CommandText = sql;
            dbCommand.CommandType = CommandType.Text;
            if (parameters != null && parameters.Count > 0)
            {
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = keyValuePair.Key;
                    dbParameter.Value = keyValuePair.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
            }
            using (DbDataReader dBDataReader = dbCommand.ExecuteReader())
            {
                if (startIndex <= 0 && endIndex <= 0)
                {
                    dataTable.Load(dBDataReader);
                }
                else
                {
                    foreach (DbColumn dbColumn in dBDataReader.GetColumnSchema())
                    {
                        dataTable.Columns.Add(new DataColumn(dbColumn.ColumnName, dbColumn.DataType == null ? typeof(string) : dbColumn.DataType));
                    }
                    if (dBDataReader.HasRows)
                    {
                        int index = 1;
                        foreach (DbDataRecord dbDataRecord in dBDataReader)
                        {
                            if (startIndex <= index)
                            {
                                DataRow dataRow = dataTable.NewRow();
                                foreach (DataColumn dataColumn in dataTable.Columns)
                                {
                                    dataRow[dataColumn.Ordinal] = dbDataRecord.GetValue(dataColumn.Ordinal);
                                }
                                dataTable.Rows.Add(dataRow);
                            }
                            if (endIndex <= index)
                            {
                                break;
                            }
                            index++;
                        }
                    }
                }
            }
            return dataTable;
        }
    }

    public void Dispose()
    {
        dbConnection.Dispose();
        isConnect = false;
    }

    public ulong Insert(string sql, DataRow dataRow)
    {
        return Dml(sql, dataRow);
    }
    public ulong Insert(string sql, Dictionary<string, object> parameters)
    {
        return Dml(sql, parameters);
    }
    public ulong Insert(string sql, DataTable dataTable)
    {
        switch (DmlType)
        {
            case DmlType.Loop: default: return DmlLoop(sql, dataTable);
            case DmlType.Reuse: return DmlReuse(sql, dataTable);
            case DmlType.Batch: return DmlBatch(sql, dataTable);
            case DmlType.Bulk: return DmlBulk(sql, dataTable);
        }
    }
    public ulong Insert(string sql, List<Dictionary<string, object>> list, DataTable? columnDataTable=null)
    {
        switch (DmlType)
        {
            case DmlType.Loop: default: return DmlLoop(sql, list);
            case DmlType.Reuse: return DmlReuse(sql, list);
            case DmlType.Batch: return DmlBatch(sql, list);
            case DmlType.Bulk: return DmlBulk(sql, list);
        }
    }

    private ulong Dml(string sql, Dictionary<string, object> parameters)
    {
        if(parameters.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                logSql(sql);
                dbCommand.CommandText = sql;
                dbCommand.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = keyValuePair.Key;
                    dbParameter.Value = keyValuePair.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
                affect = dbCommand.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }
    private ulong Dml(string sql, DataRow dataRow)
    {
        if (dataRow.Table.Columns.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                logSql(sql);
                dbCommand.CommandText = sql;
                dbCommand.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> keyValuePair in dataRow.Table.Columns)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = keyValuePair.Key;
                    dbParameter.Value = keyValuePair.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
                affect= dbCommand.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);    
    }
    private ulong DmlLoop(string sql, DataTable dataTable)
    {
        if (dataTable.Rows.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    logSql(sql);
                    dbCommand.CommandText = sql;
                    dbCommand.CommandType = CommandType.Text;
                    foreach (DataColumn dataColumn in dataRow.Table.Columns)
                    {
                        DbParameter dbParameter = dbCommand.CreateParameter();
                        dbParameter.ParameterName = dataColumn.ColumnName;
                        dbParameter.DbType = typeDictionary[dataColumn.ColumnName].DbType;
                        dbParameter.Value = dataRow[dataColumn];
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    affect += dbCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }
    private ulong DmlLoop(string sql, List<Dictionary<string,object>> list)
    {
        if (list.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(list);
            foreach (Dictionary<string, object> dictionary in list)
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    logSql(sql);
                    dbCommand.CommandText = sql;
                    dbCommand.CommandType = CommandType.Text;
                    foreach (KeyValuePair<string,object> keyValuePair in dictionary)
                    {
                        DbParameter dbParameter = dbCommand.CreateParameter();
                        dbParameter.ParameterName = keyValuePair.Key;
                        dbParameter.DbType = typeDictionary[keyValuePair.Key].DbType;
                        dbParameter.Value = keyValuePair.Value;
                        dbCommand.Parameters.Add(dbParameter);
                    }
                    affect += dbCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }

    private ulong DmlReuse(string sql, DataTable dataTable)
    {
        if (dataTable.Rows.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(dataTable);
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                logSql(sql);
                dbCommand.CommandText = sql;
                dbCommand.CommandType = CommandType.Text;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = dataColumn.ColumnName;
                    dbParameter.DbType = typeDictionary[dataColumn.ColumnName].DbType;
                    dbCommand.Parameters.Add(dbParameter);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        dbCommand.Parameters[dataColumn.ColumnName].Value = dataRow[dataColumn];
                    }
                    affect += dbCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }
    private ulong DmlReuse(string sql, List<Dictionary<string, object>> list)
    {
        if (list.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(list);
            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                logSql(sql);
                dbCommand.CommandText = sql;
                dbCommand.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, DataTypeInfo> keyValuePair in typeDictionary)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = keyValuePair.Key;
                    dbParameter.DbType = keyValuePair.Value.DbType;
                    dbCommand.Parameters.Add(dbParameter);
                }
                foreach (Dictionary<string, object> dictionary in list)
                {
                    foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                    {
                        dbCommand.Parameters[keyValuePair.Key].Value = keyValuePair.Value;
                    }
                    affect += dbCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }
    private ulong DmlBatch(string sql, DataTable dataTable)
    {
        if (dataTable.Rows.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(dataTable);
            using (DbBatch dbBatch = dbConnection.CreateBatch())
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    DbBatchCommand dbBatchCommand = dbBatch.CreateBatchCommand();
                    logSql(sql);
                    dbBatchCommand.CommandText = sql;
                    dbBatchCommand.CommandType = CommandType.Text;
                    foreach (DataColumn dataColumn in dataRow.Table.Columns)
                    {
                        DbParameter dbParameter = GetDbParameter(dataColumn.ColumnName, typeDictionary.ContainsKey(dataColumn.ColumnName) ? typeDictionary[dataColumn.ColumnName].DbType : DbType.String);
                        dbParameter.Value = dataRow[dataColumn];
                        dbBatchCommand.Parameters.Add(dbParameter);
                    }
                    dbBatch.BatchCommands.Add(dbBatchCommand);
                }
                affect = dbBatch.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }
    private ulong DmlBatch(string sql, List<Dictionary<string, object>> list)
    {
        if (list.Count <= 0)
        {
            return 0;
        }
        int affect = 0;
        try
        {
            BeginTransactin();
            Dictionary<string, DataTypeInfo> typeDictionary = DataUtility.GetDataType(list);
            using (DbBatch dbBatch = dbConnection.CreateBatch())
            {
                foreach (Dictionary<string, object> dictionary in list)
                {
                    DbBatchCommand dbBatchCommand = dbBatch.CreateBatchCommand();
                    logSql(sql);
                    dbBatchCommand.CommandText = sql;
                    dbBatchCommand.CommandType = CommandType.Text;
                    foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                    {
                        DbParameter dbParameter = GetDbParameter(keyValuePair.Key, typeDictionary[keyValuePair.Key].DbType);
                        dbBatchCommand.Parameters.Add(dbParameter);
                        dbBatchCommand.Parameters[keyValuePair.Key].Value = keyValuePair.Value;
                    }
                    dbBatch.BatchCommands.Add(dbBatchCommand);
                }
                affect = dbBatch.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            throw;
        }
        return Convert.ToUInt64(affect);
    }

    private void logSql(string sql)
    {
        //logger.Debug("[SQL][{0}]",sql);
    }
}