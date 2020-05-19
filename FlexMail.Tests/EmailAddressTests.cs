using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.ApplicationInsights;
using FlexMail.Service;

namespace FlexMail.Tests
{
    [TestClass()]
    public class EmailAddressTests : FlexMailTest
    {
        private static Service.EmailAddressType emailaddresstype = null;

        [ClassInitialize]
        public static void EmailAddress_EmailAddressTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void EmailAddress_EmailAddressesTest()
        {
        }

        [TestMethod()]
        public void EmailAddress_CreateTest()
        {
            try
            {
                
                Service.OptInType optintype = new Service.OptInType()
                {
                    messageId = 914859,
                    replyEmail = "demand@vilans.nl",
                    senderEmail = "demand@vilans.nl",
                    senderName = "Demand",
                    subject = "Opt-In"
                };
                emailaddresstype = new Service.EmailAddressType()
                {
                    emailAddress = "r.hemrika@vilans.nl",
                    mailingListId = 186569
                }
                ;
                emailaddresstype.flexmailId = Client.EmailAddress.Create(emailaddresstype, "186569", optintype).ToString();

                emailaddresstype.name = "James";
                emailaddresstype.surname = "Bond";
                emailaddresstype.company = "MI5";
                emailaddresstype.function = "Spy";
                emailaddresstype.gender = "Male";
                emailaddresstype.jobtitle = "Top Secret";   

                Client.EmailAddress.Update(emailaddresstype, "186569");

                //new Client().EmailAddress.Delete(emailaddresstype, "934385");

            }
            catch (FlexMail.Service.FlexMailException flex)
            {
                int code = flex.Code;
                string message = flex.Message;
                throw;

            }
        }

        [TestMethod()]
        public void EmailAddress_DeleteTest()
        {

        }

        [TestMethod()]
        public void EmailAddress_UpdateTest()
        {

        }

        [TestMethod()]
        public void EmailAddress_HistoryTest()
        {
            try
            {
                Service.EmailAddressHistoryType eaht = Client.EmailAddress.History("r.hemrika@vilans.nl");
                Service.EmailAddressType eat = eaht.emailAddressType;
                Service.EmailAddressHistoryActionType[] eahat = eaht.emailAddressHistoryActionTypeItems;

                foreach (Service.EmailAddressHistoryActionType action in eahat)
                {
                    //action.
                }
            }
            catch (FlexMailException flex)
            {
                Assert.AreEqual(223, flex.Code);
            }
        }

        [TestMethod()]
        public void EmailAddress_DisposeTest()
        {
            //Client.EmailAddress.Dispose();
        }
    }
}