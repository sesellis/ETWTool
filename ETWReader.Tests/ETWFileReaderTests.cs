using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Eventing.Reader;
using System.Collections.Generic;

namespace ETWReader.Tests
{
    [TestClass]
    public class ETWFileReaderTests
    {
        [TestMethod]
        public void TestETWReaderFactory()
        {
            ETWReaderFactory factory = new ETWReaderFactory();

            //Test for ETWFileReader creation
            AbstractETWReader fileReader = factory.CreateReader("FilePath");
            Assert.AreEqual(fileReader.GetType(), typeof(ETWFileReader));

            //Verify that a string not specified in the factory returns a null reader
            AbstractETWReader nullReader = factory.CreateReader("");
            Assert.IsNull(nullReader);

        }

        [TestMethod]
        public void TestReadLogFromFile()
        {
            
        }
    }
}
