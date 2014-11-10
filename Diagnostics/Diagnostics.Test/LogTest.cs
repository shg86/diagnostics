using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Diagnostics.Test
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void WriteError()
        {
            Log.Message(Log.GetCurrentMethod(), "An error occured during data retrieval.", MessageType.Error);
        }

        [TestMethod]
        public void WriteInfo()
        {
            Log.Message(Log.GetCurrentMethod(), "Data retrieved.", MessageType.Information);
        }

        [TestMethod]
        public void WriteWarning()
        {
            Log.Message(Log.GetCurrentMethod(), "Not all data has been retrieved.", MessageType.Warning);
        }

        [TestMethod]
        public void WriteCustom()
        {
            Log.Message(Log.GetCurrentMethod(), "This is a custom message.", MessageType.Custom, "Custom title");
        }

        [TestMethod]
        public void WriteErrorCustomDirectory()
        {
            Log.Message(Log.GetCurrentMethod(), "An error occured during data retrieval.", MessageType.Error, string.Empty, @"c:\temp\customLogfile.txt");
        }

        [TestMethod]
        public void WriteInfoCustomDirectory()
        {
            Log.Message(Log.GetCurrentMethod(), "Data retrieved.", MessageType.Information, string.Empty, @"c:\temp\customLogfile.txt");
        }

        [TestMethod]
        public void WriteWarningCustomDirectory()
        {
            Log.Message(Log.GetCurrentMethod(), "Not all data has been retrieved.", MessageType.Warning, string.Empty, @"c:\temp\customLogfile.txt");
        }

        [TestMethod]
        public void WriteCustomCustomDirectory()
        {
            Log.Message(Log.GetCurrentMethod(), "This is a custom message.", MessageType.Custom, "Custom title", @"c:\temp\customLogfile.txt");
        }
    }
}
