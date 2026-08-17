using System.Text;

namespace ThiRA.Base.Util
{
    public static class StringUtility
    {
        private const int COUNTER_MAX = 1000;
        private static int counter = 0;

        public static string Guid()
        {
            Interlocked.CompareExchange(ref counter, 0, COUNTER_MAX);
            return DateTime.Now.ToString("yyyyyMMddHHmmssfff") + Interlocked.Increment(ref counter);
        }

        public static long CurrentTimeMils
        {
            get { return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); }
        }

        public static string nvl(string? str, string nullValue="")
        {
            return string.IsNullOrEmpty(str) ? nullValue : str;
        }

        public static string ToString(object? obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            else if (obj is string)
            {
                return (string)obj;
            }
            else
            {
                return nvl(obj.ToString());
            }
        }

        public static string ToString(Dictionary<string, object> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<string, object> pair in dictionary)
            {
                sb.AppendLine(pair.Key + "=" + pair.Value);
            }
            return sb.ToString();
        }

        public static List<string> MergeList(List<string> list1, List<string> list2)
        {
            List<string> list = new List<string>();
            foreach(string item1 in list1)
            {
                foreach(string item2 in list2)
                {
                    if(item1.Equals(item2, StringComparison.OrdinalIgnoreCase))
                    {
                        list.Add(item2);
                    }
                }
            }
            return list;
        }
    }
}
