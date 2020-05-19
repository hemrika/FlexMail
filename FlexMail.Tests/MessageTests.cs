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
    public class MessageTests : FlexMailTest
    {
        [ClassInitialize]
        public static void MessageTestsInitialize(TestContext testContext)
        {
        }

        [TestMethod()]
        public void Message_MessagesTest()
        {
            try
            {

                List<MessageType> messages = Client.Message.Messages();

                foreach (MessageType message in messages)
                {
                    if (message.messageName.StartsWith("Opt-in%20bevestiging%20"))
                    {
                        int messageId = message.messageId;
                    }

                    if (message.messageName == "Kentico%20Demo%20Bevestiging")
                    {
                        int messageId = message.messageId;
                    }

                }
            }
            catch (FlexMailException flex)
            {
                string mesaage = flex.Message;
            }

        }

        [TestMethod()]
        public void Message_CreateTest()
        {
            //int messageId = new Client().Message.Create();
        }

        [TestMethod()]
        public void Message_DeleteTest()
        {
            //new Client().Message.Delete();
        }

        [TestMethod()]
        public void Message_UpdateTest()
        {
            //new Client().Message.Update();
        }

        [TestMethod()]
        public void Message_DisposeTest()
        {
            //Client.Message.Dispose();
        }
    }
}