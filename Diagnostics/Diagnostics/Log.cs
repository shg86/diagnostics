using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

//Requires 2 application parameters in the app.config (or web.config):
//LogFile: the location and name of the logfile, eg. C:\temp\logfile.txt
//ApplicationName: the name of the application, eg. ApplicationName

namespace Diagnostics
{
    /// <summary>
    /// Class for logging activities.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Type of messagge.
        /// </summary>
        public enum MessageType { Error, Warning, Information, Custom }

        private static string _FilePath
        {
            get
            {
                string filePath = ConfigurationManager.AppSettings["LogFile"];

                if (!string.IsNullOrEmpty(filePath))
                {
                    return filePath;
                }
                else
                {
                    return string.Format("{0}\\{1}-logFile.txt", _GetApplicationDirectory(), _ApplicationName);
                }
            }
        }

        private static string _ApplicationName
        {
            get
            {
                string applicationName = ConfigurationManager.AppSettings["ApplicationName"];

                if (!string.IsNullOrEmpty(applicationName))
                {
                    return applicationName;
                }
                else
                {
                    return "Unspecified application";
                }
            }
        }


        /// <summary>
        /// Logs a message to an (existing) text file.
        /// </summary>
        /// <param name="source">The source method.</param>
        /// <param name="message">The message that should be logged.</param>
        /// <param name="type">The type of message.</param>
        /// <param name="customTitle">Optional custom type of message.</param>
        /// <param name="filePath">Optional path and filename of the logfile.</param>
        public static void Message(string source, string message, MessageType type, string customTitle = "")
        {
            //INFO: Application information.
            //ERROR: Something went wrong and the application can't continue anymore.
            //WARNING: Something went wrong but the application can still continue.

            //TODO: build exception handlers (eg. when the program can't access the directory/file).
            var sb = new StringBuilder();

            sb.Append(string.Format("[{0}] ", _ApplicationName)); 
            sb.Append(string.Format("[{0}] ", DateTime.Now));

            switch (type)
            {
                case MessageType.Information:

                    sb.Append("[INFO] ");
                    break;

                case MessageType.Warning:

                    sb.Append("[WARNING] ");
                    break;

                case MessageType.Error:

                    sb.Append("[ERROR] ");
                    break;

                case MessageType.Custom:

                    sb.Append(string.Format("[{0}] ", customTitle.ToUpper()));
                    break;

                default:

                    sb.Append("[UNKNOWN] ");
                    break;
            }

            sb.Append(string.Format("[{0}] ", source));
            sb.Append(message);

            _WriteToFile(sb.ToString());
        }

        private static void _WriteToFile(string message)
        {
            using (StreamWriter sw = File.AppendText(_FilePath))
            {
                sw.WriteLine(message);
            }
        }

        private static string _GetApplicationDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Retrieves the current method name.
        /// </summary>
        /// <returns>The current method name.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

    }
}
