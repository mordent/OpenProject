using NLog;
using System.ComponentModel;
using ThiRA.Base.Infos;

namespace ThiRA.Base.BackGround
{
    public class BaseBackGroundWorker : BackgroundWorker
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        private WorkInfo work = new WorkInfo();

        private Action<WorkInfo> doAction;
        private Action<WorkInfo>? progressChangeAction;
        private Action<WorkInfo>? completeAction;

        public WorkInfo Work
        {
            get{ return work; }
        }

        public BaseBackGroundWorker(Action<WorkInfo> doAction)
        {
            this.WorkerReportsProgress = true;
            this.doAction = doAction;
            DoWork += new DoWorkEventHandler(WorkerDoWork);
        }

        public BaseBackGroundWorker(Action<WorkInfo> doAction, Action<WorkInfo> completeAction)
        {
            this.WorkerReportsProgress = true;
            this.doAction = doAction;
            this.completeAction = completeAction;
            DoWork += new DoWorkEventHandler(WorkerDoWork);
            RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerRunWorkerCompleted);
        }

        public BaseBackGroundWorker(Action<WorkInfo> doAction, Action<WorkInfo> progressChangeAction, Action<WorkInfo> completeAction)
        {
            this.WorkerReportsProgress = true;
            this.doAction = doAction;
            this.progressChangeAction = progressChangeAction;
            this.completeAction = completeAction;
            DoWork += new DoWorkEventHandler(WorkerDoWork);
            ProgressChanged += new ProgressChangedEventHandler(WorkerProgressChanged);
            RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerRunWorkerCompleted);
        }

        private void WorkerDoWork(object? sender, DoWorkEventArgs e)
        {
            if (doAction == null)
            {
                return;
            }
            work.BeginWork(this);
            try
            {
                doAction(work);
            }
            catch (Exception ex)
            {
                work.Error(ex);
                logger.Error(ex);
                throw;
            }
        }

        private void WorkerProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if (progressChangeAction == null)
            {
                return;
            }
            try
            {
                progressChangeAction(work);
            }
            catch (Exception ex)
            {
                work.Error(ex);
                logger.Error(ex);
                throw;
            }
        }

        private void WorkerRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (completeAction == null)
            {
                return;
            }
            try
            {
                completeAction(work);
                work.CompleteWork();
            }
            catch (Exception ex)
            {
                work.Error(ex);
                logger.Error(ex);
                throw;
            }
        }
    }
}

