using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using static System.Text.Json.JsonElement;

namespace ThiRA.Base.Util
{
    public static class MessageUtility
    {
        public static string ToJson(DataTable dataTable)
        {
            List<Dictionary<string, object>> list = DataUtility.ToListDictionary(dataTable);
            return JsonSerializer.Serialize(list);
        }

        public static DataTable JsonToDataTable(string message)
        {
            List<Dictionary<string, object>> list = JsonToListDictionary(message);
            return DataUtility.ToDataTable(list);
        }

        public static List<Dictionary<string, object>> JsonToListDictionary(string message)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try {
                JsonDocument jsonDocument = JsonDocument.Parse(message);
                switch (jsonDocument.RootElement.ValueKind)
                {
                    case JsonValueKind.Array:
                        list = ToListDictionary(jsonDocument.RootElement);
                        break;
                    default:
                        LogUtility.Logger(typeof(MessageUtility)).Debug("ValueType MisMatch:[{0}]:[{1}]", jsonDocument.RootElement.ValueKind, jsonDocument.RootElement.GetRawText());
                        break;
                }
            }
            catch (Exception e)
            {
                LogUtility.Logger(typeof(MessageUtility)).Error(e);
            }
            return list;
        }

        public static List<Dictionary<string, object>> ToListDictionary(JsonElement jsonElement)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (jsonElement.ValueKind == JsonValueKind.Array)
            {
                ArrayEnumerator arrayEnumerator = jsonElement.EnumerateArray();
                while (arrayEnumerator.MoveNext())
                {
                    JsonElement childJsonElement = arrayEnumerator.Current;
                    switch (childJsonElement.ValueKind)
                    {
                        case JsonValueKind.Object:
                            list.Add(ToDictionary(childJsonElement));
                            break;
                        default:
                            LogUtility.Logger(typeof(MessageUtility)).Debug("ValueType MisMatch:[{0}]:[{1}]", childJsonElement.ValueKind, childJsonElement.GetRawText());
                            break;
                    }
                }
            }
            return list;
        }

        public static List<object> ToList(JsonElement jsonElement)
        {
            List<object> list = new List<object>();
            if (jsonElement.ValueKind == JsonValueKind.Array)
            {
                ArrayEnumerator arrayEnumerator = jsonElement.EnumerateArray();
                while (arrayEnumerator.MoveNext())
                {
                    JsonElement childJsonElement = arrayEnumerator.Current;
                    switch (childJsonElement.ValueKind)
                    {
                        case JsonValueKind.Array:
                            list.Add(ToList(childJsonElement));
                            break;
                        case JsonValueKind.Object:
                            list.Add(ToDictionary(childJsonElement));
                            break;
                        default:
                            list.Add(StringUtility.nvl(childJsonElement.GetString()));
                            break;
                    }
                }
            }
            return list;
        }

        private static Dictionary<string, object> ToDictionary(JsonElement jsonElement)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            if (jsonElement.ValueKind == JsonValueKind.Object)
            {
                ObjectEnumerator objectEnumerator = jsonElement.EnumerateObject();
                while (objectEnumerator.MoveNext())
                {
                    JsonProperty jsonProperty = objectEnumerator.Current;
                    switch (jsonProperty.Value.ValueKind)
                    {
                        case JsonValueKind.Array:
                            dictionary.Add(jsonProperty.Name, ToList(jsonProperty.Value));
                            break;
                        case JsonValueKind.Object:
                            dictionary.Add(jsonProperty.Name, ToDictionary(jsonProperty.Value));
                            break;
                        default:
                            dictionary.Add(jsonProperty.Name, StringUtility.nvl(jsonProperty.Value.GetString()));
                            break;
                    }
                }
            }
            return dictionary;
        }
    }
}

