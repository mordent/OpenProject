using NLog;
using System.Text;
using ThiRA.Base.Log;

namespace ThiRA.Base.Util
{
    public static class ClassUtility
    {
        public static T[] ToArray<T>(IEnumerable<T> enumerable)
        {
            List<T> list = new List<T>();
            foreach (T t in enumerable)
            {
                list.Add(t);
            }
            return list.ToArray();
        }
    }
}
