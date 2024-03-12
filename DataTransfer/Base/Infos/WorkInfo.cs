using System.Text;
using ThiRA.Base.BackGround;
using ThiRA.Base.Util;

namespace ThiRA.Base.Infos
{
    public class WorkInfo
    {
        private BaseBackGroundWorker? worker;
        private string workId = StringUtility.Guid();
        private bool begin  = false;
        private DateTime beginDateTime = DateTime.MinValue;
        private bool complete = false;
        private DateTime completeDateTime = DateTime.MinValue;
        private bool error = false;
        private int minimum = 0;
        private int maximum = 100;
        private int progress = 0;
        private object? result = null;
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        private Dictionary<string, object> atttributes = new Dictionary<string, object>();
        private string title = string.Empty;
        private List<MessageInfo> messages = new List<MessageInfo>();
        public BaseBackGroundWorker? Worker { get { return worker; } }
        public string WorkId { get { return workId; } }
        public bool Begin { get { return begin; }}
        public DateTime BeginDateTime { get { return beginDateTime; } }
        public bool Complete { get { return complete; }}
        public DateTime CompleteDateTime { get { return completeDateTime; } }
        public bool IsError { get { return error; }}
        public int Minimum { get { return minimum; } set { minimum = value; } }
        public int Maximum { get { return maximum; } set { maximum = value; } }
        public int Progress { get { return progress; } set { if (value > maximum) { progress = maximum; } else { progress = value; } } }
        public object? Result { get { return result; } set { result = value; } }
        public Dictionary<string, string> Parameters { get { return parameters; } }
        public Dictionary<string, object> Atttributes { get { return atttributes; } }
        public List<MessageInfo> Messages { get { return messages; } }
        public string Title { get { return title; } set { title = value; } }
        public int ProgressPercent
        {
            get
            {
                int band = maximum - minimum;
                if (band == 0)
                {
                    return 0;
                }
                int progressMark = progress - minimum;
                return progressMark / band * 100;
            }
        }

        internal void BeginWork(BaseBackGroundWorker worker)
        {
            begin = true;
            beginDateTime = DateTime.Now;
            this.worker = worker;
        }

        internal void CompleteWork()
        {
            begin = true;
            beginDateTime = DateTime.Now;
        }

        public void ReportProgress(int progress)
        {
            if(worker != null)
            {
                this.progress = progress;
                worker.ReportProgress(progress);
            }
        }

        public void ReportProgress()
        {
            if (worker != null)
            {
                worker.ReportProgress(progress);
            }
        }

        public void Info(string message)
        {
            messages.Add(new MessageInfo(message));
            ReportProgress();
        }

        public void Error(Exception e)
        {
            error = true;
            messages.Add(new MessageInfo(e));
            ReportProgress();
        }

        public void Error(string message, string  trace)
        {
            error = true;
            messages.Add(new MessageInfo(message, trace));
            ReportProgress();
        }
    }
}
