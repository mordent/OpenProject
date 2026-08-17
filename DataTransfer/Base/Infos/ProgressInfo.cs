using System;
using System.Text;

namespace ThiRA.Base.Infos
{
    public class ProgressInfo
    {
        private string title = string.Empty;
        private StringBuilder progressText = new StringBuilder();
        private List<MessageInfo> messages = new List<MessageInfo>();
        private int minumum = 0;
        private int maximum = 0;
        private int progress = 0;
        private int currentMessage = 0;
        public string Title { get { return title; } set { title = value; } }
        public List<MessageInfo> Messages { get { return messages; } }
        public int Minimum { get { return minumum; } set { minumum = value; SetProgressText(); } }
        public int Maximum { get { return maximum; } set { maximum = value; SetProgressText(); } }
        public int Progress { get { return progress; } set { if (value > maximum) { progress = maximum; } else { progress = value; } SetProgressText(); } }
        public string ProgressText { get { return progressText.ToString(); } }
        private void SetProgressText()
        {
            progressText.Clear();
            progressText.Append("[").Append(progress).Append("/").Append(Maximum).Append("]");
        }
        public void SetProgress(WorkInfo work)
        {
            this.title = work.Title;
            this.messages = work.Messages;
            this.minumum = work.Minimum;
            this.maximum = work.Maximum;
            this.progress = work.Progress;
            SetProgressText();
        }
        public bool HasNextMessage()
        {
            return messages.Count > currentMessage;
        }

        public MessageInfo NextMessage()
        {
            return messages[currentMessage++];
        }
    }
}
