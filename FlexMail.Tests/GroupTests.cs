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
    public class GroupTests : FlexMailTest
    {
        [ClassInitialize]
        public static void GroupTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Group_GroupsTest()
        {
            List<GroupType> responses = Client.Group.Groups();

            foreach (GroupType item in responses)
            {
            }
        }

        [TestMethod()]
        public void Group_CreateTest()
        {

        }

        [TestMethod()]
        public void Group_CreateGroupTest()
        {

        }

        [TestMethod()]
        public void Group_DeleteTest()
        {

        }

        [TestMethod()]
        public void Group_DeleteTest1()
        {

        }

        [TestMethod()]
        public void Group_UpdateTest()
        {

        }

        [TestMethod()]
        public void Group_DisposeTest()
        {
            //Client.Group.Dispose();
        }
    }
}