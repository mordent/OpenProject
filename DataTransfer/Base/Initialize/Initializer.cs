using NLog;

namespace ThiRA.Base.Initialize
{
    public static  class Initializer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Initialize()
        {
            logger.Info("Initializer.Initialize Start");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            logger.Info("Initializer.Initialize End");
        }
    }
}
