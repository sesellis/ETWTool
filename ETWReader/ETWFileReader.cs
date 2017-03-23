using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETWReader
{
    /// <summary>
    /// Reads an ETW Log from a file path
    /// </summary>
    public class ETWFileReader : AbstractETWReader
    {
        /// <summary>
        /// Reads event records given a specific log.
        /// </summary>
        /// <param name="log">Path to log file, typically a .evtx</param>
        /// <returns>List<EventRecord></EventRecord></returns>
        public override List<LogEvent> ReadEvents(object data)
        {
            return ReadLogFromFile((string)data);
        }

        /// <summary>
        /// Reads log file located a given path and returns a list of the events
        /// </summary>
        /// <param name="pathToLog">String containing the file path to the log</param>
        /// <returns>List of events</returns>
        private List<LogEvent> ReadLogFromFile(string pathToLog)
        {
            List<LogEvent> logEntries = new List<LogEvent>();
            using (var reader = new EventLogReader(pathToLog, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    try
                    {
                        //add the records as a logentry so that the description etc. gets loaded
                        logEntries.Add(record);
                    }
                    finally
                    {
                        if (logEntries.Count == 0)
                            throw new FileNotFoundException("Unable to parse any events from the specified file.");
                    }
                }
            }
            return logEntries;
        }
    }
}
