using System;
using System.Collections.Generic;
using System.Linq;

namespace Diagnostics
{
    /// <summary>
    /// Class for logging activities in the Windows eventviewer.
    /// </summary>
    public static class LogEvent
    {

        /// <summary>
        /// Writes log message to the Windows eventviewer.
        /// </summary>
        /// <param name="source">The source of the log activity.</param>
        /// <param name="message">The log message.</param>
        /// <param name="logBook">Optional custom event logbook.</param>
        public static void Message(string message, System.Diagnostics.EventLogEntryType type, string logBook = "")
        {
            //Certain admin privileges are needed to execute this (to test run VS as admin).
            //A test to see if submodules work.

            System.Diagnostics.EventLog appLog;

            if (!string.IsNullOrEmpty(logBook))
            {
                appLog = new System.Diagnostics.EventLog(logBook);
            }
            else
            {
                appLog = new System.Diagnostics.EventLog("Application");
            }

            appLog.Source = Settings.ApplicationName;
            appLog.WriteEntry(message, type);
        }
    }
}
