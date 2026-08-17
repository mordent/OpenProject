using MySql.Data.MySqlClient;
using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ThiRA.Base.Infos;

public class DataTypeInfo
{
    private Type dataType;
    private TypeCode dataTypeCode;
    private DbType dbType;
    private SqlDbType sqlDbType;
    private MySqlDbType mySqlDbType;
    private OracleDbType oracleDbType;
    private NpgsqlDbType npgsqlDbType;

    public DataTypeInfo(Type dataType)
    {
        this.dataType = dataType;
        dataTypeCode = Type.GetTypeCode(dataType);
        dbType = DataType.TYPE_DB_TYPE_MAP[dataTypeCode];
        sqlDbType = DataType.MSSQL_TYPE_DB_TYPE_MAP[dataTypeCode];
        mySqlDbType = DataType.MYSQL_TYPE_DB_TYPE_MAP[dataTypeCode];
        oracleDbType = DataType.ORACLE_TYPE_DB_TYPE_MAP[dataTypeCode];
        npgsqlDbType = DataType.NPGSQL_TYPE_DB_TYPE_MAP[dataTypeCode];
    }

    public Type Type { get { return dataType; } }
    public TypeCode TypeCode { get { return dataTypeCode; } }
    public DbType DbType { get { return dbType; } }
    public SqlDbType SqlDbType { get { return sqlDbType; } }
    public MySqlDbType MySqlDbType { get { return mySqlDbType; } }
    public NpgsqlDbType NpgsqlDbType { get { return npgsqlDbType; } }
    public OracleDbType OracleDbType { get { return oracleDbType; } }
}
