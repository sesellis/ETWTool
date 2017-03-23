using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Wrapper class for error messages. Designed to be returned by a controller to provide a human readable message about the error along with details about the exception thrown. 
    /// </summary>
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }

        /// <summary>
        /// Constructor that sets the properties of the ErrorMessage object
        /// </summary>
        /// <param name="message">Human readable error message</param>
        /// <param name="e">Exception thrown to provide details for</param>
        public ErrorMessage(string message, Exception e)
        {
            Message = message;
            ExceptionMessage = e.Message;
            ExceptionStackTrace = e.StackTrace;
        }

    }
}
