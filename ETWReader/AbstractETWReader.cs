using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETWReader
{
    /// <summary>
    /// Abstract type for ETWReader. ETWReaders are objects that read ETW data from various sources in the system. 
    /// </summary>
    public abstract class AbstractETWReader
    {
        /// <summary>
        /// Method for reading event data that all ETWReaders are required to implement. 
        /// </summary>
        /// <param name="data">Source of data that the reader should utilize</param>
        /// <returns>List of ETWEvents</returns>
        public abstract List<LogEvent> ReadEvents(object data);
    }
}
