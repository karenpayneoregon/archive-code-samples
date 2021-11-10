using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogLibrary;
using static System.Configuration.ConfigurationManager;

namespace UserDocumentControl
{
    static class Program
    {
        public static bool UseTraceLogging => Convert.ToBoolean(AppSettings["UseLogging"]);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (UseTraceLogging)
            {
                ApplicationTraceListener.Instance.CreateLog(AppSettings["ListenerLogName"], AppSettings["ListenerName"]);
                ApplicationTraceListener.Instance.WriteToTraceFile = true;
                ApplicationTraceListener.Instance.Info("Started");
            }

            Application.Run(new MainForm());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (!UseTraceLogging) return;
            ApplicationTraceListener.Instance.Info("Closed");
            ApplicationTraceListener.Instance.Close();
            ApplicationTraceListener.Instance.TrimLogFile();

        }
    }
}
