using System;
using System.Text;
using System.Windows.Forms;
using ThiRA.Base.Infos;

namespace ThiRA.Base.Control
{
    public partial class ProgressControl : BaseControl
    {
        private ProgressInfo progress = new ProgressInfo();

        public ProgressControl()
        {
            InitializeComponent();
        }
        
        public void SetProgress(WorkInfo work)
        {
            progress.SetProgress(work);
            if (!labelTitle.Text.Equals(progress.Title)) { labelTitle.Text = progress.Title; }
            if (!labelProgress.Text.Equals(progress.ProgressText)) { labelProgress.Text = progress.ProgressText; }
            while (progress.HasNextMessage())
            {
                MessageInfo message = progress.NextMessage();
                switch (message.MessageType)
                {
                    case MessageType.Trace: richTextBoxMessage.SelectionColor = Color.Orange; richTextBoxMessage.AppendText(message.FullMessage); break;
                    case MessageType.Error: richTextBoxMessage.SelectionColor = Color.Red; richTextBoxMessage.AppendText(message.FullMessage); break;
                    case MessageType.Info: default: richTextBoxMessage.SelectionColor = Color.Black; richTextBoxMessage.AppendText(message.FullMessage); break;
                }
                richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                richTextBoxMessage.ScrollToCaret();
            }
            if (progressBar.Minimum != progress.Minimum) { progressBar.Minimum = progress.Minimum; }
            if (progressBar.Maximum != progress.Maximum) { progressBar.Maximum = progress.Maximum; }
            if (progressBar.Value != progress.Progress) { progressBar.Value = progress.Progress; }
        }

        public void CompleteProgress()
        {
            buttonClose.Click += buttonCloseClick;
            buttonClose.Enabled = true;
        }
        public void HideProgress()
        {
            Parent.Controls.Remove(this);
            Visible = false;
            Hide();
            SendToBack();
            progress.Title = string.Empty;
            richTextBoxMessage.Clear();
            progress.Messages.Clear();
            progress.Minimum = 0;
            progress.Maximum = 100;
            progress.Progress = 0;
            buttonClose.Enabled = false;
            buttonClose.Click -= buttonCloseClick;
        }

        private void buttonCloseClick(object? sender, EventArgs e)
        {
            HideProgress();
        }
    }
}
