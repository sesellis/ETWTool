using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETWReader;
using Models;

namespace ETWDataService
{
    /// <summary>
    /// Data service for ETW Events. Provides methods for the addition, removal, and retrieval of event log data from a given source.
    /// </summary>
    public class ETWDataSrvc : IETWDataService
    {
        private Dictionary<Guid, IEnumerable<LogEvent>> EventReaderData;

        /// <summary>
        /// Constructor. Creates a new EventReaderData object for the class to utilize
        /// </summary>
        public ETWDataSrvc()
        {
            EventReaderData = new Dictionary<Guid, IEnumerable<LogEvent>>();
        }

        /// <summary>
        /// Add ETW data with an associated ID for retrieval and removal
        /// </summary>
        /// <param name="id">Guid to identify ETW Data</param>
        /// <param name="records"></param>
        /// <returns>Guid to identify stored data</returns>
        public Guid AddETWData(Guid id, IEnumerable<LogEvent> records)
        {
            if (!HasETWData(id))
            {
                EventReaderData.Add(id, records);
            }
            return id;
        }

        /// <summary>
        /// Returns all ETW Events known to the service
        /// </summary>
        /// <returns>List of events</returns>
        public IEnumerable<LogEvent> GetEventsFromAllReaders()
        {
            return EventReaderData.SelectMany(x => x.Value);
        }

        /// <summary>
        /// Retrieves events for a specific source based on id
        /// </summary>
        /// <param name="id">Guid identifying the source of the event data you wish to retrieve</param>
        /// <returns>ETW Data from a given source</returns>
        public IEnumerable<LogEvent> GetEventsFromReader(Guid id)
        {
            IEnumerable<LogEvent> records;
            if (EventReaderData.TryGetValue(id, out records)) // Returns true.
            {
                return records;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Removes ETW Data from a given source
        /// </summary>
        /// <param name="id">Id of source to remove</param>
        public void RemoveETWData(Guid id)
        {
            EventReaderData.Remove(id);
        }

        /// <summary>
        /// Checks whether there is ETW data available in the service for a given ID
        /// </summary>
        /// <param name="id">Guid of ETW Data source to check</param>
        /// <returns>bool incidating the existence of ETW Data for a given ID</returns>
        public bool HasETWData(Guid id)
        {
            return EventReaderData.ContainsKey(id);
        }

        /// <summary>
        /// Clears all ETW Data stored in the service
        /// </summary>
        public void RemoveAllETWData()
        {
            EventReaderData.Clear();
        }
    }
}
