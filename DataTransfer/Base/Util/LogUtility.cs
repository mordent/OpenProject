using NLog;
using System.Collections.Concurrent;

namespace ThiRA.Base.Util
{
    public class LogUtility
    {
        private static ConcurrentDictionary<Type, Logger> DICTIONARY_LOG = new ConcurrentDictionary<Type, Logger>();
        
        public static Logger Logger(Type type)
        {
            return DICTIONARY_LOG.GetOrAdd(type, LogManager.GetLogger(type.ToString()));
        }
    }
}
