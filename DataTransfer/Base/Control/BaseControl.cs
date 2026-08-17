using NLog;
using ThiRA.Base.Util;

namespace ThiRA.Base.Control
{
    public partial class BaseControl : UserControl
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public BaseControl()
        {
            InitializeComponent();
        }

        protected static long CurrentTimeMils
        {
            get { return StringUtility.CurrentTimeMils; }
        }
    }
}
