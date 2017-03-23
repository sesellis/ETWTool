using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Wrapper object used to store information about creating a new ETWReader.
    /// </summary>
    public class AddETWRequest
    {
        /// <summary>
        /// Type of ETWReader to create by the factory
        /// </summary>
        public string SourceType { get; set; }
        /// <summary>
        /// Source data for the ETWReader as string
        /// </summary>
        public string Source { get; set; }
    }
}
