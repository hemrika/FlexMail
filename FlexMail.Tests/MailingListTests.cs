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
    public class MailingListTests : FlexMailTest
    {
        [ClassInitialize]
        public static void MailingListTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void MailingList_MailingListsTest()
        {
            List<MailingListType> mailinglists = Client.MailingList.MailingLists();

            foreach (MailingListType mailinglist in mailinglists)
            {
                if (mailinglist.mailingListName.StartsWith("Inschrijvingen"))
                {
                    int mailingListId = mailinglist.mailingListId;
                    new MailingListType() { mailingListType = mailinglist.mailingListType };
                }
            }
        }

        [TestMethod()]
        public void MailingList_CreateTest()
        {

        }

        [TestMethod()]
        public void MailingList_DeleteTest()
        {

        }

        [TestMethod()]
        public void MailingList_UpdateTest()
        {
        }

        [TestMethod()]
        public void MailingList_TruncateTest()
        {

        }

        [TestMethod()]
        public void MailingList_DisposeTest()
        {
            //Client.MailingList.Dispose();
        }
    }
}