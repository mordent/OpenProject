using Microsoft.Extensions.Primitives;
using System.Data;
using System.Text;
using System.Xml;
using ThiRA.Base.Infos;

namespace ThiRA.Base.Util
{
    public static class DataUtility
    {
        public static string GetParameterDelimiter(DbmsType dataBaseType)
        {
            switch (dataBaseType)
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
        public static DataTable AddRow(DataTable dataTable, Dictionary<string, object> dictionary, bool distinct, int limit)
        {
            dataTable = AddRow(dataTable, dictionary);
            if (distinct)
            {
                DataView view = dataTable.DefaultView;
                dataTable = view.ToTable(true, ClassUtility.ToArray(dictionary.Keys));
            }
            if (limit > 0)
            {
                while(dataTable.Rows.Count > limit)
                {
                    dataTable.Rows.RemoveAt(0);
                }
                dataTable.AcceptChanges();
            }
            return dataTable;
        }

        public static DataTable AddRow(DataTable dataTable, Dictionary<string, object> dictionary)
        {
            if (dataTable == null)
            {
                dataTable = new DataTable();
            }
            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                if (!dataTable.Columns.Contains(entry.Key))
                {
                    dataTable.Columns.Add(entry.Key);
                }
            }
            DataRow dataRow = dataTable.NewRow();
            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                dataRow[entry.Key] = entry.Value;
            }
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }

        public static bool Contains(List<Dictionary<string, object>> list, string columnName)
        {
            foreach (Dictionary<string, object> dictionary in list)
            {
                if (dictionary.ContainsKey(columnName))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ToString(DataRow dataRow)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn dataColumn  in dataRow.Table.Columns)
            {
                sb.AppendLine(dataColumn.ColumnName + "=" + dataRow[dataColumn.ColumnName]);
            }
            return sb.ToString();
        }

        public static string ToString(DataRow dataRow, string columnName)
        {
            if (!dataRow.Table.Columns.Contains(columnName))
            {
                return string.Empty;
            }
            if (dataRow[columnName] is string)
            {
                return (string)dataRow[columnName];
            }
            string? result = dataRow.ToString();
            return String.IsNullOrEmpty(result) ? string.Empty : result;
        }

        public static object[] ToArray(DataTable dataTable, string columnName)
        {
            object[] objects = new object[dataTable.Rows.Count];
            if (!dataTable.Columns.Contains(columnName))
            {
                return objects;
            }
            int index = 0;
            foreach(DataRow dataRow in dataTable.Rows)
            {
                objects[index] = dataRow[columnName];
                index++;
            }
            return objects;
        }

        public static object[] ToArray(List<Dictionary<string, object>> list, string columnName)
        {
            object[] objects = new object[list.Count];
            if (!Contains(list, columnName))
            {
                return objects;
            }
            int index = 0;
            foreach (Dictionary<string, object> dictionary in list)
            {
                objects[index] = dictionary[columnName];
                index++;
            }
            return objects;
        }

        public static object[] ToArray(DataRow dataRow)
        {
            object[] objects = new object[dataRow.Table.Columns.Count];
            for(int index = 0; dataRow.Table.Columns.Count > index; index++)
            {
                objects[index] = dataRow[index];
            }
            return objects;
        }

        public static Dictionary<string, object> ToDictionary(DataRow dataRow)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            if (dataRow.Table.Columns.Count <= 0)
            {
                return dictionary;
            }
            foreach (DataColumn dataColumn in dataRow.Table.Columns)
            {
                dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
            }
            return dictionary;
        }

        public static List<Dictionary<string, object>> ToListDictionary(DataTable dataTable)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (dataTable == null || dataTable.Columns.Count <= 0 || dataTable.Rows.Count <= 0)
            {
                return list;
            }
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                }
                list.Add(dictionary);
            }
            return list;
        }

        public static List<string> ToList(DataRow[] dataRows, string columnName)
        {
            List<string> list = new List<string>();
            if (dataRows == null || dataRows.Length <= 0 || dataRows[0].Table.Columns.Count <= 0 || !dataRows[0].Table.Columns.Contains(columnName))
            {
                return list;
            }
            foreach (DataRow dataRow in dataRows)
            {
                list.Add(ToString(dataRow, columnName));
            }
            return list;
        }

        public static List<string> ToList(DataRow[] dataRows, string delemiter=",", params string[] columnNames)
        {
            List<string> list = new List<string>();
            if (dataRows == null || dataRows.Length <= 0 || dataRows[0].Table.Columns.Count <= 0)
            {
                return list;
            }
            bool isContain = false;
            foreach (string columnName in columnNames)
            {
                if (dataRows[0].Table.Columns.Contains(columnName))
                {
                    isContain = true;
                    break;
                }
            }
            if (!isContain)
            {
                return list;
            }
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dataRow in dataRows)
            {
                sb.Clear();
                foreach (string columnName in columnNames)
                {
                    if(sb.Length > 0)
                    {
                        sb.Append(delemiter).Append(ToString(dataRow, columnName));
                    }
                    else
                    {
                        sb.Append(ToString(dataRow, columnName));
                    }
                }
                list.Add(sb.ToString());
            }
            return list;
        }

        public static List<Dictionary<string, object>> ToListDictionary(DataRow[] dataRows)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (dataRows == null || dataRows.Length <= 0 || dataRows[0].Table.Columns.Count <= 0)
            {
                return list;
            }
            foreach (DataRow dataRow in dataRows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                }
                list.Add(dictionary);
            }
            return list;
        }

        public static DataTable ToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable dataTable = new DataTable();
            foreach(Dictionary<string, object> dictionary in list)
            {
                AddRow(dataTable, dictionary);
            }
            return dataTable;
        }

        public static Dictionary<string, DataTypeInfo> GetDataType(DataTable dataTable){
            Dictionary<string, DataTypeInfo> dictionary = new Dictionary<string, DataTypeInfo>();
            Dictionary<string, bool> matchDictionary = new Dictionary<string, bool>();
            foreach(DataColumn dataColumn in dataTable.Columns)
            {
                dictionary.Add(dataColumn.ColumnName, DataType.GetDataTypeInfo(dataColumn.DataType));
            }
            return dictionary;
        }

        public static Dictionary<string, DataTypeInfo> GetDataType(List<Dictionary<string, object>> list)
        {
            Dictionary<string, DataTypeInfo> dictionary = new Dictionary<string, DataTypeInfo>();
            Dictionary<string, bool> matchDictionary = new Dictionary<string, bool>();
            foreach (String key in dictionary.Keys)
            {
                matchDictionary.Add(key, false);
            }
            foreach (Dictionary<string, object> dataDictionary in list)
            {
                foreach (KeyValuePair<string, object> keyValuePair in dataDictionary)
                {
                    string columnName = keyValuePair.Key;
                    if (dictionary.ContainsKey(columnName) || keyValuePair.Value == DBNull.Value)
                    {
                        continue;
                    }
                    dictionary.Add(columnName, DataType.GetDataTypeInfo(keyValuePair.Value.GetType()));
                    matchDictionary[columnName] = true;
                    if (dictionary.Count == dataDictionary.Count)
                    {
                        break;
                    }
                }
            }
            foreach (KeyValuePair<string, bool> keyValuePair in matchDictionary)
            {
                if (!keyValuePair.Value)
                {
                    dictionary.Add(keyValuePair.Key, DataType.GetDataTypeInfo(typeof(string)));
                }
            }
            return dictionary;
        }
    }
}
