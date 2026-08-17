using NLog;

namespace ThiRA.Base.Log
{
    public class BaseLog
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
    }
}
