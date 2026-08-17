using NLog;
using ThiRA.DataTransfer.Forms;

namespace DataTransfer
{
    internal static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static MainForm mainForm = new MainForm();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                mainForm.ModalException(ex);
            }
        }
    }
}