using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Wrapper object for success messages. To be used by controllers to indicate success.
    /// </summary>
    public class SuccessMessage
    {
        public bool Success { get; set; }
    }
}
