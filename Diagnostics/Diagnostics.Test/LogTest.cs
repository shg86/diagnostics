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
            Log.Message(Log.GetCurrentMethod(), "An error occured during data retrieval.", Log.MessageType.Error);
        }

        [TestMethod]
        public void WriteInfo()
        {
            Log.Message(Log.GetCurrentMethod(), "Data retrieved.", Log.MessageType.Information);
        }

        [TestMethod]
        public void WriteWarning()
        {
            Log.Message(Log.GetCurrentMethod(), "Not all data has been retrieved.", Log.MessageType.Warning);
        }

        [TestMethod]
        public void WriteCustom()
        {
            Log.Message(Log.GetCurrentMethod(), "This is a custom message.", Log.MessageType.Custom, "Custom title");
        }

        [TestMethod]
        public void WriteInfoEvent()
        {
            LogEvent.Message("This is an info event.", System.Diagnostics.EventLogEntryType.Information);
        }

        [TestMethod]
        public void WriteErrorEvent()
        {
            LogEvent.Message("This is an error event.", System.Diagnostics.EventLogEntryType.Error);
        }

        [TestMethod]
        public void WriteWarningEvent()
        {
            LogEvent.Message("This is an warning event.", System.Diagnostics.EventLogEntryType.Warning);
        }
    }
}
