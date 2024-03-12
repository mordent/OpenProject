using System.Data;
using System.Text;
using ThiRA.Base.DB;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Datatransfer.DataBase
{
    public static class SqlUtility
    {
        public static string GeTableListSQL(string str)
        {
            DbmsType dbmsType = DbManager.GetDbmsType(str);
            string sql = string.Empty;
            switch (dbmsType)
            {
                case DbmsType.MSSQL:
                case DbmsType.MySQL:
                    sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
                    break;
                case DbmsType.Oracle:
                    sql = "SELECT '0' IS_SELECT, USER OWNER, USER SCHEMA, TABLE_NAME FROM USER_TABLES ORDER BY USER, TABLE_NAME";
                    break;
                case DbmsType.PostgreSQL:
                    sql = "SELECT '0' IS_SELECT, TABLEOWNER OWNER, SCHEMANAME SCHEMA, TABLENAME TABLE_NAME FROM PG_TABLES WHERE TABLEOWNER = (SELECT CURRENT_USER) ORDER BY SCHEMANAME, TABLENAME";
                    break;
            }
            return sql;
        }

        public static string getColumnListSQL(string str)
        {
            DbmsType dbmsType = DbManager.GetDbmsType(str);
            string sql = string.Empty;
            switch (dbmsType)
            {
                case DbmsType.MSSQL:
                case DbmsType.MySQL:
                    sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
                    break;
                case DbmsType.Oracle:
                    sql = "SELECT COLUMN_ID, COLUMN_NAME, DATA_TYPE, DATA_LENGTH, DATA_DEFAULT FROM USER_TAB_COLUMNS WHERE UPPER(TABLE_NAME) = UPPER(:TABLE_NAME) ORDER BY COLUMN_ID";
                    break;
                case DbmsType.PostgreSQL:
                    sql = "SELECT ORDINAL_POSITION COLUMN_ID, COLUMN_NAME, DATA_TYPE, COALESCE(COALESCE(CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION),DATETIME_PRECISION) DATA_LENGTH, COLUMN_DEFAULT DATA_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS ISCLM INNER JOIN PG_TABLES PGT ON PGT.TABLEOWNER = (SELECT CURRENT_USER) AND UPPER(PGT.TABLENAME) = UPPER(@TABLE_NAME) AND ISCLM.TABLE_SCHEMA = PGT.SCHEMANAME AND ISCLM.TABLE_NAME  = PGT.TABLENAME ORDER BY ISCLM.ORDINAL_POSITION";
                    break;
            }
            return sql;
        }

        public static string GetSelectSql(string tableName, DataTable dataTable)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            bool first = true;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string columnName = StringUtility.ToString(dataRow["COLUMN_NAME"]);
                if (first)
                {
                    first = false;
                }
                else
                {
                    sql.Append(',');
                }
                sql.Append(columnName);
            }
            sql.Append(" FROM ").Append(tableName);

            return sql.ToString();
        }

        public static string GetInsertSql(string tableName, DataTable dataTable, DbManager dbManager)
        {
            switch (dbManager.DbmsType)
            {
                case DbmsType.PostgreSQL:
                case DbmsType.MSSQL:
                case DbmsType.MySQL:
                case DbmsType.Oracle:
                default:
                    return MakeInsertSql(tableName, dataTable, dbManager);
            }
        }

        public static string MakeInsertSql(string tableName, DataTable dataTable, DbManager dbManager)
        {

            StringBuilder sqlColumns = new StringBuilder();
            StringBuilder sqlValues = new StringBuilder();
            sqlColumns.Append("INSERT INTO ").Append(tableName).Append('(');
            sqlValues.Append(")VALUES(");
            bool first = true;
            bool combine = true;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                combine = true;
                string columnName = StringUtility.ToString(dataRow["COLUMN_NAME"]);
                string dataDefault = StringUtility.ToString(dataRow["DATA_DEFAULT"]);
                if (dataDefault.IndexOf("nextval", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    combine = false;
                }
                if (combine)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sqlColumns.Append(',');
                        sqlValues.Append(',');
                    }
                    sqlColumns.Append(columnName);
                    sqlValues.Append(dbManager.ParameterDelimiter).Append(columnName);
                }
            }
            sqlColumns.Append(sqlValues).Append(')');
            return sqlColumns.ToString();
        }
    }
}
