using ETWDataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETWReader.Tests
{
    [TestClass]
    public class ETWDataServiceTests
    {
        [TestMethod]
        public void TestDataService()
        {
            ETWDataSrvc srvc = new ETWDataSrvc();
        }
    }
}
