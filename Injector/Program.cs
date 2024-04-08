using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Injector
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TODO: maybe delete this Unhandled Exception Error things later

            // Attach global exception handler
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Loader());
            }
            catch (Exception ex)
            {
                // Log the exception
                LogException(ex);
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Global exception handler for unhandled exceptions
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogException((Exception)e.ExceptionObject);
            MessageBox.Show("An unhandled error occurred: " + ((Exception)e.ExceptionObject).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Global exception handler for UI thread exceptions
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogException(e.Exception);
            MessageBox.Show("An error occurred: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Logging function
        private static void LogException(Exception ex)
        {
            // Implement your logging mechanism here
            // Example:
            // Logger.LogException(ex);
        }
    }
}
