using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Diagnostics
{
    internal static class Settings
    {
        internal static string FilePath
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
                    return string.Format("{0}\\{1}-logFile.txt", _GetApplicationDirectory(), ApplicationName);
                }
            }
        }

        internal static string ApplicationName
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

        private static string _GetApplicationDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
