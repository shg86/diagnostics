using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Diagnostics
{
    /// <summary>
    /// Type of messagge.
    /// </summary>
    public enum MessageType { Error, Warning, Information, Custom }

    /// <summary>
    /// Class for logging activities.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Logs a message to an (existing) text file.
        /// </summary>
        /// <param name="source">The source method.</param>
        /// <param name="message">The message that should be logged.</param>
        /// <param name="type">The type of message.</param>
        /// <param name="customTitle">Optional custom type of message.</param>
        /// <param name="filePath">Optional path and filename of the logfile.</param>
        public static void Message(string source, string message, MessageType type, string customTitle = "", string filePath = @"c:\temp\log.txt" )
        {
            //INFO: Application information.
            //ERROR: Something went wrong and the application can't continue anymore.
            //WARNING: Something went wrong but the application can still continue.

            //TODO: the parameters should be send through a single object instead of loose parameters.
            //TODO: build exception handlers (eg. when the program can't access the directory/file).
            //TODO: filePath should be dynamic.
            //TODO: make the ApplicationName dynamic.

            var sb = new StringBuilder();
            sb.Append("[ApplicationName]"); 
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

                    customTitle = customTitle.ToUpper();
                    sb.Append(string.Format("[{0}] ", customTitle));
                    break;

                default:

                    sb.Append("[UNKNOWN] ");
                    break;
            }
            sb.Append(string.Format("[{0}] ", source));
            sb.Append(message);
            Console.WriteLine(sb.ToString());
            _WriteToFile(sb.ToString(), filePath);
        }

        private static void _WriteToFile(string message, string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(message);
            }
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
