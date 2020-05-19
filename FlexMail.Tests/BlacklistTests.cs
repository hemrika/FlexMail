using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexMail.Service;

namespace FlexMail.Tests
{
    [TestClass()]
    public class BlacklistTests : FlexMailTest
    {
        [ClassInitialize]
        public static void BlacklistTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Blacklist_ImportTest()
        {
            try
            {

                List<ImportBlacklistRespType> responses = Client.Blacklist.Import();

                foreach (ImportBlacklistRespType response in responses)
                {
                    string emailAddress = response.emailAddress;
                }
            }
            catch (FlexMailException flex)
            {
                int code = flex.Code;
                string message = flex.Message;
                throw;

            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod()]
        public void Blacklist_DisposeTest()
        {
            //Client.Blacklist.Dispose();
        }
    }
}