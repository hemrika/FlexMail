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
    public class FormTests : FlexMailTest
    {
        [ClassInitialize]
        public static void FormTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Form_FormsTest()
        {
            List<FormType> responses = Client.Form.Forms();

            foreach (FormType response in responses)
            {
                string formName = response.formName;
            }

        }

        [TestMethod()]
        public void Form_ResultsTest()
        {
            List<FormResultType> responses = Client.Form.Results("21270");

            foreach (FormResultType response in responses)
            {
                //string formName = response.formResults;
            }
        }

        [TestMethod()]
        public void Form_DisposeTest()
        {
            //Client.Form.Dispose();
        }
    }
}