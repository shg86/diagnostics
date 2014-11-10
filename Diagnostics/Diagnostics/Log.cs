using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Diagnostics
{
    public enum MessageType { Error, Warning, Information, Custom }

    public static class Log
    {
        //INFO: Application information.
        //ERROR: Something went wrong and the application can't continue anymore.
        //WARNING: Something went wrong but the application can still continue.
        public static void Message(string source, string message, MessageType type, string customTitle = "", string filePath = @"c:\temp\log.txt" )
        {
            //TODO: the parameters should be send through a single object instead of loose parameters.
            //TODO: build exception handlers (eg. when the program can't access the directory/file).
            //TODO: filePath should be dynamic.

            var sb = new StringBuilder();
            sb.Append("[ApplicationName]"); //TOOD: make the ApplicationName dynamic.
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

    }
}
