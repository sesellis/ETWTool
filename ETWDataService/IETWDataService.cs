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
    /// Interface used to define required operations of the ETWDataService class
    /// </summary>
    public interface IETWDataService
    {
        IEnumerable<LogEvent> GetEventsFromAllReaders();
        Guid AddETWData(Guid id, IEnumerable<LogEvent> records);
        void RemoveETWData(Guid id);
        bool HasETWData(Guid id);
        IEnumerable<LogEvent> GetEventsFromReader(Guid id);
        void RemoveAllETWData();

    }
}
