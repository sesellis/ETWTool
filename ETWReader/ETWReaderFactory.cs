using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETWReader
{
    /// <summary>
    /// Factory class that generates ETWReader objects
    /// </summary>
    public class ETWReaderFactory
    {
        /// <summary>
        /// Creates a reader based on an input string specifying which source type the reader should use. The appropriate ETWReader is then constructed and returned.
        /// </summary>
        /// <param name="type">String indicating which ETWReader to construct</param>
        /// <returns>AbstractETWReader</returns>
        public AbstractETWReader CreateReader(string type)
        {
            AbstractETWReader reader = null;
            switch (type)
            {
                case "FilePath":
                    reader = new ETWFileReader();
                    break;

                //Additional readers go here

                default:
                    break;

            }
            return reader;
        }

    }
}
