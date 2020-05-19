using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexMail.Tests
{
    [TestClass()]
    public class AgencyTests : FlexMailTest
    {
        [ClassInitialize]
        public static void AgencyTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Agency_DisposeTest()
        {
            //Client.Agency.Dispose();
        }
    }
}