using NLog;
using ThiRA.Base.Control;
using ThiRA.Base.Infos;
using ThiRA.Base.Util;

namespace ThiRA.Base.Forms
{
    public partial class BaseForm : Form 
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected ProgressControl progressControl = new ProgressControl();

        protected static long CurrentTimeMils
        {
            get { return StringUtility.CurrentTimeMils; }
        }

        public MessageModal ModalMessage(string title, string message)
        {
            MessageModal messageModal = new MessageModal();
            messageModal.Title = title;
            messageModal.Message = message;
            messageModal.ShowDialog();
            return messageModal;
        }

        public MessageModal ModalException(Exception e)
        {
            logger.Error(e);
            MessageModal messageModal = new MessageModal();
            messageModal.Title = e.Message;
            messageModal.Message = e.ToString();
            messageModal.ShowDialog();
            return messageModal;
        }

        public void ShowProgress(WorkInfo work)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                Controls.Add(progressControl);
                progressControl.Visible = true;
                progressControl.Dock = DockStyle.Fill;
                progressControl.Show();
                progressControl.BringToFront();
                progressControl.SetProgress(work);
            }));
        }

        public void ChangeProgress(WorkInfo work)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                progressControl.SetProgress(work);
            }));
        }

        public void CompleteProgress()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                progressControl.CompleteProgress();
            }));
        }
    }
}
